﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        Guid DataContextHandle { get; }

        void Add<EntityType>(IList<EntityType> entities, IEntityWriter writer) where EntityType : class, IEntity;
        void Add<EntityType>(EntityType entity, IEntityWriter writer) where EntityType : class, IEntity;

        void Update<IdType, EntityType>(IList<EntityType> entities, IEntityWriter writer)
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : IComparable;
        void Update<IdType, EntityType>(IdType id, EntityType entity, IEntityWriter writer)
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : IComparable;

        void RemoveRange<IdType>(IList<IdType> ids, int typeHash, IEntityWriter writer) where IdType : IComparable;
        void Remove<IdType>(IdType id, int typeHash, IEntityWriter writer) where IdType : IComparable;

        void Run(IEntityWriter writer);

        void Commit();

        event UnitOfWorkCommiting UnitOfWorkCommiting;
    }
}
