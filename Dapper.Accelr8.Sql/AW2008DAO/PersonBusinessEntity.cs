
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
	public partial class PersonBusinessEntity : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonBusinessEntity()
		{			
			IsDirty = false; 
			_salesStores = new List<SalesStore>();
		_personBusinessEntityAddresses = new List<PersonBusinessEntityAddress>();
		_personBusinessEntityContacts = new List<PersonBusinessEntityContact>();
		_purchasingVendors = new List<PurchasingVendor>();
		_personPeople = new List<PersonPerson>();
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
		 
	//From Foreign Key FK_Store_BusinessEntity_BusinessEntityID	
		protected IList<SalesStore> _salesStores;
		public virtual IList<SalesStore> SalesStores 
		{ 
			get { return _salesStores; }
			set 
			{ 
				_salesStores = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID	
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
			 
	//From Foreign Key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID	
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
			 
	//From Foreign Key FK_Vendor_BusinessEntity_BusinessEntityID	
		protected IList<PurchasingVendor> _purchasingVendors;
		public virtual IList<PurchasingVendor> PurchasingVendors 
		{ 
			get { return _purchasingVendors; }
			set 
			{ 
				_purchasingVendors = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Person_BusinessEntity_BusinessEntityID	
		protected IList<PersonPerson> _personPeople;
		public virtual IList<PersonPerson> PersonPeople 
		{ 
			get { return _personPeople; }
			set 
			{ 
				_personPeople = value;  
				IsDirty = true;
			}
		} 
					}
}

		