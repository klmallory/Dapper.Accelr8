
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
    public class TransactionGroupSourceWriter : EntityWriter<int, TransactionGroupSource>
    {
        public TransactionGroupSourceWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, TransactionGroupSource entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(TransactionGroupSourceColumnNames.TransactionId.ToString(), actionType, taskIndex, count), entity.TransactionId);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.TCN.ToString(), actionType, taskIndex, count), entity.Tcn);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.CreatedDate.ToString(), actionType, taskIndex, count), entity.CreatedDate);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.TransactionType.ToString(), actionType, taskIndex, count), entity.TransactionType);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.TransactionStatus.ToString(), actionType, taskIndex, count), entity.TransactionStatus);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.Value.ToString(), actionType, taskIndex, count), entity.Value);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.TransactionFieldId.ToString(), actionType, taskIndex, count), entity.TransactionFieldId);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.FieldDescriptor.ToString(), actionType, taskIndex, count), entity.FieldDescriptor);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.Username.ToString(), actionType, taskIndex, count), entity.Username);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.SourceKey.ToString(), actionType, taskIndex, count), entity.SourceKey);
			parms.Add(GetParamName(TransactionGroupSourceColumnNames.AgencyName.ToString(), actionType, taskIndex, count), entity.AgencyName);
					
			return parms;
        }


		protected override void CascadeRelations(TransactionGroupSource entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		