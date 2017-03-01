
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
	public partial class HumanResourcesvJobCandidate : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public HumanResourcesvJobCandidate()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
			
		protected int? _businessEntityID;
		public int? BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;  
				IsDirty = true;
			}
		} 
			
		protected string _name__Prefix;
		public string Name__Prefix 
		{ 
			get { return _name__Prefix; }
			set 
			{ 
				_name__Prefix = value;  
				IsDirty = true;
			}
		} 
			
		protected string _name__First;
		public string Name__First 
		{ 
			get { return _name__First; }
			set 
			{ 
				_name__First = value;  
				IsDirty = true;
			}
		} 
			
		protected string _name__Middle;
		public string Name__Middle 
		{ 
			get { return _name__Middle; }
			set 
			{ 
				_name__Middle = value;  
				IsDirty = true;
			}
		} 
			
		protected string _name__Last;
		public string Name__Last 
		{ 
			get { return _name__Last; }
			set 
			{ 
				_name__Last = value;  
				IsDirty = true;
			}
		} 
			
		protected string _name__Suffix;
		public string Name__Suffix 
		{ 
			get { return _name__Suffix; }
			set 
			{ 
				_name__Suffix = value;  
				IsDirty = true;
			}
		} 
			
		protected string _skills;
		public string Skills 
		{ 
			get { return _skills; }
			set 
			{ 
				_skills = value;  
				IsDirty = true;
			}
		} 
			
		protected string _addr__Type;
		public string Addr__Type 
		{ 
			get { return _addr__Type; }
			set 
			{ 
				_addr__Type = value;  
				IsDirty = true;
			}
		} 
			
		protected string _addr__Loc__CountryRegion;
		public string Addr__Loc__CountryRegion 
		{ 
			get { return _addr__Loc__CountryRegion; }
			set 
			{ 
				_addr__Loc__CountryRegion = value;  
				IsDirty = true;
			}
		} 
			
		protected string _addr__Loc__State;
		public string Addr__Loc__State 
		{ 
			get { return _addr__Loc__State; }
			set 
			{ 
				_addr__Loc__State = value;  
				IsDirty = true;
			}
		} 
			
		protected string _addr__Loc__City;
		public string Addr__Loc__City 
		{ 
			get { return _addr__Loc__City; }
			set 
			{ 
				_addr__Loc__City = value;  
				IsDirty = true;
			}
		} 
			
		protected string _addr__PostalCode;
		public string Addr__PostalCode 
		{ 
			get { return _addr__PostalCode; }
			set 
			{ 
				_addr__PostalCode = value;  
				IsDirty = true;
			}
		} 
			
		protected string _eMail;
		public string EMail 
		{ 
			get { return _eMail; }
			set 
			{ 
				_eMail = value;  
				IsDirty = true;
			}
		} 
			
		protected string _webSite;
		public string WebSite 
		{ 
			get { return _webSite; }
			set 
			{ 
				_webSite = value;  
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
				}
}

		