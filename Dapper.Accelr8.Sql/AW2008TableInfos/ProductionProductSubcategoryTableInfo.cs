
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
	public enum ProductionProductSubcategoryColumnNames
	{	
		ProductSubcategoryID, 	
		ProductCategoryID, 	
		Name, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionProductSubcategoryCascadeNames
	{	
		productionproduct, 	
		
		productionproductcategory_p, 	}

	public class ProductionProductSubcategoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionProductSubcategoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionProductSubcategoryColumnNames.ProductSubcategoryID.ToString();
			//Schema = "Production.ProductSubcategory";
			TableName = "Production.ProductSubcategory";
			TableAlias = "productionproductsubcategory";
			ColumnNames = typeof(ProductionProductSubcategoryColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_ProductSubcategory_ProductCategory_ProductCategoryID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProductCategory>("ProductionProductCategory")),
			TableName = "Production.ProductCategory",
			Alias = TableAlias + "_" + "ProductionProductCategory",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProductCategory>("ProductionProductCategory");
					var st = (entity as ProductionProductSubcategory);

					if (st == null || row == null)
						return st;

					if (row.ProductCategoryID == null || row.ProductCategoryID == default(int))
						return st;

					st.ProductionProductCategory = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductCategoryColumnNames.   .ToString()
					//ProductionProductSubcategoryColumnNames.      .ToString()
					JoinField = "ProductCategoryID",
					Operator = Operator.Equals,
					ParentField = "ProductCategoryID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		