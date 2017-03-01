
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
	public enum ProductionTransactionHistoryArchiveColumnNames
	{	
		TransactionID, 	
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
		public ProductionTransactionHistoryArchiveTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionTransactionHistoryArchiveColumnNames.TransactionID.ToString();
			//Schema = "Production.TransactionHistoryArchive";
			TableName = "Production.TransactionHistoryArchive";
			TableAlias = "productiontransactionhistoryarchive";
			ColumnNames = typeof(ProductionTransactionHistoryArchiveColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		