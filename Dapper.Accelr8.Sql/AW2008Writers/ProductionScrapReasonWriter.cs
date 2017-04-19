
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
    public class ProductionScrapReasonWriter : EntityWriter<short, ProductionScrapReason>
    {
        public ProductionScrapReasonWriter
			(ProductionScrapReasonTableInfo tableInfo
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
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionScrapReason entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionScrapReasonFieldNames)f.Key)
                {
                    
					case ProductionScrapReasonFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case ProductionScrapReasonFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionScrapReason entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_WorkOrder_ScrapReason_ScrapReasonID
			var productionWorkOrder368 = GetProductionWorkOrderWriter();
			if (_cascades.Contains(ProductionScrapReasonCascadeNames.productionworkorders.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionWorkOrders)
					Cascade(productionWorkOrder368, item, context);

			if (productionWorkOrder368.Count > 0)
				WithChild(productionWorkOrder368, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionScrapReason entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_WorkOrder_ScrapReason_ScrapReasonID
			if (entity.ProductionWorkOrders != null && entity.ProductionWorkOrders.Count > 0)
				foreach (var rel in entity.ProductionWorkOrders)
					rel.ScrapReasonID = entity.Id;

				
		}

		protected override void RemoveRelations(ProductionScrapReason entity, ScriptContext context)
        {
					//From Foreign Key FK_WorkOrder_ScrapReason_ScrapReasonID
			var productionWorkOrder370 = GetProductionWorkOrderWriter();
			if (_cascades.Contains(ProductionScrapReasonCascadeNames.productionworkorder.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionWorkOrders)
					CascadeDelete(productionWorkOrder370, item, context);

			if (productionWorkOrder370.Count > 0)
				WithChild(productionWorkOrder370, entity);

				}
	}
}
		