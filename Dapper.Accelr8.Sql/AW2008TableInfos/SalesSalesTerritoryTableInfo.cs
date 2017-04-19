
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
	public enum SalesSalesTerritoryFieldNames
	{	
		Id, 	
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
		personstateprovinces, 	
		salescustomers, 	
		salessalesorderheaders, 	
		salessalespeople, 	
		salessalesterritoryhistories, 	
		
		personcountryregion_p, 	}

	public class SalesSalesTerritoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSalesTerritoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesTerritoryFieldNames.Id, "TerritoryID" }, 
						{ (int)SalesSalesTerritoryFieldNames.Name, "Name" }, 
						{ (int)SalesSalesTerritoryFieldNames.CountryRegionCode, "CountryRegionCode" }, 
						{ (int)SalesSalesTerritoryFieldNames.Group, "Group" }, 
						{ (int)SalesSalesTerritoryFieldNames.SalesYTD, "SalesYTD" }, 
						{ (int)SalesSalesTerritoryFieldNames.SalesLastYear, "SalesLastYear" }, 
						{ (int)SalesSalesTerritoryFieldNames.CostYTD, "CostYTD" }, 
						{ (int)SalesSalesTerritoryFieldNames.CostLastYear, "CostLastYear" }, 
						{ (int)SalesSalesTerritoryFieldNames.rowguid, "rowguid" }, 
						{ (int)SalesSalesTerritoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSalesTerritoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesTerritoryFieldNames.Id, "TerritoryID" }, 
				};

		public SalesSalesTerritoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SalesTerritory";
			TableAlias = "salessalesterritory";
			Columns = SalesSalesTerritoryColumnNames;
			IdColumns = SalesSalesTerritoryIdColumnNames;

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

		