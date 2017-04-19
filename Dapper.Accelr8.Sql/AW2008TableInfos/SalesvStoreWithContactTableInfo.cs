
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
	public enum SalesvStoreWithContactFieldNames
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
	
		public static readonly IDictionary<int, string> SalesvStoreWithContactColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesvStoreWithContactFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesvStoreWithContactFieldNames.Name, "Name" }, 
						{ (int)SalesvStoreWithContactFieldNames.ContactType, "ContactType" }, 
						{ (int)SalesvStoreWithContactFieldNames.Title, "Title" }, 
						{ (int)SalesvStoreWithContactFieldNames.FirstName, "FirstName" }, 
						{ (int)SalesvStoreWithContactFieldNames.MiddleName, "MiddleName" }, 
						{ (int)SalesvStoreWithContactFieldNames.LastName, "LastName" }, 
						{ (int)SalesvStoreWithContactFieldNames.Suffix, "Suffix" }, 
						{ (int)SalesvStoreWithContactFieldNames.PhoneNumber, "PhoneNumber" }, 
						{ (int)SalesvStoreWithContactFieldNames.PhoneNumberType, "PhoneNumberType" }, 
						{ (int)SalesvStoreWithContactFieldNames.EmailAddress, "EmailAddress" }, 
						{ (int)SalesvStoreWithContactFieldNames.EmailPromotion, "EmailPromotion" }, 
				};	

		public static readonly IDictionary<int, string> SalesvStoreWithContactIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)SalesvStoreWithContactFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public SalesvStoreWithContactTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Sales";
			TableName = "Sales.vStoreWithContacts";
			TableAlias = "salesvstorewithcontact";
			Columns = SalesvStoreWithContactColumnNames;
			IdColumns = SalesvStoreWithContactIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		