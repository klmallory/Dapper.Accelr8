
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
	public partial class PersonPersonPhone : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonPersonPhone()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
		 
	//From Foreign Key FK_PersonPhone_Person_BusinessEntityID	
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
		 
	//From Foreign Key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID	
		protected PersonPhoneNumberType _personPhoneNumberType;
		public virtual PersonPhoneNumberType PersonPhoneNumberType 
		{ 
			get { return _personPhoneNumberType; }
			set 
			{ 
				_personPhoneNumberType = value;  
				IsDirty = true;
			}
		} 
				}
}

		