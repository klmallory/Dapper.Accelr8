
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
	public enum PersonContactTypeFieldNames
	{	
		Id, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum PersonContactTypeCascadeNames
	{	
		personbusinessentitycontacts, 	
		}

	public class PersonContactTypeTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonContactTypeColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonContactTypeFieldNames.Id, "ContactTypeID" }, 
						{ (int)PersonContactTypeFieldNames.Name, "Name" }, 
						{ (int)PersonContactTypeFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonContactTypeIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonContactTypeFieldNames.Id, "ContactTypeID" }, 
				};

		public PersonContactTypeTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.ContactType";
			TableAlias = "personcontacttype";
			Columns = PersonContactTypeColumnNames;
			IdColumns = PersonContactTypeIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		