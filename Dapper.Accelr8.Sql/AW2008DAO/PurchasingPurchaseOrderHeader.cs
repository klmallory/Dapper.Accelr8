
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
	public partial class PurchasingPurchaseOrderHeader : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PurchasingPurchaseOrderHeader()
		{			
			IsDirty = false; 
			_purchasingPurchaseOrderDetails = new List<PurchasingPurchaseOrderDetail>();
		_orderDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected byte _revisionNumber;
		public byte RevisionNumber 
		{ 
			get { return _revisionNumber; }
			set 
			{ 
				_revisionNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected byte _status;
		public byte Status 
		{ 
			get { return _status; }
			set 
			{ 
				_status = value;  
				IsDirty = true;
			}
		} 
			
		protected int _employeeID;
		public int EmployeeID 
		{ 
			get { return _employeeID; }
			set 
			{ 
				_employeeID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _vendorID;
		public int VendorID 
		{ 
			get { return _vendorID; }
			set 
			{ 
				_vendorID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _shipMethodID;
		public int ShipMethodID 
		{ 
			get { return _shipMethodID; }
			set 
			{ 
				_shipMethodID = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _orderDate;
		public DateTime OrderDate 
		{ 
			get { return _orderDate; }
			set 
			{ 
				_orderDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _shipDate;
		public DateTime? ShipDate 
		{ 
			get { return _shipDate; }
			set 
			{ 
				_shipDate = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _subTotal;
		public decimal SubTotal 
		{ 
			get { return _subTotal; }
			set 
			{ 
				_subTotal = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _taxAmt;
		public decimal TaxAmt 
		{ 
			get { return _taxAmt; }
			set 
			{ 
				_taxAmt = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _freight;
		public decimal Freight 
		{ 
			get { return _freight; }
			set 
			{ 
				_freight = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _totalDue;
		public decimal TotalDue 
		{ 
			get { return _totalDue; }
			set 
			{ 
				_totalDue = value;  
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
		 
	//From Foreign Key FK_PurchaseOrderHeader_Vendor_VendorID	
		protected PurchasingVendor _purchasingVendor;
		public virtual PurchasingVendor PurchasingVendor 
		{ 
			get { return _purchasingVendor; }
			set 
			{ 
				_purchasingVendor = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_PurchaseOrderHeader_Employee_EmployeeID	
		protected HumanResourcesEmployee _humanResourcesEmployee;
		public virtual HumanResourcesEmployee HumanResourcesEmployee 
		{ 
			get { return _humanResourcesEmployee; }
			set 
			{ 
				_humanResourcesEmployee = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID	
		protected PurchasingShipMethod _purchasingShipMethod;
		public virtual PurchasingShipMethod PurchasingShipMethod 
		{ 
			get { return _purchasingShipMethod; }
			set 
			{ 
				_purchasingShipMethod = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID	
		protected IList<PurchasingPurchaseOrderDetail> _purchasingPurchaseOrderDetails;
		public virtual IList<PurchasingPurchaseOrderDetail> PurchasingPurchaseOrderDetails 
		{ 
			get { return _purchasingPurchaseOrderDetails; }
			set 
			{ 
				_purchasingPurchaseOrderDetails = value;  
				IsDirty = true;
			}
		} 
					}
}

		