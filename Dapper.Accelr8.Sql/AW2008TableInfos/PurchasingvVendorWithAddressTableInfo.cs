
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
	public enum PurchasingvVendorWithAddressFieldNames
	{	
		BusinessEntityID, 	
		Name, 	
		AddressType, 	
		AddressLine1, 	
		AddressLine2, 	
		City, 	
		StateProvinceName, 	
		PostalCode, 	
		CountryRegionName, 	
	}

	public enum PurchasingvVendorWithAddressCascadeNames
	{	
		}

	public class PurchasingvVendorWithAddressTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PurchasingvVendorWithAddressColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PurchasingvVendorWithAddressFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)PurchasingvVendorWithAddressFieldNames.Name, "Name" }, 
						{ (int)PurchasingvVendorWithAddressFieldNames.AddressType, "AddressType" }, 
						{ (int)PurchasingvVendorWithAddressFieldNames.AddressLine1, "AddressLine1" }, 
						{ (int)PurchasingvVendorWithAddressFieldNames.AddressLine2, "AddressLine2" }, 
						{ (int)PurchasingvVendorWithAddressFieldNames.City, "City" }, 
						{ (int)PurchasingvVendorWithAddressFieldNames.StateProvinceName, "StateProvinceName" }, 
						{ (int)PurchasingvVendorWithAddressFieldNames.PostalCode, "PostalCode" }, 
						{ (int)PurchasingvVendorWithAddressFieldNames.CountryRegionName, "CountryRegionName" }, 
				};	

		public static readonly IDictionary<int, string> PurchasingvVendorWithAddressIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)PurchasingvVendorWithAddressFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public PurchasingvVendorWithAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Purchasing";
			TableName = "Purchasing.vVendorWithAddresses";
			TableAlias = "purchasingvvendorwithaddress";
			Columns = PurchasingvVendorWithAddressColumnNames;
			IdColumns = PurchasingvVendorWithAddressIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		