
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
	public partial class HumanResourcesvJobCandidateEmployment : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public HumanResourcesvJobCandidateEmployment()
		{			
			IsDirty = false; 
			}


		
		protected int _jobCandidateID;
		public int JobCandidateID 
		{ 
			get { return _jobCandidateID; }
			set 
			{ 
				_jobCandidateID = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _emp__StartDate;
		public DateTime? Emp__StartDate 
		{ 
			get { return _emp__StartDate; }
			set 
			{ 
				_emp__StartDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _emp__EndDate;
		public DateTime? Emp__EndDate 
		{ 
			get { return _emp__EndDate; }
			set 
			{ 
				_emp__EndDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emp__OrgName;
		public string Emp__OrgName 
		{ 
			get { return _emp__OrgName; }
			set 
			{ 
				_emp__OrgName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emp__JobTitle;
		public string Emp__JobTitle 
		{ 
			get { return _emp__JobTitle; }
			set 
			{ 
				_emp__JobTitle = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emp__Responsibility;
		public string Emp__Responsibility 
		{ 
			get { return _emp__Responsibility; }
			set 
			{ 
				_emp__Responsibility = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emp__FunctionCategory;
		public string Emp__FunctionCategory 
		{ 
			get { return _emp__FunctionCategory; }
			set 
			{ 
				_emp__FunctionCategory = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emp__IndustryCategory;
		public string Emp__IndustryCategory 
		{ 
			get { return _emp__IndustryCategory; }
			set 
			{ 
				_emp__IndustryCategory = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emp__Loc__CountryRegion;
		public string Emp__Loc__CountryRegion 
		{ 
			get { return _emp__Loc__CountryRegion; }
			set 
			{ 
				_emp__Loc__CountryRegion = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emp__Loc__State;
		public string Emp__Loc__State 
		{ 
			get { return _emp__Loc__State; }
			set 
			{ 
				_emp__Loc__State = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emp__Loc__City;
		public string Emp__Loc__City 
		{ 
			get { return _emp__Loc__City; }
			set 
			{ 
				_emp__Loc__City = value;  
				IsDirty = true;
			}
		} 
				}
}

		