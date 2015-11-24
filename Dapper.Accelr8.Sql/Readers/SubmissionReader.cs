

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
    public class SubmissionReader : EntityReader<int, Submission>
    {
        public SubmissionReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 3
		//Parent Count 3
		static IEntityReader<int , SubmissionStatusHistory> _submissionStatusHistoryReader;
		static IEntityReader<int , SubmissionStatusHistory> GetSubmissionStatusHistoryReader()
		{
			if (_submissionStatusHistoryReader == null)
				_submissionStatusHistoryReader = _locator.Resolve<IEntityReader<int , SubmissionStatusHistory>>();

			return _submissionStatusHistoryReader;
		}

		static IEntityReader<int , Response> _responseReader;
		static IEntityReader<int , Response> GetResponseReader()
		{
			if (_responseReader == null)
				_responseReader = _locator.Resolve<IEntityReader<int , Response>>();

			return _responseReader;
		}

		static IEntityReader<int , MatchRequest> _matchRequestReader;
		static IEntityReader<int , MatchRequest> GetMatchRequestReader()
		{
			if (_matchRequestReader == null)
				_matchRequestReader = _locator.Resolve<IEntityReader<int , MatchRequest>>();

			return _matchRequestReader;
		}

		
		/// <summary>
		/// Sets the children of type SubmissionStatusHistory on the parent on SubmissionStatusHistories.
		/// From foriegn key FK_SubmissionStatusHistory_Submissions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenSubmissionStatusHistories(IList<Submission> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SubmissionStatusHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SubmissionStatusHistory>();

			foreach (var r in results)
			{
				r.SubmissionStatusHistories = typedChildren.Where(b => b.SubmissionId == r.Id).ToList();
				r.SubmissionStatusHistories.ToList().ForEach(b => b.Submission = r);
			}
		}

		/// <summary>
		/// Sets the children of type Response on the parent on Responses.
		/// From foriegn key FK_Responses_Submissions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenResponses(IList<Submission> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Response

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Response>();

			foreach (var r in results)
			{
				r.Responses = typedChildren.Where(b => b.SubmissionId == r.Id).ToList();
				r.Responses.ToList().ForEach(b => b.Submission = r);
			}
		}

		/// <summary>
		/// Sets the children of type MatchRequest on the parent on MatchRequests.
		/// From foriegn key FK_MatchRequest_Submission_SubmissionId
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenMatchRequests(IList<Submission> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: MatchRequest

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<MatchRequest>();

			foreach (var r in results)
			{
				r.MatchRequests = typedChildren.Where(b => b.SubmissionId == r.Id).ToList();
				r.MatchRequests.ToList().ForEach(b => b.Submission = r);
			}
		}

			/// <summary>
		/// Loads the table Submissions into class Submission
		/// </summary>
		/// <param name="results">Submission</param>
		/// <param name="row"></param>
        public override Submission LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Submission();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.TransactionId = GetRowData<int>(dataRow, SubmissionColumnNames.TransactionId.ToString()); 	
			domain.EndpointId = GetRowData<int?>(dataRow, SubmissionColumnNames.EndpointId.ToString()); 	
			domain.AgencyId = GetRowData<int?>(dataRow, SubmissionColumnNames.AgencyId.ToString()); 	
			domain.Status = GetRowData<string>(dataRow, SubmissionColumnNames.Status.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Submission></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Submission> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSubmissionStatusHistoryReader(), id, IdColumn, SetChildrenSubmissionStatusHistories);
			
			WithChildForParentId(GetResponseReader(), id, IdColumn, SetChildrenResponses);
			
			WithChildForParentId(GetMatchRequestReader(), id, IdColumn, SetChildrenMatchRequests);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Submission entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSubmissionStatusHistoryReader(), entity.Id
				, SubmissionStatusHistoryColumnNames.SubmissionId.ToString()
				, SetChildrenSubmissionStatusHistories);

			WithChildForParentId(GetResponseReader(), entity.Id
				, ResponseColumnNames.SubmissionId.ToString()
				, SetChildrenResponses);

			WithChildForParentId(GetMatchRequestReader(), entity.Id
				, MatchRequestColumnNames.SubmissionId.ToString()
				, SetChildrenMatchRequests);

			QueryResultForChildrenOnly(new List<Submission>() { entity });

			GetSubmissionStatusHistoryReader().SetAllChildrenForExisting(entity.SubmissionStatusHistories);
			GetResponseReader().SetAllChildrenForExisting(entity.Responses);
			GetMatchRequestReader().SetAllChildrenForExisting(entity.MatchRequests);
				
		}

		public override void SetAllChildrenForExisting(IList<Submission> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSubmissionStatusHistoryReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), SubmissionStatusHistoryColumnNames.SubmissionId.ToString()
				, SetChildrenSubmissionStatusHistories);

			WithChildForParentIds(GetResponseReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), ResponseColumnNames.SubmissionId.ToString()
				, SetChildrenResponses);

			WithChildForParentIds(GetMatchRequestReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), MatchRequestColumnNames.SubmissionId.ToString()
				, SetChildrenMatchRequests);

					
			QueryResultForChildrenOnly(entities);

			GetSubmissionStatusHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SubmissionStatusHistories).ToList());
			GetResponseReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Responses).ToList());
			GetMatchRequestReader().SetAllChildrenForExisting(entities.SelectMany(e => e.MatchRequests).ToList());
					
		}
    }
}
		