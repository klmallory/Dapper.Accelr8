
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
	public class PersonContactType : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonContactType()
		{
							
			IsDirty = false; 
			_personBusinessEntityContacts = new List<PersonBusinessEntityContact>();
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
		 
	//From Foreign Key FK_BusinessEntityContact_ContactType_ContactTypeID	
		protected IList<PersonBusinessEntityContact> _personBusinessEntityContacts;
		public virtual IList<PersonBusinessEntityContact> PersonBusinessEntityContacts 
		{ 
			get { return _personBusinessEntityContacts; }
			set 
			{ 
				_personBusinessEntityContacts = value;  
				IsDirty = true;
			}
		} 
					}
}

		