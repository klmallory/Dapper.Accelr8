
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
	public enum SalesvSalesPersonColumnNames
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
		TerritoryName, 	
		TerritoryGroup, 	
		SalesQuota, 	
		SalesYTD, 	
		SalesLastYear, 	
	}

	public enum SalesvSalesPersonCascadeNames
	{	
		}

	public class SalesvSalesPersonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesvSalesPersonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = SalesvSalesPersonColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.vSalesPerson";
			TableName = "Sales.vSalesPerson";
			TableAlias = "salesvsalesperson";
			ColumnNames = typeof(SalesvSalesPersonColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		