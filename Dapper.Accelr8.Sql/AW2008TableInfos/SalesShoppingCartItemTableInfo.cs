
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
	public enum SalesShoppingCartItemFieldNames
	{	
		Id, 	
		ShoppingCartID, 	
		Quantity, 	
		ProductID, 	
		DateCreated, 	
		ModifiedDate, 	
	}

	public enum SalesShoppingCartItemCascadeNames
	{	
		
		productionproduct_p, 	}

	public class SalesShoppingCartItemTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesShoppingCartItemColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesShoppingCartItemFieldNames.Id, "ShoppingCartItemID" }, 
						{ (int)SalesShoppingCartItemFieldNames.ShoppingCartID, "ShoppingCartID" }, 
						{ (int)SalesShoppingCartItemFieldNames.Quantity, "Quantity" }, 
						{ (int)SalesShoppingCartItemFieldNames.ProductID, "ProductID" }, 
						{ (int)SalesShoppingCartItemFieldNames.DateCreated, "DateCreated" }, 
						{ (int)SalesShoppingCartItemFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesShoppingCartItemIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesShoppingCartItemFieldNames.Id, "ShoppingCartItemID" }, 
				};

		public SalesShoppingCartItemTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.ShoppingCartItem";
			TableAlias = "salesshoppingcartitem";
			Columns = SalesShoppingCartItemColumnNames;
			IdColumns = SalesShoppingCartItemIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_ShoppingCartItem_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as SalesShoppingCartItem);

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
					//SalesShoppingCartItemColumnNames.      .ToString()
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

		