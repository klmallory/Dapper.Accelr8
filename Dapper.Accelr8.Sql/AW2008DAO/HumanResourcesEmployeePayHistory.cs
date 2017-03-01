
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
    public partial class HumanResourcesEmployeePayHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
    {
        public HumanResourcesEmployeePayHistory()
        {
            IsDirty = false;
            _modifiedDate = (DateTime)SqlDateTime.MinValue;
        }



        protected decimal _rate;
        public decimal Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                IsDirty = true;
            }
        }

        protected byte _payFrequency;
        public byte PayFrequency
        {
            get { return _payFrequency; }
            set
            {
                _payFrequency = value;
                IsDirty = true;
            }
        }

        protected DateTime _modifiedDate;
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set
            {
                _modifiedDate = value;
                IsDirty = true;
            }
        }

        //From Foreign Key FK_EmployeePayHistory_Employee_BusinessEntityID	
        protected HumanResourcesEmployee _humanResourcesEmployee;
        public virtual HumanResourcesEmployee HumanResourcesEmployee
        {
            get { return _humanResourcesEmployee; }
            set
            {
                _humanResourcesEmployee = value;
                IsDirty = true;
            }
        }
    }
}

		