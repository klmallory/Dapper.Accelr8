
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
    public class TransactionOperationDetailWriter : EntityWriter<int, TransactionOperationDetail>
    {
        public TransactionOperationDetailWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, TransactionOperationDetail entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(TransactionOperationDetailColumnNames.TransactionOperationDetailsId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(TransactionOperationDetailColumnNames.TransactionOperationHistoryId.ToString(), actionType, taskIndex, count), entity.TransactionOperationHistoryId);
			parms.Add(GetParamName(TransactionOperationDetailColumnNames.OperationFileName.ToString(), actionType, taskIndex, count), entity.OperationFileName);
			parms.Add(GetParamName(TransactionOperationDetailColumnNames.Status.ToString(), actionType, taskIndex, count), entity.Status);
			parms.Add(GetParamName(TransactionOperationDetailColumnNames.ReasonFailed.ToString(), actionType, taskIndex, count), entity.ReasonFailed);
					
			return parms;
        }


		protected override void CascadeRelations(TransactionOperationDetail entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		