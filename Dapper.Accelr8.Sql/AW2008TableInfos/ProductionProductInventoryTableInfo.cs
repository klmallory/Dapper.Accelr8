
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
	public enum ProductionProductInventoryFieldNames
	{	
		ProductID, 	
		LocationID, 	
		Shelf, 	
		Bin, 	
		Quantity, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionProductInventoryCascadeNames
	{	
		
		productionlocation_p, 	
		productionproduct_p, 	}

	public class ProductionProductInventoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductInventoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductInventoryFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionProductInventoryFieldNames.LocationID, "LocationID" }, 
						{ (int)ProductionProductInventoryFieldNames.Shelf, "Shelf" }, 
						{ (int)ProductionProductInventoryFieldNames.Bin, "Bin" }, 
						{ (int)ProductionProductInventoryFieldNames.Quantity, "Quantity" }, 
						{ (int)ProductionProductInventoryFieldNames.rowguid, "rowguid" }, 
						{ (int)ProductionProductInventoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductInventoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductInventoryFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionProductInventoryFieldNames.LocationID, "LocationID" }, 
				};

		public ProductionProductInventoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductInventory";
			TableAlias = "productionproductinventory";
			Columns = ProductionProductInventoryColumnNames;
			IdColumns = ProductionProductInventoryIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_ProductInventory_Location_LocationID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<short, ProductionLocation>("ProductionLocation")),
			TableName = "Production.Location",
			Alias = TableAlias + "_" + "ProductionLocation",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<short, ProductionLocation>("ProductionLocation");
					var st = (entity as ProductionProductInventory);

					if (st == null || row == null)
						return st;

					if (row.LocationID == null || row.LocationID == default(short))
						return st;

					st.ProductionLocation = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionLocationColumnNames.   .ToString()
					//ProductionProductInventoryColumnNames.      .ToString()
					JoinField = "LocationID",
					Operator = Operator.Equals,
					ParentField = "LocationID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_ProductInventory_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionProductInventory);

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
					//ProductionProductInventoryColumnNames.      .ToString()
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

		