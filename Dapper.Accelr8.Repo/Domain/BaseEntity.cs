using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Domain
{
    public abstract class BaseEntity<IdType> : IEntity, IHaveId<IdType>
        where IdType : IComparable<IdType>
    {
        public BaseEntity()
        {
            IsDirty = true;
        }

        public bool IsDirty { get; set; }

        public IdType Id { get; set; }

        public object GeneralId { get { return Id; } protected set { Id = (IdType)value; } }

        public bool IdMatches(object id)
        {
            if (!(id is IdType))
                return false;

            return Id.CompareTo((IdType)id) == 0;
        }

        internal static int? TypeHashCode;
        public int GetTypeHashCode()
        {
            if (!TypeHashCode.HasValue)
                TypeHashCode = this.GetType().GetHashCode();

            return TypeHashCode.Value;
        }

        public bool IsNew()
        {
            return Id.CompareTo(default(IdType)) == 0;
        }

        public virtual void MergeChangesFrom<EntityType>(EntityType model)
            where EntityType : IEntity
        {
            if (Merged)
                return;

            foreach (var pi in typeof(EntityType).GetProperties())
            {
                var getter = pi.GetGetMethod();
                var setter = pi.GetSetMethod();

                if (getter == null || setter == null)
                    continue;

                var priValue = getter.Invoke(this, null);
                var secValue = getter.Invoke(model, null);

                if (secValue == null)
                    continue;

                if (typeof(IEnumerable).IsAssignableFrom(pi.PropertyType)
                    && pi.PropertyType != typeof(String)
                    && pi.PropertyType.GetGenericArguments().Count() > 0
                    && pi.PropertyType.GetGenericArguments()[0].GetInterfaces().Contains(typeof(IEntity)))
                {
                    var coll = secValue as IList;

                    if (coll == null)
                        continue;

                    var oldColl = priValue as IList;

                    if (oldColl == null)
                    {
                        oldColl = Activator.CreateInstance
                        (typeof(List<>).MakeGenericType
                        (pi.PropertyType.GetGenericArguments()[0]), priValue) as IList;

                        setter.Invoke(this, new object[] { oldColl });
                    }

                    var toRemove = new List<object>();

                    var add = true;
                    foreach (dynamic e in coll)
                    {
                        add = true;
                        var entity = e as IEntity;
                        if (entity == null)
                            continue;

                        foreach (dynamic o in oldColl)
                        {
                            var ol = (o as IEntity);

                            if (ol == null)
                                continue;

                            if (!((IdType)entity.GeneralId).Equals(default(IdType)) && ((IdType)entity.GeneralId).Equals((IdType)ol.GeneralId))
                            {
                                if (ol.MergeCollection)
                                    o.MergeChangesFrom(e);

                                add = false;
                                break;
                            }

                        }
                        if (add)
                        {
                            oldColl.Add(entity);
                        }
                    }

                    var remove = true;
                    foreach (dynamic o in oldColl)
                    {
                        remove = true;
                        var ol = (o as IEntity);

                        if (ol == null)
                            continue;

                        foreach (dynamic e in coll)
                        {
                            var entity = e as IEntity;

                            if (entity == null || ((IdType)ol.GeneralId).Equals(((IdType)entity.GeneralId)) || ((IdType)entity.GeneralId).Equals(default(IdType)))
                            {
                                remove = false;
                                break;
                            }
                        }

                        if (remove)
                            toRemove.Add(ol);
                    }

                    foreach (var o in toRemove)
                        oldColl.Remove(o);
                }
                else if (pi.PropertyType.GetInterfaces().Contains(typeof(IEntity)))
                {
                    var old = (priValue as IEntity);

                    if (old != null)
                        old.MergeChangesFrom((secValue as IEntity));
                }
                else if (secValue != null
                    && (!pi.PropertyType.IsValueType
                    || !secValue.Equals(Activator.CreateInstance(pi.PropertyType))))
                {
                    setter.Invoke(this, new object[] { secValue });
                }
            }

            Merged = true;
        }

        public virtual bool MergeCollection { get { return true; } }

        public virtual bool Merged { get; set; }

        public virtual T As<T>() where T : BaseEntity<IdType>
        {
            return this as T;
        }

        public virtual E AsProperty<E>(E entity) where E : BaseEntity<int>
        {
            if (entity == null)
                return null;

            return entity.As<E>();
        }

        public virtual IList<E> AsList<E>(IList<E> list) where E : BaseEntity<int>
        {
            if (list == null)
                return null;

            return list.OfType<E>().Select(s => AsProperty<E>(s)).ToList();
        }

        public virtual void SetSelfReferences()
        {

        }
    }
}
