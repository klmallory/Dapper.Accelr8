

using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfo;
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
				r.UsersGroups = typedChildren.Where(b => b.UsersGroupsId == r.Id).ToList();
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
				r.WorkspaceGroups = typedChildren.Where(b => b.WorkspaceGroupId == r.Id).ToList();
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
				r.PrinterGroups = typedChildren.Where(b => b.PrinterGroupsId == r.Id).ToList();
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
				r.Clients = typedChildren.Where(b => b.ClientId == r.Id).ToList();
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
				r.TransactionGroups = typedChildren.Where(b => b.TransactionGroupId == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.Name = GetRowData<string>(dataRow, GroupColumnNames.Name.ToString()); 	
			domain.Description = GetRowData<string>(dataRow, GroupColumnNames.Description.ToString()); 	
			domain.IsDefault = GetRowData<bool?>(dataRow, GroupColumnNames.IsDefault.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, Group> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , UsersGroups>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , WorkspaceGroups>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , PrinterGroups>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Clients>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionGroups>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Group entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , UsersGroups>(), id, IdField, SetChildrenUsersGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , WorkspaceGroups>(), id, IdField, SetChildrenWorkspaceGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , PrinterGroups>(), id, IdField, SetChildrenPrinterGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Clients>(), id, IdField, SetChildrenClients);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionGroups>(), id, IdField, SetChildrenTransactionGroups);
			QueryResultForChildrenOnly(new List<Group>() { entity });

			_locator.Resolve<IEntityReader<int , UsersGroups>().SetAllChildrenForExisting(entity.UsersGroups);
			_locator.Resolve<IEntityReader<int , WorkspaceGroups>().SetAllChildrenForExisting(entity.WorkspaceGroups);
			_locator.Resolve<IEntityReader<int , PrinterGroups>().SetAllChildrenForExisting(entity.PrinterGroups);
			_locator.Resolve<IEntityReader<int , Clients>().SetAllChildrenForExisting(entity.Clients);
			_locator.Resolve<IEntityReader<int , TransactionGroups>().SetAllChildrenForExisting(entity.TransactionGroups);
				
		}

		public override void SetAllChildrenForExisting(IList<Group> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , UsersGroups>(), id, IdField, SetChildrenUsersGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , WorkspaceGroups>(), id, IdField, SetChildrenWorkspaceGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , PrinterGroups>(), id, IdField, SetChildrenPrinterGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Clients>(), id, IdField, SetChildrenClients);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionGroups>(), id, IdField, SetChildrenTransactionGroups);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, UsersGroups>().SetAllChildrenForExisting(entities.SelectMany(e => e.UsersGroups));
			_locator.Resolve<IEntityReader<int, WorkspaceGroups>().SetAllChildrenForExisting(entities.SelectMany(e => e.WorkspaceGroups));
			_locator.Resolve<IEntityReader<int, PrinterGroups>().SetAllChildrenForExisting(entities.SelectMany(e => e.PrinterGroups));
			_locator.Resolve<IEntityReader<int, Clients>().SetAllChildrenForExisting(entities.SelectMany(e => e.Clients));
			_locator.Resolve<IEntityReader<int, TransactionGroups>().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionGroups));
					
		}
    }
}
		