
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
	public partial class ProductionProduct : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProduct()
		{			
			IsDirty = false; 
			_productionProductInventories = new List<ProductionProductInventory>();
		_productionProductListPriceHistories = new List<ProductionProductListPriceHistory>();
		_salesSpecialOfferProducts = new List<SalesSpecialOfferProduct>();
		_productionProductProductPhotos = new List<ProductionProductProductPhoto>();
		_productionTransactionHistories = new List<ProductionTransactionHistory>();
		_productionProductReviews = new List<ProductionProductReview>();
		_purchasingProductVendors = new List<PurchasingProductVendor>();
		_productionWorkOrders = new List<ProductionWorkOrder>();
		_purchasingPurchaseOrderDetails = new List<PurchasingPurchaseOrderDetail>();
		_productionProductCostHistories = new List<ProductionProductCostHistory>();
		_salesShoppingCartItems = new List<SalesShoppingCartItem>();
		_productionProductDocuments = new List<ProductionProductDocument>();
		_sellStartDate = (DateTime)SqlDateTime.MinValue;
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
			
		protected string _productNumber;
		public string ProductNumber 
		{ 
			get { return _productNumber; }
			set 
			{ 
				_productNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected object _makeFlag;
		public object MakeFlag 
		{ 
			get { return _makeFlag; }
			set 
			{ 
				_makeFlag = value;  
				IsDirty = true;
			}
		} 
			
		protected object _finishedGoodsFlag;
		public object FinishedGoodsFlag 
		{ 
			get { return _finishedGoodsFlag; }
			set 
			{ 
				_finishedGoodsFlag = value;  
				IsDirty = true;
			}
		} 
			
		protected string _color;
		public string Color 
		{ 
			get { return _color; }
			set 
			{ 
				_color = value;  
				IsDirty = true;
			}
		} 
			
		protected short _safetyStockLevel;
		public short SafetyStockLevel 
		{ 
			get { return _safetyStockLevel; }
			set 
			{ 
				_safetyStockLevel = value;  
				IsDirty = true;
			}
		} 
			
		protected short _reorderPoint;
		public short ReorderPoint 
		{ 
			get { return _reorderPoint; }
			set 
			{ 
				_reorderPoint = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _standardCost;
		public decimal StandardCost 
		{ 
			get { return _standardCost; }
			set 
			{ 
				_standardCost = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _listPrice;
		public decimal ListPrice 
		{ 
			get { return _listPrice; }
			set 
			{ 
				_listPrice = value;  
				IsDirty = true;
			}
		} 
			
		protected string _size;
		public string Size 
		{ 
			get { return _size; }
			set 
			{ 
				_size = value;  
				IsDirty = true;
			}
		} 
			
		protected string _sizeUnitMeasureCode;
		public string SizeUnitMeasureCode 
		{ 
			get { return _sizeUnitMeasureCode; }
			set 
			{ 
				_sizeUnitMeasureCode = value;  
				IsDirty = true;
			}
		} 
			
		protected string _weightUnitMeasureCode;
		public string WeightUnitMeasureCode 
		{ 
			get { return _weightUnitMeasureCode; }
			set 
			{ 
				_weightUnitMeasureCode = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _weight;
		public decimal? Weight 
		{ 
			get { return _weight; }
			set 
			{ 
				_weight = value;  
				IsDirty = true;
			}
		} 
			
		protected int _daysToManufacture;
		public int DaysToManufacture 
		{ 
			get { return _daysToManufacture; }
			set 
			{ 
				_daysToManufacture = value;  
				IsDirty = true;
			}
		} 
			
		protected string _productLine;
		public string ProductLine 
		{ 
			get { return _productLine; }
			set 
			{ 
				_productLine = value;  
				IsDirty = true;
			}
		} 
			
		protected string _class;
		public string Class 
		{ 
			get { return _class; }
			set 
			{ 
				_class = value;  
				IsDirty = true;
			}
		} 
			
		protected string _style;
		public string Style 
		{ 
			get { return _style; }
			set 
			{ 
				_style = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _productSubcategoryID;
		public int? ProductSubcategoryID 
		{ 
			get { return _productSubcategoryID; }
			set 
			{ 
				_productSubcategoryID = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _productModelID;
		public int? ProductModelID 
		{ 
			get { return _productModelID; }
			set 
			{ 
				_productModelID = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _sellStartDate;
		public DateTime SellStartDate 
		{ 
			get { return _sellStartDate; }
			set 
			{ 
				_sellStartDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _sellEndDate;
		public DateTime? SellEndDate 
		{ 
			get { return _sellEndDate; }
			set 
			{ 
				_sellEndDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _discontinuedDate;
		public DateTime? DiscontinuedDate 
		{ 
			get { return _discontinuedDate; }
			set 
			{ 
				_discontinuedDate = value;  
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
		 
	//From Foreign Key FK_Product_ProductModel_ProductModelID	
		protected ProductionProductModel _productionProductModel;
		public virtual ProductionProductModel ProductionProductModel 
		{ 
			get { return _productionProductModel; }
			set 
			{ 
				_productionProductModel = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Product_ProductSubcategory_ProductSubcategoryID	
		protected ProductionProductSubcategory _productionProductSubcategory;
		public virtual ProductionProductSubcategory ProductionProductSubcategory 
		{ 
			get { return _productionProductSubcategory; }
			set 
			{ 
				_productionProductSubcategory = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Product_UnitMeasure_SizeUnitMeasureCode	
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
		 
	//From Foreign Key FK_Product_UnitMeasure_WeightUnitMeasureCode	
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
		 
	//From Foreign Key FK_ProductInventory_Product_ProductID	
		protected IList<ProductionProductInventory> _productionProductInventories;
		public virtual IList<ProductionProductInventory> ProductionProductInventories 
		{ 
			get { return _productionProductInventories; }
			set 
			{ 
				_productionProductInventories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ProductListPriceHistory_Product_ProductID	
		protected IList<ProductionProductListPriceHistory> _productionProductListPriceHistories;
		public virtual IList<ProductionProductListPriceHistory> ProductionProductListPriceHistories 
		{ 
			get { return _productionProductListPriceHistories; }
			set 
			{ 
				_productionProductListPriceHistories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SpecialOfferProduct_Product_ProductID	
		protected IList<SalesSpecialOfferProduct> _salesSpecialOfferProducts;
		public virtual IList<SalesSpecialOfferProduct> SalesSpecialOfferProducts 
		{ 
			get { return _salesSpecialOfferProducts; }
			set 
			{ 
				_salesSpecialOfferProducts = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ProductProductPhoto_Product_ProductID	
		protected IList<ProductionProductProductPhoto> _productionProductProductPhotos;
		public virtual IList<ProductionProductProductPhoto> ProductionProductProductPhotos 
		{ 
			get { return _productionProductProductPhotos; }
			set 
			{ 
				_productionProductProductPhotos = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_TransactionHistory_Product_ProductID	
		protected IList<ProductionTransactionHistory> _productionTransactionHistories;
		public virtual IList<ProductionTransactionHistory> ProductionTransactionHistories 
		{ 
			get { return _productionTransactionHistories; }
			set 
			{ 
				_productionTransactionHistories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ProductReview_Product_ProductID	
		protected IList<ProductionProductReview> _productionProductReviews;
		public virtual IList<ProductionProductReview> ProductionProductReviews 
		{ 
			get { return _productionProductReviews; }
			set 
			{ 
				_productionProductReviews = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ProductVendor_Product_ProductID	
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
			 
	//From Foreign Key FK_WorkOrder_Product_ProductID	
		protected IList<ProductionWorkOrder> _productionWorkOrders;
		public virtual IList<ProductionWorkOrder> ProductionWorkOrders 
		{ 
			get { return _productionWorkOrders; }
			set 
			{ 
				_productionWorkOrders = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_PurchaseOrderDetail_Product_ProductID	
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
			 
	//From Foreign Key FK_ProductCostHistory_Product_ProductID	
		protected IList<ProductionProductCostHistory> _productionProductCostHistories;
		public virtual IList<ProductionProductCostHistory> ProductionProductCostHistories 
		{ 
			get { return _productionProductCostHistories; }
			set 
			{ 
				_productionProductCostHistories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ShoppingCartItem_Product_ProductID	
		protected IList<SalesShoppingCartItem> _salesShoppingCartItems;
		public virtual IList<SalesShoppingCartItem> SalesShoppingCartItems 
		{ 
			get { return _salesShoppingCartItems; }
			set 
			{ 
				_salesShoppingCartItems = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ProductDocument_Product_ProductID	
		protected IList<ProductionProductDocument> _productionProductDocuments;
		public virtual IList<ProductionProductDocument> ProductionProductDocuments 
		{ 
			get { return _productionProductDocuments; }
			set 
			{ 
				_productionProductDocuments = value;  
				IsDirty = true;
			}
		} 
					}
}

		