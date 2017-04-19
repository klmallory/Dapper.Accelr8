
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
    public class ProductionProductInventoryWriter : EntityWriter<CompoundKey, ProductionProductInventory>
    {
        public ProductionProductInventoryWriter
			(ProductionProductInventoryTableInfo tableInfo
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

		
		static IEntityWriter<short, ProductionLocation> GetProductionLocationWriter()
		{ return s_loc8r.GetWriter<short, ProductionLocation>(); }
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductInventory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductInventoryFieldNames)f.Key)
                {
                    
					case ProductionProductInventoryFieldNames.Shelf:
						parms.Add(GetParamName("Shelf", actionType, taskIndex, ref count), entity.Shelf);
						break;
					case ProductionProductInventoryFieldNames.Bin:
						parms.Add(GetParamName("Bin", actionType, taskIndex, ref count), entity.Bin);
						break;
					case ProductionProductInventoryFieldNames.Quantity:
						parms.Add(GetParamName("Quantity", actionType, taskIndex, ref count), entity.Quantity);
						break;
					case ProductionProductInventoryFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case ProductionProductInventoryFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductInventory entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductInventory_Location_LocationID
			var productionLocation234 = GetProductionLocationWriter();
		if ((_cascades.Contains(ProductionProductInventoryCascadeNames.productionlocation_p.ToString()) || _cascades.Contains("all")) && entity.ProductionLocation != null)
			if (Cascade(productionLocation234, entity.ProductionLocation, context))
				WithParent(productionLocation234, entity);

			//From Foreign Key FK_ProductInventory_Product_ProductID
			var productionProduct235 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionProductInventoryCascadeNames.productionproduct_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct235, entity.ProductionProduct, context))
				WithParent(productionProduct235, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductInventory entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductInventory_Location_LocationID
			if (entity.ProductionLocation != null)
				entity.LocationID = entity.ProductionLocation.Id;

			//From Foreign Key FK_ProductInventory_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductID = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(ProductionProductInventory entity, ScriptContext context)
        {
				}
	}
}
		