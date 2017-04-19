
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
	public enum ProductionTransactionHistoryFieldNames
	{	
		Id, 	
		ProductID, 	
		ReferenceOrderID, 	
		ReferenceOrderLineID, 	
		TransactionDate, 	
		TransactionType, 	
		Quantity, 	
		ActualCost, 	
		ModifiedDate, 	
	}

	public enum ProductionTransactionHistoryCascadeNames
	{	
		
		productionproduct_p, 	}

	public class ProductionTransactionHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionTransactionHistoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionTransactionHistoryFieldNames.Id, "TransactionID" }, 
						{ (int)ProductionTransactionHistoryFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionTransactionHistoryFieldNames.ReferenceOrderID, "ReferenceOrderID" }, 
						{ (int)ProductionTransactionHistoryFieldNames.ReferenceOrderLineID, "ReferenceOrderLineID" }, 
						{ (int)ProductionTransactionHistoryFieldNames.TransactionDate, "TransactionDate" }, 
						{ (int)ProductionTransactionHistoryFieldNames.TransactionType, "TransactionType" }, 
						{ (int)ProductionTransactionHistoryFieldNames.Quantity, "Quantity" }, 
						{ (int)ProductionTransactionHistoryFieldNames.ActualCost, "ActualCost" }, 
						{ (int)ProductionTransactionHistoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionTransactionHistoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionTransactionHistoryFieldNames.Id, "TransactionID" }, 
				};

		public ProductionTransactionHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.TransactionHistory";
			TableAlias = "productiontransactionhistory";
			Columns = ProductionTransactionHistoryColumnNames;
			IdColumns = ProductionTransactionHistoryIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_TransactionHistory_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionTransactionHistory);

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
					//ProductionTransactionHistoryColumnNames.      .ToString()
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

		