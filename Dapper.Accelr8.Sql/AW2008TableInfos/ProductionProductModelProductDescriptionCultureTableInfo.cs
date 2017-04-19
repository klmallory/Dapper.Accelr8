
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
	public enum ProductionProductModelProductDescriptionCultureFieldNames
	{	
		ProductModelID, 	
		ProductDescriptionID, 	
		CultureID, 	
		ModifiedDate, 	
	}

	public enum ProductionProductModelProductDescriptionCultureCascadeNames
	{	
		
		productionproductmodel_p, 	
		productionculture_p, 	
		productionproductdescription_p, 	}

	public class ProductionProductModelProductDescriptionCultureTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductModelProductDescriptionCultureColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductModelProductDescriptionCultureFieldNames.ProductModelID, "ProductModelID" }, 
						{ (int)ProductionProductModelProductDescriptionCultureFieldNames.ProductDescriptionID, "ProductDescriptionID" }, 
						{ (int)ProductionProductModelProductDescriptionCultureFieldNames.CultureID, "CultureID" }, 
						{ (int)ProductionProductModelProductDescriptionCultureFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductModelProductDescriptionCultureIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductModelProductDescriptionCultureFieldNames.ProductModelID, "ProductModelID" }, 
						{ (int)ProductionProductModelProductDescriptionCultureFieldNames.ProductDescriptionID, "ProductDescriptionID" }, 
						{ (int)ProductionProductModelProductDescriptionCultureFieldNames.CultureID, "CultureID" }, 
				};

		public ProductionProductModelProductDescriptionCultureTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductModelProductDescriptionCulture";
			TableAlias = "productionproductmodelproductdescriptionculture";
			Columns = ProductionProductModelProductDescriptionCultureColumnNames;
			IdColumns = ProductionProductModelProductDescriptionCultureIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProductModel>("ProductionProductModel")),
			TableName = "Production.ProductModel",
			Alias = TableAlias + "_" + "ProductionProductModel",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProductModel>("ProductionProductModel");
					var st = (entity as ProductionProductModelProductDescriptionCulture);

					if (st == null || row == null)
						return st;

					if (row.ProductModelID == null || row.ProductModelID == default(int))
						return st;

					st.ProductionProductModel = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductModelColumnNames.   .ToString()
					//ProductionProductModelProductDescriptionCultureColumnNames.      .ToString()
					JoinField = "ProductModelID",
					Operator = Operator.Equals,
					ParentField = "ProductModelID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_ProductModelProductDescriptionCulture_Culture_CultureID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, ProductionCulture>("ProductionCulture")),
			TableName = "Production.Culture",
			Alias = TableAlias + "_" + "ProductionCulture",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, ProductionCulture>("ProductionCulture");
					var st = (entity as ProductionProductModelProductDescriptionCulture);

					if (st == null || row == null)
						return st;

					if (row.CultureID == null || row.CultureID == default(string))
						return st;

					st.ProductionCulture = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionCultureColumnNames.   .ToString()
					//ProductionProductModelProductDescriptionCultureColumnNames.      .ToString()
					JoinField = "CultureID",
					Operator = Operator.Equals,
					ParentField = "CultureID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProductDescription>("ProductionProductDescription")),
			TableName = "Production.ProductDescription",
			Alias = TableAlias + "_" + "ProductionProductDescription",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProductDescription>("ProductionProductDescription");
					var st = (entity as ProductionProductModelProductDescriptionCulture);

					if (st == null || row == null)
						return st;

					if (row.ProductDescriptionID == null || row.ProductDescriptionID == default(int))
						return st;

					st.ProductionProductDescription = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductDescriptionColumnNames.   .ToString()
					//ProductionProductModelProductDescriptionCultureColumnNames.      .ToString()
					JoinField = "ProductDescriptionID",
					Operator = Operator.Equals,
					ParentField = "ProductDescriptionID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		