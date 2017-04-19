
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
	public enum SalesSalesOrderDetailFieldNames
	{	
		SalesOrderID, 	
		SalesOrderDetailID, 	
		CarrierTrackingNumber, 	
		OrderQty, 	
		ProductID, 	
		SpecialOfferID, 	
		UnitPrice, 	
		UnitPriceDiscount, 	
		LineTotal, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSalesOrderDetailCascadeNames
	{	
		
		salesspecialofferproduct1_p, 	
		salesspecialofferproduct2_p, 	
		salessalesorderheader_p, 	}

	public class SalesSalesOrderDetailTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSalesOrderDetailColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesOrderDetailFieldNames.SalesOrderID, "SalesOrderID" }, 
						{ (int)SalesSalesOrderDetailFieldNames.SalesOrderDetailID, "SalesOrderDetailID" }, 
						{ (int)SalesSalesOrderDetailFieldNames.CarrierTrackingNumber, "CarrierTrackingNumber" }, 
						{ (int)SalesSalesOrderDetailFieldNames.OrderQty, "OrderQty" }, 
						{ (int)SalesSalesOrderDetailFieldNames.ProductID, "ProductID" }, 
						{ (int)SalesSalesOrderDetailFieldNames.SpecialOfferID, "SpecialOfferID" }, 
						{ (int)SalesSalesOrderDetailFieldNames.UnitPrice, "UnitPrice" }, 
						{ (int)SalesSalesOrderDetailFieldNames.UnitPriceDiscount, "UnitPriceDiscount" }, 
						{ (int)SalesSalesOrderDetailFieldNames.LineTotal, "LineTotal" }, 
						{ (int)SalesSalesOrderDetailFieldNames.rowguid, "rowguid" }, 
						{ (int)SalesSalesOrderDetailFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSalesOrderDetailIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesOrderDetailFieldNames.SalesOrderID, "SalesOrderID" }, 
						{ (int)SalesSalesOrderDetailFieldNames.SalesOrderDetailID, "SalesOrderDetailID" }, 
				};

		public SalesSalesOrderDetailTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SalesOrderDetail";
			TableAlias = "salessalesorderdetail";
			Columns = SalesSalesOrderDetailColumnNames;
			IdColumns = SalesSalesOrderDetailIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSpecialOfferProduct>("SalesSpecialOfferProduct")),
			TableName = "Sales.SpecialOfferProduct",
			Alias = TableAlias + "_" + "SalesSpecialOfferProduct1",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSpecialOfferProduct>("SalesSpecialOfferProduct");
					var st = (entity as SalesSalesOrderDetail);

					if (st == null || row == null)
						return st;

					if (row.SpecialOfferID == null || row.SpecialOfferID == default(int))
						return st;

					st.SalesSpecialOfferProduct1 = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSpecialOfferProductColumnNames.   .ToString()
					//SalesSalesOrderDetailColumnNames.      .ToString()
					JoinField = "SpecialOfferID",
					Operator = Operator.Equals,
					ParentField = "SpecialOfferID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSpecialOfferProduct>("SalesSpecialOfferProduct")),
			TableName = "Sales.SpecialOfferProduct",
			Alias = TableAlias + "_" + "SalesSpecialOfferProduct2",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSpecialOfferProduct>("SalesSpecialOfferProduct");
					var st = (entity as SalesSalesOrderDetail);

					if (st == null || row == null)
						return st;

					if (row.ProductID == null || row.ProductID == default(int))
						return st;

					st.SalesSpecialOfferProduct2 = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSpecialOfferProductColumnNames.   .ToString()
					//SalesSalesOrderDetailColumnNames.      .ToString()
					JoinField = "ProductID",
					Operator = Operator.Equals,
					ParentField = "ProductID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesOrderHeader>("SalesSalesOrderHeader")),
			TableName = "Sales.SalesOrderHeader",
			Alias = TableAlias + "_" + "SalesSalesOrderHeader",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesOrderHeader>("SalesSalesOrderHeader");
					var st = (entity as SalesSalesOrderDetail);

					if (st == null || row == null)
						return st;

					if (row.SalesOrderID == null || row.SalesOrderID == default(int))
						return st;

					st.SalesSalesOrderHeader = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesOrderHeaderColumnNames.   .ToString()
					//SalesSalesOrderDetailColumnNames.      .ToString()
					JoinField = "SalesOrderID",
					Operator = Operator.Equals,
					ParentField = "SalesOrderID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		