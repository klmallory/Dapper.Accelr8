

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
    public class UsersGroupReader : EntityReader<int, UsersGroup>
    {
        public UsersGroupReader(
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
		/// Loads the table UsersGroups into class UsersGroup
		/// </summary>
		/// <param name="results">UsersGroup</param>
		/// <param name="row"></param>
        public override UsersGroup LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new UsersGroup();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.UserId = GetRowData<int>(dataRow, UsersGroupColumnNames.UserId.ToString()); 	
			domain.GroupId = GetRowData<int>(dataRow, UsersGroupColumnNames.GroupId.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, UsersGroup> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(UsersGroup entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<UsersGroup> entities)
        {
					
		}
    }
}
		