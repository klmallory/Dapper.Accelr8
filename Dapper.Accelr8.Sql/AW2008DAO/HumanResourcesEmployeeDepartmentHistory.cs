
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
	public partial class HumanResourcesEmployeeDepartmentHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public HumanResourcesEmployeeDepartmentHistory()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected DateTime? _endDate;
		public DateTime? EndDate 
		{ 
			get { return _endDate; }
			set 
			{ 
				_endDate = value;  
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
		protected HumanResourcesDepartment _humanResourcesDepartment;
		public virtual HumanResourcesDepartment HumanResourcesDepartment 
		{ 
			get { return _humanResourcesDepartment; }
			set 
			{ 
				_humanResourcesDepartment = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID	
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
		 
	//From Foreign Key FK_EmployeeDepartmentHistory_Shift_ShiftID	
		protected HumanResourcesShift _humanResourcesShift;
		public virtual HumanResourcesShift HumanResourcesShift 
		{ 
			get { return _humanResourcesShift; }
			set 
			{ 
				_humanResourcesShift = value;  
				IsDirty = true;
			}
		} 
				}
}

		