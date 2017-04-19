
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
	public enum PersonBusinessEntityContactFieldNames
	{	
		BusinessEntityID, 	
		PersonID, 	
		ContactTypeID, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonBusinessEntityContactCascadeNames
	{	
		
		personbusinessentity_p, 	
		personcontacttype_p, 	
		personperson_p, 	}

	public class PersonBusinessEntityContactTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonBusinessEntityContactColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonBusinessEntityContactFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)PersonBusinessEntityContactFieldNames.PersonID, "PersonID" }, 
						{ (int)PersonBusinessEntityContactFieldNames.ContactTypeID, "ContactTypeID" }, 
						{ (int)PersonBusinessEntityContactFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonBusinessEntityContactFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonBusinessEntityContactIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonBusinessEntityContactFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)PersonBusinessEntityContactFieldNames.PersonID, "PersonID" }, 
						{ (int)PersonBusinessEntityContactFieldNames.ContactTypeID, "ContactTypeID" }, 
				};

		public PersonBusinessEntityContactTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.BusinessEntityContact";
			TableAlias = "personbusinessentitycontact";
			Columns = PersonBusinessEntityContactColumnNames;
			IdColumns = PersonBusinessEntityContactIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity")),
			TableName = "Person.BusinessEntity",
			Alias = TableAlias + "_" + "PersonBusinessEntity",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity");
					var st = (entity as PersonBusinessEntityContact);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.PersonBusinessEntity = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonBusinessEntityColumnNames.   .ToString()
					//PersonBusinessEntityContactColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_BusinessEntityContact_ContactType_ContactTypeID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonContactType>("PersonContactType")),
			TableName = "Person.ContactType",
			Alias = TableAlias + "_" + "PersonContactType",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonContactType>("PersonContactType");
					var st = (entity as PersonBusinessEntityContact);

					if (st == null || row == null)
						return st;

					if (row.ContactTypeID == null || row.ContactTypeID == default(int))
						return st;

					st.PersonContactType = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonContactTypeColumnNames.   .ToString()
					//PersonBusinessEntityContactColumnNames.      .ToString()
					JoinField = "ContactTypeID",
					Operator = Operator.Equals,
					ParentField = "ContactTypeID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_BusinessEntityContact_Person_PersonID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonPerson>("PersonPerson")),
			TableName = "Person.Person",
			Alias = TableAlias + "_" + "PersonPerson",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonPerson>("PersonPerson");
					var st = (entity as PersonBusinessEntityContact);

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
					//PersonBusinessEntityContactColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "PersonID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		