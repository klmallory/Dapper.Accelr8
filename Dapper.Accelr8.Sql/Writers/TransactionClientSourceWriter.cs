
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
    public class TransactionClientSourceWriter : EntityWriter<int, TransactionClientSource>
    {
        public TransactionClientSourceWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, TransactionClientSource entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(TransactionClientSourceColumnNames.TransactionId.ToString(), actionType, taskIndex, count), entity.TransactionId);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.SubmissionCnt.ToString(), actionType, taskIndex, count), entity.SubmissionCnt);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.ClientId.ToString(), actionType, taskIndex, count), entity.ClientId);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.TCN.ToString(), actionType, taskIndex, count), entity.Tcn);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.CreatedDate.ToString(), actionType, taskIndex, count), entity.CreatedDate);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.SourceId.ToString(), actionType, taskIndex, count), entity.SourceId);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.SourceClient.ToString(), actionType, taskIndex, count), entity.SourceClient);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.SourceName.ToString(), actionType, taskIndex, count), entity.SourceName);
			parms.Add(GetParamName(TransactionClientSourceColumnNames.Filepath.ToString(), actionType, taskIndex, count), entity.Filepath);
					
			return parms;
        }


		protected override void CascadeRelations(TransactionClientSource entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		