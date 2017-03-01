
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
	public partial class PersonPhoneNumberType : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonPhoneNumberType()
		{			
			IsDirty = false; 
			_personPersonPhones = new List<PersonPersonPhone>();
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
		 
	//From Foreign Key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID	
		protected IList<PersonPersonPhone> _personPersonPhones;
		public virtual IList<PersonPersonPhone> PersonPersonPhones 
		{ 
			get { return _personPersonPhones; }
			set 
			{ 
				_personPersonPhones = value;  
				IsDirty = true;
			}
		} 
					}
}

		