

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
    public class RoutedResponseStatusHistoryReader : EntityReader<int, RoutedResponseStatusHistory>
    {
        public RoutedResponseStatusHistoryReader(
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
		/// Loads the table RoutedResponseStatusHistory into class RoutedResponseStatusHistory
		/// </summary>
		/// <param name="results">RoutedResponseStatusHistory</param>
		/// <param name="row"></param>
        public override RoutedResponseStatusHistory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new RoutedResponseStatusHistory();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.RoutedResponseId = GetRowData<int>(dataRow, RoutedResponseStatusHistoryColumnNames.RoutedResponseId.ToString()); 	
			domain.RoutedResponseStatus = GetRowData<string>(dataRow, RoutedResponseStatusHistoryColumnNames.RoutedResponseStatus.ToString()); 	
			domain.StatusDate = GetRowData<DateTime>(dataRow, RoutedResponseStatusHistoryColumnNames.StatusDate.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, RoutedResponseStatusHistory></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, RoutedResponseStatusHistory> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(RoutedResponseStatusHistory entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<RoutedResponseStatusHistory> entities)
        {
					
		}
    }
}
		