
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
	public enum PersonvAdditionalContactInfoFieldNames
	{	
		BusinessEntityID, 	
		FirstName, 	
		MiddleName, 	
		LastName, 	
		TelephoneNumber, 	
		TelephoneSpecialInstructions, 	
		Street, 	
		City, 	
		StateProvince, 	
		PostalCode, 	
		CountryRegion, 	
		HomeAddressSpecialInstructions, 	
		EMailAddress, 	
		EMailSpecialInstructions, 	
		EMailTelephoneNumber, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonvAdditionalContactInfoCascadeNames
	{	
		}

	public class PersonvAdditionalContactInfoTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonvAdditionalContactInfoColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonvAdditionalContactInfoFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.FirstName, "FirstName" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.MiddleName, "MiddleName" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.LastName, "LastName" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.TelephoneNumber, "TelephoneNumber" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.TelephoneSpecialInstructions, "TelephoneSpecialInstructions" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.Street, "Street" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.City, "City" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.StateProvince, "StateProvince" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.PostalCode, "PostalCode" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.CountryRegion, "CountryRegion" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.HomeAddressSpecialInstructions, "HomeAddressSpecialInstructions" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.EMailAddress, "EMailAddress" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.EMailSpecialInstructions, "EMailSpecialInstructions" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.EMailTelephoneNumber, "EMailTelephoneNumber" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonvAdditionalContactInfoFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonvAdditionalContactInfoIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)PersonvAdditionalContactInfoFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public PersonvAdditionalContactInfoTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Person";
			TableName = "Person.vAdditionalContactInfo";
			TableAlias = "personvadditionalcontactinfo";
			Columns = PersonvAdditionalContactInfoColumnNames;
			IdColumns = PersonvAdditionalContactInfoIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		