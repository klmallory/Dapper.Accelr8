
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
	public enum ProductionProductColumnNames
	{	
		ProductID, 	
		Name, 	
		ProductNumber, 	
		MakeFlag, 	
		FinishedGoodsFlag, 	
		Color, 	
		SafetyStockLevel, 	
		ReorderPoint, 	
		StandardCost, 	
		ListPrice, 	
		Size, 	
		SizeUnitMeasureCode, 	
		WeightUnitMeasureCode, 	
		Weight, 	
		DaysToManufacture, 	
		ProductLine, 	
		Class, 	
		Style, 	
		ProductSubcategoryID, 	
		ProductModelID, 	
		SellStartDate, 	
		SellEndDate, 	
		DiscontinuedDate, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionProductCascadeNames
	{	
		productionproductinventory, 	
		productionproductlistpricehistory, 	
		salesspecialofferproduct, 	
		productionproductproductphoto, 	
		productiontransactionhistory, 	
		productionproductreview, 	
		purchasingproductvendor, 	
		productionworkorder, 	
		purchasingpurchaseorderdetail, 	
		productionproductcosthistory, 	
		salesshoppingcartitem, 	
		productionproductdocument, 	
		
		productionproductmodel_p, 	
		productionproductsubcategory_p, 	
		productionunitmeasure_p, 	}

	public class ProductionProductTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionProductTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionProductColumnNames.ProductID.ToString();
			//Schema = "Production.Product";
			TableName = "Production.Product";
			TableAlias = "productionproduct";
			ColumnNames = typeof(ProductionProductColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_Product_ProductModel_ProductModelID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProductModel>("ProductionProductModel")),
			TableName = "Production.ProductModel",
			Alias = TableAlias + "_" + "ProductionProductModel",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProductModel>("ProductionProductModel");
					var st = (entity as ProductionProduct);

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
					//ProductionProductColumnNames.      .ToString()
					JoinField = "ProductModelID",
					Operator = Operator.Equals,
					ParentField = "ProductModelID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Product_ProductSubcategory_ProductSubcategoryID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProductSubcategory>("ProductionProductSubcategory")),
			TableName = "Production.ProductSubcategory",
			Alias = TableAlias + "_" + "ProductionProductSubcategory",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProductSubcategory>("ProductionProductSubcategory");
					var st = (entity as ProductionProduct);

					if (st == null || row == null)
						return st;

					if (row.ProductSubcategoryID == null || row.ProductSubcategoryID == default(int))
						return st;

					st.ProductionProductSubcategory = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductSubcategoryColumnNames.   .ToString()
					//ProductionProductColumnNames.      .ToString()
					JoinField = "ProductSubcategoryID",
					Operator = Operator.Equals,
					ParentField = "ProductSubcategoryID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Product_UnitMeasure_SizeUnitMeasureCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure")),
			TableName = "Production.UnitMeasure",
			Alias = TableAlias + "_" + "ProductionUnitMeasure",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure");
					var st = (entity as ProductionProduct);

					if (st == null || row == null)
						return st;

					if (row.UnitMeasureCode == null || row.UnitMeasureCode == default(string))
						return st;

					st.ProductionUnitMeasure = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionUnitMeasureColumnNames.   .ToString()
					//ProductionProductColumnNames.      .ToString()
					JoinField = "UnitMeasureCode",
					Operator = Operator.Equals,
					ParentField = "SizeUnitMeasureCode",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Product_UnitMeasure_WeightUnitMeasureCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure")),
			TableName = "Production.UnitMeasure",
			Alias = TableAlias + "_" + "ProductionUnitMeasure",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure");
					var st = (entity as ProductionProduct);

					if (st == null || row == null)
						return st;

					if (row.UnitMeasureCode == null || row.UnitMeasureCode == default(string))
						return st;

					st.ProductionUnitMeasure = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionUnitMeasureColumnNames.   .ToString()
					//ProductionProductColumnNames.      .ToString()
					JoinField = "UnitMeasureCode",
					Operator = Operator.Equals,
					ParentField = "WeightUnitMeasureCode",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		