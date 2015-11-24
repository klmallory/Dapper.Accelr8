
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
    public class AgencySpecWriter : EntityWriter<int, AgencySpec>
    {
        public AgencySpecWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , Agency> GetAgencyWriter()
		{ return _locator.Resolve<IEntityWriter<int , Agency>>(); }
		static IEntityWriter<int , Transaction> GetTransactionWriter()
		{ return _locator.Resolve<IEntityWriter<int , Transaction>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, AgencySpec entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(AgencySpecColumnNames.AgencySpecId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(AgencySpecColumnNames.SpecKey.ToString(), actionType, taskIndex, count), entity.SpecKey);
			parms.Add(GetParamName(AgencySpecColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(AgencySpecColumnNames.FileDefinitionPath.ToString(), actionType, taskIndex, count), entity.FileDefinitionPath);
					
			return parms;
        }


		protected override void CascadeRelations(AgencySpec entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Agencies_AgencySpecs_AgencySpecId
			var agency = GetAgencyWriter();
			if (_cascades.Contains(AgencySpecCascadeNames.agency.ToString()))
				foreach (var item in entity.Agencies)
					Cascade(agency, item, context);

			if (agency.Count > 0)
				WithChild(agency, entity);

			//From Foreign Key FK_Transactions_AgencySpecs
			var transaction = GetTransactionWriter();
			if (_cascades.Contains(AgencySpecCascadeNames.transaction.ToString()))
				foreach (var item in entity.Transactions)
					Cascade(transaction, item, context);

			if (transaction.Count > 0)
				WithChild(transaction, entity);

		
        }


	}
}
		