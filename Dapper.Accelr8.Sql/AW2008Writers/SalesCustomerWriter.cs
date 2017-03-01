
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
    public class SalesCustomerWriter : EntityWriter<int, SalesCustomer>
    {
        public SalesCustomerWriter
			(SalesCustomerTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderHeader>>(); }
		
		static IEntityWriter<int, SalesStore> GetSalesStoreWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesStore>>(); }
		static IEntityWriter<int, PersonPerson> GetPersonPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonPerson>>(); }
		static IEntityWriter<int, SalesSalesTerritory> GetSalesSalesTerritoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesTerritory>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesCustomer entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesCustomerColumnNames)f.Key)
                {
                    
					case SalesCustomerColumnNames.PersonID:
						parms.Add(GetParamName("PersonID", actionType, taskIndex, ref count), entity.PersonID);
						break;
					case SalesCustomerColumnNames.StoreID:
						parms.Add(GetParamName("StoreID", actionType, taskIndex, ref count), entity.StoreID);
						break;
					case SalesCustomerColumnNames.TerritoryID:
						parms.Add(GetParamName("TerritoryID", actionType, taskIndex, ref count), entity.TerritoryID);
						break;
					case SalesCustomerColumnNames.AccountNumber:
						parms.Add(GetParamName("AccountNumber", actionType, taskIndex, ref count), entity.AccountNumber);
						break;
					case SalesCustomerColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesCustomerColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesCustomer entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID
			var salesSalesOrderHeader89 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesCustomerCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					Cascade(salesSalesOrderHeader89, item, context);

			if (salesSalesOrderHeader89.Count > 0)
				WithChild(salesSalesOrderHeader89, entity);

		
		
			//From Foreign Key FK_Customer_Store_StoreID
			var salesStore90 = GetSalesStoreWriter();
		if ((_cascades.Contains(SalesCustomerCascadeNames.salesstore.ToString()) || _cascades.Contains("all")) && entity.SalesStore != null)
			if (Cascade(salesStore90, entity.SalesStore, context))
				WithParent(salesStore90, entity);

			//From Foreign Key FK_Customer_Person_PersonID
			var personPerson91 = GetPersonPersonWriter();
		if ((_cascades.Contains(SalesCustomerCascadeNames.personperson.ToString()) || _cascades.Contains("all")) && entity.PersonPerson != null)
			if (Cascade(personPerson91, entity.PersonPerson, context))
				WithParent(personPerson91, entity);

			//From Foreign Key FK_Customer_SalesTerritory_TerritoryID
			var salesSalesTerritory92 = GetSalesSalesTerritoryWriter();
		if ((_cascades.Contains(SalesCustomerCascadeNames.salessalesterritory.ToString()) || _cascades.Contains("all")) && entity.SalesSalesTerritory != null)
			if (Cascade(salesSalesTerritory92, entity.SalesSalesTerritory, context))
				WithParent(salesSalesTerritory92, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesCustomer entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID
			if (entity.SalesSalesOrderHeaders != null && entity.SalesSalesOrderHeaders.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaders)
					rel.SalesSalesOrderHeader = entity.Id;

				
			//From Foreign Key FK_Customer_Store_StoreID
			if (entity.SalesStore != null)
				entity.SalesCustomer = entity.SalesStore.Id;

			//From Foreign Key FK_Customer_Person_PersonID
			if (entity.PersonPerson != null)
				entity.SalesCustomer = entity.PersonPerson.Id;

			//From Foreign Key FK_Customer_SalesTerritory_TerritoryID
			if (entity.SalesSalesTerritory != null)
				entity.SalesCustomer = entity.SalesSalesTerritory.Id;

		}

		protected override void RemoveRelations(SalesCustomer entity, ScriptContext context)
        {
					//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID
			var salesSalesOrderHeader97 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesCustomerCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					CascadeDelete(salesSalesOrderHeader97, item, context);

			if (salesSalesOrderHeader97.Count > 0)
				WithChild(salesSalesOrderHeader97, entity);

				}
	}
}
		