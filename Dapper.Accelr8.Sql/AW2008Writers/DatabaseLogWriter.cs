
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
    public class DatabaseLogWriter : EntityWriter<int, DatabaseLog>
    {
        public DatabaseLogWriter
			(DatabaseLogTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{
			if (s_loc8r == null)
				s_loc8r = loc8r;
		}

		static ILoc8 s_loc8r = null;

		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, DatabaseLog entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((DatabaseLogFieldNames)f.Key)
                {
                    
					case DatabaseLogFieldNames.PostTime:
						parms.Add(GetParamName("PostTime", actionType, taskIndex, ref count), entity.PostTime);
						break;
					case DatabaseLogFieldNames.DatabaseUser:
						parms.Add(GetParamName("DatabaseUser", actionType, taskIndex, ref count), entity.DatabaseUser);
						break;
					case DatabaseLogFieldNames.Event:
						parms.Add(GetParamName("Event", actionType, taskIndex, ref count), entity.Event);
						break;
					case DatabaseLogFieldNames.Schema:
						parms.Add(GetParamName("Schema", actionType, taskIndex, ref count), entity.Schema);
						break;
					case DatabaseLogFieldNames.Object:
						parms.Add(GetParamName("Object", actionType, taskIndex, ref count), entity.Object);
						break;
					case DatabaseLogFieldNames.TSQL:
						parms.Add(GetParamName("TSQL", actionType, taskIndex, ref count), entity.TSQL);
						break;
					case DatabaseLogFieldNames.XmlEvent:
						parms.Add(GetParamName("XmlEvent", actionType, taskIndex, ref count), entity.XmlEvent);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(DatabaseLog entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, DatabaseLog entity)
        {
            if (entity == null)
                return;

				
		}

		protected override void RemoveRelations(DatabaseLog entity, ScriptContext context)
        {
				}
	}
}
		