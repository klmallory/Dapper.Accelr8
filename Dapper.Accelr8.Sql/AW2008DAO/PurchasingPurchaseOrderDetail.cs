
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
	public class PurchasingPurchaseOrderDetail : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public PurchasingPurchaseOrderDetail()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_dueDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(PurchasingPurchaseOrderDetail dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.PurchaseOrderID,
							dao.PurchaseOrderDetailID,
						
				}
			};
		}

			
			protected int _purchaseOrderID;
		public int PurchaseOrderID 
		{ 
			get { return _purchaseOrderID; }
			set 
			{ 
				_purchaseOrderID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _purchaseOrderDetailID;
		public int PurchaseOrderDetailID 
		{ 
			get { return _purchaseOrderDetailID; }
			set 
			{ 
				_purchaseOrderDetailID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
		
		
		protected DateTime _dueDate;
		public DateTime DueDate 
		{ 
			get { return _dueDate; }
			set 
			{ 
				_dueDate = value;  
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
			
		protected decimal _receivedQty;
		public decimal ReceivedQty 
		{ 
			get { return _receivedQty; }
			set 
			{ 
				_receivedQty = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _rejectedQty;
		public decimal RejectedQty 
		{ 
			get { return _rejectedQty; }
			set 
			{ 
				_rejectedQty = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _stockedQty;
		public decimal StockedQty 
		{ 
			get { return _stockedQty; }
			set 
			{ 
				_stockedQty = value;  
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
		 
	//From Foreign Key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID	
		protected PurchasingPurchaseOrderHeader _purchasingPurchaseOrderHeader;
		public virtual PurchasingPurchaseOrderHeader PurchasingPurchaseOrderHeader 
		{ 
			get { return _purchasingPurchaseOrderHeader; }
			set 
			{ 
				_purchasingPurchaseOrderHeader = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_PurchaseOrderDetail_Product_ProductID	
		protected ProductionProduct _productionProduct;
		public virtual ProductionProduct ProductionProduct 
		{ 
			get { return _productionProduct; }
			set 
			{ 
				_productionProduct = value;  
				IsDirty = true;
			}
		} 
				}
}

		