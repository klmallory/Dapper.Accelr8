
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
    public class TransmissionLogWriter : EntityWriter<long, TransmissionLog>
    {
        public TransmissionLogWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, TransmissionLog entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(TransmissionLogColumnNames.TransmissionLogId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(TransmissionLogColumnNames.TransactionId.ToString(), actionType, taskIndex, count), entity.TransactionId);
			parms.Add(GetParamName(TransmissionLogColumnNames.SubmissionId.ToString(), actionType, taskIndex, count), entity.SubmissionId);
			parms.Add(GetParamName(TransmissionLogColumnNames.ResponseId.ToString(), actionType, taskIndex, count), entity.ResponseId);
			parms.Add(GetParamName(TransmissionLogColumnNames.ExecutionContextId.ToString(), actionType, taskIndex, count), entity.ExecutionContextId);
			parms.Add(GetParamName(TransmissionLogColumnNames.Request.ToString(), actionType, taskIndex, count), entity.Request);
			parms.Add(GetParamName(TransmissionLogColumnNames.Response.ToString(), actionType, taskIndex, count), entity.Response);
			parms.Add(GetParamName(TransmissionLogColumnNames.RequstToUrl.ToString(), actionType, taskIndex, count), entity.RequstToUrl);
			parms.Add(GetParamName(TransmissionLogColumnNames.ResponseFromUrl.ToString(), actionType, taskIndex, count), entity.ResponseFromUrl);
			parms.Add(GetParamName(TransmissionLogColumnNames.RequestTime.ToString(), actionType, taskIndex, count), entity.RequestTime);
			parms.Add(GetParamName(TransmissionLogColumnNames.ResponseTime.ToString(), actionType, taskIndex, count), entity.ResponseTime);
					
			return parms;
        }


		protected override void CascadeRelations(TransmissionLog entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		