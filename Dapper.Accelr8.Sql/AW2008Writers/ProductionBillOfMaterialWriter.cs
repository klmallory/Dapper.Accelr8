
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
    public class ProductionBillOfMaterialWriter : EntityWriter<int, ProductionBillOfMaterial>
    {
        public ProductionBillOfMaterialWriter
			(ProductionBillOfMaterialTableInfo tableInfo
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
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProduct>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionBillOfMaterial entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionBillOfMaterialColumnNames)f.Key)
                {
                    
					case ProductionBillOfMaterialColumnNames.ProductAssemblyID:
						parms.Add(GetParamName("ProductAssemblyID", actionType, taskIndex, ref count), entity.ProductAssemblyID);
						break;
					case ProductionBillOfMaterialColumnNames.ComponentID:
						parms.Add(GetParamName("ComponentID", actionType, taskIndex, ref count), entity.ComponentID);
						break;
					case ProductionBillOfMaterialColumnNames.StartDate:
						parms.Add(GetParamName("StartDate", actionType, taskIndex, ref count), entity.StartDate);
						break;
					case ProductionBillOfMaterialColumnNames.EndDate:
						parms.Add(GetParamName("EndDate", actionType, taskIndex, ref count), entity.EndDate);
						break;
					case ProductionBillOfMaterialColumnNames.UnitMeasureCode:
						parms.Add(GetParamName("UnitMeasureCode", actionType, taskIndex, ref count), entity.UnitMeasureCode);
						break;
					case ProductionBillOfMaterialColumnNames.BOMLevel:
						parms.Add(GetParamName("BOMLevel", actionType, taskIndex, ref count), entity.BOMLevel);
						break;
					case ProductionBillOfMaterialColumnNames.PerAssemblyQty:
						parms.Add(GetParamName("PerAssemblyQty", actionType, taskIndex, ref count), entity.PerAssemblyQty);
						break;
					case ProductionBillOfMaterialColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionBillOfMaterial entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_BillOfMaterials_UnitMeasure_UnitMeasureCode
			var productionUnitMeasure15 = GetProductionUnitMeasureWriter();
		if ((_cascades.Contains(ProductionBillOfMaterialCascadeNames.productionunitmeasure.ToString()) || _cascades.Contains("all")) && entity.ProductionUnitMeasure != null)
			if (Cascade(productionUnitMeasure15, entity.ProductionUnitMeasure, context))
				WithParent(productionUnitMeasure15, entity);

			//From Foreign Key FK_BillOfMaterials_Product_ProductAssemblyID
			var productionProduct16 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionBillOfMaterialCascadeNames.productionproduct.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct16, entity.ProductionProduct, context))
				WithParent(productionProduct16, entity);

			//From Foreign Key FK_BillOfMaterials_Product_ComponentID
			var productionProduct17 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionBillOfMaterialCascadeNames.productionproduct.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct17, entity.ProductionProduct, context))
				WithParent(productionProduct17, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionBillOfMaterial entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_BillOfMaterials_UnitMeasure_UnitMeasureCode
			if (entity.ProductionUnitMeasure != null)
				entity.ProductionBillOfMaterial = entity.ProductionUnitMeasure.Id;

			//From Foreign Key FK_BillOfMaterials_Product_ProductAssemblyID
			if (entity.ProductionProduct != null)
				entity.ProductionBillOfMaterial = entity.ProductionProduct.Id;

			//From Foreign Key FK_BillOfMaterials_Product_ComponentID
			if (entity.ProductionProduct != null)
				entity.ProductionBillOfMaterial = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(ProductionBillOfMaterial entity, ScriptContext context)
        {
				}
	}
}
		