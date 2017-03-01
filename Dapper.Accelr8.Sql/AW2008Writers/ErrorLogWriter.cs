
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008Writers
{
    public class ErrorLogWriter : EntityWriter<int, ErrorLog>
    {
        public ErrorLogWriter
			(ErrorLogTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ErrorLog entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ErrorLogColumnNames)f.Key)
                {
                    
					case ErrorLogColumnNames.ErrorTime:
						parms.Add(GetParamName("ErrorTime", actionType, taskIndex, ref count), entity.ErrorTime);
						break;
					case ErrorLogColumnNames.UserName:
						parms.Add(GetParamName("UserName", actionType, taskIndex, ref count), entity.UserName);
						break;
					case ErrorLogColumnNames.ErrorNumber:
						parms.Add(GetParamName("ErrorNumber", actionType, taskIndex, ref count), entity.ErrorNumber);
						break;
					case ErrorLogColumnNames.ErrorSeverity:
						parms.Add(GetParamName("ErrorSeverity", actionType, taskIndex, ref count), entity.ErrorSeverity);
						break;
					case ErrorLogColumnNames.ErrorState:
						parms.Add(GetParamName("ErrorState", actionType, taskIndex, ref count), entity.ErrorState);
						break;
					case ErrorLogColumnNames.ErrorProcedure:
						parms.Add(GetParamName("ErrorProcedure", actionType, taskIndex, ref count), entity.ErrorProcedure);
						break;
					case ErrorLogColumnNames.ErrorLine:
						parms.Add(GetParamName("ErrorLine", actionType, taskIndex, ref count), entity.ErrorLine);
						break;
					case ErrorLogColumnNames.ErrorMessage:
						parms.Add(GetParamName("ErrorMessage", actionType, taskIndex, ref count), entity.ErrorMessage);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ErrorLog entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ErrorLog entity)
        {
            if (entity == null)
                return;

				
		}

		protected override void RemoveRelations(ErrorLog entity, ScriptContext context)
        {
				}
	}
}
		