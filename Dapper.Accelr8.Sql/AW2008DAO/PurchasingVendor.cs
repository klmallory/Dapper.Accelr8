
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
	public class PurchasingVendor : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PurchasingVendor()
		{
							
			IsDirty = false; 
			_purchasingProductVendors = new List<PurchasingProductVendor>();
		_purchasingPurchaseOrderHeaders = new List<PurchasingPurchaseOrderHeader>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected object _accountNumber;
		public object AccountNumber 
		{ 
			get { return _accountNumber; }
			set 
			{ 
				_accountNumber = value;  
				IsDirty = true;
			}
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
			
		protected byte _creditRating;
		public byte CreditRating 
		{ 
			get { return _creditRating; }
			set 
			{ 
				_creditRating = value;  
				IsDirty = true;
			}
		} 
			
		protected object _preferredVendorStatus;
		public object PreferredVendorStatus 
		{ 
			get { return _preferredVendorStatus; }
			set 
			{ 
				_preferredVendorStatus = value;  
				IsDirty = true;
			}
		} 
			
		protected object _activeFlag;
		public object ActiveFlag 
		{ 
			get { return _activeFlag; }
			set 
			{ 
				_activeFlag = value;  
				IsDirty = true;
			}
		} 
			
		protected string _purchasingWebServiceURL;
		public string PurchasingWebServiceURL 
		{ 
			get { return _purchasingWebServiceURL; }
			set 
			{ 
				_purchasingWebServiceURL = value;  
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
		 
	//From Foreign Key FK_Vendor_BusinessEntity_BusinessEntityID	
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
		 
	//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID	
		protected IList<PurchasingProductVendor> _purchasingProductVendors;
		public virtual IList<PurchasingProductVendor> PurchasingProductVendors 
		{ 
			get { return _purchasingProductVendors; }
			set 
			{ 
				_purchasingProductVendors = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_PurchaseOrderHeader_Vendor_VendorID	
		protected IList<PurchasingPurchaseOrderHeader> _purchasingPurchaseOrderHeaders;
		public virtual IList<PurchasingPurchaseOrderHeader> PurchasingPurchaseOrderHeaders 
		{ 
			get { return _purchasingPurchaseOrderHeaders; }
			set 
			{ 
				_purchasingPurchaseOrderHeaders = value;  
				IsDirty = true;
			}
		} 
					}
}

		