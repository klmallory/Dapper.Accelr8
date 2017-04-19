
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
	public class PersonPersonPhone : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public PersonPersonPhone()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(PersonPersonPhone dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.PhoneNumber,
							dao.PhoneNumberTypeID,
						
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
			
			protected object _phoneNumber;
		public object PhoneNumber 
		{ 
			get { return _phoneNumber; }
			set 
			{ 
				_phoneNumber = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _phoneNumberTypeID;
		public int PhoneNumberTypeID 
		{ 
			get { return _phoneNumberTypeID; }
			set 
			{ 
				_phoneNumberTypeID = value;
				this.Id = GetCompoundKeyFor(this);

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

		