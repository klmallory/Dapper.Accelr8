
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
	public partial class PersonAddressType : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonAddressType()
		{			
			IsDirty = false; 
			_personBusinessEntityAddresses = new List<PersonBusinessEntityAddress>();
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
		 
	//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID	
		protected IList<PersonBusinessEntityAddress> _personBusinessEntityAddresses;
		public virtual IList<PersonBusinessEntityAddress> PersonBusinessEntityAddresses 
		{ 
			get { return _personBusinessEntityAddresses; }
			set 
			{ 
				_personBusinessEntityAddresses = value;  
				IsDirty = true;
			}
		} 
					}
}

		