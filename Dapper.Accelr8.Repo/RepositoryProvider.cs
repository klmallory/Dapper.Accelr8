using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Accelr8.Repo
{
    public interface IRepositoryProvider
    {
        IRepository<IdType, EntityType> GetRepo<IdType, EntityType>()
            where IdType : struct, IComparable<IdType>, IEquatable<IdType>
            where EntityType : class, IEntity, IHaveId<IdType>;

        IRepository GetRepo();
    }

    public class RepositoryProvider : IRepositoryProvider
    {
        public RepositoryProvider(IServiceLocatorMarker serviceLocator)
        {
            _locator = serviceLocator;
        }

        IServiceLocatorMarker _locator;

        public IRepository<IdType, EntityType> GetRepo<IdType, EntityType>()
            where EntityType : class, IEntity, IHaveId<IdType>
            where IdType : struct, IComparable<IdType>, IEquatable<IdType>
        {
            return _locator.Resolve<IRepository<IdType, EntityType>>();
        }

        public IRepository  GetRepo()
        {
            return _locator.Resolve<IRepository>();
        }
    }
}
