
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
	public partial class PersonEmailAddress : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonEmailAddress()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected string _emailAddress;
		public string EmailAddress 
		{ 
			get { return _emailAddress; }
			set 
			{ 
				_emailAddress = value;  
				IsDirty = true;
			}
		} 
			
		protected Guid _rowguid;
		public Guid rowguid 
		{ 
			get { return _rowguid; }
			set 
			{ 
				_rowguid = value;  
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
		 
	//From Foreign Key FK_EmailAddress_Person_BusinessEntityID	
		protected PersonPerson _personPerson;
		public virtual PersonPerson PersonPerson 
		{ 
			get { return _personPerson; }
			set 
			{ 
				_personPerson = value;  
				IsDirty = true;
			}
		} 
				}
}

		