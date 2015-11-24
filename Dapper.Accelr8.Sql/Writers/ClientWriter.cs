
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
    public class ClientWriter : EntityWriter<int, Client>
    {
        public ClientWriter
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, Client entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(ClientColumnNames.ClientId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(ClientColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(ClientColumnNames.Description.ToString(), actionType, taskIndex, count), entity.Description);
			parms.Add(GetParamName(ClientColumnNames.IsActive.ToString(), actionType, taskIndex, count), entity.IsActive);
			parms.Add(GetParamName(ClientColumnNames.EmailAddress.ToString(), actionType, taskIndex, count), entity.EmailAddress);
			parms.Add(GetParamName(ClientColumnNames.Address1.ToString(), actionType, taskIndex, count), entity.Address1);
			parms.Add(GetParamName(ClientColumnNames.Address2.ToString(), actionType, taskIndex, count), entity.Address2);
			parms.Add(GetParamName(ClientColumnNames.City.ToString(), actionType, taskIndex, count), entity.City);
			parms.Add(GetParamName(ClientColumnNames.State.ToString(), actionType, taskIndex, count), entity.State);
			parms.Add(GetParamName(ClientColumnNames.Zip.ToString(), actionType, taskIndex, count), entity.Zip);
			parms.Add(GetParamName(ClientColumnNames.Country.ToString(), actionType, taskIndex, count), entity.Country);
			parms.Add(GetParamName(ClientColumnNames.Phone.ToString(), actionType, taskIndex, count), entity.Phone);
			parms.Add(GetParamName(ClientColumnNames.GroupId.ToString(), actionType, taskIndex, count), entity.GroupId);
			parms.Add(GetParamName(ClientColumnNames.OriginatingAgencyId.ToString(), actionType, taskIndex, count), entity.OriginatingAgencyId);
			parms.Add(GetParamName(ClientColumnNames.EndpointId.ToString(), actionType, taskIndex, count), entity.EndpointId);
			parms.Add(GetParamName(ClientColumnNames.ContactName.ToString(), actionType, taskIndex, count), entity.ContactName);
					
			return parms;
        }


		protected override void CascadeRelations(Client entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Transactions_Clients
			var transaction = GetTransactionWriter();
			if (_cascades.Contains(ClientCascadeNames.transaction.ToString()))
				foreach (var item in entity.Transactions)
					Cascade(transaction, item, context);

			if (transaction.Count > 0)
				WithChild(transaction, entity);

		
        }


	}
}
		