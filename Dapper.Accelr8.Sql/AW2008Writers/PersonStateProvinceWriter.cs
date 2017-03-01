
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
    public class PersonStateProvinceWriter : EntityWriter<int, PersonStateProvince>
    {
        public PersonStateProvinceWriter
			(PersonStateProvinceTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, PersonAddress> GetPersonAddressWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonAddress>>(); }
		static IEntityWriter<int, SalesSalesTaxRate> GetSalesSalesTaxRateWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesTaxRate>>(); }
		
		static IEntityWriter<string, PersonCountryRegion> GetPersonCountryRegionWriter()
		{ return _locator.Resolve<IEntityWriter<string, PersonCountryRegion>>(); }
		static IEntityWriter<int, SalesSalesTerritory> GetSalesSalesTerritoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesTerritory>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonStateProvince entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonStateProvinceColumnNames)f.Key)
                {
                    
					case PersonStateProvinceColumnNames.StateProvinceCode:
						parms.Add(GetParamName("StateProvinceCode", actionType, taskIndex, ref count), entity.StateProvinceCode);
						break;
					case PersonStateProvinceColumnNames.CountryRegionCode:
						parms.Add(GetParamName("CountryRegionCode", actionType, taskIndex, ref count), entity.CountryRegionCode);
						break;
					case PersonStateProvinceColumnNames.IsOnlyStateProvinceFlag:
						parms.Add(GetParamName("IsOnlyStateProvinceFlag", actionType, taskIndex, ref count), entity.IsOnlyStateProvinceFlag);
						break;
					case PersonStateProvinceColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case PersonStateProvinceColumnNames.TerritoryID:
						parms.Add(GetParamName("TerritoryID", actionType, taskIndex, ref count), entity.TerritoryID);
						break;
					case PersonStateProvinceColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonStateProvinceColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonStateProvince entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Address_StateProvince_StateProvinceID
			var personAddress395 = GetPersonAddressWriter();
			if (_cascades.Contains(PersonStateProvinceCascadeNames.person.address.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonAddresses)
					Cascade(personAddress395, item, context);

			if (personAddress395.Count > 0)
				WithChild(personAddress395, entity);

			//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID
			var salesSalesTaxRate396 = GetSalesSalesTaxRateWriter();
			if (_cascades.Contains(PersonStateProvinceCascadeNames.sales.salestaxrate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTaxRates)
					Cascade(salesSalesTaxRate396, item, context);

			if (salesSalesTaxRate396.Count > 0)
				WithChild(salesSalesTaxRate396, entity);

		
		
			//From Foreign Key FK_StateProvince_CountryRegion_CountryRegionCode
			var personCountryRegion397 = GetPersonCountryRegionWriter();
		if ((_cascades.Contains(PersonStateProvinceCascadeNames.personcountryregion.ToString()) || _cascades.Contains("all")) && entity.PersonCountryRegion != null)
			if (Cascade(personCountryRegion397, entity.PersonCountryRegion, context))
				WithParent(personCountryRegion397, entity);

			//From Foreign Key FK_StateProvince_SalesTerritory_TerritoryID
			var salesSalesTerritory398 = GetSalesSalesTerritoryWriter();
		if ((_cascades.Contains(PersonStateProvinceCascadeNames.salessalesterritory.ToString()) || _cascades.Contains("all")) && entity.SalesSalesTerritory != null)
			if (Cascade(salesSalesTerritory398, entity.SalesSalesTerritory, context))
				WithParent(salesSalesTerritory398, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonStateProvince entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Address_StateProvince_StateProvinceID
			if (entity.PersonAddresses != null && entity.PersonAddresses.Count > 0)
				foreach (var rel in entity.PersonAddresses)
					rel.PersonAddress = entity.Id;

			//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID
			if (entity.SalesSalesTaxRates != null && entity.SalesSalesTaxRates.Count > 0)
				foreach (var rel in entity.SalesSalesTaxRates)
					rel.SalesSalesTaxRate = entity.Id;

				
			//From Foreign Key FK_StateProvince_CountryRegion_CountryRegionCode
			if (entity.PersonCountryRegion != null)
				entity.PersonStateProvince = entity.PersonCountryRegion.Id;

			//From Foreign Key FK_StateProvince_SalesTerritory_TerritoryID
			if (entity.SalesSalesTerritory != null)
				entity.PersonStateProvince = entity.SalesSalesTerritory.Id;

		}

		protected override void RemoveRelations(PersonStateProvince entity, ScriptContext context)
        {
					//From Foreign Key FK_Address_StateProvince_StateProvinceID
			var personAddress403 = GetPersonAddressWriter();
			if (_cascades.Contains(PersonStateProvinceCascadeNames.person.address.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonAddresses)
					CascadeDelete(personAddress403, item, context);

			if (personAddress403.Count > 0)
				WithChild(personAddress403, entity);

					//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID
			var salesSalesTaxRate404 = GetSalesSalesTaxRateWriter();
			if (_cascades.Contains(PersonStateProvinceCascadeNames.sales.salestaxrate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTaxRates)
					CascadeDelete(salesSalesTaxRate404, item, context);

			if (salesSalesTaxRate404.Count > 0)
				WithChild(salesSalesTaxRate404, entity);

				}
	}
}
		