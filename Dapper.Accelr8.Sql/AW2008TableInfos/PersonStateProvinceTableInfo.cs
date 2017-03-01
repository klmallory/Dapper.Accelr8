
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
	public enum PersonStateProvinceColumnNames
	{	
		StateProvinceID, 	
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
		personaddress, 	
		salessalestaxrate, 	
		
		personcountryregion_p, 	
		salessalesterritory_p, 	}

	public class PersonStateProvinceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonStateProvinceTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonStateProvinceColumnNames.StateProvinceID.ToString();
			//Schema = "Person.StateProvince";
			TableName = "Person.StateProvince";
			TableAlias = "personstateprovince";
			ColumnNames = typeof(PersonStateProvinceColumnNames).ToDataList<Type, int>();

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

		