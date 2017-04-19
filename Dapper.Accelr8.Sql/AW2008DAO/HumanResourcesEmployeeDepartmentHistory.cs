
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
	public class HumanResourcesEmployeeDepartmentHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public HumanResourcesEmployeeDepartmentHistory()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(HumanResourcesEmployeeDepartmentHistory dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.DepartmentID,
							dao.ShiftID,
							dao.StartDate,
						
				}
			};
		}

			
			protected int _businessEntityID;
		public int BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected short _departmentID;
		public short DepartmentID 
		{ 
			get { return _departmentID; }
			set 
			{ 
				_departmentID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected byte _shiftID;
		public byte ShiftID 
		{ 
			get { return _shiftID; }
			set 
			{ 
				_shiftID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected DateTime _startDate;
		public DateTime StartDate 
		{ 
			get { return _startDate; }
			set 
			{ 
				_startDate = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
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

		