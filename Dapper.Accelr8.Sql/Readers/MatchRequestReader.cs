

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
    public class MatchRequestReader : EntityReader<int, MatchRequest>
    {
        public MatchRequestReader(
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
		/// Loads the table MatchRequests into class MatchRequest
		/// </summary>
		/// <param name="results">MatchRequest</param>
		/// <param name="row"></param>
        public override MatchRequest LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new MatchRequest();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.SubmissionId = GetRowData<int>(dataRow, MatchRequestColumnNames.SubmissionId.ToString()); 	
			domain.AbisRequestId = GetRowData<string>(dataRow, MatchRequestColumnNames.AbisRequestId.ToString()); 	
			domain.AbisOperation = GetRowData<string>(dataRow, MatchRequestColumnNames.AbisOperation.ToString()); 	
			domain.Status = GetRowData<string>(dataRow, MatchRequestColumnNames.Status.ToString()); 	
			domain.PersonId = GetRowData<string>(dataRow, MatchRequestColumnNames.PersonId.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, MatchRequest></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, MatchRequest> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(MatchRequest entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<MatchRequest> entities)
        {
					
		}
    }
}
		