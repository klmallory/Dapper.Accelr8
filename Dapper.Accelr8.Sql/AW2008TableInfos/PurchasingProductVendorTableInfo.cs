
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
	public enum PurchasingProductVendorColumnNames
	{	
		ProductID, 	
		BusinessEntityID, 	
		AverageLeadTime, 	
		StandardPrice, 	
		LastReceiptCost, 	
		LastReceiptDate, 	
		MinOrderQty, 	
		MaxOrderQty, 	
		OnOrderQty, 	
		UnitMeasureCode, 	
		ModifiedDate, 	
	}

	public enum PurchasingProductVendorCascadeNames
	{	
		
		productionunitmeasure_p, 	
		purchasingvendor_p, 	
		productionproduct_p, 	}

	public class PurchasingProductVendorTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PurchasingProductVendorTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PurchasingProductVendorColumnNames.ProductID.ToString();
			//Schema = "Purchasing.ProductVendor";
			TableName = "Purchasing.ProductVendor";
			TableAlias = "purchasingproductvendor";
			ColumnNames = typeof(PurchasingProductVendorColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_ProductVendor_UnitMeasure_UnitMeasureCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure")),
			TableName = "Production.UnitMeasure",
			Alias = TableAlias + "_" + "ProductionUnitMeasure",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure");
					var st = (entity as PurchasingProductVendor);

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
					//PurchasingProductVendorColumnNames.      .ToString()
					JoinField = "UnitMeasureCode",
					Operator = Operator.Equals,
					ParentField = "UnitMeasureCode",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_ProductVendor_Vendor_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PurchasingVendor>("PurchasingVendor")),
			TableName = "Purchasing.Vendor",
			Alias = TableAlias + "_" + "PurchasingVendor",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PurchasingVendor>("PurchasingVendor");
					var st = (entity as PurchasingProductVendor);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.PurchasingVendor = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PurchasingVendorColumnNames.   .ToString()
					//PurchasingProductVendorColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_ProductVendor_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as PurchasingProductVendor);

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
					//PurchasingProductVendorColumnNames.      .ToString()
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

		