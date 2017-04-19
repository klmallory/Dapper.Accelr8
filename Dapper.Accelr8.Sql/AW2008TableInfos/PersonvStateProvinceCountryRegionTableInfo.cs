
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
	public enum PersonvStateProvinceCountryRegionFieldNames
	{	
		StateProvinceID, 	
		StateProvinceCode, 	
		IsOnlyStateProvinceFlag, 	
		StateProvinceName, 	
		TerritoryID, 	
		CountryRegionCode, 	
		CountryRegionName, 	
	}

	public enum PersonvStateProvinceCountryRegionCascadeNames
	{	
		}

	public class PersonvStateProvinceCountryRegionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonvStateProvinceCountryRegionColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonvStateProvinceCountryRegionFieldNames.StateProvinceID, "StateProvinceID" }, 
						{ (int)PersonvStateProvinceCountryRegionFieldNames.StateProvinceCode, "StateProvinceCode" }, 
						{ (int)PersonvStateProvinceCountryRegionFieldNames.IsOnlyStateProvinceFlag, "IsOnlyStateProvinceFlag" }, 
						{ (int)PersonvStateProvinceCountryRegionFieldNames.StateProvinceName, "StateProvinceName" }, 
						{ (int)PersonvStateProvinceCountryRegionFieldNames.TerritoryID, "TerritoryID" }, 
						{ (int)PersonvStateProvinceCountryRegionFieldNames.CountryRegionCode, "CountryRegionCode" }, 
						{ (int)PersonvStateProvinceCountryRegionFieldNames.CountryRegionName, "CountryRegionName" }, 
				};	

		public static readonly IDictionary<int, string> PersonvStateProvinceCountryRegionIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)PersonvStateProvinceCountryRegionFieldNames.StateProvinceID, "StateProvinceID" }, 
				};

		public PersonvStateProvinceCountryRegionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Person";
			TableName = "Person.vStateProvinceCountryRegion";
			TableAlias = "personvstateprovincecountryregion";
			Columns = PersonvStateProvinceCountryRegionColumnNames;
			IdColumns = PersonvStateProvinceCountryRegionIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		