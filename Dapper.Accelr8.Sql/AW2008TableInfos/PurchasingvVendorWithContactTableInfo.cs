
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
	public enum PurchasingvVendorWithContactColumnNames
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
		public PurchasingvVendorWithContactTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = PurchasingvVendorWithContactColumnNames.BusinessEntityID.ToString();
			//Schema = "Purchasing.vVendorWithContacts";
			TableName = "Purchasing.vVendorWithContacts";
			TableAlias = "purchasingvvendorwithcontact";
			ColumnNames = typeof(PurchasingvVendorWithContactColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		