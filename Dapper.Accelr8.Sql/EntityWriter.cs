using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Contracts.Writers;
using Dapper.Accelr8.Repo.Parameters;

namespace Dapper.Accelr8.Sql
{
    public abstract class EntityWriter<IdType, EntityType> : IEntityWriter, IEntityWriter<IdType, EntityType>
        where EntityType : class, IEntity, IHaveId<IdType>
        where IdType : struct, IComparable<IdType>, IEquatable<IdType>
    {
        protected static string _sqlIdType = "int";
        protected static int _typeHash = typeof(EntityType).GetHashCode();
        static EntityWriter()
        {
            if (typeof(IdType) == typeof(Int32))
                _sqlIdType = "int";
            if (typeof(IdType) == typeof(Int64))
                _sqlIdType = "bigint";
            if (typeof(IdType) == typeof(Guid))
                _sqlIdType = "uniqueidentifier";
            if (typeof(IdType) == typeof(Int16))
                _sqlIdType = "smallint";
            if (typeof(IdType) == typeof(string))
                _sqlIdType = "nvarchar(512)";
        }

        public EntityWriter(TableInfo tableInfo, string connectionStringName, DapperExecuter executer, QueryBuilder queryBuilder, JoinBuilder joinBuilder)
        {
            _connectionStringName = connectionStringName;
            _executer = executer;
            _queryBuilder = queryBuilder;
            _joinBuilder = joinBuilder;

            UniqueId = tableInfo.UniqueId;
            IdField = tableInfo.IdColumn;
            TableName = tableInfo.TableName;
            TableAlias = tableInfo.TableAlias;
            FieldNames = (string[])tableInfo.ColumnNames.Clone();
        }

        protected bool _withCascades;
        protected string _connectionStringName;
        protected DapperExecuter _executer;
        protected QueryBuilder _queryBuilder;
        protected JoinBuilder _joinBuilder;

        protected static readonly string insertTemplate = @"insert into [{0}] ({1}) OUTPUT Inserted.{2} INTO @affectedRows values ({3}); ";
        protected static readonly string insertNoFieldsTemplate = @"insert into [{0}] OUTPUT Inserted.{1} INTO @affectedRows default values; ";

        protected static readonly string updateTemplate = @"update [{1}] {2} from [{0}] [{1}]";
        protected static readonly string setTemplate = @"[{0}] = {1}";

        protected static readonly string deleteTemplate = @"delete [{1}] from [{0}] [{1}]";

        protected static readonly string genericWhereClause = @"where {0}[{1}].[{2}] {3}{4} "; //0 is open bracket //1 is alias
        protected static readonly string genericAndClause = @"and {0}[{1}].[{2}] {3}{4} "; //0 is open bracket //1 is alias
        protected static readonly string genericOrClause = @"or {0}[{1}].[{2}] {3}{4} "; //0 is open bracket //1 is alias

        protected static readonly string genericJoinClause = @"join {0} [{1}] on {2}{1}.[{3}] {4}{5} "; //2 is open bracket, 5 is close bracket.

        protected ActionType _action = ActionType.None;

        protected List<ExecuteTask<EntityType>> _tasks = new List<ExecuteTask<EntityType>>();
        protected List<Tuple<IEntityWriter, EntityType>> _children = new List<Tuple<IEntityWriter, EntityType>>();
        protected List<Tuple<IEntityWriter, EntityType>> _parents = new List<Tuple<IEntityWriter, EntityType>>();
        protected List<string> _cascades = new List<string>();

        protected virtual string BuildQueryElements(IList<QueryElement> elements, int taskIndex)
        {
            return _queryBuilder.BuildQueryElements(elements, taskIndex);
        }

        protected virtual string BuildQueryElement(QueryElement e, string tableAlias, int count)
        {
            return _queryBuilder.BuildQueryElement(e, 0, count);
        }

        protected virtual string BuildJoins(IList<Join> joins)
        {
            return _joinBuilder.BuildJoins(joins);
        }

        protected virtual string BuildJoin(Join join, int count)
        {
            return _joinBuilder.BuildJoin(join, count);
        }

        protected virtual string BuildFields(string[] fields)
        {
            if (fields.Length == 0)
                return string.Empty;

            var fieldNames = "[" + TableAlias + "].[" + string.Join("], [" + TableAlias + "].[", fields) + "]";

            return fieldNames;
        }

        protected virtual object BuildSetParamaters(ExecuteTask<EntityType> task)
        {
            int count = 0;
            var fieldSets = FieldNames
                .Except(new string[] { IdField })
                .Select(field =>
                    string.Format
                    (setTemplate
                    , field.Replace("_spc_", " ")
                    , GetParamName(field, "u", task.Index, count++)));

            var s = string.Join(", ", fieldSets);

            return "set " + s.TrimEnd(',', ' ');
        }

        protected virtual string BuildInsertParameters(int taskIndex)
        {
            int count = 0;

            if (FieldNames.Length == 0)
                return string.Empty;

            var fieldNames = string.Concat(FieldNames.Where(f => f != IdField).Select(s => GetParamName(s, "i", taskIndex, count++) + ", "));

            return fieldNames.TrimEnd(',', ' ');
        }

        protected virtual string GetParamName(string fieldName, ActionType actionType, int taskIndex, int count)
        {
            var s = actionType == ActionType.Add ? "i"
                : actionType == ActionType.Update ? "u" : "d";

            return GetParamName(fieldName, s, taskIndex, count);
        }

        protected virtual string GetParamName(string fieldName, string paramType, int taskIndex, int count)
        {
            return "@" + TableAlias + fieldName + "_" + paramType + "_" + taskIndex;
        }

        protected virtual bool Cascade<IType, EType>(IEntityWriter<IType, EType> writer, EType entity, ScriptContext context)
            where EType : class, IEntity, IHaveId<IType>
            where IType : struct, IComparable<IType>, IEquatable<IType>
        {
            if (entity == null || !entity.IsDirty)
                return false;

            if (context.ContainsKey(entity.GetHashCode()))// && !object.Equals(entity.Id, default(IType)))
                return false;
            else
                context.Add(entity.GetHashCode());

            if (entity.IsNew())
                writer.Insert(entity);
            else
                writer.Update(entity);

            foreach (var c in _cascades)
                writer.WithCascade(c);

            return true;
        }

        protected abstract IDictionary<string, object> GetParams(ActionType actionType, EntityType entity, int taskIndex, int count);
        protected abstract void CascadeRelations(EntityType entity, ScriptContext context);
        protected abstract void RemoveRelations(IList<string> cascades, EntityType entity);
        protected abstract void UpdateIdsFromReferences(IList<string> cascades, EntityType entity);

        public virtual bool UniqueId { get; protected set; }
        public virtual string IdField { get; protected set; }
        public virtual string TableName { get; protected set; }
        public virtual string TableAlias { get; protected set; }
        public virtual string[] FieldNames { get; protected set; }

        public virtual int Count { get { return _tasks.Count; } }

        public virtual IEntityWriter<IdType, EntityType> WithChild(IEntityWriter writer, EntityType parent)
        {
            _children.Add(new Tuple<IEntityWriter, EntityType>(writer, parent));

            return this;
        }

        public virtual IEntityWriter<IdType, EntityType> WithParent(IEntityWriter writer, EntityType child)
        {
            _parents.Add(new Tuple<IEntityWriter, EntityType>(writer, child));

            return this;
        }

        #region Sql Builders

        public string GetSql(out object parms)
        {
            parms = BuildParameters(_tasks);
            var sb = new StringBuilder();
            sb.Append("declare @affectedRows AS TABLE (Id " + _sqlIdType + "); ");
            sb.Append(Environment.NewLine);

            foreach (var task in _tasks)
            {
                switch (task.TaskType)
                {
                    case ActionType.Add:
                        sb.Append(GetSqlForInsert(task));
                        break;
                    case ActionType.Update:
                        sb.Append(GetSqlForUpdate(task));
                        break;
                    case ActionType.None:
                        sb.Append(task.Script);
                        break;
                    case ActionType.Remove:
                    default:
                        sb.Append(GetSqlForDelete(task));
                        break;
                }
            }

            sb.Append(Environment.NewLine);
            sb.Append("select Id from @affectedRows;");
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

        protected virtual string GetSqlForInsert(ExecuteTask<EntityType> task)
        {
            var names = FieldNames.Where(s => s != IdField);

            var query = new StringBuilder();

            if (names.Count() > 0)
            {
                query.Append(string.Format(insertTemplate
                   , TableName
                   , "[" + String.Join("], [", names.ToArray()).Replace("_spc_", " ") + "]"
                   , IdField
                   , BuildInsertParameters(task.Index)));
            }
            else
            {
                query.Append(string.Format(insertNoFieldsTemplate
                   , TableName
                   , IdField));
            }

            query.Append(Environment.NewLine);

            return query.ToString();
        }

        protected virtual string GetSqlForUpdate(ExecuteTask<EntityType> task)
        {
            var query = new StringBuilder();

            query.Append(string.Format(updateTemplate
               , TableName
               , TableAlias
               , BuildSetParamaters(task)));

            query.Append(Environment.NewLine);

            if (task.Joins.Count > 0)
            {
                query.Append(BuildJoins(task.Joins));

                query.Append(Environment.NewLine);
            }

            if (task.Queries.Count > 0)
            {
                query.Append(BuildQueryElements(task.Queries, task.Index));

                query.Append(Environment.NewLine);
            }

            query.Append(Environment.NewLine);

            return query.ToString();
        }

        protected virtual string GetSqlForDelete(ExecuteTask<EntityType> task)
        {
            var query = new StringBuilder();

            query.Append(string.Format(deleteTemplate
               , TableName
               , TableAlias));

            query.Append(Environment.NewLine);

            if (task.Joins.Count > 0)
            {
                query.Append(_joinBuilder.BuildJoins(task.Joins));

                query.Append(Environment.NewLine);
            }

            if (task.Queries.Count < 1)
                throw new InvalidOperationException("Delete statement must contain a where clause");

            query.Append(_queryBuilder.BuildQueryElements(task.Queries, task.Index));

            query.Append(Environment.NewLine);

            return query.ToString();
        }

        #endregion

        public void ClearAllQueries()
        {
            _tasks.Clear();
        }

        public IEntityWriter<IdType, EntityType> Insert(EntityType entity)
        {
            _tasks.Add
                (new ExecuteTask<EntityType>(_tasks.Count)
                {
                    Entity = entity,
                    TaskType = ActionType.Add
                });

            return this;
        }

        public IEntityWriter<IdType, EntityType> Insert(IList<EntityType> entities)
        {
            foreach (var e in entities)
            {
                _tasks.Add
                     (new ExecuteTask<EntityType>(_tasks.Count)
                     {
                         Entity = e,
                         TaskType = ActionType.Add
                     });
            }
            return this;
        }

        public IEntityWriter<IdType, EntityType> WithColumn(string column)
        {
            var with = new List<string>(FieldNames);
            with.Add(column);
            FieldNames = with.ToArray();

            return this;
        }

        public IEntityWriter<IdType, EntityType> WithoutColumn(string column)
        {
            var without = new List<string>(FieldNames);
            without.Remove(column);
            FieldNames = without.ToArray();

            return this;
        }

        public IEntityWriter<IdType, EntityType> WithoutColumn(string[] columns)
        {
            var without = new List<string>(FieldNames);
            without.RemoveAll(a => columns.Contains(a));
            FieldNames = without.ToArray();

            return this;
        }

        public IEntityWriter<IdType, EntityType> Update(EntityType entity)
        {
            var task = new ExecuteTask<EntityType>(_tasks.Count)
            {
                TaskType = ActionType.Update,
                Entity = entity
            };

            task.Queries.Add(
              new QueryElement()
              {
                  FieldName = IdField,
                  Operator = Operator.Equals,
                  Value = entity.Id,
                  TableAlias = TableAlias
              });

            _tasks.Add(task);

            return this;
        }

        public IEntityWriter<IdType, EntityType> DeleteByQuery(IList<QueryElement> queries)
        {
            var task = new ExecuteTask<EntityType>(_tasks.Count)
            {
                TaskType = ActionType.Remove
            };

            foreach (var q in queries)
                task.Queries.Add(q);

            _tasks.Add(task);

            return this;
        }

        public IEntityWriter<IdType, EntityType> Delete(EntityType entity)
        {
            var task = new ExecuteTask<EntityType>(_tasks.Count)
            {
                TaskType = ActionType.Remove
            };

            task.Queries.Add(new QueryElement()
            {
                FieldName = IdField,
                Operator = Operator.Equals,
                TableAlias = TableAlias,
                Value = entity.Id
            });

            _tasks.Add(task);

            return this;
        }

        public IEntityWriter<IdType, EntityType> Delete(IList<EntityType> entities)
        {
            var task = new ExecuteTask<EntityType>(_tasks.Count)
            {
                TaskType = ActionType.Remove
            };

            task.Queries.Add(new QueryElement()
            {
                FieldName = IdField,
                Operator = Operator.In,
                TableAlias = TableAlias + (_tasks.Count),
                ValueArray = entities.Select(e => e.Id).Cast<object>().ToArray()
            });

            _tasks.Add(task);

            return this;
        }

        public IEntityWriter<IdType, EntityType> Delete(IdType id)
        {
            var task = new ExecuteTask<EntityType>(_tasks.Count)
            {
                TaskType = ActionType.Remove
            };

            task.Queries.Add(new QueryElement()
            {
                FieldName = IdField,
                Operator = Operator.In,
                TableAlias = TableAlias,
                Value = id
            });

            _tasks.Add(task);

            return this;
        }

        public IEntityWriter<IdType, EntityType> Delete(IList<IdType> ids)
        {
            var task = new ExecuteTask<EntityType>(_tasks.Count)
            {
                TaskType = ActionType.Remove
            };

            task.Queries.Add(new QueryElement()
            {
                FieldName = IdField,
                Operator = Operator.In,
                TableAlias = TableAlias + (_tasks.Count),
                ValueArray = ids.Cast<object>().ToArray()
            });

            _tasks.Add(task);

            return this;
        }

        public IEntityWriter<IdType, EntityType> Update(IList<EntityType> entities)
        {
            foreach (var entity in entities)
            {
                var task = new ExecuteTask<EntityType>(_tasks.Count)
                {
                    TaskType = ActionType.Update,
                    Entity = entity,
                };

                task.Queries.Add(
                  new QueryElement()
                  {
                      FieldName = IdField,
                      Operator = Operator.Equals,
                      Value = entity.Id,
                      TableAlias = TableAlias.ToString()
                  });

                _tasks.Add(task);
            }

            return this;
        }

        public IEntityWriter<IdType, EntityType> WithCascade(string cascade)
        {
            if (!_cascades.Contains(cascade))
                _cascades.Add(cascade);

            return this;
        }

        //public IEntityWriter<IdType, EntityType> Where(QueryElement query)
        //{
        //    if (_tasks.Count != 1)
        //        throw new InvalidOperationException("There was no current operation which to append this query");

        //    _tasks[0].Queries.Add(query);

        //    return this;
        //}

        public IEntityWriter<IdType, EntityType> Run(string script, IDictionary<string, object> parms)
        {
            var task = new ExecuteTask<EntityType>(_tasks.Count)
            {
                TaskType = ActionType.None,
                Script = script,
                Params = parms
            };

            _tasks.Add(task);

            return this;
        }

        //public IEntityWriter<IdType, EntityType> WithJoin(Join join)
        //{
        //    if (_tasks.Count != 1)
        //        throw new InvalidOperationException("There was no current operation which to append this query");

        //    _tasks[0].Joins.Add(join);

        //    return this;
        //}

        public virtual dynamic BuildParameters(IList<ExecuteTask<EntityType>> tasks)
        {
            var d = new ExpandoObject();
            var expand = (IDictionary<string, object>)d;
            
            foreach (var task in tasks)
            {
                if (task.Entity != null)
                    foreach (var p in GetParams(task.TaskType, task.Entity, task.Index, 0))
                        expand.Add(p.Key, p.Value);

                if (task.Params != null)
                    foreach (var t in task.Params)
                        expand.Add(t.Key, t.Value);

                foreach (var e in task.Queries)
                {
                    if (e.ParamNames != null && e.ParamNames.Length > 0)
                        continue;

                    var count = 0;

                    if (e.Operator != Operator.In)
                        expand.Add(e.GetUniqueParameter("q") + "_" + task.Index, e.Value);
                    else
                        foreach (var p in e.GetUniqueParameters("q"))
                            expand.Add(p, e.ValueArray[count++]);
                }
            }

            return d;
        }

        private void SetIds(IList<IdType> ids)
        {
            if (ids.Count == 0)
                return;

            var index = 0;

            foreach (var task in _tasks.Where(t => t.TaskType == ActionType.Add))
            {
                if (task.Entity == null)
                {
                    index++;
                    continue;
                }

                if (ids.Count <= index)
                    throw new System.Data.DataException(string.Format("Insert did not return an id for entity {0}", task.Entity));

                task.Entity.Id = ids[index];
            }
        }

        public int Execute()
        {
            return Execute(new ScriptContext());
        }

        public virtual int Execute(ScriptContext context)
        {
            if (!_tasks.Any(t => t.Entity == null || t.Entity.IsDirty))
                return 0;

            foreach (var d in _tasks)
            {
                if (d.Entity == null)
                    continue;

                UpdateIdsFromReferences(_cascades, d.Entity);

                context.Add(d.Entity.GetHashCode());

                if (_cascades.Count > 0)
                {
                    if (d.TaskType == ActionType.Remove && d.Entity != null)
                        RemoveRelations(_cascades, d.Entity);
                    else if (d.Entity != null)
                        CascadeRelations(d.Entity, context);
                }
            }

            var count = 0;

            foreach (var p in _parents)
            {
                count += p.Item1.Execute(context);
                UpdateIdsFromReferences(_cascades, p.Item2);
            }

            //if the entity was already inserted via cascade since the task was initiated, remove it.
            _tasks.RemoveAll(d => d.Entity != null && d.TaskType == ActionType.Add && !d.Entity.IsDirty);

            if (_tasks.Count < 1)
                return count;

            object parms;

            var sql = GetSql(out parms);

            count += _executer.Execute<IdType>(_connectionStringName, sql, parms, SetIds);

            foreach (var d in _tasks)
                if (d.Entity != null)
                    d.Entity.IsDirty = false;

            foreach (var c in _children)
            {
                if (c.Item2 != null)
                    UpdateIdsFromReferences(_cascades, c.Item2);

                count += c.Item1.Execute(context);
            }

            return count;
        }

        #region IEntityWriter Memebers

        IEntityWriter IEntityWriter.Insert(object entity)
        {
            return this.Insert(entity as EntityType);
        }

        IEntityWriter IEntityWriter.Insert(IList<object> entities)
        {
            return this.Insert(entities.Cast<EntityType>().ToList());
        }

        IEntityWriter IEntityWriter.Update(object entity)
        {
            return this.Update(entity as EntityType);
        }

        IEntityWriter IEntityWriter.Update(IList<object> entities)
        {
            return this.Update(entities.Cast<EntityType>().ToList());
        }

        IEntityWriter IEntityWriter.DeleteId(object id)
        {
            return this.Delete((IdType)id);
        }

        IEntityWriter IEntityWriter.Delete(object entity)
        {
            return this.Delete(entity as EntityType);
        }

        IEntityWriter IEntityWriter.Delete(IList<object> ids)
        {
            return this.Delete(ids.Cast<IdType>().ToList());
        }

        IEntityWriter IEntityWriter.Delete(IList<QueryElement> queries)
        {
            return this.DeleteByQuery(queries);
        }

        //IEntityWriter IEntityWriter.Where(QueryElement query)
        //{
        //    return this.Where(query);
        //}

        //IEntityWriter IEntityWriter.WithJoin(Join join)
        //{
        //    return this.WithJoin(join);
        //}

        IEntityWriter IEntityWriter.WithChild(IEntityWriter writer, object parent)
        {
            return this.WithChild(writer, parent as EntityType);
        }

        void IEntityWriter.ClearAllQueries()
        {
            this.ClearAllQueries();
        }

        void IEntityWriter.UpdateIdsFromReferences(params string[] cascades)
        {
            foreach (var t in _tasks)
                if (t.Entity != null)
                    UpdateIdsFromReferences(cascades.ToList(), t.Entity);
        }

        int IEntityWriter.Execute()
        {
            return this.Execute();
        }

        #endregion

        public void Dispose()
        {
        }
    }
}
