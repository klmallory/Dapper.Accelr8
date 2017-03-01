
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
	public enum SalesvStoreWithAddressColumnNames
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
		public SalesvStoreWithAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = SalesvStoreWithAddressColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.vStoreWithAddresses";
			TableName = "Sales.vStoreWithAddresses";
			TableAlias = "salesvstorewithaddress";
			ColumnNames = typeof(SalesvStoreWithAddressColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		