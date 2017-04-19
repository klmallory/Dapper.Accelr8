
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
	public enum PersonStateProvinceFieldNames
	{	
		Id, 	
		StateProvinceCode, 	
		CountryRegionCode, 	
		IsOnlyStateProvinceFlag, 	
		Name, 	
		TerritoryID, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonStateProvinceCascadeNames
	{	
		personaddresses, 	
		salessalestaxrates, 	
		
		personcountryregion_p, 	
		salessalesterritory_p, 	}

	public class PersonStateProvinceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonStateProvinceColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonStateProvinceFieldNames.Id, "StateProvinceID" }, 
						{ (int)PersonStateProvinceFieldNames.StateProvinceCode, "StateProvinceCode" }, 
						{ (int)PersonStateProvinceFieldNames.CountryRegionCode, "CountryRegionCode" }, 
						{ (int)PersonStateProvinceFieldNames.IsOnlyStateProvinceFlag, "IsOnlyStateProvinceFlag" }, 
						{ (int)PersonStateProvinceFieldNames.Name, "Name" }, 
						{ (int)PersonStateProvinceFieldNames.TerritoryID, "TerritoryID" }, 
						{ (int)PersonStateProvinceFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonStateProvinceFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonStateProvinceIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonStateProvinceFieldNames.Id, "StateProvinceID" }, 
				};

		public PersonStateProvinceTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.StateProvince";
			TableAlias = "personstateprovince";
			Columns = PersonStateProvinceColumnNames;
			IdColumns = PersonStateProvinceIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_StateProvince_CountryRegion_CountryRegionCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, PersonCountryRegion>("PersonCountryRegion")),
			TableName = "Person.CountryRegion",
			Alias = TableAlias + "_" + "PersonCountryRegion",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, PersonCountryRegion>("PersonCountryRegion");
					var st = (entity as PersonStateProvince);

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
					//PersonStateProvinceColumnNames.      .ToString()
					JoinField = "CountryRegionCode",
					Operator = Operator.Equals,
					ParentField = "CountryRegionCode",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_StateProvince_SalesTerritory_TerritoryID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory")),
			TableName = "Sales.SalesTerritory",
			Alias = TableAlias + "_" + "SalesSalesTerritory",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory");
					var st = (entity as PersonStateProvince);

					if (st == null || row == null)
						return st;

					if (row.TerritoryID == null || row.TerritoryID == default(int))
						return st;

					st.SalesSalesTerritory = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesTerritoryColumnNames.   .ToString()
					//PersonStateProvinceColumnNames.      .ToString()
					JoinField = "TerritoryID",
					Operator = Operator.Equals,
					ParentField = "TerritoryID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		