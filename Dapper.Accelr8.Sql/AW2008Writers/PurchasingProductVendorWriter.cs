
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
    public class PurchasingProductVendorWriter : EntityWriter<int, PurchasingProductVendor>
    {
        public PurchasingProductVendorWriter
			(PurchasingProductVendorTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<string, ProductionUnitMeasure> GetProductionUnitMeasureWriter()
		{ return _locator.Resolve<IEntityWriter<string, ProductionUnitMeasure>>(); }
		static IEntityWriter<int, PurchasingVendor> GetPurchasingVendorWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingVendor>>(); }
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProduct>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PurchasingProductVendor entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PurchasingProductVendorColumnNames)f.Key)
                {
                    
					case PurchasingProductVendorColumnNames.AverageLeadTime:
						parms.Add(GetParamName("AverageLeadTime", actionType, taskIndex, ref count), entity.AverageLeadTime);
						break;
					case PurchasingProductVendorColumnNames.StandardPrice:
						parms.Add(GetParamName("StandardPrice", actionType, taskIndex, ref count), entity.StandardPrice);
						break;
					case PurchasingProductVendorColumnNames.LastReceiptCost:
						parms.Add(GetParamName("LastReceiptCost", actionType, taskIndex, ref count), entity.LastReceiptCost);
						break;
					case PurchasingProductVendorColumnNames.LastReceiptDate:
						parms.Add(GetParamName("LastReceiptDate", actionType, taskIndex, ref count), entity.LastReceiptDate);
						break;
					case PurchasingProductVendorColumnNames.MinOrderQty:
						parms.Add(GetParamName("MinOrderQty", actionType, taskIndex, ref count), entity.MinOrderQty);
						break;
					case PurchasingProductVendorColumnNames.MaxOrderQty:
						parms.Add(GetParamName("MaxOrderQty", actionType, taskIndex, ref count), entity.MaxOrderQty);
						break;
					case PurchasingProductVendorColumnNames.OnOrderQty:
						parms.Add(GetParamName("OnOrderQty", actionType, taskIndex, ref count), entity.OnOrderQty);
						break;
					case PurchasingProductVendorColumnNames.UnitMeasureCode:
						parms.Add(GetParamName("UnitMeasureCode", actionType, taskIndex, ref count), entity.UnitMeasureCode);
						break;
					case PurchasingProductVendorColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PurchasingProductVendor entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductVendor_UnitMeasure_UnitMeasureCode
			var productionUnitMeasure273 = GetProductionUnitMeasureWriter();
		if ((_cascades.Contains(PurchasingProductVendorCascadeNames.productionunitmeasure.ToString()) || _cascades.Contains("all")) && entity.ProductionUnitMeasure != null)
			if (Cascade(productionUnitMeasure273, entity.ProductionUnitMeasure, context))
				WithParent(productionUnitMeasure273, entity);

			//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID
			var purchasingVendor274 = GetPurchasingVendorWriter();
		if ((_cascades.Contains(PurchasingProductVendorCascadeNames.purchasingvendor.ToString()) || _cascades.Contains("all")) && entity.PurchasingVendor != null)
			if (Cascade(purchasingVendor274, entity.PurchasingVendor, context))
				WithParent(purchasingVendor274, entity);

			//From Foreign Key FK_ProductVendor_Product_ProductID
			var productionProduct275 = GetProductionProductWriter();
		if ((_cascades.Contains(PurchasingProductVendorCascadeNames.productionproduct.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct275, entity.ProductionProduct, context))
				WithParent(productionProduct275, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PurchasingProductVendor entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductVendor_UnitMeasure_UnitMeasureCode
			if (entity.ProductionUnitMeasure != null)
				entity.PurchasingProductVendor = entity.ProductionUnitMeasure.Id;

			//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID
			if (entity.PurchasingVendor != null)
				entity.PurchasingProductVendor = entity.PurchasingVendor.Id;

			//From Foreign Key FK_ProductVendor_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.PurchasingProductVendor = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(PurchasingProductVendor entity, ScriptContext context)
        {
				}
	}
}
		