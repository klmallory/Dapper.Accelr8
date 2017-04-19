
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
	public enum PersonEmailAddressFieldNames
	{	
		BusinessEntityID, 	
		EmailAddressID, 	
		EmailAddress, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonEmailAddressCascadeNames
	{	
		
		personperson_p, 	}

	public class PersonEmailAddressTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonEmailAddressColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonEmailAddressFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)PersonEmailAddressFieldNames.EmailAddressID, "EmailAddressID" }, 
						{ (int)PersonEmailAddressFieldNames.EmailAddress, "EmailAddress" }, 
						{ (int)PersonEmailAddressFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonEmailAddressFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonEmailAddressIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonEmailAddressFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)PersonEmailAddressFieldNames.EmailAddressID, "EmailAddressID" }, 
				};

		public PersonEmailAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.EmailAddress";
			TableAlias = "personemailaddress";
			Columns = PersonEmailAddressColumnNames;
			IdColumns = PersonEmailAddressIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_EmailAddress_Person_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonPerson>("PersonPerson")),
			TableName = "Person.Person",
			Alias = TableAlias + "_" + "PersonPerson",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonPerson>("PersonPerson");
					var st = (entity as PersonEmailAddress);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.PersonPerson = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonPersonColumnNames.   .ToString()
					//PersonEmailAddressColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		