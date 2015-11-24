
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
    public class ResponseWriter : EntityWriter<int, Response>
    {
        public ResponseWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , RoutedResponse> GetRoutedResponseWriter()
		{ return _locator.Resolve<IEntityWriter<int , RoutedResponse>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Response entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(ResponseColumnNames.ResponseId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(ResponseColumnNames.SubmissionId.ToString(), actionType, taskIndex, count), entity.SubmissionId);
			parms.Add(GetParamName(ResponseColumnNames.DateReceived.ToString(), actionType, taskIndex, count), entity.DateReceived);
			parms.Add(GetParamName(ResponseColumnNames.FilePath.ToString(), actionType, taskIndex, count), entity.FilePath);
			parms.Add(GetParamName(ResponseColumnNames.ResponseType.ToString(), actionType, taskIndex, count), entity.ResponseType);
			parms.Add(GetParamName(ResponseColumnNames.TCR.ToString(), actionType, taskIndex, count), entity.Tcr);
			parms.Add(GetParamName(ResponseColumnNames.TCN.ToString(), actionType, taskIndex, count), entity.Tcn);
			parms.Add(GetParamName(ResponseColumnNames.AgencyId.ToString(), actionType, taskIndex, count), entity.AgencyId);
					
			return parms;
        }


		protected override void CascadeRelations(Response entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_RoutedResponses_Responses
			var routedResponse = GetRoutedResponseWriter();
			if (_cascades.Contains(ResponseCascadeNames.routedresponse.ToString()))
				foreach (var item in entity.RoutedResponses)
					Cascade(routedResponse, item, context);

			if (routedResponse.Count > 0)
				WithChild(routedResponse, entity);

		
        }


	}
}
		