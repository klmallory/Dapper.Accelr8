
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
    public class UserWriter : EntityWriter<int, User>
    {
        public UserWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , License> GetLicenseWriter()
		{ return _locator.Resolve<IEntityWriter<int , License>>(); }
		static IEntityWriter<int , UsersGroup> GetUsersGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , UsersGroup>>(); }
		static IEntityWriter<int , Transaction> GetTransactionWriter()
		{ return _locator.Resolve<IEntityWriter<int , Transaction>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, User entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(UserColumnNames.UserId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(UserColumnNames.Username.ToString(), actionType, taskIndex, count), entity.Username);
			parms.Add(GetParamName(UserColumnNames.ApplicationId.ToString(), actionType, taskIndex, count), entity.ApplicationId);
			parms.Add(GetParamName(UserColumnNames.DisplayLanguage.ToString(), actionType, taskIndex, count), entity.DisplayLanguage);
			parms.Add(GetParamName(UserColumnNames.IsDisabled.ToString(), actionType, taskIndex, count), entity.IsDisabled);
					
			return parms;
        }


		protected override void CascadeRelations(User entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Licenses_Users
			var license = GetLicenseWriter();
			if (_cascades.Contains(UserCascadeNames.license.ToString()))
				foreach (var item in entity.Licenses)
					Cascade(license, item, context);

			if (license.Count > 0)
				WithChild(license, entity);

			//From Foreign Key FK_UsersGroups_Users
			var usersGroup = GetUsersGroupWriter();
			if (_cascades.Contains(UserCascadeNames.usersgroup.ToString()))
				foreach (var item in entity.UsersGroups)
					Cascade(usersGroup, item, context);

			if (usersGroup.Count > 0)
				WithChild(usersGroup, entity);

			//From Foreign Key FK_Transactions_Users
			var transaction = GetTransactionWriter();
			if (_cascades.Contains(UserCascadeNames.transaction.ToString()))
				foreach (var item in entity.Transactions)
					Cascade(transaction, item, context);

			if (transaction.Count > 0)
				WithChild(transaction, entity);

		
        }


	}
}
		