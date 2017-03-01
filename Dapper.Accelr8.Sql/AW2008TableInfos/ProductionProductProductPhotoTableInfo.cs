
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
	public enum ProductionProductProductPhotoColumnNames
	{	
		ProductID, 	
		ProductPhotoID, 	
		Primary, 	
		ModifiedDate, 	
	}

	public enum ProductionProductProductPhotoCascadeNames
	{	
		
		productionproductphoto_p, 	
		productionproduct_p, 	}

	public class ProductionProductProductPhotoTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionProductProductPhotoTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionProductProductPhotoColumnNames.ProductID.ToString();
			//Schema = "Production.ProductProductPhoto";
			TableName = "Production.ProductProductPhoto";
			TableAlias = "productionproductproductphoto";
			ColumnNames = typeof(ProductionProductProductPhotoColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProductPhoto>("ProductionProductPhoto")),
			TableName = "Production.ProductPhoto",
			Alias = TableAlias + "_" + "ProductionProductPhoto",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProductPhoto>("ProductionProductPhoto");
					var st = (entity as ProductionProductProductPhoto);

					if (st == null || row == null)
						return st;

					if (row.ProductPhotoID == null || row.ProductPhotoID == default(int))
						return st;

					st.ProductionProductPhoto = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductPhotoColumnNames.   .ToString()
					//ProductionProductProductPhotoColumnNames.      .ToString()
					JoinField = "ProductPhotoID",
					Operator = Operator.Equals,
					ParentField = "ProductPhotoID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_ProductProductPhoto_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionProductProductPhoto);

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
					//ProductionProductProductPhotoColumnNames.      .ToString()
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

		