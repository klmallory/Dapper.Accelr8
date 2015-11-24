
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
    public class TransactionFilePathWriter : EntityWriter<int, TransactionFilePath>
    {
        public TransactionFilePathWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, TransactionFilePath entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(TransactionFilePathColumnNames.TransactionFilePathId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(TransactionFilePathColumnNames.TransactionId.ToString(), actionType, taskIndex, count), entity.TransactionId);
			parms.Add(GetParamName(TransactionFilePathColumnNames.FilePath.ToString(), actionType, taskIndex, count), entity.FilePath);
					
			return parms;
        }


		protected override void CascadeRelations(TransactionFilePath entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		