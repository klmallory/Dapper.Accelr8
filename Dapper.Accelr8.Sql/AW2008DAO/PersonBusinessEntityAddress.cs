
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
	public class PersonBusinessEntityAddress : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public PersonBusinessEntityAddress()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(PersonBusinessEntityAddress dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.AddressID,
							dao.AddressTypeID,
						
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
			
			protected int _addressID;
		public int AddressID 
		{ 
			get { return _addressID; }
			set 
			{ 
				_addressID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _addressTypeID;
		public int AddressTypeID 
		{ 
			get { return _addressTypeID; }
			set 
			{ 
				_addressTypeID = value;
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
		 
	//From Foreign Key FK_BusinessEntityAddress_Address_AddressID	
		protected PersonAddress _personAddress;
		public virtual PersonAddress PersonAddress 
		{ 
			get { return _personAddress; }
			set 
			{ 
				_personAddress = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID	
		protected PersonAddressType _personAddressType;
		public virtual PersonAddressType PersonAddressType 
		{ 
			get { return _personAddressType; }
			set 
			{ 
				_personAddressType = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID	
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
				}
}

		