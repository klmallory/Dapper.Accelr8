using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Dynamic
{
    public class DynamicMap<EntityType>
    {
        public Func<EntityType, object> Getter;
        public Action<EntityType, object> Setter;
        public Func<EntityType, EntityType, int> Comparer;
        public Action<EntityType, object> Remove;
        public Action<EntityType, object> Add;
    }
}
