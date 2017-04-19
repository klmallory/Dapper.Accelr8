
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
	public enum SalesPersonCreditCardFieldNames
	{	
		BusinessEntityID, 	
		CreditCardID, 	
		ModifiedDate, 	
	}

	public enum SalesPersonCreditCardCascadeNames
	{	
		
		salescreditcard_p, 	
		personperson_p, 	}

	public class SalesPersonCreditCardTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesPersonCreditCardColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesPersonCreditCardFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesPersonCreditCardFieldNames.CreditCardID, "CreditCardID" }, 
						{ (int)SalesPersonCreditCardFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesPersonCreditCardIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesPersonCreditCardFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesPersonCreditCardFieldNames.CreditCardID, "CreditCardID" }, 
				};

		public SalesPersonCreditCardTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.PersonCreditCard";
			TableAlias = "salespersoncreditcard";
			Columns = SalesPersonCreditCardColumnNames;
			IdColumns = SalesPersonCreditCardIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_PersonCreditCard_CreditCard_CreditCardID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesCreditCard>("SalesCreditCard")),
			TableName = "Sales.CreditCard",
			Alias = TableAlias + "_" + "SalesCreditCard",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesCreditCard>("SalesCreditCard");
					var st = (entity as SalesPersonCreditCard);

					if (st == null || row == null)
						return st;

					if (row.CreditCardID == null || row.CreditCardID == default(int))
						return st;

					st.SalesCreditCard = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesCreditCardColumnNames.   .ToString()
					//SalesPersonCreditCardColumnNames.      .ToString()
					JoinField = "CreditCardID",
					Operator = Operator.Equals,
					ParentField = "CreditCardID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_PersonCreditCard_Person_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonPerson>("PersonPerson")),
			TableName = "Person.Person",
			Alias = TableAlias + "_" + "PersonPerson",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonPerson>("PersonPerson");
					var st = (entity as SalesPersonCreditCard);

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
					//SalesPersonCreditCardColumnNames.      .ToString()
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

		