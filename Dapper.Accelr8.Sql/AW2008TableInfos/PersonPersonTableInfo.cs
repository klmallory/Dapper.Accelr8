
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
	public enum PersonPersonFieldNames
	{	
		Id, 	
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
		personbusinessentitycontacts, 	
		salescustomers, 	
		personemailaddresses, 	
		humanresourcesemployees, 	
		personpasswords, 	
		salespersoncreditcards, 	
		personpersonphones, 	
		
		personbusinessentity_p, 	}

	public class PersonPersonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonPersonColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonPersonFieldNames.Id, "BusinessEntityID" }, 
						{ (int)PersonPersonFieldNames.PersonType, "PersonType" }, 
						{ (int)PersonPersonFieldNames.NameStyle, "NameStyle" }, 
						{ (int)PersonPersonFieldNames.Title, "Title" }, 
						{ (int)PersonPersonFieldNames.FirstName, "FirstName" }, 
						{ (int)PersonPersonFieldNames.MiddleName, "MiddleName" }, 
						{ (int)PersonPersonFieldNames.LastName, "LastName" }, 
						{ (int)PersonPersonFieldNames.Suffix, "Suffix" }, 
						{ (int)PersonPersonFieldNames.EmailPromotion, "EmailPromotion" }, 
						{ (int)PersonPersonFieldNames.AdditionalContactInfo, "AdditionalContactInfo" }, 
						{ (int)PersonPersonFieldNames.Demographics, "Demographics" }, 
						{ (int)PersonPersonFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonPersonFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonPersonIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonPersonFieldNames.Id, "BusinessEntityID" }, 
				};

		public PersonPersonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.Person";
			TableAlias = "personperson";
			Columns = PersonPersonColumnNames;
			IdColumns = PersonPersonIdColumnNames;

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

		