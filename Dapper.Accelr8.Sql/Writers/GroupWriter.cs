
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
    public class GroupWriter : EntityWriter<int, Group>
    {
        public GroupWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , UsersGroup> GetUsersGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , UsersGroup>>(); }
		static IEntityWriter<int , WorkspaceGroup> GetWorkspaceGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , WorkspaceGroup>>(); }
		static IEntityWriter<int , PrinterGroup> GetPrinterGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , PrinterGroup>>(); }
		static IEntityWriter<int , Client> GetClientWriter()
		{ return _locator.Resolve<IEntityWriter<int , Client>>(); }
		static IEntityWriter<int , TransactionGroup> GetTransactionGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , TransactionGroup>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Group entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(GroupColumnNames.GroupId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(GroupColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(GroupColumnNames.Description.ToString(), actionType, taskIndex, count), entity.Description);
			parms.Add(GetParamName(GroupColumnNames.IsDefault.ToString(), actionType, taskIndex, count), entity.IsDefault);
					
			return parms;
        }


		protected override void CascadeRelations(Group entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_UsersGroups_Groups
			var usersGroup = GetUsersGroupWriter();
			if (_cascades.Contains(GroupCascadeNames.usersgroup.ToString()))
				foreach (var item in entity.UsersGroups)
					Cascade(usersGroup, item, context);

			if (usersGroup.Count > 0)
				WithChild(usersGroup, entity);

			//From Foreign Key FK_WorkspaceGroups_Groups
			var workspaceGroup = GetWorkspaceGroupWriter();
			if (_cascades.Contains(GroupCascadeNames.workspacegroup.ToString()))
				foreach (var item in entity.WorkspaceGroups)
					Cascade(workspaceGroup, item, context);

			if (workspaceGroup.Count > 0)
				WithChild(workspaceGroup, entity);

			//From Foreign Key FK_PrinterGroups_Groups
			var printerGroup = GetPrinterGroupWriter();
			if (_cascades.Contains(GroupCascadeNames.printergroup.ToString()))
				foreach (var item in entity.PrinterGroups)
					Cascade(printerGroup, item, context);

			if (printerGroup.Count > 0)
				WithChild(printerGroup, entity);

			//From Foreign Key FK_Clients_Groups
			var client = GetClientWriter();
			if (_cascades.Contains(GroupCascadeNames.client.ToString()))
				foreach (var item in entity.Clients)
					Cascade(client, item, context);

			if (client.Count > 0)
				WithChild(client, entity);

			//From Foreign Key FK_TransactionGroups_Groups
			var transactionGroup = GetTransactionGroupWriter();
			if (_cascades.Contains(GroupCascadeNames.transactiongroup.ToString()))
				foreach (var item in entity.TransactionGroups)
					Cascade(transactionGroup, item, context);

			if (transactionGroup.Count > 0)
				WithChild(transactionGroup, entity);

		
        }


	}
}
		