
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
	public partial class HumanResourcesDepartment : Dapper.Accelr8.Repo.Domain.BaseEntity<short>
	{
			public HumanResourcesDepartment()
		{			
			IsDirty = false; 
			_humanResourcesEmployeeDepartmentHistories = new List<HumanResourcesEmployeeDepartmentHistory>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected object _name;
		public object Name 
		{ 
			get { return _name; }
			set 
			{ 
				_name = value;  
				IsDirty = true;
			}
		} 
			
		protected object _groupName;
		public object GroupName 
		{ 
			get { return _groupName; }
			set 
			{ 
				_groupName = value;  
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
		 
	//From Foreign Key FK_EmployeeDepartmentHistory_Department_DepartmentID	
		protected IList<HumanResourcesEmployeeDepartmentHistory> _humanResourcesEmployeeDepartmentHistories;
		public virtual IList<HumanResourcesEmployeeDepartmentHistory> HumanResourcesEmployeeDepartmentHistories 
		{ 
			get { return _humanResourcesEmployeeDepartmentHistories; }
			set 
			{ 
				_humanResourcesEmployeeDepartmentHistories = value;  
				IsDirty = true;
			}
		} 
					}
}

		