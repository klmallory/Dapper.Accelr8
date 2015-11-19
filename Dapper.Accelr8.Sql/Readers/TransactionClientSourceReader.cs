

using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfo;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.Readers
{
    public class TransactionClientSourceReader : EntityReader<int, TransactionClientSource>
    {
        public TransactionClientSourceReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 0

			/// <summary>
		/// Loads the table TransactionClientSource into class TransactionClientSource
		/// </summary>
		/// <param name="results">TransactionClientSource</param>
		/// <param name="row"></param>
        public override TransactionClientSource LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new TransactionClientSource();

			
			domain.TransactionId = GetRowData<int>(dataRow, TransactionClientSourceColumnNames.TransactionId.ToString()); 	
			domain.SubmissionCnt = GetRowData<int?>(dataRow, TransactionClientSourceColumnNames.SubmissionCnt.ToString()); 	
			domain.ClientId = GetRowData<int?>(dataRow, TransactionClientSourceColumnNames.ClientId.ToString()); 	
			domain.TCN = GetRowData<string>(dataRow, TransactionClientSourceColumnNames.TCN.ToString()); 	
			domain.CreatedDate = GetRowData<DateTime>(dataRow, TransactionClientSourceColumnNames.CreatedDate.ToString()); 	
			domain.Name = GetRowData<string>(dataRow, TransactionClientSourceColumnNames.Name.ToString()); 	
			domain.SourceId = GetRowData<int?>(dataRow, TransactionClientSourceColumnNames.SourceId.ToString()); 	
			domain.SourceClient = GetRowData<string>(dataRow, TransactionClientSourceColumnNames.SourceClient.ToString()); 	
			domain.SourceName = GetRowData<string>(dataRow, TransactionClientSourceColumnNames.SourceName.ToString()); 	
			domain.Filepath = GetRowData<string>(dataRow, TransactionClientSourceColumnNames.Filepath.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, TransactionClientSource> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(TransactionClientSource entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<TransactionClientSource> entities)
        {
					
		}
    }
}
		