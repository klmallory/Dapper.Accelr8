
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
	public class HumanResourcesvJobCandidateEducation : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public HumanResourcesvJobCandidateEducation()
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
			
		protected string _edu__Level;
		public string Edu__Level 
		{ 
			get { return _edu__Level; }
			set 
			{ 
				_edu__Level = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _edu__StartDate;
		public DateTime? Edu__StartDate 
		{ 
			get { return _edu__StartDate; }
			set 
			{ 
				_edu__StartDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _edu__EndDate;
		public DateTime? Edu__EndDate 
		{ 
			get { return _edu__EndDate; }
			set 
			{ 
				_edu__EndDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__Degree;
		public string Edu__Degree 
		{ 
			get { return _edu__Degree; }
			set 
			{ 
				_edu__Degree = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__Major;
		public string Edu__Major 
		{ 
			get { return _edu__Major; }
			set 
			{ 
				_edu__Major = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__Minor;
		public string Edu__Minor 
		{ 
			get { return _edu__Minor; }
			set 
			{ 
				_edu__Minor = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__GPA;
		public string Edu__GPA 
		{ 
			get { return _edu__GPA; }
			set 
			{ 
				_edu__GPA = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__GPAScale;
		public string Edu__GPAScale 
		{ 
			get { return _edu__GPAScale; }
			set 
			{ 
				_edu__GPAScale = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__School;
		public string Edu__School 
		{ 
			get { return _edu__School; }
			set 
			{ 
				_edu__School = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__Loc__CountryRegion;
		public string Edu__Loc__CountryRegion 
		{ 
			get { return _edu__Loc__CountryRegion; }
			set 
			{ 
				_edu__Loc__CountryRegion = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__Loc__State;
		public string Edu__Loc__State 
		{ 
			get { return _edu__Loc__State; }
			set 
			{ 
				_edu__Loc__State = value;  
				IsDirty = true;
			}
		} 
			
		protected string _edu__Loc__City;
		public string Edu__Loc__City 
		{ 
			get { return _edu__Loc__City; }
			set 
			{ 
				_edu__Loc__City = value;  
				IsDirty = true;
			}
		} 
				}
}

		