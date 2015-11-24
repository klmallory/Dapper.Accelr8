

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
    public class TransactionFieldValueReader : EntityReader<int, TransactionFieldValue>
    {
        public TransactionFieldValueReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 2
		
			/// <summary>
		/// Loads the table TransactionFieldValues into class TransactionFieldValue
		/// </summary>
		/// <param name="results">TransactionFieldValue</param>
		/// <param name="row"></param>
        public override TransactionFieldValue LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new TransactionFieldValue();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.TransactionId = GetRowData<int>(dataRow, TransactionFieldValueColumnNames.TransactionId.ToString()); 	
			domain.TransactionFieldId = GetRowData<int>(dataRow, TransactionFieldValueColumnNames.TransactionFieldId.ToString()); 	
			domain.Value = GetRowData<string>(dataRow, TransactionFieldValueColumnNames.Value.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, TransactionFieldValue></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, TransactionFieldValue> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(TransactionFieldValue entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<TransactionFieldValue> entities)
        {
					
		}
    }
}
		