
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
	public enum ProductionProductReviewFieldNames
	{	
		Id, 	
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
	
		public static readonly IDictionary<int, string> ProductionProductReviewColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductReviewFieldNames.Id, "ProductReviewID" }, 
						{ (int)ProductionProductReviewFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionProductReviewFieldNames.ReviewerName, "ReviewerName" }, 
						{ (int)ProductionProductReviewFieldNames.ReviewDate, "ReviewDate" }, 
						{ (int)ProductionProductReviewFieldNames.EmailAddress, "EmailAddress" }, 
						{ (int)ProductionProductReviewFieldNames.Rating, "Rating" }, 
						{ (int)ProductionProductReviewFieldNames.Comments, "Comments" }, 
						{ (int)ProductionProductReviewFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductReviewIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductReviewFieldNames.Id, "ProductReviewID" }, 
				};

		public ProductionProductReviewTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductReview";
			TableAlias = "productionproductreview";
			Columns = ProductionProductReviewColumnNames;
			IdColumns = ProductionProductReviewIdColumnNames;

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

		