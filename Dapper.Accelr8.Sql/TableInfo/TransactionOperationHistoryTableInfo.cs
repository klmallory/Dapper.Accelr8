
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum TransactionOperationHistoryColumnNames
	{	
		TransactionOperationHistoryId, 	
		Name, 	
		Timestamp, 	
		Username, 	
		TransactionCount, 	
		TransactionSuccessCount, 	
		Status, 	
		OperationType, 	
	}

	public enum TransactionOperationHistoryCascadeNames
	{	
		transactionoperationdetail, 	
		
	}

	public class TransactionOperationHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionOperationHistoryTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionOperationHistoryColumnNames.TransactionOperationHistoryId.ToString();
			TableName = "TransactionOperationHistory";
			TableAlias = "transactionoperationhistory";
			ColumnNames = Enum.GetNames(typeof(TransactionOperationHistoryColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		