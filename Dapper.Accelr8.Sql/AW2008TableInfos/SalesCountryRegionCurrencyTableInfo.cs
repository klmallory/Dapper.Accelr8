
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
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008TableInfos
{
	public enum SalesCountryRegionCurrencyFieldNames
	{	
		CountryRegionCode, 	
		CurrencyCode, 	
		ModifiedDate, 	
	}

	public enum SalesCountryRegionCurrencyCascadeNames
	{	
		
		personcountryregion_p, 	
		salescurrency_p, 	}

	public class SalesCountryRegionCurrencyTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesCountryRegionCurrencyColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesCountryRegionCurrencyFieldNames.CountryRegionCode, "CountryRegionCode" }, 
						{ (int)SalesCountryRegionCurrencyFieldNames.CurrencyCode, "CurrencyCode" }, 
						{ (int)SalesCountryRegionCurrencyFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesCountryRegionCurrencyIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesCountryRegionCurrencyFieldNames.CountryRegionCode, "CountryRegionCode" }, 
						{ (int)SalesCountryRegionCurrencyFieldNames.CurrencyCode, "CurrencyCode" }, 
				};

		public SalesCountryRegionCurrencyTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.CountryRegionCurrency";
			TableAlias = "salescountryregioncurrency";
			Columns = SalesCountryRegionCurrencyColumnNames;
			IdColumns = SalesCountryRegionCurrencyIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, PersonCountryRegion>("PersonCountryRegion")),
			TableName = "Person.CountryRegion",
			Alias = TableAlias + "_" + "PersonCountryRegion",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, PersonCountryRegion>("PersonCountryRegion");
					var st = (entity as SalesCountryRegionCurrency);

					if (st == null || row == null)
						return st;

					if (row.CountryRegionCode == null || row.CountryRegionCode == default(string))
						return st;

					st.PersonCountryRegion = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonCountryRegionColumnNames.   .ToString()
					//SalesCountryRegionCurrencyColumnNames.      .ToString()
					JoinField = "CountryRegionCode",
					Operator = Operator.Equals,
					ParentField = "CountryRegionCode",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_CountryRegionCurrency_Currency_CurrencyCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, SalesCurrency>("SalesCurrency")),
			TableName = "Sales.Currency",
			Alias = TableAlias + "_" + "SalesCurrency",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, SalesCurrency>("SalesCurrency");
					var st = (entity as SalesCountryRegionCurrency);

					if (st == null || row == null)
						return st;

					if (row.CurrencyCode == null || row.CurrencyCode == default(string))
						return st;

					st.SalesCurrency = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesCurrencyColumnNames.   .ToString()
					//SalesCountryRegionCurrencyColumnNames.      .ToString()
					JoinField = "CurrencyCode",
					Operator = Operator.Equals,
					ParentField = "CurrencyCode",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		