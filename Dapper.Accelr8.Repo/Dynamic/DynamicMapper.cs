using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Dynamic
{

    public abstract class DynamicMapper<EntityType>
            : IDynamicMapper<EntityType>
            where EntityType : class, IEntity
    {

        protected static object _syncRoot = new object();
        protected static Dictionary<string, DynamicMap<EntityType>> _mappings
            = new Dictionary<string, DynamicMap<EntityType>>();

        protected DynamicMapper(ILoc8 locator)
        {
            _locator = locator;
        }

        ILoc8 _locator;

        protected string[] GetKeys(string key)
        {
            if (key == null)
                throw new ArgumentNullException();

            var keys = key.Split('.');

            return keys;
        }

        protected virtual void FilterKeyQueries(ref string key, out int index, out string queryName, out string queryVal)
        {
            index = -1; queryName = null; queryVal = null;

            if (key.Contains('|'))
            {
                int.TryParse(key.Split('|').Last(), out index);

                key = key.Split('|').First();
            }
            else if (key.Contains('='))
            {
                var q = key.Split('?').Last();

                queryName = q.Split('=').First();
                queryVal = q.Split('=').Last();

                key = key.Split('?').First();
            }
        }

        protected virtual object GetPropertyFromCollection(int index, string queryName, string queryVal, IEnumerable property)
        {
            if (queryName != null && queryVal != null)
            {
                var queryCollection = (property as IEnumerable).OfType<IEntity>().ToList();

                foreach (var val in queryCollection)
                {
                    var mapper = _locator.GetMapper(val.GetType().Name);

                    //(typeof(IDynamicMapper<>).MakeGenericType(val.GetType())) as IDynamicMapper;

                    if (mapper == null)
                        throw new InvalidOperationException(string.Format("Mapper not found for type {0}", val.GetType()));

                    if (mapper.Compare(queryName, val, queryVal) == 0)
                        return val;
                }

                return null;
            }
            else if (index >= 0)
            {
                var simpleCollection = (property as IEnumerable).OfType<object>().ToList();

                if (simpleCollection.Count() <= index)
                    return null;

                return simpleCollection[index];
            }
            else
            {
                return (property as IEnumerable).OfType<object>().ToList().FirstOrDefault();
            }
        }

        protected virtual object GetChildProperty(string key, IEntity entity)
        {
            if (entity == null)
                return null;

            var mapper = _locator.GetMapper(entity.GetType().Name);

            if (mapper == null)
                throw new InvalidOperationException(string.Format("Mapper not found for type {0}", entity.GetType()));

            return mapper.Get(key, entity);
        }

        protected virtual void SetChildProperty(string key, IEntity entity, object value)
        {
            var mapper = _locator.GetMapper(entity.GetType().Name);

            if (mapper == null)
                throw new InvalidOperationException(string.Format("Mapper not found for type {0}", entity.GetType()));

            mapper.Set(key, value, entity);
        }

        public virtual object Get(string key, IEntity entity)
        {
            if (entity == null)
                return null;

            Trace.TraceInformation("Getting value for {0} from {1} with id {2} ", key, entity, entity.GenericId);

            int index; string queryName; string queryVal;

            var keys = GetKeys(key);
            FilterKeyQueries(ref keys[0], out index, out queryName, out queryVal);

            if (!_mappings.ContainsKey(keys[0]) || _mappings[keys[0]].Getter == null)
                throw new InvalidOperationException(string.Format
                    ("Mapper {0} did not contain Key {1} or getter was not set", this.GetType().Name, key));

            var val = _mappings[keys[0]].Getter.Invoke(entity as EntityType);

            if (val == null)
                return null;

            if ((val is IEnumerable || val.GetType().IsArray) && keys.Length > 1)
            {
                val = GetPropertyFromCollection(index, queryName, queryVal, val as IEnumerable);
                //keys = keys.Skip(1).ToArray();
            }

            if (keys.Length > 1)
            {
                if (val == null)
                    return null;

                if (!(val is IEntity))
                    throw new InvalidOperationException
                        (string.Format("mapped property tree parent was not of type IEntity: {0}", keys[0]));

                return GetChildProperty(string.Join(".", GetKeys(key).Skip(1)), val as IEntity);
            }
            else
                return val;
        }

        public virtual void Set(string key, object value, IEntity entity)
        {
            Trace.TraceInformation("Setting value for {0} on {1} with id {2} ", key, entity, entity.GenericId);

            if (entity == null)
                return;

            int index; string queryName; string queryVal;

            var keys = GetKeys(key);
            FilterKeyQueries(ref keys[0], out index, out queryName, out queryVal);

            if (!_mappings.ContainsKey(keys[0]) || _mappings[keys[0]].Getter == null)
                throw new InvalidOperationException(string.Format
                    ("Mapper {0} did not contain Key {1} or getter was not set", this.GetType().Name, key));

            var val = _mappings[keys[0]].Getter.Invoke(entity as EntityType);

            if (val != null && !(val is string) && (val is IEnumerable || val.GetType().IsArray)
                && (index > -1 || (!string.IsNullOrWhiteSpace(queryName) && !string.IsNullOrWhiteSpace(queryVal))))
            {
                var obj = GetPropertyFromCollection(index, queryName, queryVal, val as IEnumerable);

                if (obj == null && value != null && _mappings[keys[0]].Add != null)
                {
                    _mappings[keys[0]].Add.Invoke(entity as EntityType, value);

                    obj = GetPropertyFromCollection(index, queryName, queryVal, val as IEnumerable);

                    if (obj == null && queryName != null && queryVal != null)
                    {
                        obj = _mappings[keys[0]].Getter.Invoke(entity as EntityType).SafeToList<object>().Last();

                        var cMapper = _locator.GetMapper(obj.GetType().Name) as IDynamicMapper;

                        cMapper.Set(queryName, queryVal, obj as IEntity);
                    }
                    else if (obj == null && index > -1)
                    {
                        while (obj == null)
                        {
                            _mappings[keys[0]].Add.Invoke(entity as EntityType, value);

                            obj = GetPropertyFromCollection(index, queryName, queryVal, val as IEnumerable);
                        }
                    }

                    if (keys.Length == 1)
                        return;
                }
                else if (keys.Length == 1 && obj != null && value == null && _mappings[keys[0]].Remove != null)
                {
                    _mappings[keys[0]].Remove.Invoke(entity as EntityType, obj);
                    return;
                }
                else if (keys.Length == 1)
                    throw new KeyNotFoundException(
                        string.Format("Collection item with index {0} or query {1}={2} was not found."
                        , index, queryName, queryVal));

                val = obj;
                //keys = keys.Skip(1).ToArray();
            }

            if (keys.Length > 1)
            {
                if (val == null)
                    return;

                if (!(val is IEntity))
                    throw new InvalidOperationException
                        (string.Format("mapped property tree parent was not of type IEntity: {0}", keys[0]));

                SetChildProperty(string.Join(".", GetKeys(key).Skip(1)), val as IEntity, value);
            }
            else
            {
                if (!_mappings.ContainsKey(keys[0]) || _mappings[keys[0]].Setter == null)
                    throw new InvalidOperationException(string.Format
                        ("Mapper {0} did not contain Key {1} or setter was null", this.GetType().Name, key));

                _mappings[keys[0]].Setter.Invoke(entity as EntityType, value);
            }
        }

        public virtual int Compare(string key, object entity, object compareEntity)
        {
            if (!(entity is EntityType))
                throw new ArgumentException("entity {0} is wrong type", entity.GetType().Name);

            if (entity == null && compareEntity == null)
                return 0;

            if (entity != null && compareEntity == null)
                return 1;

            if (entity == null && compareEntity != null)
                return -1;

            if (_mappings.ContainsKey(key) && _mappings[key].Comparer != null)
                return _mappings[key].Comparer.Invoke(entity as EntityType, compareEntity as EntityType);

            return 0;
        }

        public virtual int Compare(string key, object entity, string compareValue)
        {
            if (entity == null || !(entity is EntityType))
                return -1;

            if (!_mappings.ContainsKey(key) || _mappings[key].Getter == null)
                return -1;

            var val = _mappings[key].Getter.Invoke(entity as EntityType);

            if (val == null && compareValue == null)
                return 0;

            if (val != null && compareValue == null)
                return 1;

            if (val == null)
                return -1;

            return string.Compare((string)Convert.ChangeType(val, typeof(string)), compareValue);
        }

        public virtual PropertyType Get<PropertyType>(string key, EntityType entity)
        {
            if (entity == null)
                return default(PropertyType);

            Trace.TraceInformation("Getting value for {0} from {1} with id {2} ", key, entity, entity.GenericId);

            int index; string queryName; string queryVal;

            var keys = GetKeys(key);
            FilterKeyQueries(ref keys[0], out index, out queryName, out queryVal);

            if (!_mappings.ContainsKey(keys[0]) || _mappings[keys[0]].Getter == null)
                throw new InvalidOperationException(string.Format
                    ("Mapper {0} did not contain Key {1} or getter was not set", this.GetType().Name, key));

            var val = _mappings[keys[0]].Getter.Invoke(entity as EntityType);

            if (val == null)
                return default(PropertyType);

            if ((val is IEnumerable || val.GetType().IsArray) && keys.Length > 1)
            {
                val = GetPropertyFromCollection(index, queryName, queryVal, val as IEnumerable);
                //keys = keys.Skip(1).ToArray();
            }

            if (keys.Length > 1)
            {
                if (!(val is IEntity))
                    throw new InvalidOperationException
                        (string.Format("mapped property tree parent was not of type IEntity: {0}", keys[0]));

                return (PropertyType)Convert.ChangeType(GetChildProperty(string.Join(".", GetKeys(key).Skip(1)), val as IEntity), typeof(PropertyType));
            }
            else
                return (PropertyType)Convert.ChangeType(val, typeof(PropertyType));
        }
    }
}
