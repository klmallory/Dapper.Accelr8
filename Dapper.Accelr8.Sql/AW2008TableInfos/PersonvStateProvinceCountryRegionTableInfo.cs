
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
	public enum PersonvStateProvinceCountryRegionColumnNames
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
		public PersonvStateProvinceCountryRegionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = PersonvStateProvinceCountryRegionColumnNames.StateProvinceID.ToString();
			//Schema = "Person.vStateProvinceCountryRegion";
			TableName = "Person.vStateProvinceCountryRegion";
			TableAlias = "personvstateprovincecountryregion";
			ColumnNames = typeof(PersonvStateProvinceCountryRegionColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		