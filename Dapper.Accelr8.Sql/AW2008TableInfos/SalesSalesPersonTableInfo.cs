
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
	public enum SalesSalesPersonFieldNames
	{	
		Id, 	
		TerritoryID, 	
		SalesQuota, 	
		Bonus, 	
		CommissionPct, 	
		SalesYTD, 	
		SalesLastYear, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSalesPersonCascadeNames
	{	
		salesstores, 	
		salessalesorderheaders, 	
		salessalespersonquotahistories, 	
		salessalesterritoryhistories, 	
		
		humanresourcesemployee_p, 	
		salessalesterritory_p, 	}

	public class SalesSalesPersonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSalesPersonColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesPersonFieldNames.Id, "BusinessEntityID" }, 
						{ (int)SalesSalesPersonFieldNames.TerritoryID, "TerritoryID" }, 
						{ (int)SalesSalesPersonFieldNames.SalesQuota, "SalesQuota" }, 
						{ (int)SalesSalesPersonFieldNames.Bonus, "Bonus" }, 
						{ (int)SalesSalesPersonFieldNames.CommissionPct, "CommissionPct" }, 
						{ (int)SalesSalesPersonFieldNames.SalesYTD, "SalesYTD" }, 
						{ (int)SalesSalesPersonFieldNames.SalesLastYear, "SalesLastYear" }, 
						{ (int)SalesSalesPersonFieldNames.rowguid, "rowguid" }, 
						{ (int)SalesSalesPersonFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSalesPersonIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesPersonFieldNames.Id, "BusinessEntityID" }, 
				};

		public SalesSalesPersonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SalesPerson";
			TableAlias = "salessalesperson";
			Columns = SalesSalesPersonColumnNames;
			IdColumns = SalesSalesPersonIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_SalesPerson_Employee_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee")),
			TableName = "HumanResources.Employee",
			Alias = TableAlias + "_" + "HumanResourcesEmployee",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee");
					var st = (entity as SalesSalesPerson);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.HumanResourcesEmployee = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//HumanResourcesEmployeeColumnNames.   .ToString()
					//SalesSalesPersonColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesPerson_SalesTerritory_TerritoryID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory")),
			TableName = "Sales.SalesTerritory",
			Alias = TableAlias + "_" + "SalesSalesTerritory",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory");
					var st = (entity as SalesSalesPerson);

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
					//SalesSalesPersonColumnNames.      .ToString()
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

		