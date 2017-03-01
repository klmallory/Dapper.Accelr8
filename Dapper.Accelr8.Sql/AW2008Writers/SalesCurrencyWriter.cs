
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
    public class SalesCurrencyWriter : EntityWriter<string, SalesCurrency>
    {
        public SalesCurrencyWriter
			(SalesCurrencyTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<string, SalesCountryRegionCurrency> GetSalesCountryRegionCurrencyWriter()
		{ return _locator.Resolve<IEntityWriter<string, SalesCountryRegionCurrency>>(); }
		static IEntityWriter<int, SalesCurrencyRate> GetSalesCurrencyRateWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesCurrencyRate>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesCurrency entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesCurrencyColumnNames)f.Key)
                {
                    
					case SalesCurrencyColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case SalesCurrencyColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesCurrency entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_CountryRegionCurrency_Currency_CurrencyCode
			var salesCountryRegionCurrency73 = GetSalesCountryRegionCurrencyWriter();
			if (_cascades.Contains(SalesCurrencyCascadeNames.sales.countryregioncurrency.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCountryRegionCurrencies)
					Cascade(salesCountryRegionCurrency73, item, context);

			if (salesCountryRegionCurrency73.Count > 0)
				WithChild(salesCountryRegionCurrency73, entity);

			//From Foreign Key FK_CurrencyRate_Currency_FromCurrencyCode
			var salesCurrencyRate74 = GetSalesCurrencyRateWriter();
			if (_cascades.Contains(SalesCurrencyCascadeNames.sales.currencyrate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCurrencyRates)
					Cascade(salesCurrencyRate74, item, context);

			if (salesCurrencyRate74.Count > 0)
				WithChild(salesCurrencyRate74, entity);

			//From Foreign Key FK_CurrencyRate_Currency_ToCurrencyCode
			var salesCurrencyRate75 = GetSalesCurrencyRateWriter();
			if (_cascades.Contains(SalesCurrencyCascadeNames.sales.currencyrate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCurrencyRates)
					Cascade(salesCurrencyRate75, item, context);

			if (salesCurrencyRate75.Count > 0)
				WithChild(salesCurrencyRate75, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesCurrency entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_CountryRegionCurrency_Currency_CurrencyCode
			if (entity.SalesCountryRegionCurrencies != null && entity.SalesCountryRegionCurrencies.Count > 0)
				foreach (var rel in entity.SalesCountryRegionCurrencies)
					rel.SalesCountryRegionCurrency = entity.Id;

			//From Foreign Key FK_CurrencyRate_Currency_FromCurrencyCode
			if (entity.SalesCurrencyRates != null && entity.SalesCurrencyRates.Count > 0)
				foreach (var rel in entity.SalesCurrencyRates)
					rel.SalesCurrencyRate = entity.Id;

			//From Foreign Key FK_CurrencyRate_Currency_ToCurrencyCode
			if (entity.SalesCurrencyRates != null && entity.SalesCurrencyRates.Count > 0)
				foreach (var rel in entity.SalesCurrencyRates)
					rel.SalesCurrencyRate = entity.Id;

				
		}

		protected override void RemoveRelations(SalesCurrency entity, ScriptContext context)
        {
					//From Foreign Key FK_CountryRegionCurrency_Currency_CurrencyCode
			var salesCountryRegionCurrency79 = GetSalesCountryRegionCurrencyWriter();
			if (_cascades.Contains(SalesCurrencyCascadeNames.sales.countryregioncurrency.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCountryRegionCurrencies)
					CascadeDelete(salesCountryRegionCurrency79, item, context);

			if (salesCountryRegionCurrency79.Count > 0)
				WithChild(salesCountryRegionCurrency79, entity);

					//From Foreign Key FK_CurrencyRate_Currency_FromCurrencyCode
			var salesCurrencyRate80 = GetSalesCurrencyRateWriter();
			if (_cascades.Contains(SalesCurrencyCascadeNames.sales.currencyrate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCurrencyRates)
					CascadeDelete(salesCurrencyRate80, item, context);

			if (salesCurrencyRate80.Count > 0)
				WithChild(salesCurrencyRate80, entity);

					//From Foreign Key FK_CurrencyRate_Currency_ToCurrencyCode
			var salesCurrencyRate81 = GetSalesCurrencyRateWriter();
			if (_cascades.Contains(SalesCurrencyCascadeNames.sales.currencyrate.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCurrencyRates)
					CascadeDelete(salesCurrencyRate81, item, context);

			if (salesCurrencyRate81.Count > 0)
				WithChild(salesCurrencyRate81, entity);

				}
	}
}
		