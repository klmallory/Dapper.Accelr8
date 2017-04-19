
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
	public class PurchasingProductVendor : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public PurchasingProductVendor()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(PurchasingProductVendor dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.ProductID,
							dao.BusinessEntityID,
						
				}
			};
		}

			
			protected int _productID;
		public int ProductID 
		{ 
			get { return _productID; }
			set 
			{ 
				_productID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
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
		
		
		protected int _averageLeadTime;
		public int AverageLeadTime 
		{ 
			get { return _averageLeadTime; }
			set 
			{ 
				_averageLeadTime = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _standardPrice;
		public decimal StandardPrice 
		{ 
			get { return _standardPrice; }
			set 
			{ 
				_standardPrice = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _lastReceiptCost;
		public decimal? LastReceiptCost 
		{ 
			get { return _lastReceiptCost; }
			set 
			{ 
				_lastReceiptCost = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _lastReceiptDate;
		public DateTime? LastReceiptDate 
		{ 
			get { return _lastReceiptDate; }
			set 
			{ 
				_lastReceiptDate = value;  
				IsDirty = true;
			}
		} 
			
		protected int _minOrderQty;
		public int MinOrderQty 
		{ 
			get { return _minOrderQty; }
			set 
			{ 
				_minOrderQty = value;  
				IsDirty = true;
			}
		} 
			
		protected int _maxOrderQty;
		public int MaxOrderQty 
		{ 
			get { return _maxOrderQty; }
			set 
			{ 
				_maxOrderQty = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _onOrderQty;
		public int? OnOrderQty 
		{ 
			get { return _onOrderQty; }
			set 
			{ 
				_onOrderQty = value;  
				IsDirty = true;
			}
		} 
			
		protected string _unitMeasureCode;
		public string UnitMeasureCode 
		{ 
			get { return _unitMeasureCode; }
			set 
			{ 
				_unitMeasureCode = value;  
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
		 
	//From Foreign Key FK_ProductVendor_UnitMeasure_UnitMeasureCode	
		protected ProductionUnitMeasure _productionUnitMeasure;
		public virtual ProductionUnitMeasure ProductionUnitMeasure 
		{ 
			get { return _productionUnitMeasure; }
			set 
			{ 
				_productionUnitMeasure = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID	
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
		 
	//From Foreign Key FK_ProductVendor_Product_ProductID	
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

		