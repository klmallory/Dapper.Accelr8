
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
    public class PurchasingProductVendorWriter : EntityWriter<CompoundKey, PurchasingProductVendor>
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
			if (s_loc8r == null)
				s_loc8r = loc8r;
		}

		static ILoc8 s_loc8r = null;

		
		static IEntityWriter<string, ProductionUnitMeasure> GetProductionUnitMeasureWriter()
		{ return s_loc8r.GetWriter<string, ProductionUnitMeasure>(); }
		static IEntityWriter<int, PurchasingVendor> GetPurchasingVendorWriter()
		{ return s_loc8r.GetWriter<int, PurchasingVendor>(); }
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		
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
                switch ((PurchasingProductVendorFieldNames)f.Key)
                {
                    
					case PurchasingProductVendorFieldNames.AverageLeadTime:
						parms.Add(GetParamName("AverageLeadTime", actionType, taskIndex, ref count), entity.AverageLeadTime);
						break;
					case PurchasingProductVendorFieldNames.StandardPrice:
						parms.Add(GetParamName("StandardPrice", actionType, taskIndex, ref count), entity.StandardPrice);
						break;
					case PurchasingProductVendorFieldNames.LastReceiptCost:
						parms.Add(GetParamName("LastReceiptCost", actionType, taskIndex, ref count), entity.LastReceiptCost);
						break;
					case PurchasingProductVendorFieldNames.LastReceiptDate:
						parms.Add(GetParamName("LastReceiptDate", actionType, taskIndex, ref count), entity.LastReceiptDate);
						break;
					case PurchasingProductVendorFieldNames.MinOrderQty:
						parms.Add(GetParamName("MinOrderQty", actionType, taskIndex, ref count), entity.MinOrderQty);
						break;
					case PurchasingProductVendorFieldNames.MaxOrderQty:
						parms.Add(GetParamName("MaxOrderQty", actionType, taskIndex, ref count), entity.MaxOrderQty);
						break;
					case PurchasingProductVendorFieldNames.OnOrderQty:
						parms.Add(GetParamName("OnOrderQty", actionType, taskIndex, ref count), entity.OnOrderQty);
						break;
					case PurchasingProductVendorFieldNames.UnitMeasureCode:
						parms.Add(GetParamName("UnitMeasureCode", actionType, taskIndex, ref count), entity.UnitMeasureCode);
						break;
					case PurchasingProductVendorFieldNames.ModifiedDate:
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
		if ((_cascades.Contains(PurchasingProductVendorCascadeNames.productionunitmeasure_p.ToString()) || _cascades.Contains("all")) && entity.ProductionUnitMeasure != null)
			if (Cascade(productionUnitMeasure273, entity.ProductionUnitMeasure, context))
				WithParent(productionUnitMeasure273, entity);

			//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID
			var purchasingVendor274 = GetPurchasingVendorWriter();
		if ((_cascades.Contains(PurchasingProductVendorCascadeNames.purchasingvendor_p.ToString()) || _cascades.Contains("all")) && entity.PurchasingVendor != null)
			if (Cascade(purchasingVendor274, entity.PurchasingVendor, context))
				WithParent(purchasingVendor274, entity);

			//From Foreign Key FK_ProductVendor_Product_ProductID
			var productionProduct275 = GetProductionProductWriter();
		if ((_cascades.Contains(PurchasingProductVendorCascadeNames.productionproduct_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct275, entity.ProductionProduct, context))
				WithParent(productionProduct275, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PurchasingProductVendor entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductVendor_UnitMeasure_UnitMeasureCode
			if (entity.ProductionUnitMeasure != null)
				entity.UnitMeasureCode = entity.ProductionUnitMeasure.Id;

			//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID
			if (entity.PurchasingVendor != null)
				entity.BusinessEntityID = entity.PurchasingVendor.Id;

			//From Foreign Key FK_ProductVendor_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductID = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(PurchasingProductVendor entity, ScriptContext context)
        {
				}
	}
}
		