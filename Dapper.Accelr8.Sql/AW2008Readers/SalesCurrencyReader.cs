
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

namespace Dapper.Accelr8.AW2008Readers
{
    public class SalesCurrencyReader : EntityReader<string, SalesCurrency>
    {
        public SalesCurrencyReader(
            SalesCurrencyTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 3
		//Parent Count 0
		static IEntityReader<string , SalesCountryRegionCurrency> _salesCountryRegionCurrencyReader;
		protected static IEntityReader<string , SalesCountryRegionCurrency> GetSalesCountryRegionCurrencyReader()
		{
			return _locator.Resolve<IEntityReader<string , SalesCountryRegionCurrency>>();
		}

		static IEntityReader<int , SalesCurrencyRate> _salesCurrencyRateReader;
		protected static IEntityReader<int , SalesCurrencyRate> GetSalesCurrencyRateReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesCurrencyRate>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesCountryRegionCurrency on the parent on SalesCountryRegionCurrencies.
		/// From foriegn key FK_CountryRegionCurrency_Currency_CurrencyCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCountryRegionCurrencies(IList<SalesCurrency> results, IList<object> children)
		{
			//Child Id Type: string
			//Child Type: SalesCountryRegionCurrency

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCountryRegionCurrency>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesCountryRegionCurrencies = typedChildren.Where(b => b.SalesCountryRegionCurrency == r.Id).ToList();
				r.SalesCountryRegionCurrencies.ToList().ForEach(b => { b.Loaded = false; b.SalesCurrency = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesCurrencyRate on the parent on SalesCurrencyRates.
		/// From foriegn key FK_CurrencyRate_Currency_FromCurrencyCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCurrencyRates(IList<SalesCurrency> results, IList<object> children)
		{
			//Child Id Type: string
			//Child Type: SalesCurrencyRate

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCurrencyRate>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesCurrencyRates = typedChildren.Where(b => b.SalesCurrencyRate == r.Id).ToList();
				r.SalesCurrencyRates.ToList().ForEach(b => { b.Loaded = false; b.SalesCurrency = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesCurrencyRate on the parent on SalesCurrencyRates.
		/// From foriegn key FK_CurrencyRate_Currency_ToCurrencyCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCurrencyRates(IList<SalesCurrency> results, IList<object> children)
		{
			//Child Id Type: string
			//Child Type: SalesCurrencyRate

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCurrencyRate>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesCurrencyRates = typedChildren.Where(b => b.SalesCurrencyRate == r.Id).ToList();
				r.SalesCurrencyRates.ToList().ForEach(b => { b.Loaded = false; b.SalesCurrency = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.Currency into class SalesCurrency
		/// </summary>
		/// <param name="results">SalesCurrency</param>
		/// <param name="row"></param>
        public override SalesCurrency LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesCurrency();
			domain.Loaded = false;

			domain.Id = GetRowData<string>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified string Id.
		/// </summary>
		/// <param name="results">IEntityReader<string, SalesCurrency></param>
		/// <param name="id">string</param>
        public override IEntityReader<string, SalesCurrency> WithAllChildrenForId(string id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesCountryRegionCurrencyReader(), id, IdColumn, SetChildrenSalesCountryRegionCurrencies);
			
			WithChildForParentId(GetSalesCurrencyRateReader(), id, IdColumn, SetChildrenSalesCurrencyRates);
			
			WithChildForParentId(GetSalesCurrencyRateReader(), id, IdColumn, SetChildrenSalesCurrencyRates);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesCurrency entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesCountryRegionCurrencyReader(), entity.Id
				, SalesCountryRegionCurrencyColumnNames.CurrencyCode.ToString()
				, SetChildrenSalesCountryRegionCurrencies);

			WithChildForParentId(GetSalesCurrencyRateReader(), entity.Id
				, SalesCurrencyRateColumnNames.FromCurrencyCode.ToString()
				, SetChildrenSalesCurrencyRates);

			WithChildForParentId(GetSalesCurrencyRateReader(), entity.Id
				, SalesCurrencyRateColumnNames.ToCurrencyCode.ToString()
				, SetChildrenSalesCurrencyRates);

			QueryResultForChildrenOnly(new List<SalesCurrency>() { entity });
			entity.Loaded = false;
			GetSalesCountryRegionCurrencyReader().SetAllChildrenForExisting(entity.SalesCountryRegionCurrencies);
			GetSalesCurrencyRateReader().SetAllChildrenForExisting(entity.SalesCurrencyRates);
			GetSalesCurrencyRateReader().SetAllChildrenForExisting(entity.SalesCurrencyRates);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesCurrency> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesCountryRegionCurrencyReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesCountryRegionCurrencyColumnNames.CurrencyCode.ToString()
				, SetChildrenSalesCountryRegionCurrencies);

			WithChildForParentIds(GetSalesCurrencyRateReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesCurrencyRateColumnNames.FromCurrencyCode.ToString()
				, SetChildrenSalesCurrencyRates);

			WithChildForParentIds(GetSalesCurrencyRateReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesCurrencyRateColumnNames.ToCurrencyCode.ToString()
				, SetChildrenSalesCurrencyRates);

					
			QueryResultForChildrenOnly(entities);

			GetSalesCountryRegionCurrencyReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCountryRegionCurrencies).ToList());
			GetSalesCurrencyRateReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCurrencyRates).ToList());
			GetSalesCurrencyRateReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCurrencyRates).ToList());
					
		}
    }
}
		