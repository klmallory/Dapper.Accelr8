
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
    public class SalesCountryRegionCurrencyWriter : EntityWriter<string, SalesCountryRegionCurrency>
    {
        public SalesCountryRegionCurrencyWriter
			(SalesCountryRegionCurrencyTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<string, PersonCountryRegion> GetPersonCountryRegionWriter()
		{ return _locator.Resolve<IEntityWriter<string, PersonCountryRegion>>(); }
		static IEntityWriter<string, SalesCurrency> GetSalesCurrencyWriter()
		{ return _locator.Resolve<IEntityWriter<string, SalesCurrency>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesCountryRegionCurrency entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesCountryRegionCurrencyColumnNames)f.Key)
                {
                    
					case SalesCountryRegionCurrencyColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesCountryRegionCurrency entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
			var personCountryRegion60 = GetPersonCountryRegionWriter();
		if ((_cascades.Contains(SalesCountryRegionCurrencyCascadeNames.personcountryregion.ToString()) || _cascades.Contains("all")) && entity.PersonCountryRegion != null)
			if (Cascade(personCountryRegion60, entity.PersonCountryRegion, context))
				WithParent(personCountryRegion60, entity);

			//From Foreign Key FK_CountryRegionCurrency_Currency_CurrencyCode
			var salesCurrency61 = GetSalesCurrencyWriter();
		if ((_cascades.Contains(SalesCountryRegionCurrencyCascadeNames.salescurrency.ToString()) || _cascades.Contains("all")) && entity.SalesCurrency != null)
			if (Cascade(salesCurrency61, entity.SalesCurrency, context))
				WithParent(salesCurrency61, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesCountryRegionCurrency entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
			if (entity.PersonCountryRegion != null)
				entity.SalesCountryRegionCurrency = entity.PersonCountryRegion.Id;

			//From Foreign Key FK_CountryRegionCurrency_Currency_CurrencyCode
			if (entity.SalesCurrency != null)
				entity.SalesCountryRegionCurrency = entity.SalesCurrency.Id;

		}

		protected override void RemoveRelations(SalesCountryRegionCurrency entity, ScriptContext context)
        {
				}
	}
}
		