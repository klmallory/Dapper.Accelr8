
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
using Dapper.Accelr8.Repo.Contracts.Writers;

namespace Dapper.Accelr8.Writers
{
    public class UsersGroupWriter : EntityWriter<int, UsersGroup>
    {
        public UsersGroupWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, UsersGroup entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(UsersGroupColumnNames.UsersGroupsId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(UsersGroupColumnNames.UserId.ToString(), actionType, taskIndex, count), entity.UserId);
			parms.Add(GetParamName(UsersGroupColumnNames.GroupId.ToString(), actionType, taskIndex, count), entity.GroupId);
					
			return parms;
        }


		protected override void CascadeRelations(UsersGroup entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		