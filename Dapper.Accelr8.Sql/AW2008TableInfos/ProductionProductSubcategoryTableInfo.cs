
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
	public enum ProductionProductSubcategoryFieldNames
	{	
		Id, 	
		ProductCategoryID, 	
		Name, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionProductSubcategoryCascadeNames
	{	
		productionproducts, 	
		
		productionproductcategory_p, 	}

	public class ProductionProductSubcategoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductSubcategoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductSubcategoryFieldNames.Id, "ProductSubcategoryID" }, 
						{ (int)ProductionProductSubcategoryFieldNames.ProductCategoryID, "ProductCategoryID" }, 
						{ (int)ProductionProductSubcategoryFieldNames.Name, "Name" }, 
						{ (int)ProductionProductSubcategoryFieldNames.rowguid, "rowguid" }, 
						{ (int)ProductionProductSubcategoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductSubcategoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductSubcategoryFieldNames.Id, "ProductSubcategoryID" }, 
				};

		public ProductionProductSubcategoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductSubcategory";
			TableAlias = "productionproductsubcategory";
			Columns = ProductionProductSubcategoryColumnNames;
			IdColumns = ProductionProductSubcategoryIdColumnNames;

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

		