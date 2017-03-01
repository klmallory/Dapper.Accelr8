
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
	public partial class HumanResourcesJobCandidate : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public HumanResourcesJobCandidate()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
			
		protected string _resume;
		public string Resume 
		{ 
			get { return _resume; }
			set 
			{ 
				_resume = value;  
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
		 
	//From Foreign Key FK_JobCandidate_Employee_BusinessEntityID	
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

		