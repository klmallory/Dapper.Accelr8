
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008Readers
{
    public class ProductionProductReader : EntityReader<int, ProductionProduct>
    {
        public ProductionProductReader(
            ProductionProductTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 14
		//Parent Count 4
				//Is CompoundKey False
		protected static IEntityReader<int , ProductionBillOfMaterial> GetProductionBillOfMaterialReader()
		{
			return s_loc8r.GetReader<int , ProductionBillOfMaterial>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , ProductionProductCostHistory> GetProductionProductCostHistoryReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductCostHistory>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , ProductionProductDocument> GetProductionProductDocumentReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductDocument>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , ProductionProductInventory> GetProductionProductInventoryReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductInventory>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , ProductionProductListPriceHistory> GetProductionProductListPriceHistoryReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductListPriceHistory>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , ProductionProductProductPhoto> GetProductionProductProductPhotoReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductProductPhoto>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , ProductionProductReview> GetProductionProductReviewReader()
		{
			return s_loc8r.GetReader<int , ProductionProductReview>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PurchasingProductVendor> GetPurchasingProductVendorReader()
		{
			return s_loc8r.GetReader<CompoundKey , PurchasingProductVendor>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PurchasingPurchaseOrderDetail> GetPurchasingPurchaseOrderDetailReader()
		{
			return s_loc8r.GetReader<CompoundKey , PurchasingPurchaseOrderDetail>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesShoppingCartItem> GetSalesShoppingCartItemReader()
		{
			return s_loc8r.GetReader<int , SalesShoppingCartItem>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesSpecialOfferProduct> GetSalesSpecialOfferProductReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesSpecialOfferProduct>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , ProductionTransactionHistory> GetProductionTransactionHistoryReader()
		{
			return s_loc8r.GetReader<int , ProductionTransactionHistory>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , ProductionWorkOrder> GetProductionWorkOrderReader()
		{
			return s_loc8r.GetReader<int , ProductionWorkOrder>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionBillOfMaterial on the parent on ProductionBillOfMaterials.
		/// From foriegn key FK_BillOfMaterials_Product_ComponentID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionBillOfMaterials1(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionBillOfMaterial

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionBillOfMaterial>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionBillOfMaterials1 = typedChildren.Where(b =>  b.ComponentID == r.Id ).ToList();
				r.ProductionBillOfMaterials1.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct2 = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionBillOfMaterial on the parent on ProductionBillOfMaterials.
		/// From foriegn key FK_BillOfMaterials_Product_ProductAssemblyID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionBillOfMaterials2(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionBillOfMaterial

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionBillOfMaterial>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionBillOfMaterials2 = typedChildren.Where(b =>  b.ProductAssemblyID == r.Id ).ToList();
				r.ProductionBillOfMaterials2.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct1 = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProductCostHistory on the parent on ProductionProductCostHistories.
		/// From foriegn key FK_ProductCostHistory_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductCostHistories(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: ProductionProductCostHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductCostHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductCostHistories = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.ProductionProductCostHistories.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProductDocument on the parent on ProductionProductDocuments.
		/// From foriegn key FK_ProductDocument_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductDocuments(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: ProductionProductDocument

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductDocument>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductDocuments = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.ProductionProductDocuments.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProductInventory on the parent on ProductionProductInventories.
		/// From foriegn key FK_ProductInventory_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductInventories(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: ProductionProductInventory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductInventory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductInventories = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.ProductionProductInventories.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProductListPriceHistory on the parent on ProductionProductListPriceHistories.
		/// From foriegn key FK_ProductListPriceHistory_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductListPriceHistories(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: ProductionProductListPriceHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductListPriceHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductListPriceHistories = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.ProductionProductListPriceHistories.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProductProductPhoto on the parent on ProductionProductProductPhotos.
		/// From foriegn key FK_ProductProductPhoto_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductProductPhotos(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: ProductionProductProductPhoto

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductProductPhoto>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductProductPhotos = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.ProductionProductProductPhotos.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProductReview on the parent on ProductionProductReviews.
		/// From foriegn key FK_ProductReview_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductReviews(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionProductReview

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductReview>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductReviews = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.ProductionProductReviews.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PurchasingProductVendor on the parent on PurchasingProductVendors.
		/// From foriegn key FK_ProductVendor_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingProductVendors(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: PurchasingProductVendor

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingProductVendor>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PurchasingProductVendors = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.PurchasingProductVendors.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PurchasingPurchaseOrderDetail on the parent on PurchasingPurchaseOrderDetails.
		/// From foriegn key FK_PurchaseOrderDetail_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingPurchaseOrderDetails(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: PurchasingPurchaseOrderDetail

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingPurchaseOrderDetail>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PurchasingPurchaseOrderDetails = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.PurchasingPurchaseOrderDetails.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesShoppingCartItem on the parent on SalesShoppingCartItems.
		/// From foriegn key FK_ShoppingCartItem_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesShoppingCartItems(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesShoppingCartItem

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesShoppingCartItem>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesShoppingCartItems = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.SalesShoppingCartItems.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSpecialOfferProduct on the parent on SalesSpecialOfferProducts.
		/// From foriegn key FK_SpecialOfferProduct_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSpecialOfferProducts(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesSpecialOfferProduct

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSpecialOfferProduct>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSpecialOfferProducts = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.SalesSpecialOfferProducts.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionTransactionHistory on the parent on ProductionTransactionHistories.
		/// From foriegn key FK_TransactionHistory_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionTransactionHistories(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionTransactionHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionTransactionHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionTransactionHistories = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.ProductionTransactionHistories.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionWorkOrder on the parent on ProductionWorkOrders.
		/// From foriegn key FK_WorkOrder_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionWorkOrders(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionWorkOrder

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionWorkOrder>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionWorkOrders = typedChildren.Where(b =>  b.ProductID == r.Id ).ToList();
				r.ProductionWorkOrders.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.Product into class ProductionProduct
		/// </summary>
		/// <param name="results">ProductionProduct</param>
		/// <param name="row"></param>
        public override ProductionProduct LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProduct();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "ProductID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ProductNumber = GetRowData<string>(dataRow, "ProductNumber"); 
      		domain.MakeFlag = GetRowData<object>(dataRow, "MakeFlag"); 
      		domain.FinishedGoodsFlag = GetRowData<object>(dataRow, "FinishedGoodsFlag"); 
      		domain.Color = GetRowData<string>(dataRow, "Color"); 
      		domain.SafetyStockLevel = GetRowData<short>(dataRow, "SafetyStockLevel"); 
      		domain.ReorderPoint = GetRowData<short>(dataRow, "ReorderPoint"); 
      		domain.StandardCost = GetRowData<decimal>(dataRow, "StandardCost"); 
      		domain.ListPrice = GetRowData<decimal>(dataRow, "ListPrice"); 
      		domain.Size = GetRowData<string>(dataRow, "Size"); 
      		domain.SizeUnitMeasureCode = GetRowData<string>(dataRow, "SizeUnitMeasureCode"); 
      		domain.WeightUnitMeasureCode = GetRowData<string>(dataRow, "WeightUnitMeasureCode"); 
      		domain.Weight = GetRowData<decimal?>(dataRow, "Weight"); 
      		domain.DaysToManufacture = GetRowData<int>(dataRow, "DaysToManufacture"); 
      		domain.ProductLine = GetRowData<string>(dataRow, "ProductLine"); 
      		domain.Class = GetRowData<string>(dataRow, "Class"); 
      		domain.Style = GetRowData<string>(dataRow, "Style"); 
      		domain.ProductSubcategoryID = GetRowData<int?>(dataRow, "ProductSubcategoryID"); 
      		domain.ProductModelID = GetRowData<int?>(dataRow, "ProductModelID"); 
      		domain.SellStartDate = GetRowData<DateTime>(dataRow, "SellStartDate"); 
      		domain.SellEndDate = GetRowData<DateTime?>(dataRow, "SellEndDate"); 
      		domain.DiscontinuedDate = GetRowData<DateTime?>(dataRow, "DiscontinuedDate"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionProduct></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionProduct> WithAllChildrenForExisting(ProductionProduct existing)
        {
						WithChildForParentValues(GetProductionBillOfMaterialReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ComponentID",  }
				, SetChildrenProductionBillOfMaterials1);
						WithChildForParentValues(GetProductionBillOfMaterialReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductAssemblyID",  }
				, SetChildrenProductionBillOfMaterials2);
						WithChildForParentValues(GetProductionProductCostHistoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductCostHistories);
						WithChildForParentValues(GetProductionProductDocumentReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductDocuments);
						WithChildForParentValues(GetProductionProductInventoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductInventories);
						WithChildForParentValues(GetProductionProductListPriceHistoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductListPriceHistories);
						WithChildForParentValues(GetProductionProductProductPhotoReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductProductPhotos);
						WithChildForParentValues(GetProductionProductReviewReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductReviews);
						WithChildForParentValues(GetPurchasingProductVendorReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenPurchasingProductVendors);
						WithChildForParentValues(GetPurchasingPurchaseOrderDetailReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenPurchasingPurchaseOrderDetails);
						WithChildForParentValues(GetSalesShoppingCartItemReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenSalesShoppingCartItems);
						WithChildForParentValues(GetSalesSpecialOfferProductReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenSalesSpecialOfferProducts);
						WithChildForParentValues(GetProductionTransactionHistoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionTransactionHistories);
						WithChildForParentValues(GetProductionWorkOrderReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionWorkOrders);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionProduct entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionBillOfMaterialReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ComponentID",  }
				, SetChildrenProductionBillOfMaterials1);

						WithChildForParentValues(GetProductionBillOfMaterialReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductAssemblyID",  }
				, SetChildrenProductionBillOfMaterials2);

						WithChildForParentValues(GetProductionProductCostHistoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductCostHistories);

						WithChildForParentValues(GetProductionProductDocumentReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductDocuments);

						WithChildForParentValues(GetProductionProductInventoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductInventories);

						WithChildForParentValues(GetProductionProductListPriceHistoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductListPriceHistories);

						WithChildForParentValues(GetProductionProductProductPhotoReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductProductPhotos);

						WithChildForParentValues(GetProductionProductReviewReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductReviews);

						WithChildForParentValues(GetPurchasingProductVendorReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenPurchasingProductVendors);

						WithChildForParentValues(GetPurchasingPurchaseOrderDetailReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenPurchasingPurchaseOrderDetails);

						WithChildForParentValues(GetSalesShoppingCartItemReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenSalesShoppingCartItems);

						WithChildForParentValues(GetSalesSpecialOfferProductReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenSalesSpecialOfferProducts);

						WithChildForParentValues(GetProductionTransactionHistoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionTransactionHistories);

						WithChildForParentValues(GetProductionWorkOrderReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionWorkOrders);

			
QueryResultForChildrenOnly(new List<ProductionProduct>() { entity });
			entity.Loaded = false;
			GetProductionBillOfMaterialReader().SetAllChildrenForExisting(entity.ProductionBillOfMaterials);
			GetProductionBillOfMaterialReader().SetAllChildrenForExisting(entity.ProductionBillOfMaterials);
			GetProductionProductCostHistoryReader().SetAllChildrenForExisting(entity.ProductionProductCostHistories);
			GetProductionProductDocumentReader().SetAllChildrenForExisting(entity.ProductionProductDocuments);
			GetProductionProductInventoryReader().SetAllChildrenForExisting(entity.ProductionProductInventories);
			GetProductionProductListPriceHistoryReader().SetAllChildrenForExisting(entity.ProductionProductListPriceHistories);
			GetProductionProductProductPhotoReader().SetAllChildrenForExisting(entity.ProductionProductProductPhotos);
			GetProductionProductReviewReader().SetAllChildrenForExisting(entity.ProductionProductReviews);
			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entity.PurchasingProductVendors);
			GetPurchasingPurchaseOrderDetailReader().SetAllChildrenForExisting(entity.PurchasingPurchaseOrderDetails);
			GetSalesShoppingCartItemReader().SetAllChildrenForExisting(entity.SalesShoppingCartItems);
			GetSalesSpecialOfferProductReader().SetAllChildrenForExisting(entity.SalesSpecialOfferProducts);
			GetProductionTransactionHistoryReader().SetAllChildrenForExisting(entity.ProductionTransactionHistories);
			GetProductionWorkOrderReader().SetAllChildrenForExisting(entity.ProductionWorkOrders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProduct> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionBillOfMaterialReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ComponentID",  }
				, SetChildrenProductionBillOfMaterials1);

			WithChildForParentsValues(GetProductionBillOfMaterialReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductAssemblyID",  }
				, SetChildrenProductionBillOfMaterials2);

			WithChildForParentsValues(GetProductionProductCostHistoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductCostHistories);

			WithChildForParentsValues(GetProductionProductDocumentReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductDocuments);

			WithChildForParentsValues(GetProductionProductInventoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductInventories);

			WithChildForParentsValues(GetProductionProductListPriceHistoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductListPriceHistories);

			WithChildForParentsValues(GetProductionProductProductPhotoReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductProductPhotos);

			WithChildForParentsValues(GetProductionProductReviewReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionProductReviews);

			WithChildForParentsValues(GetPurchasingProductVendorReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenPurchasingProductVendors);

			WithChildForParentsValues(GetPurchasingPurchaseOrderDetailReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenPurchasingPurchaseOrderDetails);

			WithChildForParentsValues(GetSalesShoppingCartItemReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenSalesShoppingCartItems);

			WithChildForParentsValues(GetSalesSpecialOfferProductReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenSalesSpecialOfferProducts);

			WithChildForParentsValues(GetProductionTransactionHistoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionTransactionHistories);

			WithChildForParentsValues(GetProductionWorkOrderReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductID",  }
				, SetChildrenProductionWorkOrders);

					
			QueryResultForChildrenOnly(entities);

			GetProductionBillOfMaterialReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionBillOfMaterials1).ToList());
			GetProductionBillOfMaterialReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionBillOfMaterials2).ToList());
			GetProductionProductCostHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductCostHistories).ToList());
			GetProductionProductDocumentReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductDocuments).ToList());
			GetProductionProductInventoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductInventories).ToList());
			GetProductionProductListPriceHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductListPriceHistories).ToList());
			GetProductionProductProductPhotoReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductProductPhotos).ToList());
			GetProductionProductReviewReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductReviews).ToList());
			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingProductVendors).ToList());
			GetPurchasingPurchaseOrderDetailReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingPurchaseOrderDetails).ToList());
			GetSalesShoppingCartItemReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesShoppingCartItems).ToList());
			GetSalesSpecialOfferProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSpecialOfferProducts).ToList());
			GetProductionTransactionHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionTransactionHistories).ToList());
			GetProductionWorkOrderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionWorkOrders).ToList());
					
		}
    }
}
		