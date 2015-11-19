using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Accelr8.Repo
{
    public interface IUnitOfWorkStore
    {
        IUnitOfWork ActiveUnitOfWork { get; set; }
    }

    public class UnitOfWorkStore : IUnitOfWorkStore
    {
        object _syncRoot = new object();

        IUnitOfWork _unitOfWork;
        Dictionary<Guid, IUnitOfWork> _units = new Dictionary<Guid, IUnitOfWork>();

        public UnitOfWorkStore()
        {
            if (_syncRoot == null)
                _syncRoot = new object();

            if (_units == null)
                _units = new Dictionary<Guid, IUnitOfWork>();
        }

        public virtual IUnitOfWork ActiveUnitOfWork
        {
            get
            {
                lock (_syncRoot)
                    if (_units.Count > 0)
                        return _units.Last().Value;

                return null;
            }
            set
            {
                lock (_syncRoot)
                {
                    if (value == null)
                    {
                        _unitOfWork = value;
                        return;
                    }

                    value.UnitOfWorkCommiting += OnUnitOfWorkCommiting;

                    _units.Add(value.DataContextHandle, value);
                }
            }
        }

        void OnUnitOfWorkCommiting(IUnitOfWork uow)
        {
            lock (_syncRoot)
            {
                if (uow != null && _units.ContainsKey(uow.DataContextHandle))
                    _units.Remove(uow.DataContextHandle);
            }
        }
    }
}
