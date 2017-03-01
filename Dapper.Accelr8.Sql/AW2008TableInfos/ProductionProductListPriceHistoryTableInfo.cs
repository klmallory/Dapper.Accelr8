
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
	public enum ProductionProductListPriceHistoryColumnNames
	{	
		ProductID, 	
		StartDate, 	
		EndDate, 	
		ListPrice, 	
		ModifiedDate, 	
	}

	public enum ProductionProductListPriceHistoryCascadeNames
	{	
		
		productionproduct_p, 	}

	public class ProductionProductListPriceHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionProductListPriceHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionProductListPriceHistoryColumnNames.ProductID.ToString();
			//Schema = "Production.ProductListPriceHistory";
			TableName = "Production.ProductListPriceHistory";
			TableAlias = "productionproductlistpricehistory";
			ColumnNames = typeof(ProductionProductListPriceHistoryColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_ProductListPriceHistory_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionProductListPriceHistory);

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
					//ProductionProductListPriceHistoryColumnNames.      .ToString()
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

		