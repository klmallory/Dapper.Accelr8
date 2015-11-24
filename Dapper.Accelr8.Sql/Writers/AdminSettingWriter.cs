
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
    public class AdminSettingWriter : EntityWriter<int, AdminSetting>
    {
        public AdminSettingWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, AdminSetting entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(AdminSettingColumnNames.AdminSettingsId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(AdminSettingColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(AdminSettingColumnNames.Type.ToString(), actionType, taskIndex, count), entity.Type);
			parms.Add(GetParamName(AdminSettingColumnNames.Description.ToString(), actionType, taskIndex, count), entity.Description);
			parms.Add(GetParamName(AdminSettingColumnNames.Value.ToString(), actionType, taskIndex, count), entity.Value);
					
			return parms;
        }


		protected override void CascadeRelations(AdminSetting entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		