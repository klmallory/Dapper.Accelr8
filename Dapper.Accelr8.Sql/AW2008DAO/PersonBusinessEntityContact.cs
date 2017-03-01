
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
	public partial class PersonBusinessEntityContact : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonBusinessEntityContact()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
		 
	//From Foreign Key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID	
		protected PersonBusinessEntity _personBusinessEntity;
		public virtual PersonBusinessEntity PersonBusinessEntity 
		{ 
			get { return _personBusinessEntity; }
			set 
			{ 
				_personBusinessEntity = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_BusinessEntityContact_ContactType_ContactTypeID	
		protected PersonContactType _personContactType;
		public virtual PersonContactType PersonContactType 
		{ 
			get { return _personContactType; }
			set 
			{ 
				_personContactType = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_BusinessEntityContact_Person_PersonID	
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

		