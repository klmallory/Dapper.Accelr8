using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using EnvDTE;
using System.Runtime.InteropServices;
using System.Globalization;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.Sql
{
    public abstract class EntityReader<IdType, EntityType>
        : IEntityReader<IdType, EntityType>
        where EntityType : class, IHaveId<IdType>
        where IdType : IComparable
    {
        #region Lookups

        protected static object _syncRoot = new object();
        protected static Dictionary<string, object> _readers = new Dictionary<string, object>();
        protected static bool _cacheReaders = true;

        public static Dictionary<AggregateType, string> AggregateCommands
            = new Dictionary<AggregateType, string>()
             {
                 {AggregateType.Average, "avg" },
                 {AggregateType.Check, "checksum_agg"},
                 {AggregateType.Count, "count"},
                 {AggregateType.CountBig, "count_big"},
                 {AggregateType.Grouping, "grouping"},
                 {AggregateType.GroupingId, "grouping_id"},
                 {AggregateType.Max, "max"},
                 {AggregateType.Min, "min"},
                 {AggregateType.STDev, "stdev"},
                 {AggregateType.STDevP, "stdevp"},
                 {AggregateType.Sum, "sum"},
                 {AggregateType.Var, "var"},
                 {AggregateType.VarP, "varp"}
             };

        #endregion

        protected static readonly string selectById = @"select {0} from [{1}] where {2} = @Id ";
        protected static readonly string genericSelectQuery = @"select {0}{1}{2} from [{3}] [{4}]{5} "; //0 distinct, 1 top, 2 fields, 3 alias, 5 with nolock

        protected static readonly string genericHavingClause = @"having {0}{1} {2}{3} ";
        protected static readonly string genericHavingAnd = @"and {0}{1} {2}{3} ";
        protected static readonly string genericHavingOr = @"or {0}{1} {2}{3} ";

        protected static readonly string genericJoinClause = @"join [{0}] [{1}]{6} on {2}{1}.[{3}] {4}{5} "; //2 is open bracket, 5 is close bracket.6 is no lock
        protected static readonly string genericAggregateClause = @"{0}({1} [{2}].[{3}]) {4}{5} "; //3 is over clause

        protected static readonly string genericGroupByClause = @"group by {0} {1} ";
        protected static readonly string genericGroupByField = @"[{0}].[{1}], ";
        protected static readonly string genericGroupByFunction = @"[{0}]({1}), ";

        protected static readonly string genericOrderByClause = @"order by {0} ";
        protected static readonly string genericOrderByField = @"[{0}].[{1}] {2}, ";

        protected static readonly string genericOverClause = @"over ({0} {1} {2}) ";
        protected static readonly string genericPartitionClause = @"partition by [{0}].[{1}] ";

        protected static readonly string genericRowNumberClause = @"row_number() {0}as _rowsByNumber";

        protected List<QueryElement> _queries = new List<QueryElement>();
        protected List<Join> _joins = new List<Join>();
        protected List<Aggregate> _aggregates = new List<Aggregate>();
        protected List<Having> _havings = new List<Having>();
        protected List<OrderBy> _orderBys = new List<OrderBy>();
        protected List<GroupBy> _groups = new List<GroupBy>();

        protected List<Tuple<IEntityReader, Action<IList<EntityType>, IList<object>>>> _children
            = new List<Tuple<IEntityReader, Action<IList<EntityType>, IList<object>>>>();

        protected ILoc8 _loc8r;

        protected string _connectionStringName;
        protected DapperExecuter _executer;
        protected QueryBuilder _queryBuilder;
        protected JoinBuilder _joinBuilder;

        protected bool _distinct;
        protected int _top;
        protected int _skip;
        protected bool _noLock;

        public EntityReader
            (TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r)
        {
            _connectionStringName = connectionStringName;
            _executer = executer;
            _queryBuilder = queryBuilder;
            _joinBuilder = joinBuilder;

            if (_loc8r == null)
                _loc8r = loc8r;

            //UniqueId = tableInfo.UniqueId;
            //IdColumn = tableInfo.IdColumn;
            //TableName = tableInfo.TableName;
            //TableAlias = tableInfo.TableAlias;
            //ColumnNames = tableInfo.Columns.OrderBy(c => c.Value).ToList();
            //Joins = (JoinInfo[])tableInfo.Joins.Clone();
            TableInfo = tableInfo;
        }

        protected ReturnType GetRowData<ReturnType>(IDictionary<string, object> dataRow, string property)
        {
            if (!dataRow.ContainsKey(property) || dataRow[property] == null)
                return default(ReturnType);

            if (dataRow[property] is ReturnType)
                return (ReturnType)dataRow[property];
            else if (dataRow[property] is string && typeof(ReturnType) == typeof(Guid))
                return (ReturnType)(object)(new Guid((string)dataRow[property]));
            else
                return (ReturnType)Convert.ChangeType(dataRow[property], typeof(ReturnType));
        }


        protected virtual string BuildChildren(IList<Tuple<IEntityReader, Action<IList<EntityType>, IList<object>>>> children)
        {
            var sb = new StringBuilder();

            var count = 1;
            foreach (var e in children)
                sb.Append(BuildChild(e.Item1, count++));

            return sb.ToString();
        }

        protected virtual string BuildChild(IEntityReader reader, int count)
        {
            return reader.GetSqlForQueries(count);
        }

        protected virtual string BuildJoins(IList<Join> joins)
        {
            return _joinBuilder.BuildJoins(joins);
        }

        protected virtual string BuildJoin(Join join, int count)
        {
            return _joinBuilder.BuildJoin(join, count);
        }

        protected virtual string BuildQueryElements(IList<QueryElement> elements, int taskIndex)
        {
            return _queryBuilder.BuildQueryElements(elements, taskIndex);
        }

        protected virtual string BuildSkipRowsClause()
        {
            var overCl = string.Empty;

            //if (_orderBys.Count < 1)
            //    throw new System.Data.InvalidExpressionException("you must use order bys to use 'skip' clause");

            var over = new Over() { OrderBy = _orderBys.ToArray() };

            overCl = BuildOverClause(over) + " ";

            return string.Format(genericRowNumberClause, overCl);
        }

        protected virtual string BuildSkipRowsClause(IList<OrderBy> ordering)
        {
            var overCl = string.Empty;

            //if (_orderBys.Count < 1)
            //    throw new System.Data.InvalidExpressionException("you must use order bys to use 'skip' clause");

            var over = new Over() { OrderBy = ordering.ToArray() };

            overCl = BuildOverClause(over) + " ";

            return string.Format(genericRowNumberClause, overCl);
        }

        protected virtual string BuildFields()
        {
            return BuildFields(TableInfo.Columns, _aggregates);
        }

        protected virtual string BuildFields(IDictionary<int, string> fields, IList<Aggregate> aggregates)
        {
            var cols = fields.Select(f => f.Value).ToArray();

            var fieldNames = "[" + TableInfo.TableAlias + "].[" + string.Join("], [" + TableInfo.TableAlias + "].[", cols) + "]";

            var agg = BuildAggregates(aggregates);

            if (!string.IsNullOrWhiteSpace(agg))
                return fieldNames + ", " + agg;

            return fieldNames;
        }

        protected virtual string BuildAggregates(IList<Aggregate> aggregates)
        {
            var sb = new StringBuilder();

            var count = 0;
            foreach (var a in aggregates)
            {
                sb.Append(BuildAggregate(a, true));
                count++;
            }

            return sb.ToString();
        }

        protected virtual string BuildAggregate(Aggregate aggregate, bool withAlias)
        {
            var over = string.Empty;
            if (aggregate.OverClause.HasValue)
                over = BuildOverClause(aggregate.OverClause.Value);

            var agg = string.Format(genericAggregateClause
                , AggregateCommands[aggregate.AggregateType]
                , aggregate.Distinct ? "distinct" : ""
                , aggregate.Field.TableAlias
                , aggregate.Field.FieldName
                , string.IsNullOrWhiteSpace(over) ? string.Empty : over
                , withAlias ? " as " + aggregate.ResultAlias : string.Empty);

            return agg;
        }

        protected virtual string BuildOverClause(Over over, bool reverse = false)
        {
            var partition = string.Empty;

            if (!string.IsNullOrWhiteSpace(over.Partition.FieldName))
                partition = string.Format(genericPartitionClause, over.Partition.TableAlias, over.Partition.FieldName);

            var order = string.Empty;

            if (over.OrderBy != null && over.OrderBy.Length > 0)
                order = BuildOrderByClauses(over.OrderBy.ToList(), reverse);

            return string.Format(genericOverClause, partition, order, over.Rows);
        }

        protected virtual string BuildGroupByClauses(IList<GroupBy> groupings)
        {
            var sb = new StringBuilder();

            var count = 0;
            foreach (var g in groupings)
            {
                sb.Append(BuildGroupByField(g));
                count++;
            }

            return string.Format(genericGroupByClause, string.Empty, sb.ToString().TrimEnd(',', ' '));
        }

        protected virtual string BuildGroupByField(GroupBy groupby)
        {
            string field = string.Empty;

            if (string.IsNullOrWhiteSpace(groupby.Function))
                field = string.Format(genericGroupByField, groupby.TableAlias, groupby.FieldName);
            else
                field = string.Format(genericGroupByFunction, groupby.Function, groupby.GetUniqueParameter());

            return field;
        }

        protected virtual string BuildHavingClauses(IList<Having> havings)
        {
            var sb = new StringBuilder();

            var count = 0;
            foreach (var h in havings)
            {
                sb.Append(BuildHavingClause(h, count));
                count++;
            }

            return sb.ToString();
        }

        protected virtual string BuildHavingClause(Having having, int count)
        {
            var template = count == 0 ? genericHavingClause :
                having.UseOr ? genericHavingOr : genericHavingAnd;

            var openBlock = having.OpenBlock ? "(" : string.Empty;
            var closeBlock = having.CloseBlock ? ")" : string.Empty;
            var o = QueryBuilder.OperatorFormats[having.Operator];

            var agg = BuildAggregate(having.Aggregate, false);

            var valOp = string.Format(o, having.GetUniqueParameter());

            return string.Format(template, openBlock, agg, valOp, closeBlock);
        }

        protected virtual string BuildOrderByClauses(IList<OrderBy> orderby, bool reverse = false)
        {
            var sb = new StringBuilder();

            foreach (var o in orderby)
            {
                sb.Append(string.Format(genericOrderByField, o.TableAlias, o.FieldName, (o.Descending != reverse) ? "desc" : string.Empty));
            }

            return string.Format(genericOrderByClause, sb.ToString().TrimEnd(',', ' '));
        }

        protected virtual string GetSqlForChildren()
        {
            var query = new StringBuilder();

            if (_children.Count > 0)
                query.Append(BuildChildren(_children));

            return query.ToString();
        }

        protected virtual EntityType LoadJoinRow<IType, EType>(object entity, dynamic row, Action<EntityType, EType> setter)
            where EType : class, IHaveId<IType>
            where IType : IComparable
        {
            var reader = _loc8r.GetReader<IType, EType>();

            var boffer = entity as EntityType;

            if (boffer == null || row == null)
                return boffer;

            var rowData = (IDictionary<string, object>)row;

            setter(boffer, reader.LoadEntity(row));

            return boffer;
        }

        protected virtual EntityType LoadJoinEntities(dynamic row, dynamic join)
        {
            var entity = LoadEntity(row);

            if (entity == null)
                return entity;

            entity.Loaded = false;

            if (_joins.Count == 1 && _joins[0].Load != null)
                entity = _joins[0].Load(entity, join) as EntityType;
            else
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            entity.IsDirty = false;
            entity.Loaded = true;
            return entity;
        }

        protected virtual EntityType LoadJoinEntities(dynamic row, dynamic join, dynamic join2)
        {
            var entity = LoadEntity(row);

            if (entity == null)
                return entity;

            entity.Loaded = false;

            if (_joins.Count != 2)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            if (_joins[0].Load == null || _joins[1].Load == null)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            entity = _joins[0].Load(entity, join) as EntityType;

            entity = _joins[1].Load(entity, join2) as EntityType;

            entity.IsDirty = false;
            entity.Loaded = true;
            return entity;
        }

        protected virtual EntityType LoadJoinEntities(dynamic row, dynamic join, dynamic join2, dynamic join3)
        {
            var entity = LoadEntity(row);

            if (entity == null)
                return entity;

            entity.Loaded = false;

            if (_joins.Count != 3)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            if (_joins[0].Load == null || _joins[1].Load == null || _joins[2].Load == null)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            entity = _joins[0].Load(entity, join) as EntityType;

            entity = _joins[1].Load(entity, join2) as EntityType;

            entity = _joins[2].Load(entity, join3) as EntityType;

            entity.IsDirty = false;
            entity.Loaded = true;
            return entity;
        }

        protected virtual EntityType LoadJoinEntities(dynamic row, dynamic join, dynamic join2, dynamic join3, dynamic join4)
        {
            var entity = LoadEntity(row);

            if (entity == null)
                return entity;

            entity.Loaded = false;

            if (_joins.Count != 4)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            if (_joins[0].Load == null || _joins[1].Load == null || _joins[2].Load == null || _joins[3].Load == null)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            entity = _joins[0].Load(entity, join) as EntityType;

            entity = _joins[1].Load(entity, join2) as EntityType;

            entity = _joins[2].Load(entity, join3) as EntityType;

            entity = _joins[3].Load(entity, join4) as EntityType;

            entity.IsDirty = false;
            entity.Loaded = true;
            return entity;
        }

        protected virtual EntityType LoadJoinEntities(dynamic row, dynamic join, dynamic join2, dynamic join3, dynamic join4, dynamic join5)
        {
            var entity = LoadEntity(row);

            if (entity == null)
                return entity;

            entity.Loaded = false;

            if (_joins.Count != 5)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            if (_joins[0].Load == null || _joins[1].Load == null || _joins[2].Load == null || _joins[3].Load == null || _joins[4].Load == null)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            entity = _joins[0].Load(entity, join) as EntityType;

            entity = _joins[1].Load(entity, join2) as EntityType;

            entity = _joins[2].Load(entity, join3) as EntityType;

            entity = _joins[3].Load(entity, join4) as EntityType;

            entity = _joins[4].Load(entity, join5) as EntityType;

            entity.IsDirty = false;
            entity.Loaded = true;
            return entity;
        }
        protected virtual EntityType LoadJoinEntities(dynamic row, dynamic join, dynamic join2, dynamic join3, dynamic join4, dynamic join5, dynamic join6)
        {
            var entity = LoadEntity(row);

            if (entity == null)
                return entity;

            entity.Loaded = false;

            //if (_joins.Count != 6)
            //    throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            if (_joins[0].Load == null || _joins[1].Load == null || _joins[2].Load == null || _joins[3].Load == null || _joins[4].Load == null || _joins[5].Load == null)
                throw new InvalidOperationException("Invalid number of joins, or Load function was null");

            entity = _joins[0].Load(entity, join) as EntityType;

            entity = _joins[1].Load(entity, join2) as EntityType;

            entity = _joins[2].Load(entity, join3) as EntityType;

            entity = _joins[3].Load(entity, join4) as EntityType;

            entity = _joins[4].Load(entity, join5) as EntityType;

            entity = _joins[5].Load(entity, join6) as EntityType;

            entity.IsDirty = false;
            entity.Loaded = true;
            return entity;
        }

        //public virtual bool UniqueId { get; protected set; }
        //public virtual string TableName { get; protected set; }
        //public virtual string SchemaName { get; protected set; }
        //public virtual string TableAlias { get; protected set; }
        //public virtual IList<KeyValuePair<int, string>> ColumnNames { get; protected set; }
        //public virtual JoinInfo[] Joins { get; protected set; }
        public virtual TableInfo TableInfo { get; protected set; }
        ITableInfo IEntityReader.TableInfo
        { get { return this.TableInfo; } }

        public void ClearJoins()
        {
            _joins.Clear();
            TableInfo.Joins = new JoinInfo[0];
        }

        public IEntityReader<IdType, EntityType> WithColumn(string column)
        {
            var matchingColumn = this.TableInfo.Columns.FirstOrDefault(c => string.Equals(c.Value, column, StringComparison.CurrentCultureIgnoreCase));

            if (matchingColumn.Value == null)
                throw new KeyNotFoundException(string.Format("column {0} not found.", column));

            TableInfo.Columns.Add(matchingColumn);

            return this;
        }

        public IEntityReader<IdType, EntityType> WithoutColumn(string column)
        {
            var matchingColumn = TableInfo.Columns
                .FirstOrDefault(c => string.Equals(c.Value, column
                    , StringComparison.CurrentCultureIgnoreCase));

            if (matchingColumn.Value == null)
                return this;

            TableInfo.Columns.Remove(matchingColumn);

            return this;
        }

        public IEntityReader<IdType, EntityType> WithoutColumns(string[] columns)
        {
            var matchingColumns = TableInfo.Columns
                .Where(c => columns.Any(m => string.Equals(c.Value, m
                    , StringComparison.CurrentCultureIgnoreCase))).ToList();

            foreach (var c in matchingColumns)
                TableInfo.Columns.Remove(c);

            return this;
        }

        public virtual IList<EntityType> LoadEntities(IEnumerable<dynamic> rows)
        {
            var entities = new List<EntityType>();

            foreach (var row in rows)
            {
                var data = LoadEntity(row);

                if (data != null)
                    entities.Add(data);
            }
            return entities;
        }

        public virtual IList<EntityType> LoadMultipleEntities(IList<EntityType> results, object reader, int count)
        {
            var gridReader = reader as SqlMapper.GridReader;

            if (gridReader == null)
                throw new ArgumentNullException("reader was null or not of type SqlMapper.GridReader");

            if (count == 0)
            {
                switch (_joins.Count)
                {
                    case 0:
                        var read0 = gridReader.Read<dynamic>(true);
                        results = LoadEntities(read0).ToList();
                        break;
                    case 1:
                        results = gridReader.Read<dynamic, dynamic, EntityType>
                            (new Func<dynamic, dynamic, EntityType>
                                ((r, j) => LoadJoinEntities(r, j))
                                , string.Join(",", _joins.Select(j => j.SplitOnColumnName)), true)
                                .ToList();
                        break;
                    case 2:
                        results = gridReader.Read<dynamic, dynamic, dynamic, EntityType>
                            (new Func<dynamic, dynamic, dynamic, EntityType>
                                ((r, j, j2) => LoadJoinEntities(r, j, j2))
                                , string.Join(",", _joins.Select(j => j.SplitOnColumnName)), true)
                                .ToList();
                        break;
                    case 3:
                        results = gridReader.Read<dynamic, dynamic, dynamic, dynamic, EntityType>
                            (new Func<dynamic, dynamic, dynamic, dynamic, EntityType>
                                ((r, j, j2, j3) => LoadJoinEntities(r, j, j2, j3))
                                , string.Join(",", _joins.Select(j => j.SplitOnColumnName)), true)
                                .ToList();
                        break;
                    case 4:
                        results = gridReader.Read<dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>
                            (new Func<dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>
                                ((r, j, j2, j3, j4) => LoadJoinEntities(r, j, j2, j3, j4))
                                , string.Join(",", _joins.Select(j => j.SplitOnColumnName)), true)
                                .ToList();
                        break;
                    case 5:
                        results = gridReader.Read<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>
                            (new Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>
                                ((r, j, j2, j3, j4, j5) => LoadJoinEntities(r, j, j2, j3, j4, j5))
                                , string.Join(",", _joins.Select(j => j.SplitOnColumnName)), true)
                                .ToList();
                        break;
                    case 6:
                        results = gridReader.Read<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>
                            (new Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>
                                ((r, j, j2, j3, j4, j5, j6) => LoadJoinEntities(r, j, j2, j3, j4, j5, j6))
                                , string.Join(",", _joins.Select(j => j.SplitOnColumnName)), true)
                                .ToList();
                        break;
                    case 8:
                        results = gridReader.Read<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>
                            (new Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>
                                ((r, j, j2, j3, j4, j5, j6) => LoadJoinEntities(r, j, j2, j3, j4, j5, j6))
                                , string.Join(",", _joins.Select(j => j.SplitOnColumnName)), true)
                                .ToList();
                        break;

                    default:
                        throw new NotSupportedException("More than 6 joins not supported.");
                }
            }
            else
            {
                var index = count - 1;

                if (_children.Count <= index)
                    throw new InvalidOperationException(string.Format("Too many results from reader {0}: only {1} children specified in table {2}.", count, _children.Count, TableInfo.TableName));

                var children = _children[index].Item1.LoadMultiple(reader);

                _children[index].Item2(results, children);
            }

            return results;
        }

        public virtual IList<EntityType> LoadMultipleEntities(object reader)
        {
            SqlMapper.GridReader gridReader = reader as SqlMapper.GridReader;

            var count = 0;
            var results = new List<EntityType>();

            while (!gridReader.IsConsumed && _children.Count >= count)
            {
                results = LoadMultipleEntities(results, reader, count).ToList();

                count++;
            }

            return results;
        }

        public virtual IList<EntityType> LoadChildEntities(IList<EntityType> existing, SqlMapper.GridReader reader)
        {
            var count = 1;

            while (!reader.IsConsumed && _children.Count >= count)
            {
                if (existing != null)
                    LoadMultipleEntities(existing, reader, count);

                count++;
            }

            return existing;
        }

        public void ClearAllQueries()
        {
            _queries.Clear();
            _joins.Clear();
            _children.Clear();
        }

        public IList<object> LoadResults(IEnumerable<dynamic> rows)
        {
            if (TableInfo.UniqueId)
                return LoadEntities(rows).GroupBy(e => e.Id).Select(s => s.First()).Cast<object>().ToList();
            else
                return LoadEntities(rows).Cast<object>().ToList();
        }

        public virtual IList<object> LoadMultiple(object reader)
        {
            if (TableInfo.UniqueId)
                return LoadMultipleEntities(reader).GroupBy(e => e.Id).Select(s => s.First()).Cast<object>().ToList();
            else
                return LoadMultipleEntities(reader).Cast<object>().ToList();
        }

        public abstract EntityType LoadEntity(dynamic row);
        public abstract void SetAllChildrenForExisting(EntityType entity);
        public abstract void SetAllChildrenForExisting(IList<EntityType> entities);
        public abstract IEntityReader<IdType, EntityType> WithAllChildrenForExisting(EntityType existing);
        //public virtual IEntityReader<IdType, EntityType> WithAllChildrenForExisting(IdType id)
        //{
        //    ClearAllQueries();

        //    WhereId(id);

        //    WithAllJoins();

        //    return this;
        //}

        /// <summary>
        /// Sets the Reader to execute all joins from the table info.
        /// </summary>
        /// <returns>this entity reader instance</returns>
        public virtual IEntityReader WithAllJoins()
        {
            foreach (var j in TableInfo.Joins)
            {
                WithManyToOneJoin(j);
            }
            //var g = this.TableInfo.Joins.GroupBy(j => j.TableName);
            //foreach (var i in g)
            //    foreach (var j in i)
            //        j.
            return this;
        }

        public virtual IList<EntityType> QueryResultForChildrenOnly(IList<EntityType> existing)
        {
            object parms;

            IList<EntityType> res = new List<EntityType>();

            if (_children.Count < 1)
                return res;

            var query = GetSqlForChildQueriesOnly(out parms);

            if (_children.Count > 0)
            {
                res = _executer.Execute(_connectionStringName, query.ToString(), parms, new Func<SqlMapper.GridReader, IList<EntityType>>(f => LoadChildEntities(existing, f)));
            }

            return res;
        }

        public virtual IList<EntityType> QueryResult()
        {
            object parms;

            var query = GetSqlForQueries(out parms);

            IList<EntityType> res = new List<EntityType>();

            if (_children.Count > 0)
            {
                res = _executer.Execute(_connectionStringName, query.ToString(), parms, new Func<SqlMapper.GridReader, IList<EntityType>>(f => LoadMultipleEntities(f)));
            }
            else
            {
                switch (_joins.Count)
                {
                    case 0:
                        res = _executer.Execute(_connectionStringName, query, parms
                            , new Func<IEnumerable<dynamic>, IList<EntityType>>(f => LoadEntities(f)));
                        break;
                    case 1:
                        res = _executer.Execute(_connectionStringName, query, parms, _joins
                            , new Func<dynamic, dynamic, EntityType>((r, j) => LoadJoinEntities(r, j)));
                        break;
                    case 2:
                        res = _executer.Execute(_connectionStringName, query.ToString(), parms, _joins
                            , new Func<dynamic, dynamic, dynamic, EntityType>((r, j, j2) => LoadJoinEntities(r, j, j2)));
                        break;
                    case 3:
                        res = _executer.Execute(_connectionStringName, query.ToString(), parms, _joins
                            , new Func<dynamic, dynamic, dynamic, dynamic, EntityType>((r, j, j2, j3) => LoadJoinEntities(r, j, j2, j3)));
                        break;
                    case 4:
                        res = _executer.Execute(_connectionStringName, query.ToString(), parms, _joins
                            , new Func<dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>((r, j, j2, j3, j4) => LoadJoinEntities(r, j, j2, j3, j4)));
                        break;
                    case 5:
                        res = _executer.Execute(_connectionStringName, query.ToString(), parms, _joins
                            , new Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>((r, j, j2, j3, j4, j5) => LoadJoinEntities(r, j, j2, j3, j4, j5)));
                        break;
                    case 6:
                        res = _executer.Execute(_connectionStringName, query.ToString(), parms, _joins
                            , new Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>((r, j, j2, j3, j4, j5, j6) => LoadJoinEntities(r, j, j2, j3, j4, j5, j6)));
                        break;
                    case 8:
                        res = _executer.Execute(_connectionStringName, query.ToString(), parms, _joins
                            , new Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, EntityType>((r, j, j2, j3, j4, j5, j6) => LoadJoinEntities(r, j, j2, j3, j4, j5, j6)));
                        break;
                    default:
                        throw new NotSupportedException("More than 6 joins not supported.");
                }
            }

            return res;
        }

        public virtual object LoadEntityObject(dynamic row)
        {
            return LoadEntity(row);
        }

        public IList<object> LoadEntityObjects(IEnumerable<dynamic> rows)
        {
            return LoadEntities(rows).Cast<object>().ToList();
        }

        public virtual dynamic BuildParameters(int taskIndex)
        {
            return BuildParameters(_queries, taskIndex);
        }

        public virtual dynamic BuildParameters(IList<QueryElement> elements, int taskIndex)
        {
            var d = new ExpandoObject();
            var expand = (IDictionary<string, object>)d;
            int count = 0;
            foreach (var e in elements)
            {
                if (e.ParamNames != null && e.ParamNames.Length > 0)
                    continue;

                var pc = 0;
                if (e.Operator == Operator.In)
                    foreach (var p in e.GetUniqueParameters("q"))
                        expand.Add(p + "_" + taskIndex + "_" + count++, e.ValueArray[pc++]);
                else if (e.Operator == Operator.StartsLike)
                    expand.Add(e.GetUniqueParameter("q") + "_" + taskIndex + "_" + count++, "%" + e.Value);
                else if (e.Operator == Operator.EndsLike)
                    expand.Add(e.GetUniqueParameter("q") + "_" + taskIndex + "_" + count++, e.Value + "%");
                else if (e.Operator == Operator.Like)
                    expand.Add(e.GetUniqueParameter("q") + "_" + taskIndex + "_" + count++, "%" + e.Value + "%");
                else
                    expand.Add(e.GetUniqueParameter("q") + "_" + taskIndex + "_" + count++, e.Value);
            }

            var cCount = 1;
            foreach (var c in _children)
                foreach (var p in c.Item1.GetParameters(cCount++))
                {
                    var f = (KeyValuePair<string, object>)p;
                    expand.Add(f.Key, f.Value);
                }

            count = 0;
            foreach (var h in _havings)
                expand.Add(h.GetUniqueParameter() + "_" + count++, h.Value);

            if (_skip > 0 || _top > 0)
                expand.Add("@top", _top);

            if (_skip > 0 || _top > 0)
                expand.Add("@skip", _skip);

            return d;
        }

        protected virtual string GetPagingQuery()
        {
            var query = new StringBuilder();
            query.Append("with pagingCte AS (");

            string fields = null;

            fields = BuildSkipRowsClause
                (_orderBys.Count > 0 ? _orderBys
                : TableInfo.IdColumns.Select(i => new OrderBy() { FieldName = i.Value, TableAlias = TableInfo.TableAlias }).ToList())
                + ", ";

            fields += TableInfo.IdColumns.Select(i => "[" + TableInfo.TableAlias + "].[" + i.Value + "], ");

            var distinct = _distinct ? "distinct " : "";
            var nolock = _noLock ? " with (nolock)" : string.Empty;

            query.Append(string.Format(genericSelectQuery
               , distinct
               , ""
               , fields
               , (TableInfo.Schema != null ? TableInfo.Schema + "." : "") + TableInfo.TableName
               , TableInfo.TableAlias
               , nolock));

            query.Append(Environment.NewLine);

            if (_joins.Count > 0)
            {
                query.Append(BuildJoins(_joins));

                query.Append(Environment.NewLine);
            }

            if (_queries.Count > 0)
            {
                query.Append(BuildQueryElements(_queries, 0));

                query.Append(Environment.NewLine);
            }

            if (_groups.Count > 0)
            {
                query.Append(BuildGroupByClauses(_groups));

                query.Append(Environment.NewLine);
            }

            if (_havings.Count > 0)
            {
                query.Append(BuildHavingClauses(_havings));

                query.Append(Environment.NewLine);
            }

            query.Append(")");
            query.Append(Environment.NewLine);

            return query.ToString();
        }

        public virtual string GetSqlForQueries(int taskIndex = 0)
        {
            var query = new StringBuilder();
            var fields = string.Empty;

            if (_skip > 0)
            {
                query.Append(GetPagingQuery());
            }

            fields += BuildFields();

            if (_joins.Count > 0)
            {
                foreach (var j in _joins)
                {
                    var joinFields = ", 0 as " + j.SplitOnColumnName + ", [" + j.JoinAlias + "].[" + string.Join("], [" + j.JoinAlias + "].[", j.JoinColumnNames) + "]";

                    fields += joinFields;
                }
            }

            fields.Replace("_spc_", " ");

            var distinct = _distinct ? "distinct " : "";
            var top = _top > 0 ? "top (@top) " : "";
            var nolock = _noLock ? " with (nolock)" : string.Empty;

            query.Append(string.Format(genericSelectQuery
               , distinct
               , top
               , fields
               , (TableInfo.Schema != null ? TableInfo.Schema + "." : "") + TableInfo.TableName
               , TableInfo.TableAlias
               , nolock));

            query.Append(Environment.NewLine);

            if (_joins.Count > 0)
            {
                if (_skip > 0)
                {
                    query.Append(Environment.NewLine);
                    if (TableInfo.IdColumns.Count == 1)
                        query.Append(" join pagingCTE on pagingCTE.[" + TableInfo.IdColumns.First() + "] = " + "[" + TableInfo.TableAlias + "].[" + TableInfo.IdColumns.First() + "] and pagingCTE.[_rowsByNumber] > @skip ");
                    else
                    {
                        query.Append(" join pagingCTE on"); 
                        
                        foreach (var c in TableInfo.Columns)
                        {
                            query.Append(" pagingCTE.[" + c.Value + "] = " + "[" + TableInfo.TableAlias + "].[" + c.Value + "] and");
                        }    
                            
                        query.Append(" pagingCTE.[_rowsByNumber] > @skip ");
                    }

                    query.Append(Environment.NewLine);
                }

                query.Append(BuildJoins(_joins));

                query.Append(Environment.NewLine);
            }

            if (_queries.Count > 0)
            {
                query.Append(BuildQueryElements(_queries, taskIndex));

                query.Append(Environment.NewLine);
            }

            if (_groups.Count > 0)
            {
                query.Append(BuildGroupByClauses(_groups));

                query.Append(Environment.NewLine);
            }

            if (_havings.Count > 0)
            {
                query.Append(BuildHavingClauses(_havings));

                query.Append(Environment.NewLine);
            }

            if (_orderBys.Count > 0)
            {
                query.Append(BuildOrderByClauses(_orderBys));

                query.Append(Environment.NewLine);
            }

            query.Append(";");
            query.Append(Environment.NewLine);

            query.Append(GetSqlForChildren());

            return query.ToString();
        }

        public virtual string GetSqlForQueries(out object parms, int taskIndex = 0)
        {
            var query = GetSqlForQueries(taskIndex);

            parms = BuildParameters(_queries, taskIndex);

            return query.ToString();
        }

        public virtual string GetSqlForChildQueriesOnly(out object parms)
        {
            var query = GetSqlForChildren();

            var count = 1;
            IDictionary<string, object> parameters = new Dictionary<string, object>();

            foreach (var c in _children)
            {
                foreach (var parm in ((IDictionary<string, object>)c.Item1.BuildParameters(count++)))
                {
                    parameters.Add(parm.Key, parm.Value);
                }
            }
            parms = parameters;

            return query.ToString();
        }

        public virtual dynamic GetParameters(int taskIndex = 0)
        {
            return BuildParameters(_queries, taskIndex);
        }

        public virtual EntityType FetchById(IdType id)
        {
            ClearAllQueries();

            WhereId(id);

            return QueryResult().FirstOrDefault();
        }

        public IEntityReader WithAlias(string alias)
        {
            TableInfo.TableAlias = alias;

            return this;
        }

        public IEntityReader<IdType, EntityType> WithDistinct()
        {
            _distinct = true;

            return this;
        }

        public IEntityReader<IdType, EntityType> WithSkip(int skip)
        {
            _skip = skip;

            return this;
        }

        public IEntityReader<IdType, EntityType> WithNoLock()
        {
            _noLock = true;

            return this;
        }

        public IEntityReader<IdType, EntityType> WithTop(int top)
        {
            _top = top;

            return this;
        }

        public IEntityReader WithAggregate(Aggregate aggregate)
        {
            _aggregates.Add(aggregate);

            return this;
        }

        public IEntityReader WhereId(object id)
        {
            if (id is CompoundKey)
            {
                var keys = ((CompoundKey)id).Keys;
                 
                for (var i = 0; i < keys.Length; i++)
                {
                    _queries.Add(new QueryElement()
                    {
                        FieldName = TableInfo.IdColumns[i],
                        TableAlias = TableInfo.TableAlias,
                        Operator = Operator.Equals,
                        Value = keys[i]
                    });
                }
            }
            else
            {
                _queries.Add(new QueryElement()
                {
                    FieldName = TableInfo.IdColumns.First().Value,
                    TableAlias = TableInfo.TableAlias,
                    Operator = Operator.Equals,
                    Value = id
                });
            }

            return this;
        }

        public IEntityReader<IdType, EntityType> WhereId(IdType id)
        {
            return this.WhereId(id as object) as IEntityReader<IdType, EntityType>;

            //return this;
        }

        public IEntityReader Where(QueryElement query)
        {
            if (string.IsNullOrWhiteSpace(query.TableAlias))
                query.TableAlias = TableInfo.TableAlias;

            _queries.Add(query);

            return this;
        }

        public IEntityReader Where(string fieldName, Operator op, object value)
        {
            return Where(new QueryElement()
            {
                TableAlias = TableInfo.TableAlias,
                FieldName = fieldName,
                Operator = op,
                Value = value
            });
        }

        public IEntityReader GroupBy(GroupBy group)
        {
            if (string.IsNullOrWhiteSpace(group.TableAlias))
                group.TableAlias = TableInfo.TableAlias;

            _groups.Add(group);

            return this;
        }

        public IEntityReader Having(Having having)
        {
            _havings.Add(having);

            return this;
        }

        public IEntityReader OrderBy(OrderBy ordering)
        {
            if (string.IsNullOrWhiteSpace(ordering.TableAlias))
                ordering.TableAlias = TableInfo.TableAlias;

            _orderBys.Add(ordering);

            return this;
        }

        public virtual IEntityReader WithManyToOneJoin
            (JoinInfo join)
        {
            for (var i = 0; i < join.JoinQuery.Length; i++)
            {
                join.JoinQuery[i].ParentTableAlias = TableInfo.TableAlias;
            }

            var jti = join.Reader().TableInfo as TableInfo;

            var j = new Join()
            {
                Load = join.Load,
                SplitOnColumnName = "SplitMe",
                JoinAlias = join.Alias,
                JoinColumnNames = jti.Columns.Select(d => d.Value).ToArray(),
                JoinTable = join.TableName,
                Outer = join.Outer,
                JoinOnQueries = join.JoinQuery
            };

            _joins.Add(j);

            return this;
        }

        public virtual IEntityReader<IdType, EntityType> WithManyToOneJoin<IType, EType>
            (IEntityReader<IType, EType> joinReader
            , string[] joinFields
            , string[] parentFields
            , Func<object, dynamic, object> loadVisitor)
        {
            return this.WithManyToOneJoin(joinReader, joinFields, parentFields, "", false, loadVisitor);
        }

        public virtual IEntityReader<IdType, EntityType> WithManyToOneJoin<IType, EType>
            (IEntityReader<IType, EType> joinReader
            , string[] joinFields
            , string[] parentFields
            , string alias
            , bool outer
            , Func<object, dynamic, object> loadVisitor)
        {
            var jti = joinReader.TableInfo as TableInfo;

            var j = new Join()
            {
                Load = loadVisitor,
                SplitOnColumnName = "SplitMe",
                JoinAlias = TableInfo.TableAlias + "_" + jti.TableAlias + alias,
                JoinColumnNames = jti.Columns.Select(c => c.Value).ToArray(),
                JoinTable = jti.TableName,
                Outer = outer
            };

            var joins = new List<JoinQueryElement>();

            for (var i = 0; i < joinFields.Length; i++)
            {
                joins.Add(new JoinQueryElement()
                {
                    JoinField = joinFields[i],
                    Operator = Operator.Equals,
                    ParentField = parentFields[i],
                    ParentTableAlias = TableInfo.TableAlias
                });
            }

            j.JoinOnQueries = joins.ToArray();

            return WithJoin(j);
        }

        public virtual IEntityReader<IdType, EntityType> WithJoin
            (string joinTable
            , string joinAlias
            , string[] joinColumnNames
            , JoinQueryElement[] joinQueries
            , Func<object, dynamic, object> loadVisitor)
        {
            var join = new Join()
            {
                JoinColumnNames = joinColumnNames,
                SplitOnColumnName = "SplitOnColumn",
                JoinTable = joinTable,
                JoinAlias = joinAlias,
                JoinOnQueries = joinQueries,
                Load = loadVisitor
            };

            return WithJoin(join);
        }

        public virtual IEntityReader<IdType, EntityType> WithJoin(Join join)
        {
            if (!_joins.Any(j => j.JoinAlias == join.JoinAlias))
                _joins.Add(join);

            return this;
        }

        public virtual IEntityReader<IdType, EntityType> WithChildForParentValues
        (IEntityReader childReader
        , object[] values
        , string[] childJoinFieldNames
        , Action<IList<EntityType>, IList<object>> setOnParentVisitor
        , bool withJoins = true)
        {
            childReader.ClearAllQueries();
            var cri = childReader.TableInfo as TableInfo;

            childReader.WithAlias(TableInfo.TableAlias + "_" + cri.TableAlias);

            for (var i = 0; i < childJoinFieldNames.Length; i++)
            {
                childReader.Where(new QueryElement()
                {
                    TableAlias = cri.TableAlias,
                    FieldName = childJoinFieldNames[i],
                    Operator = Operator.Equals,
                    Value = values[i]
                });
            }

            if (withJoins)
                childReader.WithAllJoins();

            return WithChild(childReader, setOnParentVisitor);
        }

        public virtual IEntityReader<IdType, EntityType> WithChildForParentsValues
        (IEntityReader childReader
        , List<object[]> parentsValues
        , string[] childJoinFieldNames
        , Action<IList<EntityType>, IList<object>> setOnParentVisitor
        , bool withJoins = true)
        {
            childReader.ClearAllQueries();
            var cri = childReader.TableInfo as TableInfo;

            childReader.WithAlias(TableInfo.TableAlias + "_" + cri.TableAlias);

            for (var i = 0; i < childJoinFieldNames.Length; i++)
            {
                childReader.Where(new QueryElement()
                {
                    TableAlias = cri.TableAlias,
                    FieldName = childJoinFieldNames[i],
                    Operator = Operator.In,
                    ValueArray = parentsValues.Select(p => p[i]).ToArray()  //ids.Cast<object>().ToArray()
                });
            }

            if (withJoins)
                childReader.WithAllJoins();

            return WithChild(childReader, setOnParentVisitor);
        }

        public virtual IEntityReader<IdType, EntityType> WithChildForParentsFields
            (IEntityReader childReader
            , List<object[]> parentsFields
            , string[] childJoinFieldNames
            , Action<IList<EntityType>, IList<object>> setOnParentVisitor
            , bool withJoins = true)
        {
            childReader.ClearAllQueries();
            var cri = childReader.TableInfo as TableInfo;

            childReader.WithAlias(TableInfo.TableAlias + "_" + cri.TableAlias);

            for (var i = 0; i < childJoinFieldNames.Length; i++)
            {
                childReader.Where(new QueryElement()
                {
                    TableAlias = cri.TableAlias,
                    FieldName = childJoinFieldNames[i],
                    Operator = Operator.In,
                    ValueArray = parentsFields.Select(p => p[i]).ToArray()  //ids.Cast<object>().ToArray()
                });
            }

            if (withJoins)
                childReader.WithAllJoins();

            return WithChild(childReader, setOnParentVisitor);
        }

        public virtual IEntityReader<IdType, EntityType> WithChildForParentFields
            (IEntityReader childReader
            , object[] parentFields
            , string[] childJoinFieldNames
            , Action<IList<EntityType>, IList<object>> setOnParentVisitor
            , bool withJoins = true)
        {
            var cri = childReader.TableInfo as TableInfo;
            childReader.ClearAllQueries();

            childReader
                .WithAlias(TableInfo.TableAlias + "_" + cri.TableAlias);

            for (var i = 0; i < parentFields.Length; i++)
            {
                childReader.Where(new QueryElement()
                {
                    TableAlias = cri.TableAlias,
                    FieldName = childJoinFieldNames[i],
                    Operator = Operator.Equals,
                    Value = parentFields[i]
                });
            }

            if (withJoins)
                childReader.WithAllJoins();

            return WithChild(childReader, setOnParentVisitor);
        }

        public virtual IEntityReader<IdType, EntityType> WithChildForParameters
            (IEntityReader childReader
            , string[] paramNames
            , string[] childJoinFieldNames
            , Action<IList<EntityType>, IList<object>> setOnParentVisitor)
        {
            var cri = childReader.TableInfo as TableInfo;
            childReader.ClearAllQueries();

            childReader
                .WithAlias(TableInfo.TableAlias + "_" + cri.TableAlias);

            for (var i = 0; i < childJoinFieldNames.Length; i++)
            { 
                childReader.Where(new QueryElement()
                 {
                     TableAlias = cri.TableAlias,
                     FieldName = childJoinFieldNames[i],
                     Operator = Operator.Equals,
                     ParamNames = new string[] { paramNames[i] }
                 });
            }

            childReader.WithAllJoins();

            return WithChild(childReader, setOnParentVisitor);
        }

        public virtual IEntityReader<IdType, EntityType> WithChild
            (IEntityReader childReader
            , Action<IList<EntityType>
                , IList<object>> setOnParentVisitor)
        {
            _children.Add
                (new Tuple<IEntityReader, Action<IList<EntityType>, IList<object>>>
                (childReader, setOnParentVisitor));

            return this;
        }

        public void Dispose()
        {
            if (_joins != null)
                _joins.Clear();

            if (_children != null)
                foreach (var c in _children)
                    if (c.Item1 != null)
                        c.Item1.Dispose();
        }
    }
}
