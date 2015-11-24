
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
    public class SubmissionWriter : EntityWriter<int, Submission>
    {
        public SubmissionWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , SubmissionStatusHistory> GetSubmissionStatusHistoryWriter()
		{ return _locator.Resolve<IEntityWriter<int , SubmissionStatusHistory>>(); }
		static IEntityWriter<int , Response> GetResponseWriter()
		{ return _locator.Resolve<IEntityWriter<int , Response>>(); }
		static IEntityWriter<int , MatchRequest> GetMatchRequestWriter()
		{ return _locator.Resolve<IEntityWriter<int , MatchRequest>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Submission entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(SubmissionColumnNames.SubmissionId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(SubmissionColumnNames.TransactionId.ToString(), actionType, taskIndex, count), entity.TransactionId);
			parms.Add(GetParamName(SubmissionColumnNames.EndpointId.ToString(), actionType, taskIndex, count), entity.EndpointId);
			parms.Add(GetParamName(SubmissionColumnNames.AgencyId.ToString(), actionType, taskIndex, count), entity.AgencyId);
			parms.Add(GetParamName(SubmissionColumnNames.Status.ToString(), actionType, taskIndex, count), entity.Status);
					
			return parms;
        }


		protected override void CascadeRelations(Submission entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SubmissionStatusHistory_Submissions
			var submissionStatusHistory = GetSubmissionStatusHistoryWriter();
			if (_cascades.Contains(SubmissionCascadeNames.submissionstatushistory.ToString()))
				foreach (var item in entity.SubmissionStatusHistories)
					Cascade(submissionStatusHistory, item, context);

			if (submissionStatusHistory.Count > 0)
				WithChild(submissionStatusHistory, entity);

			//From Foreign Key FK_Responses_Submissions
			var response = GetResponseWriter();
			if (_cascades.Contains(SubmissionCascadeNames.response.ToString()))
				foreach (var item in entity.Responses)
					Cascade(response, item, context);

			if (response.Count > 0)
				WithChild(response, entity);

			//From Foreign Key FK_MatchRequest_Submission_SubmissionId
			var matchRequest = GetMatchRequestWriter();
			if (_cascades.Contains(SubmissionCascadeNames.matchrequest.ToString()))
				foreach (var item in entity.MatchRequests)
					Cascade(matchRequest, item, context);

			if (matchRequest.Count > 0)
				WithChild(matchRequest, entity);

		
        }


	}
}
		