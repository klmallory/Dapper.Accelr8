

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

namespace Dapper.Accelr8.Readers
{
    public class DocumentReader : EntityReader<int, Document>
    {
        public DocumentReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 1
		
			/// <summary>
		/// Loads the table Documents into class Document
		/// </summary>
		/// <param name="results">Document</param>
		/// <param name="row"></param>
        public override Document LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Document();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.TransactionId = GetRowData<int>(dataRow, DocumentColumnNames.TransactionID.ToString()); 	
			domain.Blob = GetRowData<byte[]>(dataRow, DocumentColumnNames.Blob.ToString()); 	
			domain.FileType = GetRowData<string>(dataRow, DocumentColumnNames.FileType.ToString()); 	
			domain.DocumentTitle = GetRowData<string>(dataRow, DocumentColumnNames.DocumentTitle.ToString()); 	
			domain.IssuingAuthority = GetRowData<string>(dataRow, DocumentColumnNames.IssuingAuthority.ToString()); 	
			domain.DocumentNumber = GetRowData<string>(dataRow, DocumentColumnNames.DocumentNumber.ToString()); 	
			domain.ExpirationDate = GetRowData<DateTime?>(dataRow, DocumentColumnNames.ExpirationDate.ToString()); 	
			domain.DocumentGroup = GetRowData<string>(dataRow, DocumentColumnNames.DocumentGroup.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Document></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Document> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(Document entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<Document> entities)
        {
					
		}
    }
}
		