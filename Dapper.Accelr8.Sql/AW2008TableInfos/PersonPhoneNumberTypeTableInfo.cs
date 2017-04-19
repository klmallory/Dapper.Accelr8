
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
	public enum PersonPhoneNumberTypeFieldNames
	{	
		Id, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum PersonPhoneNumberTypeCascadeNames
	{	
		personpersonphones, 	
		}

	public class PersonPhoneNumberTypeTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonPhoneNumberTypeColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonPhoneNumberTypeFieldNames.Id, "PhoneNumberTypeID" }, 
						{ (int)PersonPhoneNumberTypeFieldNames.Name, "Name" }, 
						{ (int)PersonPhoneNumberTypeFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonPhoneNumberTypeIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonPhoneNumberTypeFieldNames.Id, "PhoneNumberTypeID" }, 
				};

		public PersonPhoneNumberTypeTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.PhoneNumberType";
			TableAlias = "personphonenumbertype";
			Columns = PersonPhoneNumberTypeColumnNames;
			IdColumns = PersonPhoneNumberTypeIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		