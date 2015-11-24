

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
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.Readers
{
    public class AgencyReader : EntityReader<int, Agency>
    {
        public AgencyReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 3
		//Parent Count 1
		static IEntityReader<int , Workspace> _workspaceReader;
		static IEntityReader<int , Workspace> GetWorkspaceReader()
		{
			if (_workspaceReader == null)
				_workspaceReader = _locator.Resolve<IEntityReader<int , Workspace>>();

			return _workspaceReader;
		}

		static IEntityReader<int , Submission> _submissionReader;
		static IEntityReader<int , Submission> GetSubmissionReader()
		{
			if (_submissionReader == null)
				_submissionReader = _locator.Resolve<IEntityReader<int , Submission>>();

			return _submissionReader;
		}

		static IEntityReader<int , AgencyEndpoint> _agencyEndpointReader;
		static IEntityReader<int , AgencyEndpoint> GetAgencyEndpointReader()
		{
			if (_agencyEndpointReader == null)
				_agencyEndpointReader = _locator.Resolve<IEntityReader<int , AgencyEndpoint>>();

			return _agencyEndpointReader;
		}

		
		/// <summary>
		/// Sets the children of type Workspace on the parent on Workspaces.
		/// From foriegn key FK_Workspaces_Agencies
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenWorkspaces(IList<Agency> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Workspace

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Workspace>();

			foreach (var r in results)
			{
				r.Workspaces = typedChildren.Where(b => b.AgencyId == r.Id).ToList();
				r.Workspaces.ToList().ForEach(b => b.Agency = r);
			}
		}

		/// <summary>
		/// Sets the children of type Submission on the parent on Submissions.
		/// From foriegn key FK_Submission_Agency
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenSubmissions(IList<Agency> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Submission

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Submission>();

			foreach (var r in results)
			{
				r.Submissions = typedChildren.Where(b => b.AgencyId == r.Id).ToList();
				r.Submissions.ToList().ForEach(b => b.Agency = r);
			}
		}

		/// <summary>
		/// Sets the children of type AgencyEndpoint on the parent on AgencyEndpoints.
		/// From foriegn key FK_AgencyEndpoints_Agencies
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenAgencyEndpoints(IList<Agency> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: AgencyEndpoint

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<AgencyEndpoint>();

			foreach (var r in results)
			{
				r.AgencyEndpoints = typedChildren.Where(b => b.AgencyId == r.Id).ToList();
				r.AgencyEndpoints.ToList().ForEach(b => b.Agency = r);
			}
		}

			/// <summary>
		/// Loads the table Agencies into class Agency
		/// </summary>
		/// <param name="results">Agency</param>
		/// <param name="row"></param>
        public override Agency LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Agency();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.Name = GetRowData<string>(dataRow, AgencyColumnNames.Name.ToString()); 	
			domain.Ori = GetRowData<string>(dataRow, AgencyColumnNames.ORI.ToString()); 	
			domain.Cmabi = GetRowData<bool>(dataRow, AgencyColumnNames.CMABIS.ToString()); 	
			domain.AgencySpecId = GetRowData<int>(dataRow, AgencyColumnNames.AgencySpecId.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Agency></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Agency> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetWorkspaceReader(), id, IdColumn, SetChildrenWorkspaces);
			
			WithChildForParentId(GetSubmissionReader(), id, IdColumn, SetChildrenSubmissions);
			
			WithChildForParentId(GetAgencyEndpointReader(), id, IdColumn, SetChildrenAgencyEndpoints);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Agency entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetWorkspaceReader(), entity.Id
				, WorkspaceColumnNames.AgencyId.ToString()
				, SetChildrenWorkspaces);

			WithChildForParentId(GetSubmissionReader(), entity.Id
				, SubmissionColumnNames.AgencyId.ToString()
				, SetChildrenSubmissions);

			WithChildForParentId(GetAgencyEndpointReader(), entity.Id
				, AgencyEndpointColumnNames.AgencyId.ToString()
				, SetChildrenAgencyEndpoints);

			QueryResultForChildrenOnly(new List<Agency>() { entity });

			GetWorkspaceReader().SetAllChildrenForExisting(entity.Workspaces);
			GetSubmissionReader().SetAllChildrenForExisting(entity.Submissions);
			GetAgencyEndpointReader().SetAllChildrenForExisting(entity.AgencyEndpoints);
				
		}

		public override void SetAllChildrenForExisting(IList<Agency> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetWorkspaceReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), WorkspaceColumnNames.AgencyId.ToString()
				, SetChildrenWorkspaces);

			WithChildForParentIds(GetSubmissionReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), SubmissionColumnNames.AgencyId.ToString()
				, SetChildrenSubmissions);

			WithChildForParentIds(GetAgencyEndpointReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), AgencyEndpointColumnNames.AgencyId.ToString()
				, SetChildrenAgencyEndpoints);

					
			QueryResultForChildrenOnly(entities);

			GetWorkspaceReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Workspaces).ToList());
			GetSubmissionReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Submissions).ToList());
			GetAgencyEndpointReader().SetAllChildrenForExisting(entities.SelectMany(e => e.AgencyEndpoints).ToList());
					
		}
    }
}
		