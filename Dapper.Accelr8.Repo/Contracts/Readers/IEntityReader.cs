using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Repo.Parameters;


namespace Dapper.Accelr8.Repo.Contracts.Readers
{
    public interface IEntityReader : IDisposable
    {
        bool UniqueId { get; }
        string IdColumn { get; }
        string TableName { get; }
        string SchemaName { get; }
        object TableInfo { get; }
        IList<KeyValuePair<int, string>> ColumnNames { get; }
        string TableAlias { get; }
        object LoadEntityObject(dynamic row);
        IList<object> LoadEntityObjects(IEnumerable<dynamic> rows);
        IList<object> LoadMultiple(object reader);
        string GetSqlForQueries(int taskIndex = 0);
        string GetSqlForQueries(out object parms, int taskIndex = 0);
        dynamic GetParameters(int taskIndex = 0);
        dynamic BuildParameters(int taskIndex);
        dynamic BuildParameters(IList<QueryElement> elements, int taskIndex);

        void ClearAllQueries();

        IEntityReader WhereId(object id);
        IEntityReader Where(QueryElement query);
        IEntityReader Where(string fieldName, Operator op, object value);
        IEntityReader WithAlias(string alias);
        IEntityReader WithAggregate(Aggregate aggregate);
        IEntityReader GroupBy(GroupBy group);
        IEntityReader Having(Having having);
        IEntityReader OrderBy(OrderBy ordering);
        IEntityReader WithAllJoins();
    }

    public interface IEntityReader<IdType, EntityType> : IEntityReader
    {
        IEntityReader<IdType, EntityType> WithAllChildrenForId(IdType id);
        void SetAllChildrenForExisting(EntityType entity);
        void SetAllChildrenForExisting(IList<EntityType> entities);
        EntityType LoadEntity(object row);
        EntityType FetchById(IdType id);
        IList<EntityType> LoadEntities(IEnumerable<dynamic> rows);
        IList<EntityType> LoadMultipleEntities(object reader);
        IList<EntityType> QueryResult();
        IEntityReader<IdType, EntityType> WhereId(IdType id);
        IEntityReader<IdType, EntityType> WithJoin(Join join);
        IEntityReader<IdType, EntityType> WithDistinct();
        IEntityReader<IdType, EntityType> WithSkip(int skip);
        IEntityReader<IdType, EntityType> WithTop(int top);
        IEntityReader<IdType, EntityType> WithColumn(string name);
        IEntityReader<IdType, EntityType> WithoutColumn(string name);
        IEntityReader<IdType, EntityType> WithoutColumns(string[] name);
        IEntityReader<IdType, EntityType> WithChildForParentId(IEntityReader childReader, IdType id, string childJoinFieldName, Action<IList<EntityType>, IList<object>> setOnParentVisitor, bool withJoins = false);
        IEntityReader<IdType, EntityType> WithChildForParentIds(IEntityReader childReader, IdType[] ids, string childJoinFieldName, Action<IList<EntityType>, IList<object>> setOnParentVisitor, bool withJoins = false);
        IEntityReader<IdType, EntityType> WithChild(IEntityReader childReader, string childJoinFieldName, Action<IList<EntityType>, IList<object>> setOnParentVisitor);
        IEntityReader<IdType, EntityType> WithJoin(string joinTable, string joinAlias, string[] joinColumnNames, JoinQueryElement[] joinQueries, Func<object, dynamic, object> load);
    }
}
