
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
	public enum DocumentColumnNames
	{	
		DocumentId, 	
		TransactionID, 	
		Blob, 	
		FileType, 	
		DocumentTitle, 	
		IssuingAuthority, 	
		DocumentNumber, 	
		ExpirationDate, 	
		DocumentGroup, 	
	}

	public enum DocumentCascadeNames
	{	
		
		transaction, 	
	}

	public class DocumentTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public DocumentTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = DocumentColumnNames.DocumentId.ToString();
			TableName = "Documents";
			TableAlias = "document";
			ColumnNames = Enum.GetNames(typeof(DocumentColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Documents_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as Document);

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
					ParentField = DocumentColumnNames.DocumentId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		