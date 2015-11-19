

using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfo;
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
				r.Workspaces = typedChildren.Where(b => b.WorkspaceId == r.Id).ToList();
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
				r.Submissions = typedChildren.Where(b => b.SubmissionId == r.Id).ToList();
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
				r.AgencyEndpoints = typedChildren.Where(b => b.AgencyEndpointId == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.Name = GetRowData<string>(dataRow, AgencyColumnNames.Name.ToString()); 	
			domain.ORI = GetRowData<string>(dataRow, AgencyColumnNames.ORI.ToString()); 	
			domain.CMABIS = GetRowData<bool>(dataRow, AgencyColumnNames.CMABIS.ToString()); 	
			domain.AgencySpecId = GetRowData<int>(dataRow, AgencyColumnNames.AgencySpecId.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, Agency> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Workspaces>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , AgencyEndpoints>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Agency entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Workspaces>(), id, IdField, SetChildrenWorkspaces);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildrenSubmissions);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , AgencyEndpoints>(), id, IdField, SetChildrenAgencyEndpoints);
			QueryResultForChildrenOnly(new List<Agency>() { entity });

			_locator.Resolve<IEntityReader<int , Workspaces>().SetAllChildrenForExisting(entity.Workspaces);
			_locator.Resolve<IEntityReader<int , Submissions>().SetAllChildrenForExisting(entity.Submissions);
			_locator.Resolve<IEntityReader<int , AgencyEndpoints>().SetAllChildrenForExisting(entity.AgencyEndpoints);
				
		}

		public override void SetAllChildrenForExisting(IList<Agency> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Workspaces>(), id, IdField, SetChildrenWorkspaces);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildrenSubmissions);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , AgencyEndpoints>(), id, IdField, SetChildrenAgencyEndpoints);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, Workspaces>().SetAllChildrenForExisting(entities.SelectMany(e => e.Workspaces));
			_locator.Resolve<IEntityReader<int, Submissions>().SetAllChildrenForExisting(entities.SelectMany(e => e.Submissions));
			_locator.Resolve<IEntityReader<int, AgencyEndpoints>().SetAllChildrenForExisting(entities.SelectMany(e => e.AgencyEndpoints));
					
		}
    }
}
		