

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
    public class WorkspaceGroupReader : EntityReader<int, WorkspaceGroup>
    {
        public WorkspaceGroupReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 2
		
			/// <summary>
		/// Loads the table WorkspaceGroups into class WorkspaceGroup
		/// </summary>
		/// <param name="results">WorkspaceGroup</param>
		/// <param name="row"></param>
        public override WorkspaceGroup LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new WorkspaceGroup();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.WorkspaceId = GetRowData<int>(dataRow, WorkspaceGroupColumnNames.WorkspaceId.ToString()); 	
			domain.GroupId = GetRowData<int>(dataRow, WorkspaceGroupColumnNames.GroupId.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, WorkspaceGroup></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, WorkspaceGroup> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(WorkspaceGroup entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<WorkspaceGroup> entities)
        {
					
		}
    }
}
		