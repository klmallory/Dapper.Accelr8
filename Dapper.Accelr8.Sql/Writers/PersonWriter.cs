
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
    public class PersonWriter : EntityWriter<int, Person>
    {
        public PersonWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, Person entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(PersonColumnNames.PersonId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(PersonColumnNames.LastName.ToString(), actionType, taskIndex, count), entity.LastName);
			parms.Add(GetParamName(PersonColumnNames.FirstName.ToString(), actionType, taskIndex, count), entity.FirstName);
			parms.Add(GetParamName(PersonColumnNames.MatcherPersonId.ToString(), actionType, taskIndex, count), entity.MatcherPersonId);
					
			return parms;
        }


		protected override void CascadeRelations(Person entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Transactions_People
			var transaction = GetTransactionWriter();
			if (_cascades.Contains(PersonCascadeNames.transaction.ToString()))
				foreach (var item in entity.Transactions)
					Cascade(transaction, item, context);

			if (transaction.Count > 0)
				WithChild(transaction, entity);

		
        }


	}
}
		