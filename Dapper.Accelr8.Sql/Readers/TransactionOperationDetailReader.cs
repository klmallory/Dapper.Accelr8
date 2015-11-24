

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
    public class TransactionOperationDetailReader : EntityReader<int, TransactionOperationDetail>
    {
        public TransactionOperationDetailReader(
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
		/// Loads the table TransactionOperationDetails into class TransactionOperationDetail
		/// </summary>
		/// <param name="results">TransactionOperationDetail</param>
		/// <param name="row"></param>
        public override TransactionOperationDetail LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new TransactionOperationDetail();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.TransactionOperationHistoryId = GetRowData<int>(dataRow, TransactionOperationDetailColumnNames.TransactionOperationHistoryId.ToString()); 	
			domain.OperationFileName = GetRowData<string>(dataRow, TransactionOperationDetailColumnNames.OperationFileName.ToString()); 	
			domain.Status = GetRowData<string>(dataRow, TransactionOperationDetailColumnNames.Status.ToString()); 	
			domain.ReasonFailed = GetRowData<string>(dataRow, TransactionOperationDetailColumnNames.ReasonFailed.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, TransactionOperationDetail></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, TransactionOperationDetail> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(TransactionOperationDetail entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<TransactionOperationDetail> entities)
        {
					
		}
    }
}
		