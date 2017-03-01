
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
	public partial class SalesSalesOrderDetail : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSalesOrderDetail()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected string _carrierTrackingNumber;
		public string CarrierTrackingNumber 
		{ 
			get { return _carrierTrackingNumber; }
			set 
			{ 
				_carrierTrackingNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected short _orderQty;
		public short OrderQty 
		{ 
			get { return _orderQty; }
			set 
			{ 
				_orderQty = value;  
				IsDirty = true;
			}
		} 
			
		protected int _productID;
		public int ProductID 
		{ 
			get { return _productID; }
			set 
			{ 
				_productID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _specialOfferID;
		public int SpecialOfferID 
		{ 
			get { return _specialOfferID; }
			set 
			{ 
				_specialOfferID = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _unitPrice;
		public decimal UnitPrice 
		{ 
			get { return _unitPrice; }
			set 
			{ 
				_unitPrice = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _unitPriceDiscount;
		public decimal UnitPriceDiscount 
		{ 
			get { return _unitPriceDiscount; }
			set 
			{ 
				_unitPriceDiscount = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _lineTotal;
		public decimal LineTotal 
		{ 
			get { return _lineTotal; }
			set 
			{ 
				_lineTotal = value;  
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
		 
	//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID	
		protected SalesSpecialOfferProduct _salesSpecialOfferProduct;
		public virtual SalesSpecialOfferProduct SalesSpecialOfferProduct 
		{ 
			get { return _salesSpecialOfferProduct; }
			set 
			{ 
				_salesSpecialOfferProduct = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID	
		protected SalesSpecialOfferProduct _salesSpecialOfferProduct;
		public virtual SalesSpecialOfferProduct SalesSpecialOfferProduct 
		{ 
			get { return _salesSpecialOfferProduct; }
			set 
			{ 
				_salesSpecialOfferProduct = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID	
		protected SalesSalesOrderHeader _salesSalesOrderHeader;
		public virtual SalesSalesOrderHeader SalesSalesOrderHeader 
		{ 
			get { return _salesSalesOrderHeader; }
			set 
			{ 
				_salesSalesOrderHeader = value;  
				IsDirty = true;
			}
		} 
				}
}

		