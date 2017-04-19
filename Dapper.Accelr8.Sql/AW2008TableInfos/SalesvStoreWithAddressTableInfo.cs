
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
	public enum SalesvStoreWithAddressFieldNames
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

	public enum SalesvStoreWithAddressCascadeNames
	{	
		}

	public class SalesvStoreWithAddressTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesvStoreWithAddressColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesvStoreWithAddressFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesvStoreWithAddressFieldNames.Name, "Name" }, 
						{ (int)SalesvStoreWithAddressFieldNames.AddressType, "AddressType" }, 
						{ (int)SalesvStoreWithAddressFieldNames.AddressLine1, "AddressLine1" }, 
						{ (int)SalesvStoreWithAddressFieldNames.AddressLine2, "AddressLine2" }, 
						{ (int)SalesvStoreWithAddressFieldNames.City, "City" }, 
						{ (int)SalesvStoreWithAddressFieldNames.StateProvinceName, "StateProvinceName" }, 
						{ (int)SalesvStoreWithAddressFieldNames.PostalCode, "PostalCode" }, 
						{ (int)SalesvStoreWithAddressFieldNames.CountryRegionName, "CountryRegionName" }, 
				};	

		public static readonly IDictionary<int, string> SalesvStoreWithAddressIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)SalesvStoreWithAddressFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public SalesvStoreWithAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Sales";
			TableName = "Sales.vStoreWithAddresses";
			TableAlias = "salesvstorewithaddress";
			Columns = SalesvStoreWithAddressColumnNames;
			IdColumns = SalesvStoreWithAddressIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		