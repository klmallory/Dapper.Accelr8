

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
    public class TransactionFilePathReader : EntityReader<int, TransactionFilePath>
    {
        public TransactionFilePathReader(
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
		/// Loads the table TransactionFilePaths into class TransactionFilePath
		/// </summary>
		/// <param name="results">TransactionFilePath</param>
		/// <param name="row"></param>
        public override TransactionFilePath LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new TransactionFilePath();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.TransactionId = GetRowData<int>(dataRow, TransactionFilePathColumnNames.TransactionId.ToString()); 	
			domain.FilePath = GetRowData<string>(dataRow, TransactionFilePathColumnNames.FilePath.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, TransactionFilePath></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, TransactionFilePath> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(TransactionFilePath entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<TransactionFilePath> entities)
        {
					
		}
    }
}
		