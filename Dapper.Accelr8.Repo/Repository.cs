using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Contracts.Readers;
using Dapper.Accelr8.Repo.Contracts.Writers;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Domain;


namespace Dapper.Accelr8.Repo
{
    public class Repository<IdType, EntityType> : IRepository<IdType, EntityType>, IRepository
        where EntityType : class, IEntity, IHaveId<IdType>
        where IdType : struct, IComparable<IdType>, IEquatable<IdType>
    {
        static int _typeHash = typeof(EntityType).GetHashCode();

        public Repository(IAccelr8Locator serviceLocator, IUnitOfWorkStore unitStore)
        {
            _serviceLocator = serviceLocator;
            _unitStore = unitStore;
        }

        IAccelr8Locator _serviceLocator;
        IUnitOfWorkStore _unitStore;

        protected virtual IEntityWriter<IdType, EntityType> GetWriter()
        {
            return _serviceLocator.Resolve<IEntityWriter<IdType, EntityType>>();
        }

        public IEntityReader<IdType, EntityType> GetReader()
        {
            return _serviceLocator.Resolve<IEntityReader<IdType, EntityType>>();
        }

        public IUnitOfWork BeginUnsafeUnitOfWork()
        {
            var uow = _serviceLocator.Resolve<IUnitOfWork>("unsafe");

            _unitStore.ActiveUnitOfWork = uow;

            return uow;
        }

        public IUnitOfWork BeginUnitOfWork()
        {
            var uow = _serviceLocator.Resolve<IUnitOfWork>();

            _unitStore.ActiveUnitOfWork = uow;

            return uow;
        }

        public IUnitOfWork BeginLockedUnitOfWork()
        {
            var uow = _serviceLocator.Resolve<IUnitOfWork>("locked");

            _unitStore.ActiveUnitOfWork = uow;

            return uow;
        }

        public void SetAllChildrenForExisting(EntityType entity)
        {
            var reader = GetReader();
            {
                reader.SetAllChildrenForExisting(entity);
            }
        }

        public void SetAllChildrenForExisting(IList<EntityType> entities)
        {
            using (var reader = GetReader())
            {
                reader.SetAllChildrenForExisting(entities);
            }
        }

        public IList<EntityType> SelectAll(int take, params OrderBy[] ordering)
        {
            using (var reader = GetReader())
            {
                reader.WithAllJoins();

                reader.WithTop(take);

                foreach (var o in ordering)
                    reader.OrderBy(o);

                return reader.QueryResult();
            }
        }

        public EntityType SelectById(IdType id)
        {
            using (var reader = GetReader())
            {
                reader.WhereId(id);

                reader.WithAllJoins();

                return reader.QueryResult().FirstOrDefault();
            }
        }

        public EntityType SelectByIdWithChildren(IdType id)
        {
            using (var reader = GetReader())
            {
                reader.WithAllChildrenForId(id);

                return reader.QueryResult().FirstOrDefault();
            }
        }

        public IList<EntityType> Select(QueryElement query, bool withChildren = false)
        {
            using (var reader = GetReader())
            {
                reader.Where(query);

                reader.WithAllJoins();

                var res = reader.QueryResult();

                if (withChildren)
                    reader.SetAllChildrenForExisting(res);

                return res;
            }
        }


        public IList<EntityType> Select(IList<QueryElement> query, bool withChildren = false)
        {
            using (var reader = GetReader())
            {
                foreach (var q in query)
                    reader.Where(q);

                reader.WithAllJoins();

                var res = reader.QueryResult();

                if (withChildren)
                    reader.SetAllChildrenForExisting(res);

                return res;
            }
        }

        public IList<EntityType> Select(QueryElement query, int skip, int take, bool withChildren = false)
        {
            using (var reader = GetReader())
            {
                reader.Where(query);

                reader.WithAllJoins();

                if (take > 0)
                    reader.WithTop(take);

                if (skip > 0)
                    reader.WithSkip(skip);

                var res = reader.QueryResult();

                if (withChildren)
                    reader.SetAllChildrenForExisting(res);

                return res;
            }
        }

        public IList<EntityType> Select(IList<QueryElement> query, int skip, int take, bool withChildren = false)
        {
            using (var reader = GetReader())
            {
                foreach (var q in query)
                    reader.Where(q);

                reader.WithAllJoins();

                if (take > 0)
                    reader.WithTop(take);

                if (skip > 0)
                    reader.WithSkip(skip);

                var res = reader.QueryResult();

                if (withChildren)
                    reader.SetAllChildrenForExisting(res);

                return res;
            }
        }
        public IList<EntityType> Select(IList<QueryElement> query, IList<OrderBy> ordering)
        {
            using (var reader = GetReader())
            {
                foreach (var q in query)
                    reader.Where(q);

                reader.WithAllJoins();

                foreach (var o in ordering)
                    reader.OrderBy(o);

                return reader.QueryResult();
            }
        }

        public IList<EntityType> Select(IList<QueryElement> query, IList<OrderBy> ordering, int skip, int take)
        {
            using (var reader = GetReader())
            {
                foreach (var q in query)
                    reader.Where(q);

                reader.WithAllJoins();

                foreach (var o in ordering)
                    reader.OrderBy(o);

                return reader.QueryResult();
            }
        }

        public IList<EntityType> Select(IList<QueryElement> query, IList<GroupBy> grouping)
        {
            using (var reader = GetReader())
            {
                foreach (var q in query)
                    reader.Where(q);

                reader.WithAllJoins();

                foreach (var g in grouping)
                    reader.GroupBy(g);

                return reader.QueryResult();
            }
        }

        public IList<EntityType> Select(IList<QueryElement> query, IList<Aggregate> aggregates)
        {
            using (var reader = GetReader())
            {
                foreach (var q in query)
                    reader.Where(q);

                reader.WithAllJoins();

                foreach (var a in aggregates)
                    reader.WithAggregate(a);

                return reader.QueryResult();
            }
        }

        public IList<EntityType> Select(IList<QueryElement> query, IList<Having> havings)
        {
            using (var reader = GetReader())
            {
                foreach (var q in query)
                    reader.Where(q);

                reader.WithAllJoins();

                foreach (var h in havings)
                    reader.Having(h);

                return reader.QueryResult();
            }
        }

        public IList<EntityType> Select
            (IList<QueryElement> query
            , IList<Aggregate> aggregates
            , IList<GroupBy> grouping
            , IList<Having> havings
            , IList<OrderBy> ordering
            , int skip
            , int take)
        {
            using (var reader = GetReader())
            {
                foreach (var q in query)
                    reader.Where(q);

                reader.WithAllJoins();

                foreach (var a in aggregates)
                    reader.WithAggregate(a);

                foreach (var g in grouping)
                    reader.GroupBy(g);

                foreach (var h in havings)
                    reader.Having(h);

                foreach (var o in ordering)
                    reader.OrderBy(o);

                if (take > 0)
                    reader.WithTop(take);

                if (skip > 0)
                    reader.WithSkip(skip);

                return reader.QueryResult();
            }
        }

        public IList<EntityType> Select(IEntityReader<IdType, EntityType> customQuery)
        {
            return customQuery.QueryResult();
        }

        public void AddOrUpdate(EntityType entity, params string[] cascades)
        {
            var writer = GetWriter();

            foreach (var c in cascades)
                writer.WithCascade(c);

            if (entity.IsNew())
            {
                writer.Insert(entity);

                if (_unitStore.ActiveUnitOfWork != null)
                    _unitStore.ActiveUnitOfWork.Add(entity, writer);
                else
                {
                    writer.Execute();
                    writer.Dispose();
                }
            }
            else
            {
                writer.Update(entity);

                if (_unitStore.ActiveUnitOfWork != null)
                    _unitStore.ActiveUnitOfWork.Update(entity.Id, entity, writer);
                else
                {
                    writer.Execute();
                    writer.Dispose();
                }
            }
        }

        public void AddOrUpdate(IList<EntityType> entities, params string[] cascades)
        {
            var writer = GetWriter();

            foreach (var c in cascades)
                writer.WithCascade(c);

            var inserts = entities.GetInserts<IdType, EntityType>(); // entities.Where(e => object.Equals(e.Id, default(IdType))).ToList();

            writer.Insert(inserts);

            if (_unitStore.ActiveUnitOfWork != null)
                _unitStore.ActiveUnitOfWork.Add<EntityType>(inserts, writer);
            else
            {
                writer.Execute();
                writer.Dispose();
            }

            writer = GetWriter();

            var updates = entities.GetInserts<IdType, EntityType>(); //.Where(e => !object.Equals(e.Id, default(IdType))).ToList();

            writer.Update(updates);

            if (_unitStore.ActiveUnitOfWork != null)
                _unitStore.ActiveUnitOfWork.Update<IdType, EntityType>(updates, writer);
            else
            {
                writer.Execute();
                writer.Dispose();
            }
        }

        public void Delete(IdType id)
        {
            var writer = GetWriter();

            writer.Delete(new List<IdType>() { id });

            if (_unitStore.ActiveUnitOfWork != null)
                _unitStore.ActiveUnitOfWork.Remove(id, _typeHash, writer);
            else
            {
                writer.Execute();
                writer.Dispose();
            }
        }

        public void Delete(EntityType entity, params string[] cascades)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var writer = GetWriter();

            foreach (var c in cascades)
                writer.WithCascade(c);

            writer.Delete(entity);

            if (_unitStore.ActiveUnitOfWork != null)
                _unitStore.ActiveUnitOfWork.Remove(entity.Id, _typeHash, writer);
            else
            {
                writer.Execute();
                writer.Dispose();
            }
        }

        //public void Delete(IList<EntityType> entities)
        //{
        //    Delete(entities, new List<string>());
        //}

        public void Delete(IList<EntityType> entities, params string[] cascades)
        {
            var writer = GetWriter();

            foreach (var c in cascades)
                writer.WithCascade(c);

            writer.Delete(entities);

            if (_unitStore.ActiveUnitOfWork != null)
                _unitStore.ActiveUnitOfWork.RemoveRange(entities.Select(s => s.Id).Cast<IdType>().ToList(), _typeHash, writer);
            else
            {
                writer.Execute();
                writer.Dispose();
            }
        }

        public void Delete(IList<QueryElement> queries)
        {
            var writer = GetWriter();

            var qq = queries.ToArray();

            for (var i = 0; i < qq.Length; i++)
                if (string.IsNullOrWhiteSpace(qq[i].TableAlias))
                    qq[i].TableAlias = writer.TableAlias;

            writer.Delete(qq.ToList());

            if (_unitStore.ActiveUnitOfWork != null)
                _unitStore.ActiveUnitOfWork.Run(writer);
            else
            {
                writer.Execute();
                writer.Dispose();
            }
        }

        public void Execute(string script, IDictionary<string, object> parms)
        {
            var writer = GetWriter();

            writer.Run(script, parms);

            if (_unitStore.ActiveUnitOfWork != null)
                _unitStore.ActiveUnitOfWork.Run(writer);
            else
            {
                writer.Execute();
                writer.Dispose();
            }
        }
        public void Dispose()
        {
            if (_unitStore != null && _unitStore.ActiveUnitOfWork != null)
                _unitStore.ActiveUnitOfWork.Dispose();

            _unitStore.ActiveUnitOfWork = null;
        }

        void IRepository.AddOrUpdate(object entity, params string[] cascades)
        {
            AddOrUpdate(entity as EntityType, cascades);
        }

        void IRepository.AddOrUpdate(IList<object> entities, params string[] cascades)
        {
            AddOrUpdate(entities.OfType<EntityType>().ToList(), cascades);
        }

        IList<object> IRepository.SelectAllObj(int take, params OrderBy[] ordering)
        {
            return SelectAll(take, ordering).OfType<object>().ToList();
        }

        object IRepository.SelectById(object id)
        {
            return SelectById((IdType)id);
        }

        object IRepository.SelectByIdWithChildren(object id)
        {
            return SelectByIdWithChildren((IdType)id);
        }

        void IRepository.SetAllChildrenForExisting(object entity)
        {
            SetAllChildrenForExisting(entity as EntityType);
        }

        void IRepository.SetAllChildrenForExisting(IList<object> entities)
        {
            SetAllChildrenForExisting(entities.OfType<EntityType>().ToList());
        }

        IList<object> IRepository.SelectObj(QueryElement query, bool withChildren)
        {
            return Select(query, withChildren).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(IList<QueryElement> query, bool withChildren)
        {
            return Select(query, withChildren).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(QueryElement query, int skip, int take, bool withChildren)
        {
            return Select(query, skip, take, withChildren).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(IList<QueryElement> query, int skip, int take, bool withChildren)
        {
            return Select(query, skip, take, withChildren).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(IList<QueryElement> query, IList<OrderBy> ordering)
        {
            return Select(query, ordering).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(IList<QueryElement> query, IList<OrderBy> ordering, int skip, int take)
        {
            return Select(query, ordering, skip, take).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(IList<QueryElement> query, IList<GroupBy> grouping)
        {
            return Select(query, grouping).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(IList<QueryElement> query, IList<Aggregate> aggregates)
        {
            return Select(query, aggregates).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(IList<QueryElement> query, IList<Having> havings)
        {
            return Select(query, havings).OfType<object>().ToList();
        }

        IList<object> IRepository.SelectObj(IList<QueryElement> query, IList<Aggregate> aggregates, IList<GroupBy> grouping, IList<Having> havings, IList<OrderBy> ordering, int skip, int take)
        {
            return Select(query, aggregates, grouping, havings, ordering, skip, take).OfType<object>().ToList();
        }

        void IRepository.Delete(object entity, params string[] cascades)
        {
            Delete(entity as EntityType, cascades);
        }

        void IRepository.Delete(IList<object> entities, params string[] cascades)
        {
            Delete(entities.OfType<EntityType>().ToList(), cascades);
        }
    }
}
