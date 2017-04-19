
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
	public enum PurchasingvVendorWithContactFieldNames
	{	
		BusinessEntityID, 	
		Name, 	
		ContactType, 	
		Title, 	
		FirstName, 	
		MiddleName, 	
		LastName, 	
		Suffix, 	
		PhoneNumber, 	
		PhoneNumberType, 	
		EmailAddress, 	
		EmailPromotion, 	
	}

	public enum PurchasingvVendorWithContactCascadeNames
	{	
		}

	public class PurchasingvVendorWithContactTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PurchasingvVendorWithContactColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PurchasingvVendorWithContactFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.Name, "Name" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.ContactType, "ContactType" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.Title, "Title" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.FirstName, "FirstName" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.MiddleName, "MiddleName" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.LastName, "LastName" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.Suffix, "Suffix" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.PhoneNumber, "PhoneNumber" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.PhoneNumberType, "PhoneNumberType" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.EmailAddress, "EmailAddress" }, 
						{ (int)PurchasingvVendorWithContactFieldNames.EmailPromotion, "EmailPromotion" }, 
				};	

		public static readonly IDictionary<int, string> PurchasingvVendorWithContactIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)PurchasingvVendorWithContactFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public PurchasingvVendorWithContactTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Purchasing";
			TableName = "Purchasing.vVendorWithContacts";
			TableAlias = "purchasingvvendorwithcontact";
			Columns = PurchasingvVendorWithContactColumnNames;
			IdColumns = PurchasingvVendorWithContactIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		