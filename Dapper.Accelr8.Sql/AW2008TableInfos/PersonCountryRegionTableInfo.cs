
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
	public enum PersonCountryRegionFieldNames
	{	
		Id, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum PersonCountryRegionCascadeNames
	{	
		personstateprovinces, 	
		salescountryregioncurrencies, 	
		salessalesterritories, 	
		}

	public class PersonCountryRegionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonCountryRegionColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonCountryRegionFieldNames.Id, "CountryRegionCode" }, 
						{ (int)PersonCountryRegionFieldNames.Name, "Name" }, 
						{ (int)PersonCountryRegionFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonCountryRegionIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonCountryRegionFieldNames.Id, "CountryRegionCode" }, 
				};

		public PersonCountryRegionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.CountryRegion";
			TableAlias = "personcountryregion";
			Columns = PersonCountryRegionColumnNames;
			IdColumns = PersonCountryRegionIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		