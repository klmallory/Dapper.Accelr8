﻿using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo.Contracts.Readers;
using Dapper.Accelr8.Repo.Contracts.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Accelr8.Repo.Contracts
{
    public interface ILoc8
    {
        string ConnectionStringName { get; set; }
        IDictionary<string, string> ConnectionStringContainer { get; set; }

        IDictionary<Type, Type> ClassesToRegister { get; }

        IUnitOfWork GetUnitOfWork(string type = null);

        IEntityReader<IdType, EntityType> GetReader<IdType, EntityType>()
                    where EntityType : class, IHaveId<IdType>
                    where IdType : IComparable;

        IEntityWriter<IdType, EntityType> GetWriter<IdType, EntityType>()
                    where EntityType : class, IHaveId<IdType>
                    where IdType : IComparable;

        IEntityReader<IdType, EntityType> GetReader<IdType, EntityType>(string className)
                    where EntityType : class, IHaveId<IdType>
                    where IdType : IComparable;

        IEntityWriter<IdType, EntityType> GetWriter<IdType, EntityType>(string className)
                    where EntityType : class, IHaveId<IdType>
                    where IdType : IComparable;
    }
}