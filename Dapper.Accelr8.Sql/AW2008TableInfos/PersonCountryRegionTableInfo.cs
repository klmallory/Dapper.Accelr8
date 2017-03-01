
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
	public enum PersonCountryRegionColumnNames
	{	
		CountryRegionCode, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum PersonCountryRegionCascadeNames
	{	
		personstateprovince, 	
		salescountryregioncurrency, 	
		salessalesterritory, 	
		}

	public class PersonCountryRegionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonCountryRegionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonCountryRegionColumnNames.CountryRegionCode.ToString();
			//Schema = "Person.CountryRegion";
			TableName = "Person.CountryRegion";
			TableAlias = "personcountryregion";
			ColumnNames = typeof(PersonCountryRegionColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		