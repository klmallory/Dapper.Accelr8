
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
	public enum HumanResourcesvEmployeeColumnNames
	{	
		BusinessEntityID, 	
		Title, 	
		FirstName, 	
		MiddleName, 	
		LastName, 	
		Suffix, 	
		JobTitle, 	
		PhoneNumber, 	
		PhoneNumberType, 	
		EmailAddress, 	
		EmailPromotion, 	
		AddressLine1, 	
		AddressLine2, 	
		City, 	
		StateProvinceName, 	
		PostalCode, 	
		CountryRegionName, 	
		AdditionalContactInfo, 	
	}

	public enum HumanResourcesvEmployeeCascadeNames
	{	
		}

	public class HumanResourcesvEmployeeTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public HumanResourcesvEmployeeTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = HumanResourcesvEmployeeColumnNames.BusinessEntityID.ToString();
			//Schema = "HumanResources.vEmployee";
			TableName = "HumanResources.vEmployee";
			TableAlias = "humanresourcesvemployee";
			ColumnNames = typeof(HumanResourcesvEmployeeColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		