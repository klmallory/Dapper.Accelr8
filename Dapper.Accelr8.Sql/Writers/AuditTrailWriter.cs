
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
    public class AuditTrailWriter : EntityWriter<int, AuditTrail>
    {
        public AuditTrailWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, AuditTrail entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(AuditTrailColumnNames.AuditTrailId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(AuditTrailColumnNames.UserName.ToString(), actionType, taskIndex, count), entity.UserName);
			parms.Add(GetParamName(AuditTrailColumnNames.AuditDate.ToString(), actionType, taskIndex, count), entity.AuditDate);
			parms.Add(GetParamName(AuditTrailColumnNames.Action.ToString(), actionType, taskIndex, count), entity.Action);
			parms.Add(GetParamName(AuditTrailColumnNames.Area.ToString(), actionType, taskIndex, count), entity.Area);
			parms.Add(GetParamName(AuditTrailColumnNames.Details.ToString(), actionType, taskIndex, count), entity.Detail);
					
			return parms;
        }


		protected override void CascadeRelations(AuditTrail entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		