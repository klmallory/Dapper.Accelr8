
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
	public enum PersonEmailAddressColumnNames
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
		public PersonEmailAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonEmailAddressColumnNames.BusinessEntityID.ToString();
			//Schema = "Person.EmailAddress";
			TableName = "Person.EmailAddress";
			TableAlias = "personemailaddress";
			ColumnNames = typeof(PersonEmailAddressColumnNames).ToDataList<Type, int>();

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

		