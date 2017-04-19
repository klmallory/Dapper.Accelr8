
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
	public enum ProductionProductCostHistoryFieldNames
	{	
		ProductID, 	
		StartDate, 	
		EndDate, 	
		StandardCost, 	
		ModifiedDate, 	
	}

	public enum ProductionProductCostHistoryCascadeNames
	{	
		
		productionproduct_p, 	}

	public class ProductionProductCostHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductCostHistoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductCostHistoryFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionProductCostHistoryFieldNames.StartDate, "StartDate" }, 
						{ (int)ProductionProductCostHistoryFieldNames.EndDate, "EndDate" }, 
						{ (int)ProductionProductCostHistoryFieldNames.StandardCost, "StandardCost" }, 
						{ (int)ProductionProductCostHistoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductCostHistoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductCostHistoryFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionProductCostHistoryFieldNames.StartDate, "StartDate" }, 
				};

		public ProductionProductCostHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductCostHistory";
			TableAlias = "productionproductcosthistory";
			Columns = ProductionProductCostHistoryColumnNames;
			IdColumns = ProductionProductCostHistoryIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_ProductCostHistory_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionProductCostHistory);

					if (st == null || row == null)
						return st;

					if (row.ProductID == null || row.ProductID == default(int))
						return st;

					st.ProductionProduct = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductColumnNames.   .ToString()
					//ProductionProductCostHistoryColumnNames.      .ToString()
					JoinField = "ProductID",
					Operator = Operator.Equals,
					ParentField = "ProductID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		