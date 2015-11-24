
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
    public class MatchRequestWriter : EntityWriter<int, MatchRequest>
    {
        public MatchRequestWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, MatchRequest entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(MatchRequestColumnNames.MatchRequestId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(MatchRequestColumnNames.SubmissionId.ToString(), actionType, taskIndex, count), entity.SubmissionId);
			parms.Add(GetParamName(MatchRequestColumnNames.AbisRequestId.ToString(), actionType, taskIndex, count), entity.AbisRequestId);
			parms.Add(GetParamName(MatchRequestColumnNames.AbisOperation.ToString(), actionType, taskIndex, count), entity.AbisOperation);
			parms.Add(GetParamName(MatchRequestColumnNames.Status.ToString(), actionType, taskIndex, count), entity.Status);
			parms.Add(GetParamName(MatchRequestColumnNames.PersonId.ToString(), actionType, taskIndex, count), entity.PersonId);
					
			return parms;
        }


		protected override void CascadeRelations(MatchRequest entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		