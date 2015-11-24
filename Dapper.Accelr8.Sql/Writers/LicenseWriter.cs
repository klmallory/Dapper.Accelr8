
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
    public class LicenseWriter : EntityWriter<int, License>
    {
        public LicenseWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, License entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(LicenseColumnNames.LicenseId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(LicenseColumnNames.LicenseType.ToString(), actionType, taskIndex, count), entity.LicenseType);
			parms.Add(GetParamName(LicenseColumnNames.ComputerName.ToString(), actionType, taskIndex, count), entity.ComputerName);
			parms.Add(GetParamName(LicenseColumnNames.MACAddress.ToString(), actionType, taskIndex, count), entity.MacAddress);
			parms.Add(GetParamName(LicenseColumnNames.DeviceSerialNum.ToString(), actionType, taskIndex, count), entity.DeviceSerialNum);
			parms.Add(GetParamName(LicenseColumnNames.UserId.ToString(), actionType, taskIndex, count), entity.UserId);
			parms.Add(GetParamName(LicenseColumnNames.WorkstationId.ToString(), actionType, taskIndex, count), entity.WorkstationId);
					
			return parms;
        }


		protected override void CascadeRelations(License entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		