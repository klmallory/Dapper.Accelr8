using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Contracts.Readers;
using Dapper.Accelr8.Domain;


namespace Dapper.Accelr8.Repo
{
    public interface IRepository : IDisposable
    {
        IUnitOfWork BeginUnsafeUnitOfWork();
        IUnitOfWork BeginUnitOfWork();
        IUnitOfWork BeginLockedUnitOfWork();

        void Execute(string script, IDictionary<string, object> parms);

        void AddOrUpdate(object entity, params string[] cascades);
        void AddOrUpdate(IList<object> entities, params string[] cascades);

        IList<object> SelectAllObj(int skip, int take, params OrderBy[] ordering);
        object SelectById(object id);
        object SelectByIdWithChildren(object id);
        void SetAllChildrenForExisting(object entity);
        void SetAllChildrenForExisting(IList<object> entities);
        IList<object> SelectObj(QueryElement query, bool withChildren = false);
        IList<object> SelectObj(IList<QueryElement> query, bool withChildren = false);
        IList<object> SelectObj(QueryElement query, int skip, int take, bool withChildren = false);
        IList<object> SelectObj(IList<QueryElement> query, int skip, int take, bool withChildren = false);
        IList<object> SelectObj(IList<QueryElement> query, IList<OrderBy> ordering);
        IList<object> SelectObj(IList<QueryElement> query, IList<OrderBy> ordering, int skip, int take);
        IList<object> SelectObj(IList<QueryElement> query, IList<GroupBy> grouping);
        IList<object> SelectObj(IList<QueryElement> query, IList<Aggregate> aggregates);
        IList<object> SelectObj(IList<QueryElement> query, IList<Having> havings);
        IList<object> SelectObj(IList<QueryElement> query, IList<Aggregate> aggregates, IList<GroupBy> grouping, IList<Having> havings, IList<OrderBy> ordering, int skip, int take);
        void Delete(object entity, params string[] cascades);
        void Delete(IList<object> entities, params string[] cascades);
    }

    public interface IRepository<IdType, EntityType> : IRepository
        where EntityType : IEntity, IHaveId<IdType>
        where IdType : IComparable
    {
        IEntityReader<IdType, EntityType> GetReader();
        void AddOrUpdate(EntityType entity, params string[] cascades);
        void AddOrUpdate(IList<EntityType> entities, params string[] cascades);

        IList<EntityType> SelectAll(int skip, int take, params OrderBy[] ordering);
        EntityType SelectById(IdType id);
        EntityType SelectByIdWithChildren(IdType id);
        void SetAllChildrenForExisting(EntityType entity);
        void SetAllChildrenForExisting(IList<EntityType> entities);
        IList<EntityType> Select(QueryElement query, bool withChildren = false);
        IList<EntityType> Select(IList<QueryElement> query, bool withChildren = false);
        IList<EntityType> Select(QueryElement query, int skip, int take, bool withChildren = false);
        IList<EntityType> Select(IList<QueryElement> query, int skip, int take, bool withChildren = false);
        IList<EntityType> Select(IList<QueryElement> query, IList<OrderBy> ordering, bool withChildren = false);
        IList<EntityType> Select(IList<QueryElement> query, IList<OrderBy> ordering, int skip, int take, bool withChildren = false);
        IList<EntityType> Select(IList<QueryElement> query, IList<GroupBy> grouping, bool withChildren = false);
        IList<EntityType> Select(IList<QueryElement> query, IList<Aggregate> aggregates, bool withChildren = false);
        IList<EntityType> Select(IList<QueryElement> query, IList<Having> havings, bool withChildren = false);
        IList<EntityType> Select(IList<QueryElement> query, IList<Aggregate> aggregates, IList<GroupBy> grouping, IList<Having> havings, IList<OrderBy> ordering, int skip, int take, bool withChildren = false);
        IList<EntityType> Select(IEntityReader<IdType, EntityType> customQuery, bool withChildren = false);
        void Delete(EntityType entity, params string[] cascades);
        void Delete(IList<EntityType> entities, params string[] cascades);
        void Delete(IList<QueryElement> query);
    }
}
