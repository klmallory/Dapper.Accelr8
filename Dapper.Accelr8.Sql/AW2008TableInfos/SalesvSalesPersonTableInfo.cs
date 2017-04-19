
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
	public enum SalesvSalesPersonFieldNames
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
	
		public static readonly IDictionary<int, string> SalesvSalesPersonColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesvSalesPersonFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesvSalesPersonFieldNames.Title, "Title" }, 
						{ (int)SalesvSalesPersonFieldNames.FirstName, "FirstName" }, 
						{ (int)SalesvSalesPersonFieldNames.MiddleName, "MiddleName" }, 
						{ (int)SalesvSalesPersonFieldNames.LastName, "LastName" }, 
						{ (int)SalesvSalesPersonFieldNames.Suffix, "Suffix" }, 
						{ (int)SalesvSalesPersonFieldNames.JobTitle, "JobTitle" }, 
						{ (int)SalesvSalesPersonFieldNames.PhoneNumber, "PhoneNumber" }, 
						{ (int)SalesvSalesPersonFieldNames.PhoneNumberType, "PhoneNumberType" }, 
						{ (int)SalesvSalesPersonFieldNames.EmailAddress, "EmailAddress" }, 
						{ (int)SalesvSalesPersonFieldNames.EmailPromotion, "EmailPromotion" }, 
						{ (int)SalesvSalesPersonFieldNames.AddressLine1, "AddressLine1" }, 
						{ (int)SalesvSalesPersonFieldNames.AddressLine2, "AddressLine2" }, 
						{ (int)SalesvSalesPersonFieldNames.City, "City" }, 
						{ (int)SalesvSalesPersonFieldNames.StateProvinceName, "StateProvinceName" }, 
						{ (int)SalesvSalesPersonFieldNames.PostalCode, "PostalCode" }, 
						{ (int)SalesvSalesPersonFieldNames.CountryRegionName, "CountryRegionName" }, 
						{ (int)SalesvSalesPersonFieldNames.TerritoryName, "TerritoryName" }, 
						{ (int)SalesvSalesPersonFieldNames.TerritoryGroup, "TerritoryGroup" }, 
						{ (int)SalesvSalesPersonFieldNames.SalesQuota, "SalesQuota" }, 
						{ (int)SalesvSalesPersonFieldNames.SalesYTD, "SalesYTD" }, 
						{ (int)SalesvSalesPersonFieldNames.SalesLastYear, "SalesLastYear" }, 
				};	

		public static readonly IDictionary<int, string> SalesvSalesPersonIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)SalesvSalesPersonFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public SalesvSalesPersonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Sales";
			TableName = "Sales.vSalesPerson";
			TableAlias = "salesvsalesperson";
			Columns = SalesvSalesPersonColumnNames;
			IdColumns = SalesvSalesPersonIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		