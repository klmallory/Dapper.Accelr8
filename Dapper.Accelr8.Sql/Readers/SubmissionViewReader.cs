

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
    public class SubmissionViewReader : EntityReader<int, SubmissionView>
    {
        public SubmissionViewReader(
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
		/// Loads the table Submissions_VW into class SubmissionView
		/// </summary>
		/// <param name="results">SubmissionView</param>
		/// <param name="row"></param>
        public override SubmissionView LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SubmissionView();

			
			domain.SubmissionId = GetRowData<int>(dataRow, SubmissionViewColumnNames.SubmissionId.ToString()); 	
			domain.TransactionId = GetRowData<int>(dataRow, SubmissionViewColumnNames.TransactionId.ToString()); 	
			domain.EndpointId = GetRowData<int?>(dataRow, SubmissionViewColumnNames.EndpointId.ToString()); 	
			domain.AgencyId = GetRowData<int?>(dataRow, SubmissionViewColumnNames.AgencyId.ToString()); 	
			domain.Status = GetRowData<string>(dataRow, SubmissionViewColumnNames.Status.ToString()); 	
			domain.ResponseCount = GetRowData<int?>(dataRow, SubmissionViewColumnNames.ResponseCount.ToString()); 	
			domain.Tcn = GetRowData<string>(dataRow, SubmissionViewColumnNames.TCN.ToString()); 	
			domain.StatusDate = GetRowData<DateTime?>(dataRow, SubmissionViewColumnNames.StatusDate.ToString()); 	
			domain.Destination = GetRowData<string>(dataRow, SubmissionViewColumnNames.Destination.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SubmissionView></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SubmissionView> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SubmissionView entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<SubmissionView> entities)
        {
					
		}
    }
}
		