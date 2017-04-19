
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
	public enum SalesvIndividualCustomerFieldNames
	{	
		BusinessEntityID, 	
		Title, 	
		FirstName, 	
		MiddleName, 	
		LastName, 	
		Suffix, 	
		PhoneNumber, 	
		PhoneNumberType, 	
		EmailAddress, 	
		EmailPromotion, 	
		AddressType, 	
		AddressLine1, 	
		AddressLine2, 	
		City, 	
		StateProvinceName, 	
		PostalCode, 	
		CountryRegionName, 	
		Demographics, 	
	}

	public enum SalesvIndividualCustomerCascadeNames
	{	
		}

	public class SalesvIndividualCustomerTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesvIndividualCustomerColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesvIndividualCustomerFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesvIndividualCustomerFieldNames.Title, "Title" }, 
						{ (int)SalesvIndividualCustomerFieldNames.FirstName, "FirstName" }, 
						{ (int)SalesvIndividualCustomerFieldNames.MiddleName, "MiddleName" }, 
						{ (int)SalesvIndividualCustomerFieldNames.LastName, "LastName" }, 
						{ (int)SalesvIndividualCustomerFieldNames.Suffix, "Suffix" }, 
						{ (int)SalesvIndividualCustomerFieldNames.PhoneNumber, "PhoneNumber" }, 
						{ (int)SalesvIndividualCustomerFieldNames.PhoneNumberType, "PhoneNumberType" }, 
						{ (int)SalesvIndividualCustomerFieldNames.EmailAddress, "EmailAddress" }, 
						{ (int)SalesvIndividualCustomerFieldNames.EmailPromotion, "EmailPromotion" }, 
						{ (int)SalesvIndividualCustomerFieldNames.AddressType, "AddressType" }, 
						{ (int)SalesvIndividualCustomerFieldNames.AddressLine1, "AddressLine1" }, 
						{ (int)SalesvIndividualCustomerFieldNames.AddressLine2, "AddressLine2" }, 
						{ (int)SalesvIndividualCustomerFieldNames.City, "City" }, 
						{ (int)SalesvIndividualCustomerFieldNames.StateProvinceName, "StateProvinceName" }, 
						{ (int)SalesvIndividualCustomerFieldNames.PostalCode, "PostalCode" }, 
						{ (int)SalesvIndividualCustomerFieldNames.CountryRegionName, "CountryRegionName" }, 
						{ (int)SalesvIndividualCustomerFieldNames.Demographics, "Demographics" }, 
				};	

		public static readonly IDictionary<int, string> SalesvIndividualCustomerIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)SalesvIndividualCustomerFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public SalesvIndividualCustomerTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Sales";
			TableName = "Sales.vIndividualCustomer";
			TableAlias = "salesvindividualcustomer";
			Columns = SalesvIndividualCustomerColumnNames;
			IdColumns = SalesvIndividualCustomerIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		