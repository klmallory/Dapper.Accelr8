
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
    public class ProductionUnitMeasureWriter : EntityWriter<string, ProductionUnitMeasure>
    {
        public ProductionUnitMeasureWriter
			(ProductionUnitMeasureTableInfo tableInfo
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

		static IEntityWriter<int, PurchasingProductVendor> GetPurchasingProductVendorWriter()
		{ return s_loc8r.GetWriter<int, PurchasingProductVendor>(); }
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionUnitMeasure entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionUnitMeasureFieldNames)f.Key)
                {
                    
					case ProductionUnitMeasureFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case ProductionUnitMeasureFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionUnitMeasure entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductVendor_UnitMeasure_UnitMeasureCode
			var purchasingProductVendor414 = GetPurchasingProductVendorWriter();
			if (_cascades.Contains(ProductionUnitMeasureCascadeNames.purchasingproductvendors.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingProductVendors)
					Cascade(purchasingProductVendor414, item, context);

			if (purchasingProductVendor414.Count > 0)
				WithChild(purchasingProductVendor414, entity);

			//From Foreign Key FK_Product_UnitMeasure_SizeUnitMeasureCode
			var productionProduct415 = GetProductionProductWriter();
			if (_cascades.Contains(ProductionUnitMeasureCascadeNames.productionproducts1.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProducts1s)
					Cascade(productionProduct415, item, context);

			if (productionProduct415.Count > 0)
				WithChild(productionProduct415, entity);

			//From Foreign Key FK_Product_UnitMeasure_WeightUnitMeasureCode
			var productionProduct416 = GetProductionProductWriter();
			if (_cascades.Contains(ProductionUnitMeasureCascadeNames.productionproducts2.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProducts2s)
					Cascade(productionProduct416, item, context);

			if (productionProduct416.Count > 0)
				WithChild(productionProduct416, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionUnitMeasure entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductVendor_UnitMeasure_UnitMeasureCode
			if (entity.PurchasingProductVendors != null && entity.PurchasingProductVendors.Count > 0)
				foreach (var rel in entity.PurchasingProductVendors)
					rel.UnitMeasureCode = entity.Id;

			//From Foreign Key FK_Product_UnitMeasure_SizeUnitMeasureCode
			if (entity.ProductionProducts != null && entity.ProductionProducts.Count > 0)
				foreach (var rel in entity.ProductionProducts)
					rel.SizeUnitMeasureCode = entity.Id;

			//From Foreign Key FK_Product_UnitMeasure_WeightUnitMeasureCode
			if (entity.ProductionProducts != null && entity.ProductionProducts.Count > 0)
				foreach (var rel in entity.ProductionProducts)
					rel.WeightUnitMeasureCode = entity.Id;

				
		}

		protected override void RemoveRelations(ProductionUnitMeasure entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductVendor_UnitMeasure_UnitMeasureCode
			var purchasingProductVendor420 = GetPurchasingProductVendorWriter();
			if (_cascades.Contains(ProductionUnitMeasureCascadeNames.purchasingproductvendor.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingProductVendors)
					CascadeDelete(purchasingProductVendor420, item, context);

			if (purchasingProductVendor420.Count > 0)
				WithChild(purchasingProductVendor420, entity);

					//From Foreign Key FK_Product_UnitMeasure_SizeUnitMeasureCode
			var productionProduct421 = GetProductionProductWriter();
			if (_cascades.Contains(ProductionUnitMeasureCascadeNames.productionproduct.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProducts)
					CascadeDelete(productionProduct421, item, context);

			if (productionProduct421.Count > 0)
				WithChild(productionProduct421, entity);

					//From Foreign Key FK_Product_UnitMeasure_WeightUnitMeasureCode
			var productionProduct422 = GetProductionProductWriter();
			if (_cascades.Contains(ProductionUnitMeasureCascadeNames.productionproduct.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProducts)
					CascadeDelete(productionProduct422, item, context);

			if (productionProduct422.Count > 0)
				WithChild(productionProduct422, entity);

				}
	}
}
		