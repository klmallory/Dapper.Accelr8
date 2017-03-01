
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
	public enum SalesvIndividualCustomerColumnNames
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
		public SalesvIndividualCustomerTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = SalesvIndividualCustomerColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.vIndividualCustomer";
			TableName = "Sales.vIndividualCustomer";
			TableAlias = "salesvindividualcustomer";
			ColumnNames = typeof(SalesvIndividualCustomerColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		