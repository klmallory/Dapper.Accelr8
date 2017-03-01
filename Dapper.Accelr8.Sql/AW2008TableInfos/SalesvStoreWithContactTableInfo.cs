
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
	public enum SalesvStoreWithContactColumnNames
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

	public enum SalesvStoreWithContactCascadeNames
	{	
		}

	public class SalesvStoreWithContactTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesvStoreWithContactTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = SalesvStoreWithContactColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.vStoreWithContacts";
			TableName = "Sales.vStoreWithContacts";
			TableAlias = "salesvstorewithcontact";
			ColumnNames = typeof(SalesvStoreWithContactColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		