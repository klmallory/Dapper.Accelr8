
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
    public class AgencyWriter : EntityWriter<int, Agency>
    {
        public AgencyWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , Workspace> GetWorkspaceWriter()
		{ return _locator.Resolve<IEntityWriter<int , Workspace>>(); }
		static IEntityWriter<int , Submission> GetSubmissionWriter()
		{ return _locator.Resolve<IEntityWriter<int , Submission>>(); }
		static IEntityWriter<int , AgencyEndpoint> GetAgencyEndpointWriter()
		{ return _locator.Resolve<IEntityWriter<int , AgencyEndpoint>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Agency entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(AgencyColumnNames.AgencyId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(AgencyColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(AgencyColumnNames.ORI.ToString(), actionType, taskIndex, count), entity.Ori);
			parms.Add(GetParamName(AgencyColumnNames.CMABIS.ToString(), actionType, taskIndex, count), entity.Cmabi);
			parms.Add(GetParamName(AgencyColumnNames.AgencySpecId.ToString(), actionType, taskIndex, count), entity.AgencySpecId);
					
			return parms;
        }


		protected override void CascadeRelations(Agency entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Workspaces_Agencies
			var workspace = GetWorkspaceWriter();
			if (_cascades.Contains(AgencyCascadeNames.workspace.ToString()))
				foreach (var item in entity.Workspaces)
					Cascade(workspace, item, context);

			if (workspace.Count > 0)
				WithChild(workspace, entity);

			//From Foreign Key FK_Submission_Agency
			var submission = GetSubmissionWriter();
			if (_cascades.Contains(AgencyCascadeNames.submission.ToString()))
				foreach (var item in entity.Submissions)
					Cascade(submission, item, context);

			if (submission.Count > 0)
				WithChild(submission, entity);

			//From Foreign Key FK_AgencyEndpoints_Agencies
			var agencyEndpoint = GetAgencyEndpointWriter();
			if (_cascades.Contains(AgencyCascadeNames.agencyendpoint.ToString()))
				foreach (var item in entity.AgencyEndpoints)
					Cascade(agencyEndpoint, item, context);

			if (agencyEndpoint.Count > 0)
				WithChild(agencyEndpoint, entity);

		
        }


	}
}
		