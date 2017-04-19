
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
	public enum ProductionProductModelIllustrationFieldNames
	{	
		ProductModelID, 	
		IllustrationID, 	
		ModifiedDate, 	
	}

	public enum ProductionProductModelIllustrationCascadeNames
	{	
		
		productionproductmodel_p, 	
		productionillustration_p, 	}

	public class ProductionProductModelIllustrationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductModelIllustrationColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductModelIllustrationFieldNames.ProductModelID, "ProductModelID" }, 
						{ (int)ProductionProductModelIllustrationFieldNames.IllustrationID, "IllustrationID" }, 
						{ (int)ProductionProductModelIllustrationFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductModelIllustrationIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductModelIllustrationFieldNames.ProductModelID, "ProductModelID" }, 
						{ (int)ProductionProductModelIllustrationFieldNames.IllustrationID, "IllustrationID" }, 
				};

		public ProductionProductModelIllustrationTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductModelIllustration";
			TableAlias = "productionproductmodelillustration";
			Columns = ProductionProductModelIllustrationColumnNames;
			IdColumns = ProductionProductModelIllustrationIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_ProductModelIllustration_ProductModel_ProductModelID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProductModel>("ProductionProductModel")),
			TableName = "Production.ProductModel",
			Alias = TableAlias + "_" + "ProductionProductModel",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProductModel>("ProductionProductModel");
					var st = (entity as ProductionProductModelIllustration);

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
					//ProductionProductModelIllustrationColumnNames.      .ToString()
					JoinField = "ProductModelID",
					Operator = Operator.Equals,
					ParentField = "ProductModelID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_ProductModelIllustration_Illustration_IllustrationID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionIllustration>("ProductionIllustration")),
			TableName = "Production.Illustration",
			Alias = TableAlias + "_" + "ProductionIllustration",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionIllustration>("ProductionIllustration");
					var st = (entity as ProductionProductModelIllustration);

					if (st == null || row == null)
						return st;

					if (row.IllustrationID == null || row.IllustrationID == default(int))
						return st;

					st.ProductionIllustration = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionIllustrationColumnNames.   .ToString()
					//ProductionProductModelIllustrationColumnNames.      .ToString()
					JoinField = "IllustrationID",
					Operator = Operator.Equals,
					ParentField = "IllustrationID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		