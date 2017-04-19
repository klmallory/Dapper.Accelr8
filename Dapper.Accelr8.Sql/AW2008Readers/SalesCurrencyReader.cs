
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
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 3
		//Parent Count 0
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesCountryRegionCurrency> GetSalesCountryRegionCurrencyReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesCountryRegionCurrency>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesCurrencyRate> GetSalesCurrencyRateReader()
		{
			return s_loc8r.GetReader<int , SalesCurrencyRate>();
		}

		
		/// <summary>
		/// Sets the children of type SalesCountryRegionCurrency on the parent on SalesCountryRegionCurrencies.
		/// From foriegn key FK_CountryRegionCurrency_Currency_CurrencyCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCountryRegionCurrencies(IList<SalesCurrency> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesCountryRegionCurrency

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCountryRegionCurrency>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesCountryRegionCurrencies = typedChildren.Where(b =>  b.CurrencyCode == r.Id ).ToList();
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
		public void SetChildrenSalesCurrencyRates1(IList<SalesCurrency> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesCurrencyRate

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCurrencyRate>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesCurrencyRates1 = typedChildren.Where(b =>  b.FromCurrencyCode == r.Id ).ToList();
				r.SalesCurrencyRates1.ToList().ForEach(b => { b.Loaded = false; b.SalesCurrency1 = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesCurrencyRate on the parent on SalesCurrencyRates.
		/// From foriegn key FK_CurrencyRate_Currency_ToCurrencyCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCurrencyRates2(IList<SalesCurrency> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesCurrencyRate

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCurrencyRate>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesCurrencyRates2 = typedChildren.Where(b =>  b.ToCurrencyCode == r.Id ).ToList();
				r.SalesCurrencyRates2.ToList().ForEach(b => { b.Loaded = false; b.SalesCurrency2 = r; b.Loaded = true; });
				
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

			domain.Id = GetRowData<string>(dataRow, "CurrencyCode"); 
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
        public override IEntityReader<string, SalesCurrency> WithAllChildrenForExisting(SalesCurrency existing)
        {
						WithChildForParentValues(GetSalesCountryRegionCurrencyReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "CurrencyCode",  }
				, SetChildrenSalesCountryRegionCurrencies);
						WithChildForParentValues(GetSalesCurrencyRateReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "FromCurrencyCode",  }
				, SetChildrenSalesCurrencyRates1);
						WithChildForParentValues(GetSalesCurrencyRateReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ToCurrencyCode",  }
				, SetChildrenSalesCurrencyRates2);
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesCurrency entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetSalesCountryRegionCurrencyReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "CurrencyCode",  }
				, SetChildrenSalesCountryRegionCurrencies);

						WithChildForParentValues(GetSalesCurrencyRateReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "FromCurrencyCode",  }
				, SetChildrenSalesCurrencyRates1);

						WithChildForParentValues(GetSalesCurrencyRateReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ToCurrencyCode",  }
				, SetChildrenSalesCurrencyRates2);

			
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

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetSalesCountryRegionCurrencyReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "CurrencyCode",  }
				, SetChildrenSalesCountryRegionCurrencies);

			WithChildForParentsValues(GetSalesCurrencyRateReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "FromCurrencyCode",  }
				, SetChildrenSalesCurrencyRates1);

			WithChildForParentsValues(GetSalesCurrencyRateReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ToCurrencyCode",  }
				, SetChildrenSalesCurrencyRates2);

					
			QueryResultForChildrenOnly(entities);

			GetSalesCountryRegionCurrencyReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCountryRegionCurrencies).ToList());
			GetSalesCurrencyRateReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCurrencyRates1).ToList());
			GetSalesCurrencyRateReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCurrencyRates2).ToList());
					
		}
    }
}
		