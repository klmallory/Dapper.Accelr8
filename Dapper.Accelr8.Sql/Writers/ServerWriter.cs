
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
    public class ServerWriter : EntityWriter<int, Server>
    {
        public ServerWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , Endpoint> GetEndpointWriter()
		{ return _locator.Resolve<IEntityWriter<int , Endpoint>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Server entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(ServerColumnNames.ServerId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(ServerColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(ServerColumnNames.Direction.ToString(), actionType, taskIndex, count), entity.Direction);
			parms.Add(GetParamName(ServerColumnNames.Description.ToString(), actionType, taskIndex, count), entity.Description);
			parms.Add(GetParamName(ServerColumnNames.Protocol.ToString(), actionType, taskIndex, count), entity.Protocol);
			parms.Add(GetParamName(ServerColumnNames.Configuration.ToString(), actionType, taskIndex, count), entity.Configuration);
					
			return parms;
        }


		protected override void CascadeRelations(Server entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Endpoints_Servers
			var endpoint = GetEndpointWriter();
			if (_cascades.Contains(ServerCascadeNames.endpoint.ToString()))
				foreach (var item in entity.Endpoints)
					Cascade(endpoint, item, context);

			if (endpoint.Count > 0)
				WithChild(endpoint, entity);

		
        }


	}
}
		