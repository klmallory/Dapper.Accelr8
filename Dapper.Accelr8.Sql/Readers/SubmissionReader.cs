

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
				r.SubmissionStatusHistories = typedChildren.Where(b => b.SubmissionStatusHistoryId == r.Id).ToList();
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
				r.Responses = typedChildren.Where(b => b.ResponseId == r.Id).ToList();
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
				r.MatchRequests = typedChildren.Where(b => b.MatchRequestId == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.TransactionId = GetRowData<int>(dataRow, SubmissionColumnNames.TransactionId.ToString()); 	
			domain.EndpointId = GetRowData<int?>(dataRow, SubmissionColumnNames.EndpointId.ToString()); 	
			domain.AgencyId = GetRowData<int?>(dataRow, SubmissionColumnNames.AgencyId.ToString()); 	
			domain.Status = GetRowData<string>(dataRow, SubmissionColumnNames.Status.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, Submission> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , SubmissionStatusHistory>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Responses>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , MatchRequests>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Submission entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , SubmissionStatusHistory>(), id, IdField, SetChildrenSubmissionStatusHistories);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Responses>(), id, IdField, SetChildrenResponses);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , MatchRequests>(), id, IdField, SetChildrenMatchRequests);
			QueryResultForChildrenOnly(new List<Submission>() { entity });

			_locator.Resolve<IEntityReader<int , SubmissionStatusHistory>().SetAllChildrenForExisting(entity.SubmissionStatusHistories);
			_locator.Resolve<IEntityReader<int , Responses>().SetAllChildrenForExisting(entity.Responses);
			_locator.Resolve<IEntityReader<int , MatchRequests>().SetAllChildrenForExisting(entity.MatchRequests);
				
		}

		public override void SetAllChildrenForExisting(IList<Submission> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , SubmissionStatusHistory>(), id, IdField, SetChildrenSubmissionStatusHistories);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Responses>(), id, IdField, SetChildrenResponses);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , MatchRequests>(), id, IdField, SetChildrenMatchRequests);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, SubmissionStatusHistory>().SetAllChildrenForExisting(entities.SelectMany(e => e.SubmissionStatusHistories));
			_locator.Resolve<IEntityReader<int, Responses>().SetAllChildrenForExisting(entities.SelectMany(e => e.Responses));
			_locator.Resolve<IEntityReader<int, MatchRequests>().SetAllChildrenForExisting(entities.SelectMany(e => e.MatchRequests));
					
		}
    }
}
		