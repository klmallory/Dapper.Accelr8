
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
			if (s_loc8r == null)
				s_loc8r = loc8r;
		}

		static ILoc8 s_loc8r = null;

		static IEntityWriter<int, PersonAddress> GetPersonAddressWriter()
		{ return s_loc8r.GetWriter<int, PersonAddress>(); }
		static IEntityWriter<int, SalesSalesTaxRate> GetSalesSalesTaxRateWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesTaxRate>(); }
		
		static IEntityWriter<string, PersonCountryRegion> GetPersonCountryRegionWriter()
		{ return s_loc8r.GetWriter<string, PersonCountryRegion>(); }
		static IEntityWriter<int, SalesSalesTerritory> GetSalesSalesTerritoryWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesTerritory>(); }
		
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
                switch ((PersonStateProvinceFieldNames)f.Key)
                {
                    
					case PersonStateProvinceFieldNames.StateProvinceCode:
						parms.Add(GetParamName("StateProvinceCode", actionType, taskIndex, ref count), entity.StateProvinceCode);
						break;
					case PersonStateProvinceFieldNames.CountryRegionCode:
						parms.Add(GetParamName("CountryRegionCode", actionType, taskIndex, ref count), entity.CountryRegionCode);
						break;
					case PersonStateProvinceFieldNames.IsOnlyStateProvinceFlag:
						parms.Add(GetParamName("IsOnlyStateProvinceFlag", actionType, taskIndex, ref count), entity.IsOnlyStateProvinceFlag);
						break;
					case PersonStateProvinceFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case PersonStateProvinceFieldNames.TerritoryID:
						parms.Add(GetParamName("TerritoryID", actionType, taskIndex, ref count), entity.TerritoryID);
						break;
					case PersonStateProvinceFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonStateProvinceFieldNames.ModifiedDate:
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
			if (_cascades.Contains(PersonStateProvinceCascadeNames.personaddresses.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonAddresses)
					Cascade(personAddress395, item, context);

			if (personAddress395.Count > 0)
				WithChild(personAddress395, entity);

			//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID
			var salesSalesTaxRate396 = GetSalesSalesTaxRateWriter();
			if (_cascades.Contains(PersonStateProvinceCascadeNames.salessalestaxrates.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTaxRates)
					Cascade(salesSalesTaxRate396, item, context);

			if (salesSalesTaxRate396.Count > 0)
				WithChild(salesSalesTaxRate396, entity);

		
		
			//From Foreign Key FK_StateProvince_CountryRegion_CountryRegionCode
			var personCountryRegion397 = GetPersonCountryRegionWriter();
		if ((_cascades.Contains(PersonStateProvinceCascadeNames.personcountryregion_p.ToString()) || _cascades.Contains("all")) && entity.PersonCountryRegion != null)
			if (Cascade(personCountryRegion397, entity.PersonCountryRegion, context))
				WithParent(personCountryRegion397, entity);

			//From Foreign Key FK_StateProvince_SalesTerritory_TerritoryID
			var salesSalesTerritory398 = GetSalesSalesTerritoryWriter();
		if ((_cascades.Contains(PersonStateProvinceCascadeNames.salessalesterritory_p.ToString()) || _cascades.Contains("all")) && entity.SalesSalesTerritory != null)
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
					rel.StateProvinceID = entity.Id;

			//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID
			if (entity.SalesSalesTaxRates != null && entity.SalesSalesTaxRates.Count > 0)
				foreach (var rel in entity.SalesSalesTaxRates)
					rel.StateProvinceID = entity.Id;

				
			//From Foreign Key FK_StateProvince_CountryRegion_CountryRegionCode
			if (entity.PersonCountryRegion != null)
				entity.CountryRegionCode = entity.PersonCountryRegion.Id;

			//From Foreign Key FK_StateProvince_SalesTerritory_TerritoryID
			if (entity.SalesSalesTerritory != null)
				entity.TerritoryID = entity.SalesSalesTerritory.Id;

		}

		protected override void RemoveRelations(PersonStateProvince entity, ScriptContext context)
        {
					//From Foreign Key FK_Address_StateProvince_StateProvinceID
			var personAddress403 = GetPersonAddressWriter();
			if (_cascades.Contains(PersonStateProvinceCascadeNames.personaddress.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonAddresses)
					CascadeDelete(personAddress403, item, context);

			if (personAddress403.Count > 0)
				WithChild(personAddress403, entity);

					//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID
			var salesSalesTaxRate404 = GetSalesSalesTaxRateWriter();
			if (_cascades.Contains(PersonStateProvinceCascadeNames.salessalestaxrate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesTaxRates)
					CascadeDelete(salesSalesTaxRate404, item, context);

			if (salesSalesTaxRate404.Count > 0)
				WithChild(salesSalesTaxRate404, entity);

				}
	}
}
		