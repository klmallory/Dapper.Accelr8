
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
	public enum HumanResourcesvEmployeeFieldNames
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
	
		public static readonly IDictionary<int, string> HumanResourcesvEmployeeColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesvEmployeeFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.Title, "Title" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.FirstName, "FirstName" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.MiddleName, "MiddleName" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.LastName, "LastName" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.Suffix, "Suffix" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.JobTitle, "JobTitle" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.PhoneNumber, "PhoneNumber" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.PhoneNumberType, "PhoneNumberType" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.EmailAddress, "EmailAddress" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.EmailPromotion, "EmailPromotion" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.AddressLine1, "AddressLine1" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.AddressLine2, "AddressLine2" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.City, "City" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.StateProvinceName, "StateProvinceName" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.PostalCode, "PostalCode" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.CountryRegionName, "CountryRegionName" }, 
						{ (int)HumanResourcesvEmployeeFieldNames.AdditionalContactInfo, "AdditionalContactInfo" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesvEmployeeIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)HumanResourcesvEmployeeFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public HumanResourcesvEmployeeTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "HumanResources";
			TableName = "HumanResources.vEmployee";
			TableAlias = "humanresourcesvemployee";
			Columns = HumanResourcesvEmployeeColumnNames;
			IdColumns = HumanResourcesvEmployeeIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		