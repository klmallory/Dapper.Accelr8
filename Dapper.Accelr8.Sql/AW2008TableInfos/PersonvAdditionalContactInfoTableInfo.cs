
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
	public enum PersonvAdditionalContactInfoColumnNames
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
		public PersonvAdditionalContactInfoTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = PersonvAdditionalContactInfoColumnNames.BusinessEntityID.ToString();
			//Schema = "Person.vAdditionalContactInfo";
			TableName = "Person.vAdditionalContactInfo";
			TableAlias = "personvadditionalcontactinfo";
			ColumnNames = typeof(PersonvAdditionalContactInfoColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		