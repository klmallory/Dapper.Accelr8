
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
	public enum ProductionTransactionHistoryArchiveFieldNames
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

	public enum ProductionTransactionHistoryArchiveCascadeNames
	{	
		}

	public class ProductionTransactionHistoryArchiveTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionTransactionHistoryArchiveColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionTransactionHistoryArchiveFieldNames.Id, "TransactionID" }, 
						{ (int)ProductionTransactionHistoryArchiveFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionTransactionHistoryArchiveFieldNames.ReferenceOrderID, "ReferenceOrderID" }, 
						{ (int)ProductionTransactionHistoryArchiveFieldNames.ReferenceOrderLineID, "ReferenceOrderLineID" }, 
						{ (int)ProductionTransactionHistoryArchiveFieldNames.TransactionDate, "TransactionDate" }, 
						{ (int)ProductionTransactionHistoryArchiveFieldNames.TransactionType, "TransactionType" }, 
						{ (int)ProductionTransactionHistoryArchiveFieldNames.Quantity, "Quantity" }, 
						{ (int)ProductionTransactionHistoryArchiveFieldNames.ActualCost, "ActualCost" }, 
						{ (int)ProductionTransactionHistoryArchiveFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionTransactionHistoryArchiveIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionTransactionHistoryArchiveFieldNames.Id, "TransactionID" }, 
				};

		public ProductionTransactionHistoryArchiveTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.TransactionHistoryArchive";
			TableAlias = "productiontransactionhistoryarchive";
			Columns = ProductionTransactionHistoryArchiveColumnNames;
			IdColumns = ProductionTransactionHistoryArchiveIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		