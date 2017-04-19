
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
	public class PersonEmailAddress : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public PersonEmailAddress()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(PersonEmailAddress dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.EmailAddressID,
						
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
			
			protected int _emailAddressID;
		public int EmailAddressID 
		{ 
			get { return _emailAddressID; }
			set 
			{ 
				_emailAddressID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
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

		