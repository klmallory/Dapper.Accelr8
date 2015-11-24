
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
	public enum TransactionFilePathColumnNames
	{	
		TransactionFilePathId, 	
		TransactionId, 	
		FilePath, 	
	}

	public enum TransactionFilePathCascadeNames
	{	
		
		transaction, 	
	}

	public class TransactionFilePathTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionFilePathTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionFilePathColumnNames.TransactionFilePathId.ToString();
			TableName = "TransactionFilePaths";
			TableAlias = "transactionfilepath";
			ColumnNames = Enum.GetNames(typeof(TransactionFilePathColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionFilePaths_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as TransactionFilePath);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionFilePathColumnNames.TransactionFilePathId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		