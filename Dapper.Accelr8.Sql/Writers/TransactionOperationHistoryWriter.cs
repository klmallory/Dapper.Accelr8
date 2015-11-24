
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
    public class TransactionOperationHistoryWriter : EntityWriter<int, TransactionOperationHistory>
    {
        public TransactionOperationHistoryWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , TransactionOperationDetail> GetTransactionOperationDetailWriter()
		{ return _locator.Resolve<IEntityWriter<int , TransactionOperationDetail>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, TransactionOperationHistory entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(TransactionOperationHistoryColumnNames.TransactionOperationHistoryId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(TransactionOperationHistoryColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(TransactionOperationHistoryColumnNames.Timestamp.ToString(), actionType, taskIndex, count), entity.Timestamp);
			parms.Add(GetParamName(TransactionOperationHistoryColumnNames.Username.ToString(), actionType, taskIndex, count), entity.Username);
			parms.Add(GetParamName(TransactionOperationHistoryColumnNames.TransactionCount.ToString(), actionType, taskIndex, count), entity.TransactionCount);
			parms.Add(GetParamName(TransactionOperationHistoryColumnNames.TransactionSuccessCount.ToString(), actionType, taskIndex, count), entity.TransactionSuccessCount);
			parms.Add(GetParamName(TransactionOperationHistoryColumnNames.Status.ToString(), actionType, taskIndex, count), entity.Status);
			parms.Add(GetParamName(TransactionOperationHistoryColumnNames.OperationType.ToString(), actionType, taskIndex, count), entity.OperationType);
					
			return parms;
        }


		protected override void CascadeRelations(TransactionOperationHistory entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_TransactionOperationDetails_History
			var transactionOperationDetail = GetTransactionOperationDetailWriter();
			if (_cascades.Contains(TransactionOperationHistoryCascadeNames.transactionoperationdetail.ToString()))
				foreach (var item in entity.TransactionOperationDetails)
					Cascade(transactionOperationDetail, item, context);

			if (transactionOperationDetail.Count > 0)
				WithChild(transactionOperationDetail, entity);

		
        }


	}
}
		