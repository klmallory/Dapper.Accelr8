
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
    public class ProductionProductCostHistoryWriter : EntityWriter<CompoundKey, ProductionProductCostHistory>
    {
        public ProductionProductCostHistoryWriter
			(ProductionProductCostHistoryTableInfo tableInfo
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

		
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductCostHistory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductCostHistoryFieldNames)f.Key)
                {
                    
					case ProductionProductCostHistoryFieldNames.EndDate:
						parms.Add(GetParamName("EndDate", actionType, taskIndex, ref count), entity.EndDate);
						break;
					case ProductionProductCostHistoryFieldNames.StandardCost:
						parms.Add(GetParamName("StandardCost", actionType, taskIndex, ref count), entity.StandardCost);
						break;
					case ProductionProductCostHistoryFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductCostHistory entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductCostHistory_Product_ProductID
			var productionProduct227 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionProductCostHistoryCascadeNames.productionproduct_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct227, entity.ProductionProduct, context))
				WithParent(productionProduct227, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductCostHistory entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductCostHistory_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductID = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(ProductionProductCostHistory entity, ScriptContext context)
        {
				}
	}
}
		