
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
	public enum TransactionFieldValueColumnNames
	{	
		TransactionFieldValueId, 	
		TransactionId, 	
		TransactionFieldId, 	
		Value, 	
	}

	public enum TransactionFieldValueCascadeNames
	{	
		
		transactionfield, 	
		transaction, 	
	}

	public class TransactionFieldValueTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionFieldValueTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionFieldValueColumnNames.TransactionFieldValueId.ToString();
			TableName = "TransactionFieldValues";
			TableAlias = "transactionfieldvalue";
			ColumnNames = Enum.GetNames(typeof(TransactionFieldValueColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionFields_Fields
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(TransactionField))),
			TableName = "TransactionFields",
			Alias = TableAlias + "_" + "transactionfield",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(TransactionField));
					var st = (entity as TransactionFieldValue);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.TransactionField = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionFieldColumnNames.FieldId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionFieldValueColumnNames.TransactionFieldValueId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_TransactionFieldValues_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as TransactionFieldValue);

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
					ParentField = TransactionFieldValueColumnNames.TransactionFieldValueId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		