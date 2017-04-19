
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
	public class PersonBusinessEntityContact : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public PersonBusinessEntityContact()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(PersonBusinessEntityContact dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.PersonID,
							dao.ContactTypeID,
						
				}
			};
		}

			
			protected int _businessEntityID;
		public int BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _personID;
		public int PersonID 
		{ 
			get { return _personID; }
			set 
			{ 
				_personID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _contactTypeID;
		public int ContactTypeID 
		{ 
			get { return _contactTypeID; }
			set 
			{ 
				_contactTypeID = value;
				this.Id = GetCompoundKeyFor(this);

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

		