
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
	public partial class PurchasingShipMethod : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PurchasingShipMethod()
		{			
			IsDirty = false; 
			_purchasingPurchaseOrderHeaders = new List<PurchasingPurchaseOrderHeader>();
		_salesSalesOrderHeaders = new List<SalesSalesOrderHeader>();
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
			
		protected decimal _shipBase;
		public decimal ShipBase 
		{ 
			get { return _shipBase; }
			set 
			{ 
				_shipBase = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _shipRate;
		public decimal ShipRate 
		{ 
			get { return _shipRate; }
			set 
			{ 
				_shipRate = value;  
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
		 
	//From Foreign Key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID	
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
			 
	//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID	
		protected IList<SalesSalesOrderHeader> _salesSalesOrderHeaders;
		public virtual IList<SalesSalesOrderHeader> SalesSalesOrderHeaders 
		{ 
			get { return _salesSalesOrderHeaders; }
			set 
			{ 
				_salesSalesOrderHeaders = value;  
				IsDirty = true;
			}
		} 
					}
}

		