

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
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.Readers
{
    public class GroupReader : EntityReader<int, Group>
    {
        public GroupReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 5
		//Parent Count 0
		static IEntityReader<int , UsersGroup> _usersGroupReader;
		static IEntityReader<int , UsersGroup> GetUsersGroupReader()
		{
			if (_usersGroupReader == null)
				_usersGroupReader = _locator.Resolve<IEntityReader<int , UsersGroup>>();

			return _usersGroupReader;
		}

		static IEntityReader<int , WorkspaceGroup> _workspaceGroupReader;
		static IEntityReader<int , WorkspaceGroup> GetWorkspaceGroupReader()
		{
			if (_workspaceGroupReader == null)
				_workspaceGroupReader = _locator.Resolve<IEntityReader<int , WorkspaceGroup>>();

			return _workspaceGroupReader;
		}

		static IEntityReader<int , PrinterGroup> _printerGroupReader;
		static IEntityReader<int , PrinterGroup> GetPrinterGroupReader()
		{
			if (_printerGroupReader == null)
				_printerGroupReader = _locator.Resolve<IEntityReader<int , PrinterGroup>>();

			return _printerGroupReader;
		}

		static IEntityReader<int , Client> _clientReader;
		static IEntityReader<int , Client> GetClientReader()
		{
			if (_clientReader == null)
				_clientReader = _locator.Resolve<IEntityReader<int , Client>>();

			return _clientReader;
		}

		static IEntityReader<int , TransactionGroup> _transactionGroupReader;
		static IEntityReader<int , TransactionGroup> GetTransactionGroupReader()
		{
			if (_transactionGroupReader == null)
				_transactionGroupReader = _locator.Resolve<IEntityReader<int , TransactionGroup>>();

			return _transactionGroupReader;
		}

		
		/// <summary>
		/// Sets the children of type UsersGroup on the parent on UsersGroups.
		/// From foriegn key FK_UsersGroups_Groups
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenUsersGroups(IList<Group> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: UsersGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<UsersGroup>();

			foreach (var r in results)
			{
				r.UsersGroups = typedChildren.Where(b => b.GroupId == r.Id).ToList();
				r.UsersGroups.ToList().ForEach(b => b.Group = r);
			}
		}

		/// <summary>
		/// Sets the children of type WorkspaceGroup on the parent on WorkspaceGroups.
		/// From foriegn key FK_WorkspaceGroups_Groups
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenWorkspaceGroups(IList<Group> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: WorkspaceGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<WorkspaceGroup>();

			foreach (var r in results)
			{
				r.WorkspaceGroups = typedChildren.Where(b => b.GroupId == r.Id).ToList();
				r.WorkspaceGroups.ToList().ForEach(b => b.Group = r);
			}
		}

		/// <summary>
		/// Sets the children of type PrinterGroup on the parent on PrinterGroups.
		/// From foriegn key FK_PrinterGroups_Groups
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenPrinterGroups(IList<Group> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PrinterGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PrinterGroup>();

			foreach (var r in results)
			{
				r.PrinterGroups = typedChildren.Where(b => b.GroupId == r.Id).ToList();
				r.PrinterGroups.ToList().ForEach(b => b.Group = r);
			}
		}

		/// <summary>
		/// Sets the children of type Client on the parent on Clients.
		/// From foriegn key FK_Clients_Groups
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenClients(IList<Group> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Client

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Client>();

			foreach (var r in results)
			{
				r.Clients = typedChildren.Where(b => b.GroupId == r.Id).ToList();
				r.Clients.ToList().ForEach(b => b.Group = r);
			}
		}

		/// <summary>
		/// Sets the children of type TransactionGroup on the parent on TransactionGroups.
		/// From foriegn key FK_TransactionGroups_Groups
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactionGroups(IList<Group> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: TransactionGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<TransactionGroup>();

			foreach (var r in results)
			{
				r.TransactionGroups = typedChildren.Where(b => b.GroupId == r.Id).ToList();
				r.TransactionGroups.ToList().ForEach(b => b.Group = r);
			}
		}

			/// <summary>
		/// Loads the table Groups into class Group
		/// </summary>
		/// <param name="results">Group</param>
		/// <param name="row"></param>
        public override Group LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Group();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.Name = GetRowData<string>(dataRow, GroupColumnNames.Name.ToString()); 	
			domain.Description = GetRowData<string>(dataRow, GroupColumnNames.Description.ToString()); 	
			domain.IsDefault = GetRowData<bool?>(dataRow, GroupColumnNames.IsDefault.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Group></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Group> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetUsersGroupReader(), id, IdColumn, SetChildrenUsersGroups);
			
			WithChildForParentId(GetWorkspaceGroupReader(), id, IdColumn, SetChildrenWorkspaceGroups);
			
			WithChildForParentId(GetPrinterGroupReader(), id, IdColumn, SetChildrenPrinterGroups);
			
			WithChildForParentId(GetClientReader(), id, IdColumn, SetChildrenClients);
			
			WithChildForParentId(GetTransactionGroupReader(), id, IdColumn, SetChildrenTransactionGroups);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Group entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetUsersGroupReader(), entity.Id
				, UsersGroupColumnNames.GroupId.ToString()
				, SetChildrenUsersGroups);

			WithChildForParentId(GetWorkspaceGroupReader(), entity.Id
				, WorkspaceGroupColumnNames.GroupId.ToString()
				, SetChildrenWorkspaceGroups);

			WithChildForParentId(GetPrinterGroupReader(), entity.Id
				, PrinterGroupColumnNames.GroupId.ToString()
				, SetChildrenPrinterGroups);

			WithChildForParentId(GetClientReader(), entity.Id
				, ClientColumnNames.GroupId.ToString()
				, SetChildrenClients);

			WithChildForParentId(GetTransactionGroupReader(), entity.Id
				, TransactionGroupColumnNames.GroupId.ToString()
				, SetChildrenTransactionGroups);

			QueryResultForChildrenOnly(new List<Group>() { entity });

			GetUsersGroupReader().SetAllChildrenForExisting(entity.UsersGroups);
			GetWorkspaceGroupReader().SetAllChildrenForExisting(entity.WorkspaceGroups);
			GetPrinterGroupReader().SetAllChildrenForExisting(entity.PrinterGroups);
			GetClientReader().SetAllChildrenForExisting(entity.Clients);
			GetTransactionGroupReader().SetAllChildrenForExisting(entity.TransactionGroups);
				
		}

		public override void SetAllChildrenForExisting(IList<Group> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetUsersGroupReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), UsersGroupColumnNames.GroupId.ToString()
				, SetChildrenUsersGroups);

			WithChildForParentIds(GetWorkspaceGroupReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), WorkspaceGroupColumnNames.GroupId.ToString()
				, SetChildrenWorkspaceGroups);

			WithChildForParentIds(GetPrinterGroupReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), PrinterGroupColumnNames.GroupId.ToString()
				, SetChildrenPrinterGroups);

			WithChildForParentIds(GetClientReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), ClientColumnNames.GroupId.ToString()
				, SetChildrenClients);

			WithChildForParentIds(GetTransactionGroupReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), TransactionGroupColumnNames.GroupId.ToString()
				, SetChildrenTransactionGroups);

					
			QueryResultForChildrenOnly(entities);

			GetUsersGroupReader().SetAllChildrenForExisting(entities.SelectMany(e => e.UsersGroups).ToList());
			GetWorkspaceGroupReader().SetAllChildrenForExisting(entities.SelectMany(e => e.WorkspaceGroups).ToList());
			GetPrinterGroupReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PrinterGroups).ToList());
			GetClientReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Clients).ToList());
			GetTransactionGroupReader().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionGroups).ToList());
					
		}
    }
}
		