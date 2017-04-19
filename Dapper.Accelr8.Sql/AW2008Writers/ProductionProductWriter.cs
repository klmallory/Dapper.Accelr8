
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

namespace Dapper.Accelr8.AW2008Writers
{
    public class ProductionProductWriter : EntityWriter<int, ProductionProduct>
    {
        public ProductionProductWriter
			(ProductionProductTableInfo tableInfo
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

		static IEntityWriter<int, ProductionProductInventory> GetProductionProductInventoryWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductInventory>(); }
		static IEntityWriter<int, ProductionProductListPriceHistory> GetProductionProductListPriceHistoryWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductListPriceHistory>(); }
		static IEntityWriter<int, SalesSpecialOfferProduct> GetSalesSpecialOfferProductWriter()
		{ return s_loc8r.GetWriter<int, SalesSpecialOfferProduct>(); }
		static IEntityWriter<int, ProductionProductProductPhoto> GetProductionProductProductPhotoWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductProductPhoto>(); }
		static IEntityWriter<int, ProductionTransactionHistory> GetProductionTransactionHistoryWriter()
		{ return s_loc8r.GetWriter<int, ProductionTransactionHistory>(); }
		static IEntityWriter<int, ProductionProductReview> GetProductionProductReviewWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductReview>(); }
		static IEntityWriter<int, PurchasingProductVendor> GetPurchasingProductVendorWriter()
		{ return s_loc8r.GetWriter<int, PurchasingProductVendor>(); }
		static IEntityWriter<int, ProductionWorkOrder> GetProductionWorkOrderWriter()
		{ return s_loc8r.GetWriter<int, ProductionWorkOrder>(); }
		static IEntityWriter<int, PurchasingPurchaseOrderDetail> GetPurchasingPurchaseOrderDetailWriter()
		{ return s_loc8r.GetWriter<int, PurchasingPurchaseOrderDetail>(); }
		static IEntityWriter<int, ProductionProductCostHistory> GetProductionProductCostHistoryWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductCostHistory>(); }
		static IEntityWriter<int, SalesShoppingCartItem> GetSalesShoppingCartItemWriter()
		{ return s_loc8r.GetWriter<int, SalesShoppingCartItem>(); }
		static IEntityWriter<int, ProductionProductDocument> GetProductionProductDocumentWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductDocument>(); }
		
		static IEntityWriter<int, ProductionProductModel> GetProductionProductModelWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductModel>(); }
		static IEntityWriter<int, ProductionProductSubcategory> GetProductionProductSubcategoryWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductSubcategory>(); }
		static IEntityWriter<string, ProductionUnitMeasure> GetProductionUnitMeasureWriter()
		{ return s_loc8r.GetWriter<string, ProductionUnitMeasure>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProduct entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductFieldNames)f.Key)
                {
                    
					case ProductionProductFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case ProductionProductFieldNames.ProductNumber:
						parms.Add(GetParamName("ProductNumber", actionType, taskIndex, ref count), entity.ProductNumber);
						break;
					case ProductionProductFieldNames.MakeFlag:
						parms.Add(GetParamName("MakeFlag", actionType, taskIndex, ref count), entity.MakeFlag);
						break;
					case ProductionProductFieldNames.FinishedGoodsFlag:
						parms.Add(GetParamName("FinishedGoodsFlag", actionType, taskIndex, ref count), entity.FinishedGoodsFlag);
						break;
					case ProductionProductFieldNames.Color:
						parms.Add(GetParamName("Color", actionType, taskIndex, ref count), entity.Color);
						break;
					case ProductionProductFieldNames.SafetyStockLevel:
						parms.Add(GetParamName("SafetyStockLevel", actionType, taskIndex, ref count), entity.SafetyStockLevel);
						break;
					case ProductionProductFieldNames.ReorderPoint:
						parms.Add(GetParamName("ReorderPoint", actionType, taskIndex, ref count), entity.ReorderPoint);
						break;
					case ProductionProductFieldNames.StandardCost:
						parms.Add(GetParamName("StandardCost", actionType, taskIndex, ref count), entity.StandardCost);
						break;
					case ProductionProductFieldNames.ListPrice:
						parms.Add(GetParamName("ListPrice", actionType, taskIndex, ref count), entity.ListPrice);
						break;
					case ProductionProductFieldNames.Size:
						parms.Add(GetParamName("Size", actionType, taskIndex, ref count), entity.Size);
						break;
					case ProductionProductFieldNames.SizeUnitMeasureCode:
						parms.Add(GetParamName("SizeUnitMeasureCode", actionType, taskIndex, ref count), entity.SizeUnitMeasureCode);
						break;
					case ProductionProductFieldNames.WeightUnitMeasureCode:
						parms.Add(GetParamName("WeightUnitMeasureCode", actionType, taskIndex, ref count), entity.WeightUnitMeasureCode);
						break;
					case ProductionProductFieldNames.Weight:
						parms.Add(GetParamName("Weight", actionType, taskIndex, ref count), entity.Weight);
						break;
					case ProductionProductFieldNames.DaysToManufacture:
						parms.Add(GetParamName("DaysToManufacture", actionType, taskIndex, ref count), entity.DaysToManufacture);
						break;
					case ProductionProductFieldNames.ProductLine:
						parms.Add(GetParamName("ProductLine", actionType, taskIndex, ref count), entity.ProductLine);
						break;
					case ProductionProductFieldNames.Class:
						parms.Add(GetParamName("Class", actionType, taskIndex, ref count), entity.Class);
						break;
					case ProductionProductFieldNames.Style:
						parms.Add(GetParamName("Style", actionType, taskIndex, ref count), entity.Style);
						break;
					case ProductionProductFieldNames.ProductSubcategoryID:
						parms.Add(GetParamName("ProductSubcategoryID", actionType, taskIndex, ref count), entity.ProductSubcategoryID);
						break;
					case ProductionProductFieldNames.ProductModelID:
						parms.Add(GetParamName("ProductModelID", actionType, taskIndex, ref count), entity.ProductModelID);
						break;
					case ProductionProductFieldNames.SellStartDate:
						parms.Add(GetParamName("SellStartDate", actionType, taskIndex, ref count), entity.SellStartDate);
						break;
					case ProductionProductFieldNames.SellEndDate:
						parms.Add(GetParamName("SellEndDate", actionType, taskIndex, ref count), entity.SellEndDate);
						break;
					case ProductionProductFieldNames.DiscontinuedDate:
						parms.Add(GetParamName("DiscontinuedDate", actionType, taskIndex, ref count), entity.DiscontinuedDate);
						break;
					case ProductionProductFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case ProductionProductFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProduct entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductInventory_Product_ProductID
			var productionProductInventory180 = GetProductionProductInventoryWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductinventories.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductInventories)
					Cascade(productionProductInventory180, item, context);

			if (productionProductInventory180.Count > 0)
				WithChild(productionProductInventory180, entity);

			//From Foreign Key FK_ProductListPriceHistory_Product_ProductID
			var productionProductListPriceHistory181 = GetProductionProductListPriceHistoryWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductlistpricehistories.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductListPriceHistories)
					Cascade(productionProductListPriceHistory181, item, context);

			if (productionProductListPriceHistory181.Count > 0)
				WithChild(productionProductListPriceHistory181, entity);

			//From Foreign Key FK_SpecialOfferProduct_Product_ProductID
			var salesSpecialOfferProduct182 = GetSalesSpecialOfferProductWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.salesspecialofferproducts.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSpecialOfferProducts)
					Cascade(salesSpecialOfferProduct182, item, context);

			if (salesSpecialOfferProduct182.Count > 0)
				WithChild(salesSpecialOfferProduct182, entity);

			//From Foreign Key FK_ProductProductPhoto_Product_ProductID
			var productionProductProductPhoto183 = GetProductionProductProductPhotoWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductproductphotos.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductProductPhotos)
					Cascade(productionProductProductPhoto183, item, context);

			if (productionProductProductPhoto183.Count > 0)
				WithChild(productionProductProductPhoto183, entity);

			//From Foreign Key FK_TransactionHistory_Product_ProductID
			var productionTransactionHistory184 = GetProductionTransactionHistoryWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productiontransactionhistories.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionTransactionHistories)
					Cascade(productionTransactionHistory184, item, context);

			if (productionTransactionHistory184.Count > 0)
				WithChild(productionTransactionHistory184, entity);

			//From Foreign Key FK_ProductReview_Product_ProductID
			var productionProductReview185 = GetProductionProductReviewWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductreviews.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductReviews)
					Cascade(productionProductReview185, item, context);

			if (productionProductReview185.Count > 0)
				WithChild(productionProductReview185, entity);

			//From Foreign Key FK_ProductVendor_Product_ProductID
			var purchasingProductVendor186 = GetPurchasingProductVendorWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.purchasingproductvendors.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingProductVendors)
					Cascade(purchasingProductVendor186, item, context);

			if (purchasingProductVendor186.Count > 0)
				WithChild(purchasingProductVendor186, entity);

			//From Foreign Key FK_WorkOrder_Product_ProductID
			var productionWorkOrder187 = GetProductionWorkOrderWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionworkorders.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionWorkOrders)
					Cascade(productionWorkOrder187, item, context);

			if (productionWorkOrder187.Count > 0)
				WithChild(productionWorkOrder187, entity);

			//From Foreign Key FK_PurchaseOrderDetail_Product_ProductID
			var purchasingPurchaseOrderDetail188 = GetPurchasingPurchaseOrderDetailWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.purchasingpurchaseorderdetails.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderDetails)
					Cascade(purchasingPurchaseOrderDetail188, item, context);

			if (purchasingPurchaseOrderDetail188.Count > 0)
				WithChild(purchasingPurchaseOrderDetail188, entity);

			//From Foreign Key FK_ProductCostHistory_Product_ProductID
			var productionProductCostHistory189 = GetProductionProductCostHistoryWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductcosthistories.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductCostHistories)
					Cascade(productionProductCostHistory189, item, context);

			if (productionProductCostHistory189.Count > 0)
				WithChild(productionProductCostHistory189, entity);

			//From Foreign Key FK_ShoppingCartItem_Product_ProductID
			var salesShoppingCartItem190 = GetSalesShoppingCartItemWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.salesshoppingcartitems.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesShoppingCartItems)
					Cascade(salesShoppingCartItem190, item, context);

			if (salesShoppingCartItem190.Count > 0)
				WithChild(salesShoppingCartItem190, entity);

			//From Foreign Key FK_ProductDocument_Product_ProductID
			var productionProductDocument191 = GetProductionProductDocumentWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductdocuments.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductDocuments)
					Cascade(productionProductDocument191, item, context);

			if (productionProductDocument191.Count > 0)
				WithChild(productionProductDocument191, entity);

		
		
			//From Foreign Key FK_Product_ProductModel_ProductModelID
			var productionProductModel192 = GetProductionProductModelWriter();
		if ((_cascades.Contains(ProductionProductCascadeNames.productionproductmodel_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProductModel != null)
			if (Cascade(productionProductModel192, entity.ProductionProductModel, context))
				WithParent(productionProductModel192, entity);

			//From Foreign Key FK_Product_ProductSubcategory_ProductSubcategoryID
			var productionProductSubcategory193 = GetProductionProductSubcategoryWriter();
		if ((_cascades.Contains(ProductionProductCascadeNames.productionproductsubcategory_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProductSubcategory != null)
			if (Cascade(productionProductSubcategory193, entity.ProductionProductSubcategory, context))
				WithParent(productionProductSubcategory193, entity);

			//From Foreign Key FK_Product_UnitMeasure_SizeUnitMeasureCode
			var productionUnitMeasure194 = GetProductionUnitMeasureWriter();
		if ((_cascades.Contains(ProductionProductCascadeNames.productionunitmeasure1_p.ToString()) || _cascades.Contains("all")) && entity.ProductionUnitMeasure1 != null)
			if (Cascade(productionUnitMeasure194, entity.ProductionUnitMeasure1, context))
				WithParent(productionUnitMeasure194, entity);

			//From Foreign Key FK_Product_UnitMeasure_WeightUnitMeasureCode
			var productionUnitMeasure195 = GetProductionUnitMeasureWriter();
		if ((_cascades.Contains(ProductionProductCascadeNames.productionunitmeasure2_p.ToString()) || _cascades.Contains("all")) && entity.ProductionUnitMeasure2 != null)
			if (Cascade(productionUnitMeasure195, entity.ProductionUnitMeasure2, context))
				WithParent(productionUnitMeasure195, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProduct entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductInventory_Product_ProductID
			if (entity.ProductionProductInventories != null && entity.ProductionProductInventories.Count > 0)
				foreach (var rel in entity.ProductionProductInventories)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_ProductListPriceHistory_Product_ProductID
			if (entity.ProductionProductListPriceHistories != null && entity.ProductionProductListPriceHistories.Count > 0)
				foreach (var rel in entity.ProductionProductListPriceHistories)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_SpecialOfferProduct_Product_ProductID
			if (entity.SalesSpecialOfferProducts != null && entity.SalesSpecialOfferProducts.Count > 0)
				foreach (var rel in entity.SalesSpecialOfferProducts)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_ProductProductPhoto_Product_ProductID
			if (entity.ProductionProductProductPhotos != null && entity.ProductionProductProductPhotos.Count > 0)
				foreach (var rel in entity.ProductionProductProductPhotos)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_TransactionHistory_Product_ProductID
			if (entity.ProductionTransactionHistories != null && entity.ProductionTransactionHistories.Count > 0)
				foreach (var rel in entity.ProductionTransactionHistories)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_ProductReview_Product_ProductID
			if (entity.ProductionProductReviews != null && entity.ProductionProductReviews.Count > 0)
				foreach (var rel in entity.ProductionProductReviews)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_ProductVendor_Product_ProductID
			if (entity.PurchasingProductVendors != null && entity.PurchasingProductVendors.Count > 0)
				foreach (var rel in entity.PurchasingProductVendors)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_WorkOrder_Product_ProductID
			if (entity.ProductionWorkOrders != null && entity.ProductionWorkOrders.Count > 0)
				foreach (var rel in entity.ProductionWorkOrders)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_PurchaseOrderDetail_Product_ProductID
			if (entity.PurchasingPurchaseOrderDetails != null && entity.PurchasingPurchaseOrderDetails.Count > 0)
				foreach (var rel in entity.PurchasingPurchaseOrderDetails)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_ProductCostHistory_Product_ProductID
			if (entity.ProductionProductCostHistories != null && entity.ProductionProductCostHistories.Count > 0)
				foreach (var rel in entity.ProductionProductCostHistories)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_ShoppingCartItem_Product_ProductID
			if (entity.SalesShoppingCartItems != null && entity.SalesShoppingCartItems.Count > 0)
				foreach (var rel in entity.SalesShoppingCartItems)
					rel.ProductID = entity.Id;

			//From Foreign Key FK_ProductDocument_Product_ProductID
			if (entity.ProductionProductDocuments != null && entity.ProductionProductDocuments.Count > 0)
				foreach (var rel in entity.ProductionProductDocuments)
					rel.ProductID = entity.Id;

				
			//From Foreign Key FK_Product_ProductModel_ProductModelID
			if (entity.ProductionProductModel != null)
				entity.ProductModelID = entity.ProductionProductModel.Id;

			//From Foreign Key FK_Product_ProductSubcategory_ProductSubcategoryID
			if (entity.ProductionProductSubcategory != null)
				entity.ProductSubcategoryID = entity.ProductionProductSubcategory.Id;

			//From Foreign Key FK_Product_UnitMeasure_SizeUnitMeasureCode
			if (entity.ProductionUnitMeasure1 != null)
				entity.SizeUnitMeasureCode = entity.ProductionUnitMeasure1.Id;

			//From Foreign Key FK_Product_UnitMeasure_WeightUnitMeasureCode
			if (entity.ProductionUnitMeasure2 != null)
				entity.WeightUnitMeasureCode = entity.ProductionUnitMeasure2.Id;

		}

		protected override void RemoveRelations(ProductionProduct entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductInventory_Product_ProductID
			var productionProductInventory212 = GetProductionProductInventoryWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductinventory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductInventories)
					CascadeDelete(productionProductInventory212, item, context);

			if (productionProductInventory212.Count > 0)
				WithChild(productionProductInventory212, entity);

					//From Foreign Key FK_ProductListPriceHistory_Product_ProductID
			var productionProductListPriceHistory213 = GetProductionProductListPriceHistoryWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductlistpricehistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductListPriceHistories)
					CascadeDelete(productionProductListPriceHistory213, item, context);

			if (productionProductListPriceHistory213.Count > 0)
				WithChild(productionProductListPriceHistory213, entity);

					//From Foreign Key FK_SpecialOfferProduct_Product_ProductID
			var salesSpecialOfferProduct214 = GetSalesSpecialOfferProductWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.salesspecialofferproduct.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSpecialOfferProducts)
					CascadeDelete(salesSpecialOfferProduct214, item, context);

			if (salesSpecialOfferProduct214.Count > 0)
				WithChild(salesSpecialOfferProduct214, entity);

					//From Foreign Key FK_ProductProductPhoto_Product_ProductID
			var productionProductProductPhoto215 = GetProductionProductProductPhotoWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductproductphoto.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductProductPhotos)
					CascadeDelete(productionProductProductPhoto215, item, context);

			if (productionProductProductPhoto215.Count > 0)
				WithChild(productionProductProductPhoto215, entity);

					//From Foreign Key FK_TransactionHistory_Product_ProductID
			var productionTransactionHistory216 = GetProductionTransactionHistoryWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productiontransactionhistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionTransactionHistories)
					CascadeDelete(productionTransactionHistory216, item, context);

			if (productionTransactionHistory216.Count > 0)
				WithChild(productionTransactionHistory216, entity);

					//From Foreign Key FK_ProductReview_Product_ProductID
			var productionProductReview217 = GetProductionProductReviewWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductreview.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductReviews)
					CascadeDelete(productionProductReview217, item, context);

			if (productionProductReview217.Count > 0)
				WithChild(productionProductReview217, entity);

					//From Foreign Key FK_ProductVendor_Product_ProductID
			var purchasingProductVendor218 = GetPurchasingProductVendorWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.purchasingproductvendor.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingProductVendors)
					CascadeDelete(purchasingProductVendor218, item, context);

			if (purchasingProductVendor218.Count > 0)
				WithChild(purchasingProductVendor218, entity);

					//From Foreign Key FK_WorkOrder_Product_ProductID
			var productionWorkOrder219 = GetProductionWorkOrderWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionworkorder.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionWorkOrders)
					CascadeDelete(productionWorkOrder219, item, context);

			if (productionWorkOrder219.Count > 0)
				WithChild(productionWorkOrder219, entity);

					//From Foreign Key FK_PurchaseOrderDetail_Product_ProductID
			var purchasingPurchaseOrderDetail220 = GetPurchasingPurchaseOrderDetailWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.purchasingpurchaseorderdetail.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderDetails)
					CascadeDelete(purchasingPurchaseOrderDetail220, item, context);

			if (purchasingPurchaseOrderDetail220.Count > 0)
				WithChild(purchasingPurchaseOrderDetail220, entity);

					//From Foreign Key FK_ProductCostHistory_Product_ProductID
			var productionProductCostHistory221 = GetProductionProductCostHistoryWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductcosthistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductCostHistories)
					CascadeDelete(productionProductCostHistory221, item, context);

			if (productionProductCostHistory221.Count > 0)
				WithChild(productionProductCostHistory221, entity);

					//From Foreign Key FK_ShoppingCartItem_Product_ProductID
			var salesShoppingCartItem222 = GetSalesShoppingCartItemWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.salesshoppingcartitem.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesShoppingCartItems)
					CascadeDelete(salesShoppingCartItem222, item, context);

			if (salesShoppingCartItem222.Count > 0)
				WithChild(salesShoppingCartItem222, entity);

					//From Foreign Key FK_ProductDocument_Product_ProductID
			var productionProductDocument223 = GetProductionProductDocumentWriter();
			if (_cascades.Contains(ProductionProductCascadeNames.productionproductdocument.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductDocuments)
					CascadeDelete(productionProductDocument223, item, context);

			if (productionProductDocument223.Count > 0)
				WithChild(productionProductDocument223, entity);

				}
	}
}
		