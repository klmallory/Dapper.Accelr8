
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
	public enum TransmissionLogColumnNames
	{	
		TransmissionLogId, 	
		TransactionId, 	
		SubmissionId, 	
		ResponseId, 	
		ExecutionContextId, 	
		Request, 	
		Response, 	
		RequstToUrl, 	
		ResponseFromUrl, 	
		RequestTime, 	
		ResponseTime, 	
	}

	public enum TransmissionLogCascadeNames
	{	
		
	}

	public class TransmissionLogTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransmissionLogTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransmissionLogColumnNames.TransmissionLogId.ToString();
			TableName = "TransmissionLog";
			TableAlias = "transmissionlog";
			ColumnNames = Enum.GetNames(typeof(TransmissionLogColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		