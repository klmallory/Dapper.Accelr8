using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo.Parameters;

namespace Dapper.Accelr8.Repo.Contracts.Writers
{
    public interface IEntityWriter : IDisposable
    {
        bool UniqueId { get; }
        string IdColumn { get; }
        string TableName { get; }
        string[] ColumnNames { get; }
        string TableAlias { get; }
        int Count { get; }
        bool HasDeletes();
        IEntityWriter Insert(object entity);
        IEntityWriter Insert(IList<object> entities);

        IEntityWriter Update(object entity);
        IEntityWriter Update(IList<object> entities);

        IEntityWriter DeleteId(object id);
        IEntityWriter Delete(object entity);
        IEntityWriter Delete(IList<object> ids);
        IEntityWriter Delete(IList<QueryElement> queries);

        IEntityWriter WithChild(IEntityWriter writer, object parent);

        void UpdateIdsFromReferences(params string[] cascades);

        void ClearAllQueries();

        int Execute();
        int Execute(ScriptContext context);
    }

    public interface IEntityWriter<IdType, EntityType> : IEntityWriter, IDisposable
        where EntityType : class, IEntity, IHaveId<IdType>
        where IdType : struct, IComparable<IdType>, IEquatable<IdType>
    {
        IEntityWriter<IdType, EntityType> Insert(EntityType entity);
        IEntityWriter<IdType, EntityType> Insert(IList<EntityType> entities);
        IEntityWriter<IdType, EntityType> Update(EntityType entity);
        IEntityWriter<IdType, EntityType> Update(IList<EntityType> entities);
        IEntityWriter<IdType, EntityType> WithColumn(string column);
        IEntityWriter<IdType, EntityType> WithoutColumn(string column);
        IEntityWriter<IdType, EntityType> WithoutColumn(string[] columns);
        IEntityWriter<IdType, EntityType> WithCascade(string cascade);
        IEntityWriter<IdType, EntityType> Delete(IList<IdType> ids);
        IEntityWriter<IdType, EntityType> Delete(EntityType entity);
        IEntityWriter<IdType, EntityType> Delete(IList<EntityType> entities);
        IEntityWriter<IdType, EntityType> DeleteByQuery(IList<QueryElement> queries);
        IEntityWriter<IdType, EntityType> Run(string script, IDictionary<string, object> parms);
        IEntityWriter<IdType, EntityType> WithChild(IEntityWriter writer, EntityType parent);
    }
}
