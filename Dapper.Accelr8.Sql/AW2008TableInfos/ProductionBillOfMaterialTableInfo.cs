
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
	public enum ProductionBillOfMaterialFieldNames
	{	
		Id, 	
		ProductAssemblyID, 	
		ComponentID, 	
		StartDate, 	
		EndDate, 	
		UnitMeasureCode, 	
		BOMLevel, 	
		PerAssemblyQty, 	
		ModifiedDate, 	
	}

	public enum ProductionBillOfMaterialCascadeNames
	{	
		
		productionunitmeasure_p, 	
		productionproduct1_p, 	
		productionproduct2_p, 	}

	public class ProductionBillOfMaterialTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionBillOfMaterialColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionBillOfMaterialFieldNames.Id, "BillOfMaterialsID" }, 
						{ (int)ProductionBillOfMaterialFieldNames.ProductAssemblyID, "ProductAssemblyID" }, 
						{ (int)ProductionBillOfMaterialFieldNames.ComponentID, "ComponentID" }, 
						{ (int)ProductionBillOfMaterialFieldNames.StartDate, "StartDate" }, 
						{ (int)ProductionBillOfMaterialFieldNames.EndDate, "EndDate" }, 
						{ (int)ProductionBillOfMaterialFieldNames.UnitMeasureCode, "UnitMeasureCode" }, 
						{ (int)ProductionBillOfMaterialFieldNames.BOMLevel, "BOMLevel" }, 
						{ (int)ProductionBillOfMaterialFieldNames.PerAssemblyQty, "PerAssemblyQty" }, 
						{ (int)ProductionBillOfMaterialFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionBillOfMaterialIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionBillOfMaterialFieldNames.Id, "BillOfMaterialsID" }, 
				};

		public ProductionBillOfMaterialTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.BillOfMaterials";
			TableAlias = "productionbillofmaterial";
			Columns = ProductionBillOfMaterialColumnNames;
			IdColumns = ProductionBillOfMaterialIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_BillOfMaterials_UnitMeasure_UnitMeasureCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure")),
			TableName = "Production.UnitMeasure",
			Alias = TableAlias + "_" + "ProductionUnitMeasure",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure");
					var st = (entity as ProductionBillOfMaterial);

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
					//ProductionBillOfMaterialColumnNames.      .ToString()
					JoinField = "UnitMeasureCode",
					Operator = Operator.Equals,
					ParentField = "UnitMeasureCode",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_BillOfMaterials_Product_ComponentID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct2",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionBillOfMaterial);

					if (st == null || row == null)
						return st;

					if (row.ProductID == null || row.ProductID == default(int))
						return st;

					st.ProductionProduct2 = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductColumnNames.   .ToString()
					//ProductionBillOfMaterialColumnNames.      .ToString()
					JoinField = "ProductID",
					Operator = Operator.Equals,
					ParentField = "ComponentID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_BillOfMaterials_Product_ProductAssemblyID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct1",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionBillOfMaterial);

					if (st == null || row == null)
						return st;

					if (row.ProductID == null || row.ProductID == default(int))
						return st;

					st.ProductionProduct1 = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductColumnNames.   .ToString()
					//ProductionBillOfMaterialColumnNames.      .ToString()
					JoinField = "ProductID",
					Operator = Operator.Equals,
					ParentField = "ProductAssemblyID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		