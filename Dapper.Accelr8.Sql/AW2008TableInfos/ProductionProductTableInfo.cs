
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
	public enum ProductionProductFieldNames
	{	
		Id, 	
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
		productionproductinventories, 	
		productionproductlistpricehistories, 	
		salesspecialofferproducts, 	
		productionproductproductphotos, 	
		productiontransactionhistories, 	
		productionproductreviews, 	
		purchasingproductvendors, 	
		productionworkorders, 	
		purchasingpurchaseorderdetails, 	
		productionproductcosthistories, 	
		salesshoppingcartitems, 	
		productionproductdocuments, 	
		
		productionproductmodel_p, 	
		productionproductsubcategory_p, 	
		productionunitmeasure1_p, 	
		productionunitmeasure2_p, 	}

	public class ProductionProductTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductFieldNames.Id, "ProductID" }, 
						{ (int)ProductionProductFieldNames.Name, "Name" }, 
						{ (int)ProductionProductFieldNames.ProductNumber, "ProductNumber" }, 
						{ (int)ProductionProductFieldNames.MakeFlag, "MakeFlag" }, 
						{ (int)ProductionProductFieldNames.FinishedGoodsFlag, "FinishedGoodsFlag" }, 
						{ (int)ProductionProductFieldNames.Color, "Color" }, 
						{ (int)ProductionProductFieldNames.SafetyStockLevel, "SafetyStockLevel" }, 
						{ (int)ProductionProductFieldNames.ReorderPoint, "ReorderPoint" }, 
						{ (int)ProductionProductFieldNames.StandardCost, "StandardCost" }, 
						{ (int)ProductionProductFieldNames.ListPrice, "ListPrice" }, 
						{ (int)ProductionProductFieldNames.Size, "Size" }, 
						{ (int)ProductionProductFieldNames.SizeUnitMeasureCode, "SizeUnitMeasureCode" }, 
						{ (int)ProductionProductFieldNames.WeightUnitMeasureCode, "WeightUnitMeasureCode" }, 
						{ (int)ProductionProductFieldNames.Weight, "Weight" }, 
						{ (int)ProductionProductFieldNames.DaysToManufacture, "DaysToManufacture" }, 
						{ (int)ProductionProductFieldNames.ProductLine, "ProductLine" }, 
						{ (int)ProductionProductFieldNames.Class, "Class" }, 
						{ (int)ProductionProductFieldNames.Style, "Style" }, 
						{ (int)ProductionProductFieldNames.ProductSubcategoryID, "ProductSubcategoryID" }, 
						{ (int)ProductionProductFieldNames.ProductModelID, "ProductModelID" }, 
						{ (int)ProductionProductFieldNames.SellStartDate, "SellStartDate" }, 
						{ (int)ProductionProductFieldNames.SellEndDate, "SellEndDate" }, 
						{ (int)ProductionProductFieldNames.DiscontinuedDate, "DiscontinuedDate" }, 
						{ (int)ProductionProductFieldNames.rowguid, "rowguid" }, 
						{ (int)ProductionProductFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductFieldNames.Id, "ProductID" }, 
				};

		public ProductionProductTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.Product";
			TableAlias = "productionproduct";
			Columns = ProductionProductColumnNames;
			IdColumns = ProductionProductIdColumnNames;

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
			Alias = TableAlias + "_" + "ProductionUnitMeasure1",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure");
					var st = (entity as ProductionProduct);

					if (st == null || row == null)
						return st;

					if (row.UnitMeasureCode == null || row.UnitMeasureCode == default(string))
						return st;

					st.ProductionUnitMeasure1 = reader.LoadEntityObject(row);

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
			Alias = TableAlias + "_" + "ProductionUnitMeasure2",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure");
					var st = (entity as ProductionProduct);

					if (st == null || row == null)
						return st;

					if (row.UnitMeasureCode == null || row.UnitMeasureCode == default(string))
						return st;

					st.ProductionUnitMeasure2 = reader.LoadEntityObject(row);

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

		