
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
	public enum TransactionGroupSourceColumnNames
	{	
		TransactionId, 	
		TCN, 	
		CreatedDate, 	
		Name, 	
		TransactionType, 	
		TransactionStatus, 	
		Value, 	
		TransactionFieldId, 	
		FieldDescriptor, 	
		Username, 	
		SourceKey, 	
		AgencyName, 	
	}

	public enum TransactionGroupSourceCascadeNames
	{	
		
	}

	public class TransactionGroupSourceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionGroupSourceTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = TransactionGroupSourceColumnNames.TransactionId.ToString();
			TableName = "TransactionGroupSource";
			TableAlias = "transactiongroupsource";
			ColumnNames = Enum.GetNames(typeof(TransactionGroupSourceColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		