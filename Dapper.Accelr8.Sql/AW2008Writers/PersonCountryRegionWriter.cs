
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
    public class PersonCountryRegionWriter : EntityWriter<string, PersonCountryRegion>
    {
        public PersonCountryRegionWriter
			(PersonCountryRegionTableInfo tableInfo
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
		static IEntityWriter<string, SalesCountryRegionCurrency> GetSalesCountryRegionCurrencyWriter()
		{ return s_loc8r.GetWriter<string, SalesCountryRegionCurrency>(); }
		static IEntityWriter<int, SalesSalesTerritory> GetSalesSalesTerritoryWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesTerritory>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonCountryRegion entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonCountryRegionFieldNames)f.Key)
                {
                    
					case PersonCountryRegionFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case PersonCountryRegionFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonCountryRegion entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_StateProvince_CountryRegion_CountryRegionCode
			var personStateProvince51 = GetPersonStateProvinceWriter();
			if (_cascades.Contains(PersonCountryRegionCascadeNames.personstateprovinces.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonStateProvinces)
					Cascade(personStateProvince51, item, context);

			if (personStateProvince51.Count > 0)
				WithChild(personStateProvince51, entity);

			//From Foreign Key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
			var salesCountryRegionCurrency52 = GetSalesCountryRegionCurrencyWriter();
			if (_cascades.Contains(PersonCountryRegionCascadeNames.salescountryregioncurrencies.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCountryRegionCurrencies)
					Cascade(salesCountryRegionCurrency52, item, context);

			if (salesCountryRegionCurrency52.Count > 0)
				WithChild(salesCountryRegionCurrency52, entity);

			//From Foreign Key FK_SalesTerritory_CountryRegion_CountryRegionCode
			var salesSalesTerritory53 = GetSalesSalesTerritoryWriter();
			if (_cascades.Contains(PersonCountryRegionCascadeNames.salessalesterritories.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTerritories)
					Cascade(salesSalesTerritory53, item, context);

			if (salesSalesTerritory53.Count > 0)
				WithChild(salesSalesTerritory53, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonCountryRegion entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_StateProvince_CountryRegion_CountryRegionCode
			if (entity.PersonStateProvinces != null && entity.PersonStateProvinces.Count > 0)
				foreach (var rel in entity.PersonStateProvinces)
					rel.CountryRegionCode = entity.Id;

			//From Foreign Key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
			if (entity.SalesCountryRegionCurrencies != null && entity.SalesCountryRegionCurrencies.Count > 0)
				foreach (var rel in entity.SalesCountryRegionCurrencies)
					rel.CountryRegionCode = entity.Id;

			//From Foreign Key FK_SalesTerritory_CountryRegion_CountryRegionCode
			if (entity.SalesSalesTerritories != null && entity.SalesSalesTerritories.Count > 0)
				foreach (var rel in entity.SalesSalesTerritories)
					rel.CountryRegionCode = entity.Id;

				
		}

		protected override void RemoveRelations(PersonCountryRegion entity, ScriptContext context)
        {
					//From Foreign Key FK_StateProvince_CountryRegion_CountryRegionCode
			var personStateProvince57 = GetPersonStateProvinceWriter();
			if (_cascades.Contains(PersonCountryRegionCascadeNames.personstateprovince.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonStateProvinces)
					CascadeDelete(personStateProvince57, item, context);

			if (personStateProvince57.Count > 0)
				WithChild(personStateProvince57, entity);

					//From Foreign Key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
			var salesCountryRegionCurrency58 = GetSalesCountryRegionCurrencyWriter();
			if (_cascades.Contains(PersonCountryRegionCascadeNames.salescountryregioncurrency.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCountryRegionCurrencies)
					CascadeDelete(salesCountryRegionCurrency58, item, context);

			if (salesCountryRegionCurrency58.Count > 0)
				WithChild(salesCountryRegionCurrency58, entity);

					//From Foreign Key FK_SalesTerritory_CountryRegion_CountryRegionCode
			var salesSalesTerritory59 = GetSalesSalesTerritoryWriter();
			if (_cascades.Contains(PersonCountryRegionCascadeNames.salessalesterritory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTerritories)
					CascadeDelete(salesSalesTerritory59, item, context);

			if (salesSalesTerritory59.Count > 0)
				WithChild(salesSalesTerritory59, entity);

				}
	}
}
		