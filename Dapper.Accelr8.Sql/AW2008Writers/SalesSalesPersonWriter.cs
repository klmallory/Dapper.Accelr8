
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
    public class SalesSalesPersonWriter : EntityWriter<int, SalesSalesPerson>
    {
        public SalesSalesPersonWriter
			(SalesSalesPersonTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, SalesStore> GetSalesStoreWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesStore>>(); }
		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderHeader>>(); }
		static IEntityWriter<int, SalesSalesPersonQuotaHistory> GetSalesSalesPersonQuotaHistoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesPersonQuotaHistory>>(); }
		static IEntityWriter<int, SalesSalesTerritoryHistory> GetSalesSalesTerritoryHistoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesTerritoryHistory>>(); }
		
		static IEntityWriter<int, HumanResourcesEmployee> GetHumanResourcesEmployeeWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesEmployee>>(); }
		static IEntityWriter<int, SalesSalesTerritory> GetSalesSalesTerritoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesTerritory>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesPerson entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesPersonColumnNames)f.Key)
                {
                    
					case SalesSalesPersonColumnNames.TerritoryID:
						parms.Add(GetParamName("TerritoryID", actionType, taskIndex, ref count), entity.TerritoryID);
						break;
					case SalesSalesPersonColumnNames.SalesQuota:
						parms.Add(GetParamName("SalesQuota", actionType, taskIndex, ref count), entity.SalesQuota);
						break;
					case SalesSalesPersonColumnNames.Bonus:
						parms.Add(GetParamName("Bonus", actionType, taskIndex, ref count), entity.Bonus);
						break;
					case SalesSalesPersonColumnNames.CommissionPct:
						parms.Add(GetParamName("CommissionPct", actionType, taskIndex, ref count), entity.CommissionPct);
						break;
					case SalesSalesPersonColumnNames.SalesYTD:
						parms.Add(GetParamName("SalesYTD", actionType, taskIndex, ref count), entity.SalesYTD);
						break;
					case SalesSalesPersonColumnNames.SalesLastYear:
						parms.Add(GetParamName("SalesLastYear", actionType, taskIndex, ref count), entity.SalesLastYear);
						break;
					case SalesSalesPersonColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSalesPersonColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesPerson entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Store_SalesPerson_SalesPersonID
			var salesStore324 = GetSalesStoreWriter();
			if (_cascades.Contains(SalesSalesPersonCascadeNames.sales.store.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesStores)
					Cascade(salesStore324, item, context);

			if (salesStore324.Count > 0)
				WithChild(salesStore324, entity);

			//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID
			var salesSalesOrderHeader325 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesSalesPersonCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					Cascade(salesSalesOrderHeader325, item, context);

			if (salesSalesOrderHeader325.Count > 0)
				WithChild(salesSalesOrderHeader325, entity);

			//From Foreign Key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID
			var salesSalesPersonQuotaHistory326 = GetSalesSalesPersonQuotaHistoryWriter();
			if (_cascades.Contains(SalesSalesPersonCascadeNames.sales.salespersonquotahistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesPersonQuotaHistories)
					Cascade(salesSalesPersonQuotaHistory326, item, context);

			if (salesSalesPersonQuotaHistory326.Count > 0)
				WithChild(salesSalesPersonQuotaHistory326, entity);

			//From Foreign Key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID
			var salesSalesTerritoryHistory327 = GetSalesSalesTerritoryHistoryWriter();
			if (_cascades.Contains(SalesSalesPersonCascadeNames.sales.salesterritoryhistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTerritoryHistories)
					Cascade(salesSalesTerritoryHistory327, item, context);

			if (salesSalesTerritoryHistory327.Count > 0)
				WithChild(salesSalesTerritoryHistory327, entity);

		
		
			//From Foreign Key FK_SalesPerson_Employee_BusinessEntityID
			var humanResourcesEmployee328 = GetHumanResourcesEmployeeWriter();
		if ((_cascades.Contains(SalesSalesPersonCascadeNames.humanresourcesemployee.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesEmployee != null)
			if (Cascade(humanResourcesEmployee328, entity.HumanResourcesEmployee, context))
				WithParent(humanResourcesEmployee328, entity);

			//From Foreign Key FK_SalesPerson_SalesTerritory_TerritoryID
			var salesSalesTerritory329 = GetSalesSalesTerritoryWriter();
		if ((_cascades.Contains(SalesSalesPersonCascadeNames.salessalesterritory.ToString()) || _cascades.Contains("all")) && entity.SalesSalesTerritory != null)
			if (Cascade(salesSalesTerritory329, entity.SalesSalesTerritory, context))
				WithParent(salesSalesTerritory329, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesPerson entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Store_SalesPerson_SalesPersonID
			if (entity.SalesStores != null && entity.SalesStores.Count > 0)
				foreach (var rel in entity.SalesStores)
					rel.SalesStore = entity.Id;

			//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID
			if (entity.SalesSalesOrderHeaders != null && entity.SalesSalesOrderHeaders.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaders)
					rel.SalesSalesOrderHeader = entity.Id;

			//From Foreign Key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID
			if (entity.SalesSalesPersonQuotaHistories != null && entity.SalesSalesPersonQuotaHistories.Count > 0)
				foreach (var rel in entity.SalesSalesPersonQuotaHistories)
					rel.SalesSalesPersonQuotaHistory = entity.Id;

			//From Foreign Key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID
			if (entity.SalesSalesTerritoryHistories != null && entity.SalesSalesTerritoryHistories.Count > 0)
				foreach (var rel in entity.SalesSalesTerritoryHistories)
					rel.SalesSalesTerritoryHistory = entity.Id;

				
			//From Foreign Key FK_SalesPerson_Employee_BusinessEntityID
			if (entity.HumanResourcesEmployee != null)
				entity.SalesSalesPerson = entity.HumanResourcesEmployee.Id;

			//From Foreign Key FK_SalesPerson_SalesTerritory_TerritoryID
			if (entity.SalesSalesTerritory != null)
				entity.SalesSalesPerson = entity.SalesSalesTerritory.Id;

		}

		protected override void RemoveRelations(SalesSalesPerson entity, ScriptContext context)
        {
					//From Foreign Key FK_Store_SalesPerson_SalesPersonID
			var salesStore336 = GetSalesStoreWriter();
			if (_cascades.Contains(SalesSalesPersonCascadeNames.sales.store.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesStores)
					CascadeDelete(salesStore336, item, context);

			if (salesStore336.Count > 0)
				WithChild(salesStore336, entity);

					//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID
			var salesSalesOrderHeader337 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesSalesPersonCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					CascadeDelete(salesSalesOrderHeader337, item, context);

			if (salesSalesOrderHeader337.Count > 0)
				WithChild(salesSalesOrderHeader337, entity);

					//From Foreign Key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID
			var salesSalesPersonQuotaHistory338 = GetSalesSalesPersonQuotaHistoryWriter();
			if (_cascades.Contains(SalesSalesPersonCascadeNames.sales.salespersonquotahistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesPersonQuotaHistories)
					CascadeDelete(salesSalesPersonQuotaHistory338, item, context);

			if (salesSalesPersonQuotaHistory338.Count > 0)
				WithChild(salesSalesPersonQuotaHistory338, entity);

					//From Foreign Key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID
			var salesSalesTerritoryHistory339 = GetSalesSalesTerritoryHistoryWriter();
			if (_cascades.Contains(SalesSalesPersonCascadeNames.sales.salesterritoryhistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTerritoryHistories)
					CascadeDelete(salesSalesTerritoryHistory339, item, context);

			if (salesSalesTerritoryHistory339.Count > 0)
				WithChild(salesSalesTerritoryHistory339, entity);

				}
	}
}
		