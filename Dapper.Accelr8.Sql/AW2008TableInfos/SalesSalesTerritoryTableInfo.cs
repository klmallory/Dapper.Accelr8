
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
	public enum SalesSalesTerritoryColumnNames
	{	
		TerritoryID, 	
		Name, 	
		CountryRegionCode, 	
		Group, 	
		SalesYTD, 	
		SalesLastYear, 	
		CostYTD, 	
		CostLastYear, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSalesTerritoryCascadeNames
	{	
		personstateprovince, 	
		salescustomer, 	
		salessalesorderheader, 	
		salessalesperson, 	
		salessalesterritoryhistory, 	
		
		personcountryregion_p, 	}

	public class SalesSalesTerritoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesSalesTerritoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesSalesTerritoryColumnNames.TerritoryID.ToString();
			//Schema = "Sales.SalesTerritory";
			TableName = "Sales.SalesTerritory";
			TableAlias = "salessalesterritory";
			ColumnNames = typeof(SalesSalesTerritoryColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_SalesTerritory_CountryRegion_CountryRegionCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, PersonCountryRegion>("PersonCountryRegion")),
			TableName = "Person.CountryRegion",
			Alias = TableAlias + "_" + "PersonCountryRegion",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, PersonCountryRegion>("PersonCountryRegion");
					var st = (entity as SalesSalesTerritory);

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
					//SalesSalesTerritoryColumnNames.      .ToString()
					JoinField = "CountryRegionCode",
					Operator = Operator.Equals,
					ParentField = "CountryRegionCode",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		