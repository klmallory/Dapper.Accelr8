

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
		static IEntityReader<int , Submission> _submissionReader;
		static IEntityReader<int , Submission> GetSubmissionReader()
		{
			if (_submissionReader == null)
				_submissionReader = _locator.Resolve<IEntityReader<int , Submission>>();

			return _submissionReader;
		}

		static IEntityReader<int , Client> _clientReader;
		static IEntityReader<int , Client> GetClientReader()
		{
			if (_clientReader == null)
				_clientReader = _locator.Resolve<IEntityReader<int , Client>>();

			return _clientReader;
		}

		static IEntityReader<int , RoutedResponse> _routedResponseReader;
		static IEntityReader<int , RoutedResponse> GetRoutedResponseReader()
		{
			if (_routedResponseReader == null)
				_routedResponseReader = _locator.Resolve<IEntityReader<int , RoutedResponse>>();

			return _routedResponseReader;
		}

		static IEntityReader<int , AgencyEndpoint> _agencyEndpointReader;
		static IEntityReader<int , AgencyEndpoint> GetAgencyEndpointReader()
		{
			if (_agencyEndpointReader == null)
				_agencyEndpointReader = _locator.Resolve<IEntityReader<int , AgencyEndpoint>>();

			return _agencyEndpointReader;
		}

		
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
				r.Submissions = typedChildren.Where(b => b.EndpointId == r.Id).ToList();
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
				r.Clients = typedChildren.Where(b => b.EndpointId == r.Id).ToList();
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
				r.RoutedResponses = typedChildren.Where(b => b.EndpointId == r.Id).ToList();
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
				r.AgencyEndpoints = typedChildren.Where(b => b.EndpointId == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.ServerId = GetRowData<int>(dataRow, EndpointColumnNames.ServerId.ToString()); 	
			domain.Name = GetRowData<string>(dataRow, EndpointColumnNames.Name.ToString()); 	
			domain.Configuration = GetRowData<byte[]>(dataRow, EndpointColumnNames.Configuration.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Endpoint></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Endpoint> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSubmissionReader(), id, IdColumn, SetChildrenSubmissions);
			
			WithChildForParentId(GetClientReader(), id, IdColumn, SetChildrenClients);
			
			WithChildForParentId(GetRoutedResponseReader(), id, IdColumn, SetChildrenRoutedResponses);
			
			WithChildForParentId(GetAgencyEndpointReader(), id, IdColumn, SetChildrenAgencyEndpoints);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Endpoint entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSubmissionReader(), entity.Id
				, SubmissionColumnNames.EndpointId.ToString()
				, SetChildrenSubmissions);

			WithChildForParentId(GetClientReader(), entity.Id
				, ClientColumnNames.EndpointId.ToString()
				, SetChildrenClients);

			WithChildForParentId(GetRoutedResponseReader(), entity.Id
				, RoutedResponseColumnNames.EndpointId.ToString()
				, SetChildrenRoutedResponses);

			WithChildForParentId(GetAgencyEndpointReader(), entity.Id
				, AgencyEndpointColumnNames.EndpointId.ToString()
				, SetChildrenAgencyEndpoints);

			QueryResultForChildrenOnly(new List<Endpoint>() { entity });

			GetSubmissionReader().SetAllChildrenForExisting(entity.Submissions);
			GetClientReader().SetAllChildrenForExisting(entity.Clients);
			GetRoutedResponseReader().SetAllChildrenForExisting(entity.RoutedResponses);
			GetAgencyEndpointReader().SetAllChildrenForExisting(entity.AgencyEndpoints);
				
		}

		public override void SetAllChildrenForExisting(IList<Endpoint> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSubmissionReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), SubmissionColumnNames.EndpointId.ToString()
				, SetChildrenSubmissions);

			WithChildForParentIds(GetClientReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), ClientColumnNames.EndpointId.ToString()
				, SetChildrenClients);

			WithChildForParentIds(GetRoutedResponseReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), RoutedResponseColumnNames.EndpointId.ToString()
				, SetChildrenRoutedResponses);

			WithChildForParentIds(GetAgencyEndpointReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), AgencyEndpointColumnNames.EndpointId.ToString()
				, SetChildrenAgencyEndpoints);

					
			QueryResultForChildrenOnly(entities);

			GetSubmissionReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Submissions).ToList());
			GetClientReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Clients).ToList());
			GetRoutedResponseReader().SetAllChildrenForExisting(entities.SelectMany(e => e.RoutedResponses).ToList());
			GetAgencyEndpointReader().SetAllChildrenForExisting(entities.SelectMany(e => e.AgencyEndpoints).ToList());
					
		}
    }
}
		