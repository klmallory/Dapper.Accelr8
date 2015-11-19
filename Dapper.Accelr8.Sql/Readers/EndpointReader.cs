

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
    public class EndpointReader : EntityReader<int, Endpoint>
    {
        public EndpointReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 4
		//Parent Count 1

		/// <summary>
		/// Sets the children of type Submission on the parent on Submissions.
		/// From foriegn key FK_Submissions_Endpoints
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenSubmissions(IList<Endpoint> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Submission

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Submission>();

			foreach (var r in results)
			{
				r.Submissions = typedChildren.Where(b => b.SubmissionId == r.Id).ToList();
				r.Submissions.ToList().ForEach(b => b.Endpoint = r);
			}
		}

		/// <summary>
		/// Sets the children of type Client on the parent on Clients.
		/// From foriegn key FK_Clients_Endpoint
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenClients(IList<Endpoint> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Client

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Client>();

			foreach (var r in results)
			{
				r.Clients = typedChildren.Where(b => b.ClientId == r.Id).ToList();
				r.Clients.ToList().ForEach(b => b.Endpoint = r);
			}
		}

		/// <summary>
		/// Sets the children of type RoutedResponse on the parent on RoutedResponses.
		/// From foriegn key FK__RoutedRes__Endpo__6477ECF3
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenRoutedResponses(IList<Endpoint> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: RoutedResponse

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<RoutedResponse>();

			foreach (var r in results)
			{
				r.RoutedResponses = typedChildren.Where(b => b.RoutedResponseId == r.Id).ToList();
				r.RoutedResponses.ToList().ForEach(b => b.Endpoint = r);
			}
		}

		/// <summary>
		/// Sets the children of type AgencyEndpoint on the parent on AgencyEndpoints.
		/// From foriegn key FK_AgencyEndpoints_Endpoints
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenAgencyEndpoints(IList<Endpoint> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: AgencyEndpoint

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<AgencyEndpoint>();

			foreach (var r in results)
			{
				r.AgencyEndpoints = typedChildren.Where(b => b.AgencyEndpointId == r.Id).ToList();
				r.AgencyEndpoints.ToList().ForEach(b => b.Endpoint = r);
			}
		}

			/// <summary>
		/// Loads the table Endpoints into class Endpoint
		/// </summary>
		/// <param name="results">Endpoint</param>
		/// <param name="row"></param>
        public override Endpoint LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Endpoint();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.ServerId = GetRowData<int>(dataRow, EndpointColumnNames.ServerId.ToString()); 	
			domain.Name = GetRowData<string>(dataRow, EndpointColumnNames.Name.ToString()); 	
			domain.Configuration = GetRowData<byte[]>(dataRow, EndpointColumnNames.Configuration.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, Endpoint> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Clients>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , RoutedResponses>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , AgencyEndpoints>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Endpoint entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildrenSubmissions);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Clients>(), id, IdField, SetChildrenClients);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , RoutedResponses>(), id, IdField, SetChildrenRoutedResponses);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , AgencyEndpoints>(), id, IdField, SetChildrenAgencyEndpoints);
			QueryResultForChildrenOnly(new List<Endpoint>() { entity });

			_locator.Resolve<IEntityReader<int , Submissions>().SetAllChildrenForExisting(entity.Submissions);
			_locator.Resolve<IEntityReader<int , Clients>().SetAllChildrenForExisting(entity.Clients);
			_locator.Resolve<IEntityReader<int , RoutedResponses>().SetAllChildrenForExisting(entity.RoutedResponses);
			_locator.Resolve<IEntityReader<int , AgencyEndpoints>().SetAllChildrenForExisting(entity.AgencyEndpoints);
				
		}

		public override void SetAllChildrenForExisting(IList<Endpoint> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildrenSubmissions);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Clients>(), id, IdField, SetChildrenClients);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , RoutedResponses>(), id, IdField, SetChildrenRoutedResponses);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , AgencyEndpoints>(), id, IdField, SetChildrenAgencyEndpoints);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, Submissions>().SetAllChildrenForExisting(entities.SelectMany(e => e.Submissions));
			_locator.Resolve<IEntityReader<int, Clients>().SetAllChildrenForExisting(entities.SelectMany(e => e.Clients));
			_locator.Resolve<IEntityReader<int, RoutedResponses>().SetAllChildrenForExisting(entities.SelectMany(e => e.RoutedResponses));
			_locator.Resolve<IEntityReader<int, AgencyEndpoints>().SetAllChildrenForExisting(entities.SelectMany(e => e.AgencyEndpoints));
					
		}
    }
}
		