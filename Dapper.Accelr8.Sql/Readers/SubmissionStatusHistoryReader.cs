

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
    public class SubmissionStatusHistoryReader : EntityReader<int, SubmissionStatusHistory>
    {
        public SubmissionStatusHistoryReader(
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
		/// Loads the table SubmissionStatusHistory into class SubmissionStatusHistory
		/// </summary>
		/// <param name="results">SubmissionStatusHistory</param>
		/// <param name="row"></param>
        public override SubmissionStatusHistory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SubmissionStatusHistory();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.SubmissionId = GetRowData<int>(dataRow, SubmissionStatusHistoryColumnNames.SubmissionId.ToString()); 	
			domain.TransmissionStatus = GetRowData<string>(dataRow, SubmissionStatusHistoryColumnNames.TransmissionStatus.ToString()); 	
			domain.StatusDate = GetRowData<DateTime>(dataRow, SubmissionStatusHistoryColumnNames.StatusDate.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, SubmissionStatusHistory> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SubmissionStatusHistory entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<SubmissionStatusHistory> entities)
        {
					
		}
    }
}
		