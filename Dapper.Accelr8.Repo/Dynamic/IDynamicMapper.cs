using Dapper.Accelr8.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Dynamic
{
    public interface IDynamicMapper
    {
        object Get(string key, IEntity entity);
        void Set(string key, object value, IEntity entity);
        int Compare(string key, object entity, object compareEntity);
        int Compare(string key, object entity, string compareValue);
    }

    public interface IDynamicMapper<EntityType> : IDynamicMapper where EntityType : class, IEntity
    {
        PropertyType Get<PropertyType>(string key, EntityType entity);
        //void Set<PropertyType>(string key, PropertyType value, EntityType entity);
    }
}

