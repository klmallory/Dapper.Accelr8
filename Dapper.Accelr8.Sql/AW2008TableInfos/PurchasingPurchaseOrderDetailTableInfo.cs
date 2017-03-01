
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
	public enum PurchasingPurchaseOrderDetailColumnNames
	{	
		PurchaseOrderID, 	
		PurchaseOrderDetailID, 	
		DueDate, 	
		OrderQty, 	
		ProductID, 	
		UnitPrice, 	
		LineTotal, 	
		ReceivedQty, 	
		RejectedQty, 	
		StockedQty, 	
		ModifiedDate, 	
	}

	public enum PurchasingPurchaseOrderDetailCascadeNames
	{	
		
		purchasingpurchaseorderheader_p, 	
		productionproduct_p, 	}

	public class PurchasingPurchaseOrderDetailTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PurchasingPurchaseOrderDetailTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PurchasingPurchaseOrderDetailColumnNames.PurchaseOrderID.ToString();
			//Schema = "Purchasing.PurchaseOrderDetail";
			TableName = "Purchasing.PurchaseOrderDetail";
			TableAlias = "purchasingpurchaseorderdetail";
			ColumnNames = typeof(PurchasingPurchaseOrderDetailColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PurchasingPurchaseOrderHeader>("PurchasingPurchaseOrderHeader")),
			TableName = "Purchasing.PurchaseOrderHeader",
			Alias = TableAlias + "_" + "PurchasingPurchaseOrderHeader",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PurchasingPurchaseOrderHeader>("PurchasingPurchaseOrderHeader");
					var st = (entity as PurchasingPurchaseOrderDetail);

					if (st == null || row == null)
						return st;

					if (row.PurchaseOrderID == null || row.PurchaseOrderID == default(int))
						return st;

					st.PurchasingPurchaseOrderHeader = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PurchasingPurchaseOrderHeaderColumnNames.   .ToString()
					//PurchasingPurchaseOrderDetailColumnNames.      .ToString()
					JoinField = "PurchaseOrderID",
					Operator = Operator.Equals,
					ParentField = "PurchaseOrderID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_PurchaseOrderDetail_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as PurchasingPurchaseOrderDetail);

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
					//PurchasingPurchaseOrderDetailColumnNames.      .ToString()
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

		