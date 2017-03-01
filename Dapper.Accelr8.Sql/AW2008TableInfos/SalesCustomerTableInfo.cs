
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
	public enum SalesCustomerColumnNames
	{	
		CustomerID, 	
		PersonID, 	
		StoreID, 	
		TerritoryID, 	
		AccountNumber, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesCustomerCascadeNames
	{	
		salessalesorderheader, 	
		
		salesstore_p, 	
		personperson_p, 	
		salessalesterritory_p, 	}

	public class SalesCustomerTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesCustomerTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesCustomerColumnNames.CustomerID.ToString();
			//Schema = "Sales.Customer";
			TableName = "Sales.Customer";
			TableAlias = "salescustomer";
			ColumnNames = typeof(SalesCustomerColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_Customer_Store_StoreID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesStore>("SalesStore")),
			TableName = "Sales.Store",
			Alias = TableAlias + "_" + "SalesStore",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesStore>("SalesStore");
					var st = (entity as SalesCustomer);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.SalesStore = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesStoreColumnNames.   .ToString()
					//SalesCustomerColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "StoreID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Customer_Person_PersonID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonPerson>("PersonPerson")),
			TableName = "Person.Person",
			Alias = TableAlias + "_" + "PersonPerson",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonPerson>("PersonPerson");
					var st = (entity as SalesCustomer);

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
					//SalesCustomerColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "PersonID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Customer_SalesTerritory_TerritoryID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory")),
			TableName = "Sales.SalesTerritory",
			Alias = TableAlias + "_" + "SalesSalesTerritory",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory");
					var st = (entity as SalesCustomer);

					if (st == null || row == null)
						return st;

					if (row.TerritoryID == null || row.TerritoryID == default(int))
						return st;

					st.SalesSalesTerritory = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesTerritoryColumnNames.   .ToString()
					//SalesCustomerColumnNames.      .ToString()
					JoinField = "TerritoryID",
					Operator = Operator.Equals,
					ParentField = "TerritoryID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		