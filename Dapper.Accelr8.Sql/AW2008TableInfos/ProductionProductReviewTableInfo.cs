
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
	public enum ProductionProductReviewColumnNames
	{	
		ProductReviewID, 	
		ProductID, 	
		ReviewerName, 	
		ReviewDate, 	
		EmailAddress, 	
		Rating, 	
		Comments, 	
		ModifiedDate, 	
	}

	public enum ProductionProductReviewCascadeNames
	{	
		
		productionproduct_p, 	}

	public class ProductionProductReviewTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionProductReviewTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionProductReviewColumnNames.ProductReviewID.ToString();
			//Schema = "Production.ProductReview";
			TableName = "Production.ProductReview";
			TableAlias = "productionproductreview";
			ColumnNames = typeof(ProductionProductReviewColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_ProductReview_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionProductReview);

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
					//ProductionProductReviewColumnNames.      .ToString()
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

		