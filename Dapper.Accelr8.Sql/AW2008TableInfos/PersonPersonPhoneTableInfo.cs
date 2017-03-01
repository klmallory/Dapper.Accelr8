
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
	public enum PersonPersonPhoneColumnNames
	{	
		BusinessEntityID, 	
		PhoneNumber, 	
		PhoneNumberTypeID, 	
		ModifiedDate, 	
	}

	public enum PersonPersonPhoneCascadeNames
	{	
		
		personperson_p, 	
		personphonenumbertype_p, 	}

	public class PersonPersonPhoneTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonPersonPhoneTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonPersonPhoneColumnNames.BusinessEntityID.ToString();
			//Schema = "Person.PersonPhone";
			TableName = "Person.PersonPhone";
			TableAlias = "personpersonphone";
			ColumnNames = typeof(PersonPersonPhoneColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_PersonPhone_Person_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonPerson>("PersonPerson")),
			TableName = "Person.Person",
			Alias = TableAlias + "_" + "PersonPerson",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonPerson>("PersonPerson");
					var st = (entity as PersonPersonPhone);

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
					//PersonPersonPhoneColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonPhoneNumberType>("PersonPhoneNumberType")),
			TableName = "Person.PhoneNumberType",
			Alias = TableAlias + "_" + "PersonPhoneNumberType",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonPhoneNumberType>("PersonPhoneNumberType");
					var st = (entity as PersonPersonPhone);

					if (st == null || row == null)
						return st;

					if (row.PhoneNumberTypeID == null || row.PhoneNumberTypeID == default(int))
						return st;

					st.PersonPhoneNumberType = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonPhoneNumberTypeColumnNames.   .ToString()
					//PersonPersonPhoneColumnNames.      .ToString()
					JoinField = "PhoneNumberTypeID",
					Operator = Operator.Equals,
					ParentField = "PhoneNumberTypeID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		