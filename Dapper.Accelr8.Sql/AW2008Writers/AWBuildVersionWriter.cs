
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
    public class AWBuildVersionWriter : EntityWriter<byte, AWBuildVersion>
    {
        public AWBuildVersionWriter
			(AWBuildVersionTableInfo tableInfo
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, AWBuildVersion entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((AWBuildVersionFieldNames)f.Key)
                {
                    
					case AWBuildVersionFieldNames.Database_Spc_Version:
						parms.Add(GetParamName("Database Version", actionType, taskIndex, ref count), entity.Database_Spc_Version);
						break;
					case AWBuildVersionFieldNames.VersionDate:
						parms.Add(GetParamName("VersionDate", actionType, taskIndex, ref count), entity.VersionDate);
						break;
					case AWBuildVersionFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(AWBuildVersion entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, AWBuildVersion entity)
        {
            if (entity == null)
                return;

				
		}

		protected override void RemoveRelations(AWBuildVersion entity, ScriptContext context)
        {
				}
	}
}
		