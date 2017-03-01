
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
	public enum PersonPersonColumnNames
	{	
		BusinessEntityID, 	
		PersonType, 	
		NameStyle, 	
		Title, 	
		FirstName, 	
		MiddleName, 	
		LastName, 	
		Suffix, 	
		EmailPromotion, 	
		AdditionalContactInfo, 	
		Demographics, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonPersonCascadeNames
	{	
		personbusinessentitycontact, 	
		salescustomer, 	
		personemailaddress, 	
		humanresourcesemployee, 	
		personpassword, 	
		salespersoncreditcard, 	
		personpersonphone, 	
		
		personbusinessentity_p, 	}

	public class PersonPersonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonPersonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonPersonColumnNames.BusinessEntityID.ToString();
			//Schema = "Person.Person";
			TableName = "Person.Person";
			TableAlias = "personperson";
			ColumnNames = typeof(PersonPersonColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_Person_BusinessEntity_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity")),
			TableName = "Person.BusinessEntity",
			Alias = TableAlias + "_" + "PersonBusinessEntity",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity");
					var st = (entity as PersonPerson);

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
					//PersonPersonColumnNames.      .ToString()
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

		