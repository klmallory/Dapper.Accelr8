
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
    public class SalesSalesTerritoryHistoryWriter : EntityWriter<int, SalesSalesTerritoryHistory>
    {
        public SalesSalesTerritoryHistoryWriter
			(SalesSalesTerritoryHistoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, SalesSalesPerson> GetSalesSalesPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesPerson>>(); }
		static IEntityWriter<int, SalesSalesTerritory> GetSalesSalesTerritoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesTerritory>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesTerritoryHistory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesTerritoryHistoryColumnNames)f.Key)
                {
                    
					case SalesSalesTerritoryHistoryColumnNames.EndDate:
						parms.Add(GetParamName("EndDate", actionType, taskIndex, ref count), entity.EndDate);
						break;
					case SalesSalesTerritoryHistoryColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSalesTerritoryHistoryColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesTerritoryHistory entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID
			var salesSalesPerson364 = GetSalesSalesPersonWriter();
		if ((_cascades.Contains(SalesSalesTerritoryHistoryCascadeNames.salessalesperson.ToString()) || _cascades.Contains("all")) && entity.SalesSalesPerson != null)
			if (Cascade(salesSalesPerson364, entity.SalesSalesPerson, context))
				WithParent(salesSalesPerson364, entity);

			//From Foreign Key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID
			var salesSalesTerritory365 = GetSalesSalesTerritoryWriter();
		if ((_cascades.Contains(SalesSalesTerritoryHistoryCascadeNames.salessalesterritory.ToString()) || _cascades.Contains("all")) && entity.SalesSalesTerritory != null)
			if (Cascade(salesSalesTerritory365, entity.SalesSalesTerritory, context))
				WithParent(salesSalesTerritory365, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesTerritoryHistory entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID
			if (entity.SalesSalesPerson != null)
				entity.SalesSalesTerritoryHistory = entity.SalesSalesPerson.Id;

			//From Foreign Key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID
			if (entity.SalesSalesTerritory != null)
				entity.SalesSalesTerritoryHistory = entity.SalesSalesTerritory.Id;

		}

		protected override void RemoveRelations(SalesSalesTerritoryHistory entity, ScriptContext context)
        {
				}
	}
}
		