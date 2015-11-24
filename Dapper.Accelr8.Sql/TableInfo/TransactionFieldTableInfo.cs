
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
	public enum TransactionFieldColumnNames
	{	
		FieldId, 	
		FieldDescriptor, 	
		Description, 	
		IsVisible, 	
		IsStandardField, 	
		DataType, 	
	}

	public enum TransactionFieldCascadeNames
	{	
		transactionfieldvalue, 	
		
	}

	public class TransactionFieldTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionFieldTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionFieldColumnNames.FieldId.ToString();
			TableName = "TransactionFields";
			TableAlias = "transactionfield";
			ColumnNames = Enum.GetNames(typeof(TransactionFieldColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		