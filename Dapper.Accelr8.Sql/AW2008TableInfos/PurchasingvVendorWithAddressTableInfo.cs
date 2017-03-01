
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
	public enum PurchasingvVendorWithAddressColumnNames
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
		public PurchasingvVendorWithAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = PurchasingvVendorWithAddressColumnNames.BusinessEntityID.ToString();
			//Schema = "Purchasing.vVendorWithAddresses";
			TableName = "Purchasing.vVendorWithAddresses";
			TableAlias = "purchasingvvendorwithaddress";
			ColumnNames = typeof(PurchasingvVendorWithAddressColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		