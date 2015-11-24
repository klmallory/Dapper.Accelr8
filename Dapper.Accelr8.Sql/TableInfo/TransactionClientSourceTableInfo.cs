
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
	public enum TransactionClientSourceColumnNames
	{	
		TransactionId, 	
		SubmissionCnt, 	
		ClientId, 	
		TCN, 	
		CreatedDate, 	
		Name, 	
		SourceId, 	
		SourceClient, 	
		SourceName, 	
		Filepath, 	
	}

	public enum TransactionClientSourceCascadeNames
	{	
		
	}

	public class TransactionClientSourceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionClientSourceTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = TransactionClientSourceColumnNames.TransactionId.ToString();
			TableName = "TransactionClientSource";
			TableAlias = "transactionclientsource";
			ColumnNames = Enum.GetNames(typeof(TransactionClientSourceColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		