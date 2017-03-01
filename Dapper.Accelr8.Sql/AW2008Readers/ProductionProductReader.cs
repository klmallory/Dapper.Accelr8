
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
        { }

		//Child Count 12
		//Parent Count 4
		static IEntityReader<int , ProductionProductInventory> _productionProductInventoryReader;
		protected static IEntityReader<int , ProductionProductInventory> GetProductionProductInventoryReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductInventory>>();
		}

		static IEntityReader<int , ProductionProductListPriceHistory> _productionProductListPriceHistoryReader;
		protected static IEntityReader<int , ProductionProductListPriceHistory> GetProductionProductListPriceHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductListPriceHistory>>();
		}

		static IEntityReader<int , SalesSpecialOfferProduct> _salesSpecialOfferProductReader;
		protected static IEntityReader<int , SalesSpecialOfferProduct> GetSalesSpecialOfferProductReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSpecialOfferProduct>>();
		}

		static IEntityReader<int , ProductionProductProductPhoto> _productionProductProductPhotoReader;
		protected static IEntityReader<int , ProductionProductProductPhoto> GetProductionProductProductPhotoReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductProductPhoto>>();
		}

		static IEntityReader<int , ProductionTransactionHistory> _productionTransactionHistoryReader;
		protected static IEntityReader<int , ProductionTransactionHistory> GetProductionTransactionHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionTransactionHistory>>();
		}

		static IEntityReader<int , ProductionProductReview> _productionProductReviewReader;
		protected static IEntityReader<int , ProductionProductReview> GetProductionProductReviewReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductReview>>();
		}

		static IEntityReader<int , PurchasingProductVendor> _purchasingProductVendorReader;
		protected static IEntityReader<int , PurchasingProductVendor> GetPurchasingProductVendorReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingProductVendor>>();
		}

		static IEntityReader<int , ProductionWorkOrder> _productionWorkOrderReader;
		protected static IEntityReader<int , ProductionWorkOrder> GetProductionWorkOrderReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionWorkOrder>>();
		}

		static IEntityReader<int , PurchasingPurchaseOrderDetail> _purchasingPurchaseOrderDetailReader;
		protected static IEntityReader<int , PurchasingPurchaseOrderDetail> GetPurchasingPurchaseOrderDetailReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingPurchaseOrderDetail>>();
		}

		static IEntityReader<int , ProductionProductCostHistory> _productionProductCostHistoryReader;
		protected static IEntityReader<int , ProductionProductCostHistory> GetProductionProductCostHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductCostHistory>>();
		}

		static IEntityReader<int , SalesShoppingCartItem> _salesShoppingCartItemReader;
		protected static IEntityReader<int , SalesShoppingCartItem> GetSalesShoppingCartItemReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesShoppingCartItem>>();
		}

		static IEntityReader<int , ProductionProductDocument> _productionProductDocumentReader;
		protected static IEntityReader<int , ProductionProductDocument> GetProductionProductDocumentReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductDocument>>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProductInventory on the parent on ProductionProductInventories.
		/// From foriegn key FK_ProductInventory_Product_ProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductInventories(IList<ProductionProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionProductInventory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductInventory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductInventories = typedChildren.Where(b => b.ProductionProductInventory == r.Id).ToList();
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
			//Child Id Type: int
			//Child Type: ProductionProductListPriceHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductListPriceHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductListPriceHistories = typedChildren.Where(b => b.ProductionProductListPriceHistory == r.Id).ToList();
				r.ProductionProductListPriceHistories.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
			//Child Id Type: int
			//Child Type: SalesSpecialOfferProduct

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSpecialOfferProduct>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSpecialOfferProducts = typedChildren.Where(b => b.SalesSpecialOfferProduct == r.Id).ToList();
				r.SalesSpecialOfferProducts.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
			//Child Id Type: int
			//Child Type: ProductionProductProductPhoto

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductProductPhoto>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductProductPhotos = typedChildren.Where(b => b.ProductionProductProductPhoto == r.Id).ToList();
				r.ProductionProductProductPhotos.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
				r.ProductionTransactionHistories = typedChildren.Where(b => b.ProductionTransactionHistory == r.Id).ToList();
				r.ProductionTransactionHistories.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
				r.ProductionProductReviews = typedChildren.Where(b => b.ProductionProductReview == r.Id).ToList();
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
			//Child Id Type: int
			//Child Type: PurchasingProductVendor

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingProductVendor>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PurchasingProductVendors = typedChildren.Where(b => b.PurchasingProductVendor == r.Id).ToList();
				r.PurchasingProductVendors.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
				r.ProductionWorkOrders = typedChildren.Where(b => b.ProductionWorkOrder == r.Id).ToList();
				r.ProductionWorkOrders.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
			//Child Id Type: int
			//Child Type: PurchasingPurchaseOrderDetail

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingPurchaseOrderDetail>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PurchasingPurchaseOrderDetails = typedChildren.Where(b => b.PurchasingPurchaseOrderDetail == r.Id).ToList();
				r.PurchasingPurchaseOrderDetails.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
			//Child Id Type: int
			//Child Type: ProductionProductCostHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductCostHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductCostHistories = typedChildren.Where(b => b.ProductionProductCostHistory == r.Id).ToList();
				r.ProductionProductCostHistories.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
				r.SalesShoppingCartItems = typedChildren.Where(b => b.SalesShoppingCartItem == r.Id).ToList();
				r.SalesShoppingCartItems.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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
			//Child Id Type: int
			//Child Type: ProductionProductDocument

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductDocument>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductDocuments = typedChildren.Where(b => b.ProductionProductDocument == r.Id).ToList();
				r.ProductionProductDocuments.ToList().ForEach(b => { b.Loaded = false; b.ProductionProduct = r; b.Loaded = true; });
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
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
        public override IEntityReader<int, ProductionProduct> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetProductionProductInventoryReader(), id, IdColumn, SetChildrenProductionProductInventories);
			
			WithChildForParentId(GetProductionProductListPriceHistoryReader(), id, IdColumn, SetChildrenProductionProductListPriceHistories);
			
			WithChildForParentId(GetSalesSpecialOfferProductReader(), id, IdColumn, SetChildrenSalesSpecialOfferProducts);
			
			WithChildForParentId(GetProductionProductProductPhotoReader(), id, IdColumn, SetChildrenProductionProductProductPhotos);
			
			WithChildForParentId(GetProductionTransactionHistoryReader(), id, IdColumn, SetChildrenProductionTransactionHistories);
			
			WithChildForParentId(GetProductionProductReviewReader(), id, IdColumn, SetChildrenProductionProductReviews);
			
			WithChildForParentId(GetPurchasingProductVendorReader(), id, IdColumn, SetChildrenPurchasingProductVendors);
			
			WithChildForParentId(GetProductionWorkOrderReader(), id, IdColumn, SetChildrenProductionWorkOrders);
			
			WithChildForParentId(GetPurchasingPurchaseOrderDetailReader(), id, IdColumn, SetChildrenPurchasingPurchaseOrderDetails);
			
			WithChildForParentId(GetProductionProductCostHistoryReader(), id, IdColumn, SetChildrenProductionProductCostHistories);
			
			WithChildForParentId(GetSalesShoppingCartItemReader(), id, IdColumn, SetChildrenSalesShoppingCartItems);
			
			WithChildForParentId(GetProductionProductDocumentReader(), id, IdColumn, SetChildrenProductionProductDocuments);
			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionProduct entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetProductionProductInventoryReader(), entity.Id
				, ProductionProductInventoryColumnNames.ProductID.ToString()
				, SetChildrenProductionProductInventories);

			WithChildForParentId(GetProductionProductListPriceHistoryReader(), entity.Id
				, ProductionProductListPriceHistoryColumnNames.ProductID.ToString()
				, SetChildrenProductionProductListPriceHistories);

			WithChildForParentId(GetSalesSpecialOfferProductReader(), entity.Id
				, SalesSpecialOfferProductColumnNames.ProductID.ToString()
				, SetChildrenSalesSpecialOfferProducts);

			WithChildForParentId(GetProductionProductProductPhotoReader(), entity.Id
				, ProductionProductProductPhotoColumnNames.ProductID.ToString()
				, SetChildrenProductionProductProductPhotos);

			WithChildForParentId(GetProductionTransactionHistoryReader(), entity.Id
				, ProductionTransactionHistoryColumnNames.ProductID.ToString()
				, SetChildrenProductionTransactionHistories);

			WithChildForParentId(GetProductionProductReviewReader(), entity.Id
				, ProductionProductReviewColumnNames.ProductID.ToString()
				, SetChildrenProductionProductReviews);

			WithChildForParentId(GetPurchasingProductVendorReader(), entity.Id
				, PurchasingProductVendorColumnNames.ProductID.ToString()
				, SetChildrenPurchasingProductVendors);

			WithChildForParentId(GetProductionWorkOrderReader(), entity.Id
				, ProductionWorkOrderColumnNames.ProductID.ToString()
				, SetChildrenProductionWorkOrders);

			WithChildForParentId(GetPurchasingPurchaseOrderDetailReader(), entity.Id
				, PurchasingPurchaseOrderDetailColumnNames.ProductID.ToString()
				, SetChildrenPurchasingPurchaseOrderDetails);

			WithChildForParentId(GetProductionProductCostHistoryReader(), entity.Id
				, ProductionProductCostHistoryColumnNames.ProductID.ToString()
				, SetChildrenProductionProductCostHistories);

			WithChildForParentId(GetSalesShoppingCartItemReader(), entity.Id
				, SalesShoppingCartItemColumnNames.ProductID.ToString()
				, SetChildrenSalesShoppingCartItems);

			WithChildForParentId(GetProductionProductDocumentReader(), entity.Id
				, ProductionProductDocumentColumnNames.ProductID.ToString()
				, SetChildrenProductionProductDocuments);

			QueryResultForChildrenOnly(new List<ProductionProduct>() { entity });
			entity.Loaded = false;
			GetProductionProductInventoryReader().SetAllChildrenForExisting(entity.ProductionProductInventories);
			GetProductionProductListPriceHistoryReader().SetAllChildrenForExisting(entity.ProductionProductListPriceHistories);
			GetSalesSpecialOfferProductReader().SetAllChildrenForExisting(entity.SalesSpecialOfferProducts);
			GetProductionProductProductPhotoReader().SetAllChildrenForExisting(entity.ProductionProductProductPhotos);
			GetProductionTransactionHistoryReader().SetAllChildrenForExisting(entity.ProductionTransactionHistories);
			GetProductionProductReviewReader().SetAllChildrenForExisting(entity.ProductionProductReviews);
			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entity.PurchasingProductVendors);
			GetProductionWorkOrderReader().SetAllChildrenForExisting(entity.ProductionWorkOrders);
			GetPurchasingPurchaseOrderDetailReader().SetAllChildrenForExisting(entity.PurchasingPurchaseOrderDetails);
			GetProductionProductCostHistoryReader().SetAllChildrenForExisting(entity.ProductionProductCostHistories);
			GetSalesShoppingCartItemReader().SetAllChildrenForExisting(entity.SalesShoppingCartItems);
			GetProductionProductDocumentReader().SetAllChildrenForExisting(entity.ProductionProductDocuments);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProduct> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetProductionProductInventoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductInventoryColumnNames.ProductID.ToString()
				, SetChildrenProductionProductInventories);

			WithChildForParentIds(GetProductionProductListPriceHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductListPriceHistoryColumnNames.ProductID.ToString()
				, SetChildrenProductionProductListPriceHistories);

			WithChildForParentIds(GetSalesSpecialOfferProductReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSpecialOfferProductColumnNames.ProductID.ToString()
				, SetChildrenSalesSpecialOfferProducts);

			WithChildForParentIds(GetProductionProductProductPhotoReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductProductPhotoColumnNames.ProductID.ToString()
				, SetChildrenProductionProductProductPhotos);

			WithChildForParentIds(GetProductionTransactionHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionTransactionHistoryColumnNames.ProductID.ToString()
				, SetChildrenProductionTransactionHistories);

			WithChildForParentIds(GetProductionProductReviewReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductReviewColumnNames.ProductID.ToString()
				, SetChildrenProductionProductReviews);

			WithChildForParentIds(GetPurchasingProductVendorReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingProductVendorColumnNames.ProductID.ToString()
				, SetChildrenPurchasingProductVendors);

			WithChildForParentIds(GetProductionWorkOrderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionWorkOrderColumnNames.ProductID.ToString()
				, SetChildrenProductionWorkOrders);

			WithChildForParentIds(GetPurchasingPurchaseOrderDetailReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingPurchaseOrderDetailColumnNames.ProductID.ToString()
				, SetChildrenPurchasingPurchaseOrderDetails);

			WithChildForParentIds(GetProductionProductCostHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductCostHistoryColumnNames.ProductID.ToString()
				, SetChildrenProductionProductCostHistories);

			WithChildForParentIds(GetSalesShoppingCartItemReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesShoppingCartItemColumnNames.ProductID.ToString()
				, SetChildrenSalesShoppingCartItems);

			WithChildForParentIds(GetProductionProductDocumentReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductDocumentColumnNames.ProductID.ToString()
				, SetChildrenProductionProductDocuments);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductInventoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductInventories).ToList());
			GetProductionProductListPriceHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductListPriceHistories).ToList());
			GetSalesSpecialOfferProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSpecialOfferProducts).ToList());
			GetProductionProductProductPhotoReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductProductPhotos).ToList());
			GetProductionTransactionHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionTransactionHistories).ToList());
			GetProductionProductReviewReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductReviews).ToList());
			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingProductVendors).ToList());
			GetProductionWorkOrderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionWorkOrders).ToList());
			GetPurchasingPurchaseOrderDetailReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingPurchaseOrderDetails).ToList());
			GetProductionProductCostHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductCostHistories).ToList());
			GetSalesShoppingCartItemReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesShoppingCartItems).ToList());
			GetProductionProductDocumentReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductDocuments).ToList());
					
		}
    }
}
		