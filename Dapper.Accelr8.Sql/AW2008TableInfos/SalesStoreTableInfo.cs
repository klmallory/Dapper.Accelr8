
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
	public enum SalesStoreColumnNames
	{	
		BusinessEntityID, 	
		Name, 	
		SalesPersonID, 	
		Demographics, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesStoreCascadeNames
	{	
		salescustomer, 	
		
		personbusinessentity_p, 	
		salessalesperson_p, 	}

	public class SalesStoreTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesStoreTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesStoreColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.Store";
			TableName = "Sales.Store";
			TableAlias = "salesstore";
			ColumnNames = typeof(SalesStoreColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_Store_BusinessEntity_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity")),
			TableName = "Person.BusinessEntity",
			Alias = TableAlias + "_" + "PersonBusinessEntity",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity");
					var st = (entity as SalesStore);

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
					//SalesStoreColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Store_SalesPerson_SalesPersonID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesPerson>("SalesSalesPerson")),
			TableName = "Sales.SalesPerson",
			Alias = TableAlias + "_" + "SalesSalesPerson",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesPerson>("SalesSalesPerson");
					var st = (entity as SalesStore);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.SalesSalesPerson = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesPersonColumnNames.   .ToString()
					//SalesStoreColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "SalesPersonID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		