
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
using Dapper.Accelr8.Repo.Contracts.Writers;

namespace Dapper.Accelr8.Writers
{
    public class SubmissionViewWriter : EntityWriter<int, SubmissionView>
    {
        public SubmissionViewWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SubmissionView entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(SubmissionViewColumnNames.SubmissionId.ToString(), actionType, taskIndex, count), entity.SubmissionId);
			parms.Add(GetParamName(SubmissionViewColumnNames.TransactionId.ToString(), actionType, taskIndex, count), entity.TransactionId);
			parms.Add(GetParamName(SubmissionViewColumnNames.EndpointId.ToString(), actionType, taskIndex, count), entity.EndpointId);
			parms.Add(GetParamName(SubmissionViewColumnNames.AgencyId.ToString(), actionType, taskIndex, count), entity.AgencyId);
			parms.Add(GetParamName(SubmissionViewColumnNames.Status.ToString(), actionType, taskIndex, count), entity.Status);
			parms.Add(GetParamName(SubmissionViewColumnNames.ResponseCount.ToString(), actionType, taskIndex, count), entity.ResponseCount);
			parms.Add(GetParamName(SubmissionViewColumnNames.TCN.ToString(), actionType, taskIndex, count), entity.Tcn);
			parms.Add(GetParamName(SubmissionViewColumnNames.StatusDate.ToString(), actionType, taskIndex, count), entity.StatusDate);
			parms.Add(GetParamName(SubmissionViewColumnNames.Destination.ToString(), actionType, taskIndex, count), entity.Destination);
					
			return parms;
        }


		protected override void CascadeRelations(SubmissionView entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		