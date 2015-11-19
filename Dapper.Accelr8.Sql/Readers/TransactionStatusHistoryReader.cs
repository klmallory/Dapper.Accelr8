

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
    public class TransactionStatusHistoryReader : EntityReader<int, TransactionStatusHistory>
    {
        public TransactionStatusHistoryReader(
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
		/// Loads the table TransactionStatusHistory into class TransactionStatusHistory
		/// </summary>
		/// <param name="results">TransactionStatusHistory</param>
		/// <param name="row"></param>
        public override TransactionStatusHistory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new TransactionStatusHistory();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.TransactionId = GetRowData<int>(dataRow, TransactionStatusHistoryColumnNames.TransactionId.ToString()); 	
			domain.TransactionStatus = GetRowData<string>(dataRow, TransactionStatusHistoryColumnNames.TransactionStatus.ToString()); 	
			domain.StatusDate = GetRowData<DateTime?>(dataRow, TransactionStatusHistoryColumnNames.StatusDate.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, TransactionStatusHistory> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(TransactionStatusHistory entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<TransactionStatusHistory> entities)
        {
					
		}
    }
}
		