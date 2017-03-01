
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
	public enum SalesSalesTerritoryHistoryColumnNames
	{	
		BusinessEntityID, 	
		TerritoryID, 	
		StartDate, 	
		EndDate, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSalesTerritoryHistoryCascadeNames
	{	
		
		salessalesperson_p, 	
		salessalesterritory_p, 	}

	public class SalesSalesTerritoryHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesSalesTerritoryHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesSalesTerritoryHistoryColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.SalesTerritoryHistory";
			TableName = "Sales.SalesTerritoryHistory";
			TableAlias = "salessalesterritoryhistory";
			ColumnNames = typeof(SalesSalesTerritoryHistoryColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesPerson>("SalesSalesPerson")),
			TableName = "Sales.SalesPerson",
			Alias = TableAlias + "_" + "SalesSalesPerson",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesPerson>("SalesSalesPerson");
					var st = (entity as SalesSalesTerritoryHistory);

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
					//SalesSalesTerritoryHistoryColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory")),
			TableName = "Sales.SalesTerritory",
			Alias = TableAlias + "_" + "SalesSalesTerritory",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory");
					var st = (entity as SalesSalesTerritoryHistory);

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
					//SalesSalesTerritoryHistoryColumnNames.      .ToString()
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

		