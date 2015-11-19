using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo
{
    public interface IHaveId<IdType> where IdType : IComparable<IdType>
    {
        IdType Id { get; set; }
    }

    public interface IEntity
    {
        bool Merged { get; set; }
        bool IsDirty { get; set; }
        bool IdMatches(object id);
        object GeneralId { get; }
        int GetTypeHashCode();
        bool IsNew();
        void MergeChangesFrom<EntityType>(EntityType model) where EntityType : IEntity;
        bool MergeCollection { get; }
        void SetSelfReferences();
    }
}
