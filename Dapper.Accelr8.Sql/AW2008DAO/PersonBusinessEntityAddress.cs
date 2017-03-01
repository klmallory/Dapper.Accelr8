
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
	public partial class PersonBusinessEntityAddress : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonBusinessEntityAddress()
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

		