
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
    public class SalesSalesTerritoryWriter : EntityWriter<int, SalesSalesTerritory>
    {
        public SalesSalesTerritoryWriter
			(SalesSalesTerritoryTableInfo tableInfo
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

		static IEntityWriter<int, PersonStateProvince> GetPersonStateProvinceWriter()
		{ return s_loc8r.GetWriter<int, PersonStateProvince>(); }
		static IEntityWriter<int, SalesCustomer> GetSalesCustomerWriter()
		{ return s_loc8r.GetWriter<int, SalesCustomer>(); }
		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesOrderHeader>(); }
		static IEntityWriter<int, SalesSalesPerson> GetSalesSalesPersonWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesPerson>(); }
		static IEntityWriter<int, SalesSalesTerritoryHistory> GetSalesSalesTerritoryHistoryWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesTerritoryHistory>(); }
		
		static IEntityWriter<string, PersonCountryRegion> GetPersonCountryRegionWriter()
		{ return s_loc8r.GetWriter<string, PersonCountryRegion>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesTerritory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesTerritoryFieldNames)f.Key)
                {
                    
					case SalesSalesTerritoryFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case SalesSalesTerritoryFieldNames.CountryRegionCode:
						parms.Add(GetParamName("CountryRegionCode", actionType, taskIndex, ref count), entity.CountryRegionCode);
						break;
					case SalesSalesTerritoryFieldNames.Group:
						parms.Add(GetParamName("Group", actionType, taskIndex, ref count), entity.Group);
						break;
					case SalesSalesTerritoryFieldNames.SalesYTD:
						parms.Add(GetParamName("SalesYTD", actionType, taskIndex, ref count), entity.SalesYTD);
						break;
					case SalesSalesTerritoryFieldNames.SalesLastYear:
						parms.Add(GetParamName("SalesLastYear", actionType, taskIndex, ref count), entity.SalesLastYear);
						break;
					case SalesSalesTerritoryFieldNames.CostYTD:
						parms.Add(GetParamName("CostYTD", actionType, taskIndex, ref count), entity.CostYTD);
						break;
					case SalesSalesTerritoryFieldNames.CostLastYear:
						parms.Add(GetParamName("CostLastYear", actionType, taskIndex, ref count), entity.CostLastYear);
						break;
					case SalesSalesTerritoryFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSalesTerritoryFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesTerritory entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_StateProvince_SalesTerritory_TerritoryID
			var personStateProvince347 = GetPersonStateProvinceWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.personstateprovinces.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonStateProvinces)
					Cascade(personStateProvince347, item, context);

			if (personStateProvince347.Count > 0)
				WithChild(personStateProvince347, entity);

			//From Foreign Key FK_Customer_SalesTerritory_TerritoryID
			var salesCustomer348 = GetSalesCustomerWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.salescustomers.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCustomers)
					Cascade(salesCustomer348, item, context);

			if (salesCustomer348.Count > 0)
				WithChild(salesCustomer348, entity);

			//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID
			var salesSalesOrderHeader349 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.salessalesorderheaders.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					Cascade(salesSalesOrderHeader349, item, context);

			if (salesSalesOrderHeader349.Count > 0)
				WithChild(salesSalesOrderHeader349, entity);

			//From Foreign Key FK_SalesPerson_SalesTerritory_TerritoryID
			var salesSalesPerson350 = GetSalesSalesPersonWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.salessalespeople.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesPeoples)
					Cascade(salesSalesPerson350, item, context);

			if (salesSalesPerson350.Count > 0)
				WithChild(salesSalesPerson350, entity);

			//From Foreign Key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID
			var salesSalesTerritoryHistory351 = GetSalesSalesTerritoryHistoryWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.salessalesterritoryhistories.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTerritoryHistories)
					Cascade(salesSalesTerritoryHistory351, item, context);

			if (salesSalesTerritoryHistory351.Count > 0)
				WithChild(salesSalesTerritoryHistory351, entity);

		
		
			//From Foreign Key FK_SalesTerritory_CountryRegion_CountryRegionCode
			var personCountryRegion352 = GetPersonCountryRegionWriter();
		if ((_cascades.Contains(SalesSalesTerritoryCascadeNames.personcountryregion_p.ToString()) || _cascades.Contains("all")) && entity.PersonCountryRegion != null)
			if (Cascade(personCountryRegion352, entity.PersonCountryRegion, context))
				WithParent(personCountryRegion352, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesTerritory entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_StateProvince_SalesTerritory_TerritoryID
			if (entity.PersonStateProvinces != null && entity.PersonStateProvinces.Count > 0)
				foreach (var rel in entity.PersonStateProvinces)
					rel.TerritoryID = entity.Id;

			//From Foreign Key FK_Customer_SalesTerritory_TerritoryID
			if (entity.SalesCustomers != null && entity.SalesCustomers.Count > 0)
				foreach (var rel in entity.SalesCustomers)
					rel.TerritoryID = entity.Id;

			//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID
			if (entity.SalesSalesOrderHeaders != null && entity.SalesSalesOrderHeaders.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaders)
					rel.TerritoryID = entity.Id;

			//From Foreign Key FK_SalesPerson_SalesTerritory_TerritoryID
			if (entity.SalesSalesPeople != null && entity.SalesSalesPeople.Count > 0)
				foreach (var rel in entity.SalesSalesPeople)
					rel.TerritoryID = entity.Id;

			//From Foreign Key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID
			if (entity.SalesSalesTerritoryHistories != null && entity.SalesSalesTerritoryHistories.Count > 0)
				foreach (var rel in entity.SalesSalesTerritoryHistories)
					rel.TerritoryID = entity.Id;

				
			//From Foreign Key FK_SalesTerritory_CountryRegion_CountryRegionCode
			if (entity.PersonCountryRegion != null)
				entity.CountryRegionCode = entity.PersonCountryRegion.Id;

		}

		protected override void RemoveRelations(SalesSalesTerritory entity, ScriptContext context)
        {
					//From Foreign Key FK_StateProvince_SalesTerritory_TerritoryID
			var personStateProvince359 = GetPersonStateProvinceWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.personstateprovince.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonStateProvinces)
					CascadeDelete(personStateProvince359, item, context);

			if (personStateProvince359.Count > 0)
				WithChild(personStateProvince359, entity);

					//From Foreign Key FK_Customer_SalesTerritory_TerritoryID
			var salesCustomer360 = GetSalesCustomerWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.salescustomer.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCustomers)
					CascadeDelete(salesCustomer360, item, context);

			if (salesCustomer360.Count > 0)
				WithChild(salesCustomer360, entity);

					//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID
			var salesSalesOrderHeader361 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.salessalesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					CascadeDelete(salesSalesOrderHeader361, item, context);

			if (salesSalesOrderHeader361.Count > 0)
				WithChild(salesSalesOrderHeader361, entity);

					//From Foreign Key FK_SalesPerson_SalesTerritory_TerritoryID
			var salesSalesPerson362 = GetSalesSalesPersonWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.salessalesperson.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesPeople)
					CascadeDelete(salesSalesPerson362, item, context);

			if (salesSalesPerson362.Count > 0)
				WithChild(salesSalesPerson362, entity);

					//From Foreign Key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID
			var salesSalesTerritoryHistory363 = GetSalesSalesTerritoryHistoryWriter();
			if (_cascades.Contains(SalesSalesTerritoryCascadeNames.salessalesterritoryhistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTerritoryHistories)
					CascadeDelete(salesSalesTerritoryHistory363, item, context);

			if (salesSalesTerritoryHistory363.Count > 0)
				WithChild(salesSalesTerritoryHistory363, entity);

				}
	}
}
		