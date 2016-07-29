using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Accelr8.Domain;


namespace Dapper.Accelr8.Repo.Extensions
{
    public static class EntityExtensions
    {
        public static IList<EntityType> GetInserts<IdType, EntityType>(this IList<EntityType> entities)
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : IComparable
        {
            return entities.Where(e => e != null && e.IsNew()).ToList();
        }

        public static IList<EntityType> GetUpdates<IdType, EntityType>(this IList<EntityType> entities)
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : IComparable
        {
            return entities.Where(e => e != null && !e.IsNew()).ToList();
        }
    }
}
