

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
    public class RoutedResponseReader : EntityReader<int, RoutedResponse>
    {
        public RoutedResponseReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 1
		//Parent Count 2
		static IEntityReader<int , RoutedResponseStatusHistory> _routedResponseStatusHistoryReader;
		static IEntityReader<int , RoutedResponseStatusHistory> GetRoutedResponseStatusHistoryReader()
		{
			if (_routedResponseStatusHistoryReader == null)
				_routedResponseStatusHistoryReader = _locator.Resolve<IEntityReader<int , RoutedResponseStatusHistory>>();

			return _routedResponseStatusHistoryReader;
		}

		
		/// <summary>
		/// Sets the children of type RoutedResponseStatusHistory on the parent on RoutedResponseStatusHistories.
		/// From foriegn key FK_RoutedResponseStatusHistory_RoutedResponse_RoutedResponseId
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenRoutedResponseStatusHistories(IList<RoutedResponse> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: RoutedResponseStatusHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<RoutedResponseStatusHistory>();

			foreach (var r in results)
			{
				r.RoutedResponseStatusHistories = typedChildren.Where(b => b.RoutedResponseId == r.Id).ToList();
				r.RoutedResponseStatusHistories.ToList().ForEach(b => b.RoutedResponse = r);
			}
		}

			/// <summary>
		/// Loads the table RoutedResponses into class RoutedResponse
		/// </summary>
		/// <param name="results">RoutedResponse</param>
		/// <param name="row"></param>
        public override RoutedResponse LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new RoutedResponse();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.ResponseId = GetRowData<int>(dataRow, RoutedResponseColumnNames.ResponseId.ToString()); 	
			domain.EndpointId = GetRowData<int?>(dataRow, RoutedResponseColumnNames.EndpointId.ToString()); 	
			domain.Status = GetRowData<string>(dataRow, RoutedResponseColumnNames.Status.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, RoutedResponse></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, RoutedResponse> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetRoutedResponseStatusHistoryReader(), id, IdColumn, SetChildrenRoutedResponseStatusHistories);
			
            return this;
        }

        public override void SetAllChildrenForExisting(RoutedResponse entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetRoutedResponseStatusHistoryReader(), entity.Id
				, RoutedResponseStatusHistoryColumnNames.RoutedResponseId.ToString()
				, SetChildrenRoutedResponseStatusHistories);

			QueryResultForChildrenOnly(new List<RoutedResponse>() { entity });

			GetRoutedResponseStatusHistoryReader().SetAllChildrenForExisting(entity.RoutedResponseStatusHistories);
				
		}

		public override void SetAllChildrenForExisting(IList<RoutedResponse> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetRoutedResponseStatusHistoryReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), RoutedResponseStatusHistoryColumnNames.RoutedResponseId.ToString()
				, SetChildrenRoutedResponseStatusHistories);

					
			QueryResultForChildrenOnly(entities);

			GetRoutedResponseStatusHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.RoutedResponseStatusHistories).ToList());
					
		}
    }
}
		