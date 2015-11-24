

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
    public class ApplicationReader : EntityReader<int, Application>
    {
        public ApplicationReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , User> _userReader;
		static IEntityReader<int , User> GetUserReader()
		{
			if (_userReader == null)
				_userReader = _locator.Resolve<IEntityReader<int , User>>();

			return _userReader;
		}

		
		/// <summary>
		/// Sets the children of type User on the parent on Users.
		/// From foriegn key FK_Users_Applications
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenUsers(IList<Application> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: User

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<User>();

			foreach (var r in results)
			{
				r.Users = typedChildren.Where(b => b.ApplicationId == r.Id).ToList();
				r.Users.ToList().ForEach(b => b.Application = r);
			}
		}

			/// <summary>
		/// Loads the table Applications into class Application
		/// </summary>
		/// <param name="results">Application</param>
		/// <param name="row"></param>
        public override Application LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Application();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.Name = GetRowData<string>(dataRow, ApplicationColumnNames.Name.ToString()); 	
			domain.ApplicationKey = GetRowData<string>(dataRow, ApplicationColumnNames.ApplicationKey.ToString()); 	
			domain.Description = GetRowData<string>(dataRow, ApplicationColumnNames.Description.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Application></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Application> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetUserReader(), id, IdColumn, SetChildrenUsers);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Application entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetUserReader(), entity.Id
				, UserColumnNames.ApplicationId.ToString()
				, SetChildrenUsers);

			QueryResultForChildrenOnly(new List<Application>() { entity });

			GetUserReader().SetAllChildrenForExisting(entity.Users);
				
		}

		public override void SetAllChildrenForExisting(IList<Application> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetUserReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), UserColumnNames.ApplicationId.ToString()
				, SetChildrenUsers);

					
			QueryResultForChildrenOnly(entities);

			GetUserReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Users).ToList());
					
		}
    }
}
		