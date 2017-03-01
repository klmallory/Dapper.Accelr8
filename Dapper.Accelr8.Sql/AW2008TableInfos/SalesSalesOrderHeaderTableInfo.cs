
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
	public enum SalesSalesOrderHeaderColumnNames
	{	
		SalesOrderID, 	
		RevisionNumber, 	
		OrderDate, 	
		DueDate, 	
		ShipDate, 	
		Status, 	
		OnlineOrderFlag, 	
		SalesOrderNumber, 	
		PurchaseOrderNumber, 	
		AccountNumber, 	
		CustomerID, 	
		SalesPersonID, 	
		TerritoryID, 	
		BillToAddressID, 	
		ShipToAddressID, 	
		ShipMethodID, 	
		CreditCardID, 	
		CreditCardApprovalCode, 	
		CurrencyRateID, 	
		SubTotal, 	
		TaxAmt, 	
		Freight, 	
		TotalDue, 	
		Comment, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSalesOrderHeaderCascadeNames
	{	
		salessalesorderdetail, 	
		salessalesorderheadersalesreason, 	
		
		personaddress_p, 	
		salescreditcard_p, 	
		salescurrencyrate_p, 	
		salescustomer_p, 	
		salessalesperson_p, 	
		salessalesterritory_p, 	
		purchasingshipmethod_p, 	}

	public class SalesSalesOrderHeaderTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesSalesOrderHeaderTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesSalesOrderHeaderColumnNames.SalesOrderID.ToString();
			//Schema = "Sales.SalesOrderHeader";
			TableName = "Sales.SalesOrderHeader";
			TableAlias = "salessalesorderheader";
			ColumnNames = typeof(SalesSalesOrderHeaderColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_SalesOrderHeader_Address_BillToAddressID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonAddress>("PersonAddress")),
			TableName = "Person.Address",
			Alias = TableAlias + "_" + "PersonAddress",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonAddress>("PersonAddress");
					var st = (entity as SalesSalesOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.AddressID == null || row.AddressID == default(int))
						return st;

					st.PersonAddress = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonAddressColumnNames.   .ToString()
					//SalesSalesOrderHeaderColumnNames.      .ToString()
					JoinField = "AddressID",
					Operator = Operator.Equals,
					ParentField = "BillToAddressID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderHeader_Address_ShipToAddressID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonAddress>("PersonAddress")),
			TableName = "Person.Address",
			Alias = TableAlias + "_" + "PersonAddress",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonAddress>("PersonAddress");
					var st = (entity as SalesSalesOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.AddressID == null || row.AddressID == default(int))
						return st;

					st.PersonAddress = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonAddressColumnNames.   .ToString()
					//SalesSalesOrderHeaderColumnNames.      .ToString()
					JoinField = "AddressID",
					Operator = Operator.Equals,
					ParentField = "ShipToAddressID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderHeader_Customer_CustomerID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesCustomer>("SalesCustomer")),
			TableName = "Sales.Customer",
			Alias = TableAlias + "_" + "SalesCustomer",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesCustomer>("SalesCustomer");
					var st = (entity as SalesSalesOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.CustomerID == null || row.CustomerID == default(int))
						return st;

					st.SalesCustomer = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesCustomerColumnNames.   .ToString()
					//SalesSalesOrderHeaderColumnNames.      .ToString()
					JoinField = "CustomerID",
					Operator = Operator.Equals,
					ParentField = "CustomerID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderHeader_ShipMethod_ShipMethodID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PurchasingShipMethod>("PurchasingShipMethod")),
			TableName = "Purchasing.ShipMethod",
			Alias = TableAlias + "_" + "PurchasingShipMethod",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PurchasingShipMethod>("PurchasingShipMethod");
					var st = (entity as SalesSalesOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.ShipMethodID == null || row.ShipMethodID == default(int))
						return st;

					st.PurchasingShipMethod = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PurchasingShipMethodColumnNames.   .ToString()
					//SalesSalesOrderHeaderColumnNames.      .ToString()
					JoinField = "ShipMethodID",
					Operator = Operator.Equals,
					ParentField = "ShipMethodID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderHeader_CreditCard_CreditCardID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesCreditCard>("SalesCreditCard")),
			TableName = "Sales.CreditCard",
			Alias = TableAlias + "_" + "SalesCreditCard",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesCreditCard>("SalesCreditCard");
					var st = (entity as SalesSalesOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.CreditCardID == null || row.CreditCardID == default(int))
						return st;

					st.SalesCreditCard = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesCreditCardColumnNames.   .ToString()
					//SalesSalesOrderHeaderColumnNames.      .ToString()
					JoinField = "CreditCardID",
					Operator = Operator.Equals,
					ParentField = "CreditCardID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesCurrencyRate>("SalesCurrencyRate")),
			TableName = "Sales.CurrencyRate",
			Alias = TableAlias + "_" + "SalesCurrencyRate",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesCurrencyRate>("SalesCurrencyRate");
					var st = (entity as SalesSalesOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.CurrencyRateID == null || row.CurrencyRateID == default(int))
						return st;

					st.SalesCurrencyRate = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesCurrencyRateColumnNames.   .ToString()
					//SalesSalesOrderHeaderColumnNames.      .ToString()
					JoinField = "CurrencyRateID",
					Operator = Operator.Equals,
					ParentField = "CurrencyRateID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderHeader_SalesPerson_SalesPersonID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesPerson>("SalesSalesPerson")),
			TableName = "Sales.SalesPerson",
			Alias = TableAlias + "_" + "SalesSalesPerson",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesPerson>("SalesSalesPerson");
					var st = (entity as SalesSalesOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.SalesSalesPerson = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesPersonColumnNames.   .ToString()
					//SalesSalesOrderHeaderColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "SalesPersonID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderHeader_SalesTerritory_TerritoryID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory")),
			TableName = "Sales.SalesTerritory",
			Alias = TableAlias + "_" + "SalesSalesTerritory",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesTerritory>("SalesSalesTerritory");
					var st = (entity as SalesSalesOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.TerritoryID == null || row.TerritoryID == default(int))
						return st;

					st.SalesSalesTerritory = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesTerritoryColumnNames.   .ToString()
					//SalesSalesOrderHeaderColumnNames.      .ToString()
					JoinField = "TerritoryID",
					Operator = Operator.Equals,
					ParentField = "TerritoryID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		