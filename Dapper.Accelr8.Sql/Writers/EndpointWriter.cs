
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
    public class EndpointWriter : EntityWriter<int, Endpoint>
    {
        public EndpointWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , Submission> GetSubmissionWriter()
		{ return _locator.Resolve<IEntityWriter<int , Submission>>(); }
		static IEntityWriter<int , Client> GetClientWriter()
		{ return _locator.Resolve<IEntityWriter<int , Client>>(); }
		static IEntityWriter<int , RoutedResponse> GetRoutedResponseWriter()
		{ return _locator.Resolve<IEntityWriter<int , RoutedResponse>>(); }
		static IEntityWriter<int , AgencyEndpoint> GetAgencyEndpointWriter()
		{ return _locator.Resolve<IEntityWriter<int , AgencyEndpoint>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Endpoint entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(EndpointColumnNames.EndpointId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(EndpointColumnNames.ServerId.ToString(), actionType, taskIndex, count), entity.ServerId);
			parms.Add(GetParamName(EndpointColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(EndpointColumnNames.Configuration.ToString(), actionType, taskIndex, count), entity.Configuration);
					
			return parms;
        }


		protected override void CascadeRelations(Endpoint entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Submissions_Endpoints
			var submission = GetSubmissionWriter();
			if (_cascades.Contains(EndpointCascadeNames.submission.ToString()))
				foreach (var item in entity.Submissions)
					Cascade(submission, item, context);

			if (submission.Count > 0)
				WithChild(submission, entity);

			//From Foreign Key FK_Clients_Endpoint
			var client = GetClientWriter();
			if (_cascades.Contains(EndpointCascadeNames.client.ToString()))
				foreach (var item in entity.Clients)
					Cascade(client, item, context);

			if (client.Count > 0)
				WithChild(client, entity);

			//From Foreign Key FK__RoutedRes__Endpo__6477ECF3
			var routedResponse = GetRoutedResponseWriter();
			if (_cascades.Contains(EndpointCascadeNames.routedresponse.ToString()))
				foreach (var item in entity.RoutedResponses)
					Cascade(routedResponse, item, context);

			if (routedResponse.Count > 0)
				WithChild(routedResponse, entity);

			//From Foreign Key FK_AgencyEndpoints_Endpoints
			var agencyEndpoint = GetAgencyEndpointWriter();
			if (_cascades.Contains(EndpointCascadeNames.agencyendpoint.ToString()))
				foreach (var item in entity.AgencyEndpoints)
					Cascade(agencyEndpoint, item, context);

			if (agencyEndpoint.Count > 0)
				WithChild(agencyEndpoint, entity);

		
        }


	}
}
		