
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
	public enum TransactionGroupColumnNames
	{	
		TransactionGroupId, 	
		TransactionId, 	
		GroupId, 	
	}

	public enum TransactionGroupCascadeNames
	{	
		
		group, 	
		transaction, 	
	}

	public class TransactionGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionGroupTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionGroupColumnNames.TransactionGroupId.ToString();
			TableName = "TransactionGroups";
			TableAlias = "transactiongroup";
			ColumnNames = Enum.GetNames(typeof(TransactionGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_TransactionGroups_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as TransactionGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionGroupColumnNames.TransactionGroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_TransactionGroups_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as TransactionGroup);

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
					ParentField = TransactionGroupColumnNames.TransactionGroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		