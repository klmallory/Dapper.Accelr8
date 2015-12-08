using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Domain
{
    public interface IHaveId<IdType> where IdType : IComparable<IdType>
    {
        IdType Id { get; set; }
    }

    public interface IEntity
    {
        bool IsDirty { get; set; }
        int GetTypeHashCode();
        bool IsNew();
    }
}
