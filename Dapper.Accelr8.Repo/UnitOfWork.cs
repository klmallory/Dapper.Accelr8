using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo.Contracts.Writers;
using Dapper.Accelr8.Repo.Parameters;

namespace Dapper.Accelr8.Repo
{
    public delegate void UnitOfWorkCommiting(IUnitOfWork uow);

    public class UnitOfWork : IUnitOfWork
    {
        protected Object _syncRoot = new object();

        //protected List<IEntityWriter> _scripts = new List<IEntityWriter>();
        //protected Dictionary<IEntity, IEntityWriter> _adds = new Dictionary<IEntity, IEntityWriter>();
        //protected Dictionary<IdKey, IEntityWriter> _updates = new Dictionary<IdKey, IEntityWriter>();
        //protected Dictionary<IdKey, IEntityWriter> _deletes = new Dictionary<IdKey, IEntityWriter>();

        protected IList<IdKey> _scripts { get { lock (_syncRoot) return _tasks.Where(t => t.Value.Action == ActionType.None).Select(k => k.Key).ToList(); } }
        protected IList<IdKey> _deletes { get { lock (_syncRoot) return _tasks.Where(t => t.Value.Action == ActionType.Remove).Select(k => k.Key).ToList(); } }
        protected IList<IdKey> _adds { get { lock (_syncRoot) return _tasks.Where(t => t.Value.Action == ActionType.Add).Select(k => k.Key).ToList(); } }
        protected IList<IdKey> _updates { get { lock (_syncRoot) return _tasks.Where(t => t.Value.Action == ActionType.Update).Select(k => k.Key).ToList(); } }

        protected Dictionary<IdKey, WorkAction> _tasks = new Dictionary<IdKey, WorkAction>();

        protected TransactionScope _scope;

        public UnitOfWork() : this(Guid.NewGuid()) { }

        public UnitOfWork(Guid context)
        {
            DataContextHandle = context;

            _scope = new System.Transactions.TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted });
        }

        protected void PushUpdate<IdType, EntityType>(IdType id, EntityType entity, IEntityWriter writer)
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : IComparable
        {
            lock (_syncRoot)
            {
                var key = new IdKey(id, entity.GetTypeHashCode());

                if (_deletes.Contains(key))
                    throw new InvalidOperationException(string.Format("Entity already marked for deletion, id : {0}", id));

                if (_updates.Contains(key))
                    _tasks.Remove(key);

                _tasks.Add(key, new WorkAction(ActionType.Update, entity, writer));
                _deletes.ToDictionary(i => i);
            }
        }

        protected void PushUpdates<IdType, EntityType>(IList<EntityType> entities, IEntityWriter writer)
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : IComparable
        {
            var hash = entities.First().GetTypeHashCode();

            foreach (var entity in entities)
            {
                var key = new IdKey(entity.Id, hash);

                lock (_syncRoot)
                {
                    if (_deletes.Contains(key))
                        throw new InvalidOperationException(string.Format("Entity already marked for deletion, id : {0}", entity.Id));

                    if (_updates.Contains(key))
                        _tasks.Remove(key);

                    _tasks.Add(key, new WorkAction(ActionType.Update, entity, writer));
                }
            }
        }

        protected void PushDelete<IdType>(IdType id, int typeHash, IEntityWriter writer)
            where IdType : IComparable
        {
            var key = new IdKey(id, typeHash);

            lock (_syncRoot)
            {
                if (_updates.Contains(key))
                    _tasks.Remove(key);

                if (_deletes.Contains(key))
                    _tasks.Remove(key);

                _tasks.Add(key, new WorkAction(ActionType.Remove, null, writer));
            }
        }

        protected void PushDelete<IdType>(IList<IdType> ids, int typeHash, IEntityWriter writer)
            where IdType : IComparable
        {
            foreach (var id in ids)
            {
                var key = new IdKey(id, typeHash);

                lock (_syncRoot)
                {
                    if (_updates.Contains(key))
                        _tasks.Remove(key);

                    if (_deletes.Contains(key))
                        _tasks.Remove(key);

                    _tasks.Add(key, new WorkAction(ActionType.Remove, null, writer));
                }
            }
        }

        public Guid DataContextHandle { get; protected set; }

        public void Add<EntityType>(EntityType entity, IEntityWriter writer)
             where EntityType : class, IEntity
        {
            var key = new IdKey(entity.GetHashCode(), entity.GetTypeHashCode());
            lock (_syncRoot)
                if (!_adds.Contains(key))
                    _tasks.Add(key, new WorkAction(ActionType.Add, entity, writer));
        }

        public void Add<EntityType>(IList<EntityType> entities, IEntityWriter writer)
             where EntityType : class, IEntity
        {
            lock (_syncRoot)
                foreach (var e in entities)
                {
                    var key = new IdKey(e.GetHashCode(), e.GetTypeHashCode());

                    if (!_adds.Contains(key))
                        _tasks.Add(key, new WorkAction(ActionType.Add, e, writer));
                }
        }

        public void Update<IdType, EntityType>(IdType id, EntityType entity, IEntityWriter writer)
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : IComparable
        {
            if (entity == null)
                return;

            if (object.Equals(id, default(IdType)))
                throw new ArgumentException("id can't be empty for an update.");

            PushUpdate(id, entity, writer);
        }

        public void Update<IdType, EntityType>(IList<EntityType> entities, IEntityWriter writer)
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : IComparable
        {
            if (entities == null || entities.Count < 1)
                return;

            var hash = entities.First().GetTypeHashCode();

            PushUpdates<IdType, EntityType>(entities, writer);
        }

        public void Remove<IdType>(IdType id, int typeHash, IEntityWriter writer)
            where IdType : IComparable
        {
            PushDelete(id, typeHash, writer);
        }

        public void RemoveRange<IdType>(IList<IdType> ids, int typeHash, IEntityWriter writer)
            where IdType : IComparable
        {
            PushDelete(ids, typeHash, writer);
        }

        public void Run(IEntityWriter writer)
        {
            lock (_syncRoot)
                _tasks.Add(new IdKey(Guid.NewGuid(), writer.GetHashCode()), new WorkAction(ActionType.None, null, writer));
        }

        public virtual void Commit()
        {
            foreach (var t in _tasks.Select(b => b.Value.Writer)) //.Distinct())// _updates.Select(c => c.Value).Distinct())
                t.Execute();

            InvokeUnitOfWorkCommiting();

            _scope.Complete();
        }

        protected void InvokeUnitOfWorkCommiting()
        {
            lock (_syncRoot)
            {
                if (UnitOfWorkCommiting != null)
                    UnitOfWorkCommiting(this);
            }
        }

        public event UnitOfWorkCommiting UnitOfWorkCommiting;

        public void Dispose()
        {
            if (_scope != null)
                _scope.Dispose();

            foreach (var t in _tasks)
                if (_tasks != null && t.Value != null && t.Value.Writer != null)
                    t.Value.Writer.Dispose();
        }
    }
}
