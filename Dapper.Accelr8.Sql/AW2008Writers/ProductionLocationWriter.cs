
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
    public class ProductionLocationWriter : EntityWriter<short, ProductionLocation>
    {
        public ProductionLocationWriter
			(ProductionLocationTableInfo tableInfo
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
		static IEntityWriter<int, ProductionWorkOrderRouting> GetProductionWorkOrderRoutingWriter()
		{ return s_loc8r.GetWriter<int, ProductionWorkOrderRouting>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionLocation entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionLocationFieldNames)f.Key)
                {
                    
					case ProductionLocationFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case ProductionLocationFieldNames.CostRate:
						parms.Add(GetParamName("CostRate", actionType, taskIndex, ref count), entity.CostRate);
						break;
					case ProductionLocationFieldNames.Availability:
						parms.Add(GetParamName("Availability", actionType, taskIndex, ref count), entity.Availability);
						break;
					case ProductionLocationFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionLocation entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductInventory_Location_LocationID
			var productionProductInventory138 = GetProductionProductInventoryWriter();
			if (_cascades.Contains(ProductionLocationCascadeNames.productionproductinventories.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductInventories)
					Cascade(productionProductInventory138, item, context);

			if (productionProductInventory138.Count > 0)
				WithChild(productionProductInventory138, entity);

			//From Foreign Key FK_WorkOrderRouting_Location_LocationID
			var productionWorkOrderRouting139 = GetProductionWorkOrderRoutingWriter();
			if (_cascades.Contains(ProductionLocationCascadeNames.productionworkorderroutings.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionWorkOrderRoutings)
					Cascade(productionWorkOrderRouting139, item, context);

			if (productionWorkOrderRouting139.Count > 0)
				WithChild(productionWorkOrderRouting139, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionLocation entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductInventory_Location_LocationID
			if (entity.ProductionProductInventories != null && entity.ProductionProductInventories.Count > 0)
				foreach (var rel in entity.ProductionProductInventories)
					rel.LocationID = entity.Id;

			//From Foreign Key FK_WorkOrderRouting_Location_LocationID
			if (entity.ProductionWorkOrderRoutings != null && entity.ProductionWorkOrderRoutings.Count > 0)
				foreach (var rel in entity.ProductionWorkOrderRoutings)
					rel.LocationID = entity.Id;

				
		}

		protected override void RemoveRelations(ProductionLocation entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductInventory_Location_LocationID
			var productionProductInventory142 = GetProductionProductInventoryWriter();
			if (_cascades.Contains(ProductionLocationCascadeNames.productionproductinventory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductInventories)
					CascadeDelete(productionProductInventory142, item, context);

			if (productionProductInventory142.Count > 0)
				WithChild(productionProductInventory142, entity);

					//From Foreign Key FK_WorkOrderRouting_Location_LocationID
			var productionWorkOrderRouting143 = GetProductionWorkOrderRoutingWriter();
			if (_cascades.Contains(ProductionLocationCascadeNames.productionworkorderrouting.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionWorkOrderRoutings)
					CascadeDelete(productionWorkOrderRouting143, item, context);

			if (productionWorkOrderRouting143.Count > 0)
				WithChild(productionWorkOrderRouting143, entity);

				}
	}
}
		