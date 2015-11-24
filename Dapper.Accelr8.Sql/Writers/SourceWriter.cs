
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
    public class SourceWriter : EntityWriter<int, Source>
    {
        public SourceWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , Transaction> GetTransactionWriter()
		{ return _locator.Resolve<IEntityWriter<int , Transaction>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Source entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(SourceColumnNames.SourceId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(SourceColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(SourceColumnNames.SourceKey.ToString(), actionType, taskIndex, count), entity.SourceKey);
			parms.Add(GetParamName(SourceColumnNames.Description.ToString(), actionType, taskIndex, count), entity.Description);
					
			return parms;
        }


		protected override void CascadeRelations(Source entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Transactions_Source
			var transaction = GetTransactionWriter();
			if (_cascades.Contains(SourceCascadeNames.transaction.ToString()))
				foreach (var item in entity.Transactions)
					Cascade(transaction, item, context);

			if (transaction.Count > 0)
				WithChild(transaction, entity);

		
        }


	}
}
		