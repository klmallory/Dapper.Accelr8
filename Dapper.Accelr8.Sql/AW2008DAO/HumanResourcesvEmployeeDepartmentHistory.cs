
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
	public partial class HumanResourcesvEmployeeDepartmentHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public HumanResourcesvEmployeeDepartmentHistory()
		{			
			IsDirty = false; 
			_startDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected int _businessEntityID;
		public int BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;  
				IsDirty = true;
			}
		} 
			
		protected string _title;
		public string Title 
		{ 
			get { return _title; }
			set 
			{ 
				_title = value;  
				IsDirty = true;
			}
		} 
			
		protected object _firstName;
		public object FirstName 
		{ 
			get { return _firstName; }
			set 
			{ 
				_firstName = value;  
				IsDirty = true;
			}
		} 
			
		protected object _middleName;
		public object MiddleName 
		{ 
			get { return _middleName; }
			set 
			{ 
				_middleName = value;  
				IsDirty = true;
			}
		} 
			
		protected object _lastName;
		public object LastName 
		{ 
			get { return _lastName; }
			set 
			{ 
				_lastName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _suffix;
		public string Suffix 
		{ 
			get { return _suffix; }
			set 
			{ 
				_suffix = value;  
				IsDirty = true;
			}
		} 
			
		protected object _shift;
		public object Shift 
		{ 
			get { return _shift; }
			set 
			{ 
				_shift = value;  
				IsDirty = true;
			}
		} 
			
		protected object _department;
		public object Department 
		{ 
			get { return _department; }
			set 
			{ 
				_department = value;  
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
			
		protected DateTime _startDate;
		public DateTime StartDate 
		{ 
			get { return _startDate; }
			set 
			{ 
				_startDate = value;  
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
				}
}

		