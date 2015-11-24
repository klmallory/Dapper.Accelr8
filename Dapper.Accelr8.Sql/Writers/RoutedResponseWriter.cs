
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
    public class RoutedResponseWriter : EntityWriter<int, RoutedResponse>
    {
        public RoutedResponseWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , RoutedResponseStatusHistory> GetRoutedResponseStatusHistoryWriter()
		{ return _locator.Resolve<IEntityWriter<int , RoutedResponseStatusHistory>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, RoutedResponse entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(RoutedResponseColumnNames.RoutedResponseId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(RoutedResponseColumnNames.ResponseId.ToString(), actionType, taskIndex, count), entity.ResponseId);
			parms.Add(GetParamName(RoutedResponseColumnNames.EndpointId.ToString(), actionType, taskIndex, count), entity.EndpointId);
			parms.Add(GetParamName(RoutedResponseColumnNames.Status.ToString(), actionType, taskIndex, count), entity.Status);
					
			return parms;
        }


		protected override void CascadeRelations(RoutedResponse entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_RoutedResponseStatusHistory_RoutedResponse_RoutedResponseId
			var routedResponseStatusHistory = GetRoutedResponseStatusHistoryWriter();
			if (_cascades.Contains(RoutedResponseCascadeNames.routedresponsestatushistory.ToString()))
				foreach (var item in entity.RoutedResponseStatusHistories)
					Cascade(routedResponseStatusHistory, item, context);

			if (routedResponseStatusHistory.Count > 0)
				WithChild(routedResponseStatusHistory, entity);

		
        }


	}
}
		