
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
    public class ProductionWorkOrderRoutingWriter : EntityWriter<CompoundKey, ProductionWorkOrderRouting>
    {
        public ProductionWorkOrderRoutingWriter
			(ProductionWorkOrderRoutingTableInfo tableInfo
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

		
		static IEntityWriter<int, ProductionWorkOrder> GetProductionWorkOrderWriter()
		{ return s_loc8r.GetWriter<int, ProductionWorkOrder>(); }
		static IEntityWriter<short, ProductionLocation> GetProductionLocationWriter()
		{ return s_loc8r.GetWriter<short, ProductionLocation>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionWorkOrderRouting entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionWorkOrderRoutingFieldNames)f.Key)
                {
                    
					case ProductionWorkOrderRoutingFieldNames.LocationID:
						parms.Add(GetParamName("LocationID", actionType, taskIndex, ref count), entity.LocationID);
						break;
					case ProductionWorkOrderRoutingFieldNames.ScheduledStartDate:
						parms.Add(GetParamName("ScheduledStartDate", actionType, taskIndex, ref count), entity.ScheduledStartDate);
						break;
					case ProductionWorkOrderRoutingFieldNames.ScheduledEndDate:
						parms.Add(GetParamName("ScheduledEndDate", actionType, taskIndex, ref count), entity.ScheduledEndDate);
						break;
					case ProductionWorkOrderRoutingFieldNames.ActualStartDate:
						parms.Add(GetParamName("ActualStartDate", actionType, taskIndex, ref count), entity.ActualStartDate);
						break;
					case ProductionWorkOrderRoutingFieldNames.ActualEndDate:
						parms.Add(GetParamName("ActualEndDate", actionType, taskIndex, ref count), entity.ActualEndDate);
						break;
					case ProductionWorkOrderRoutingFieldNames.ActualResourceHrs:
						parms.Add(GetParamName("ActualResourceHrs", actionType, taskIndex, ref count), entity.ActualResourceHrs);
						break;
					case ProductionWorkOrderRoutingFieldNames.PlannedCost:
						parms.Add(GetParamName("PlannedCost", actionType, taskIndex, ref count), entity.PlannedCost);
						break;
					case ProductionWorkOrderRoutingFieldNames.ActualCost:
						parms.Add(GetParamName("ActualCost", actionType, taskIndex, ref count), entity.ActualCost);
						break;
					case ProductionWorkOrderRoutingFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionWorkOrderRouting entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_WorkOrderRouting_WorkOrder_WorkOrderID
			var productionWorkOrder438 = GetProductionWorkOrderWriter();
		if ((_cascades.Contains(ProductionWorkOrderRoutingCascadeNames.productionworkorder_p.ToString()) || _cascades.Contains("all")) && entity.ProductionWorkOrder != null)
			if (Cascade(productionWorkOrder438, entity.ProductionWorkOrder, context))
				WithParent(productionWorkOrder438, entity);

			//From Foreign Key FK_WorkOrderRouting_Location_LocationID
			var productionLocation439 = GetProductionLocationWriter();
		if ((_cascades.Contains(ProductionWorkOrderRoutingCascadeNames.productionlocation_p.ToString()) || _cascades.Contains("all")) && entity.ProductionLocation != null)
			if (Cascade(productionLocation439, entity.ProductionLocation, context))
				WithParent(productionLocation439, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionWorkOrderRouting entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_WorkOrderRouting_WorkOrder_WorkOrderID
			if (entity.ProductionWorkOrder != null)
				entity.WorkOrderID = entity.ProductionWorkOrder.Id;

			//From Foreign Key FK_WorkOrderRouting_Location_LocationID
			if (entity.ProductionLocation != null)
				entity.LocationID = entity.ProductionLocation.Id;

		}

		protected override void RemoveRelations(ProductionWorkOrderRouting entity, ScriptContext context)
        {
				}
	}
}
		