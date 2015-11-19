

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
    public class UserReader : EntityReader<int, User>
    {
        public UserReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 3
		//Parent Count 1

		/// <summary>
		/// Sets the children of type License on the parent on Licenses.
		/// From foriegn key FK_Licenses_Users
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenLicenses(IList<User> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: License

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<License>();

			foreach (var r in results)
			{
				r.Licenses = typedChildren.Where(b => b.LicenseId == r.Id).ToList();
				r.Licenses.ToList().ForEach(b => b.User = r);
			}
		}

		/// <summary>
		/// Sets the children of type UsersGroup on the parent on UsersGroups.
		/// From foriegn key FK_UsersGroups_Users
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenUsersGroups(IList<User> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: UsersGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<UsersGroup>();

			foreach (var r in results)
			{
				r.UsersGroups = typedChildren.Where(b => b.UsersGroupsId == r.Id).ToList();
				r.UsersGroups.ToList().ForEach(b => b.User = r);
			}
		}

		/// <summary>
		/// Sets the children of type Transaction on the parent on Transactions.
		/// From foriegn key FK_Transactions_Users
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactions(IList<User> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Transaction

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Transaction>();

			foreach (var r in results)
			{
				r.Transactions = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
				r.Transactions.ToList().ForEach(b => b.User = r);
			}
		}

			/// <summary>
		/// Loads the table Users into class User
		/// </summary>
		/// <param name="results">User</param>
		/// <param name="row"></param>
        public override User LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new User();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.Username = GetRowData<string>(dataRow, UserColumnNames.Username.ToString()); 	
			domain.ApplicationId = GetRowData<int?>(dataRow, UserColumnNames.ApplicationId.ToString()); 	
			domain.DisplayLanguage = GetRowData<string>(dataRow, UserColumnNames.DisplayLanguage.ToString()); 	
			domain.IsDisabled = GetRowData<bool?>(dataRow, UserColumnNames.IsDisabled.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, User> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Licenses>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , UsersGroups>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(User entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Licenses>(), id, IdField, SetChildrenLicenses);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , UsersGroups>(), id, IdField, SetChildrenUsersGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildrenTransactions);
			QueryResultForChildrenOnly(new List<User>() { entity });

			_locator.Resolve<IEntityReader<int , Licenses>().SetAllChildrenForExisting(entity.Licenses);
			_locator.Resolve<IEntityReader<int , UsersGroups>().SetAllChildrenForExisting(entity.UsersGroups);
			_locator.Resolve<IEntityReader<int , Transactions>().SetAllChildrenForExisting(entity.Transactions);
				
		}

		public override void SetAllChildrenForExisting(IList<User> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Licenses>(), id, IdField, SetChildrenLicenses);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , UsersGroups>(), id, IdField, SetChildrenUsersGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildrenTransactions);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, Licenses>().SetAllChildrenForExisting(entities.SelectMany(e => e.Licenses));
			_locator.Resolve<IEntityReader<int, UsersGroups>().SetAllChildrenForExisting(entities.SelectMany(e => e.UsersGroups));
			_locator.Resolve<IEntityReader<int, Transactions>().SetAllChildrenForExisting(entities.SelectMany(e => e.Transactions));
					
		}
    }
}
		