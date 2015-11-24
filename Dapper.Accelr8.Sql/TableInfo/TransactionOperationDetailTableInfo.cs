
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
	public enum TransactionOperationDetailColumnNames
	{	
		TransactionOperationDetailsId, 	
		TransactionOperationHistoryId, 	
		OperationFileName, 	
		Status, 	
		ReasonFailed, 	
	}

	public enum TransactionOperationDetailCascadeNames
	{	
		
		transactionoperationhistory, 	
	}

	public class TransactionOperationDetailTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionOperationDetailTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionOperationDetailColumnNames.TransactionOperationDetailsId.ToString();
			TableName = "TransactionOperationDetails";
			TableAlias = "transactionoperationdetail";
			ColumnNames = Enum.GetNames(typeof(TransactionOperationDetailColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionOperationDetails_History
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(TransactionOperationHistory))),
			TableName = "TransactionOperationHistory",
			Alias = TableAlias + "_" + "transactionoperationhistory",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(TransactionOperationHistory));
					var st = (entity as TransactionOperationDetail);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.TransactionOperationHistory = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionOperationHistoryColumnNames.TransactionOperationHistoryId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionOperationDetailColumnNames.TransactionOperationDetailsId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		