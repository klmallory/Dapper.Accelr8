

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
    public class PersonReader : EntityReader<int, Person>
    {
        public PersonReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , Transaction> _transactionReader;
		static IEntityReader<int , Transaction> GetTransactionReader()
		{
			if (_transactionReader == null)
				_transactionReader = _locator.Resolve<IEntityReader<int , Transaction>>();

			return _transactionReader;
		}

		
		/// <summary>
		/// Sets the children of type Transaction on the parent on Transactions.
		/// From foriegn key FK_Transactions_People
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactions(IList<Person> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Transaction

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Transaction>();

			foreach (var r in results)
			{
				r.Transactions = typedChildren.Where(b => b.PersonId == r.Id).ToList();
				r.Transactions.ToList().ForEach(b => b.Person = r);
			}
		}

			/// <summary>
		/// Loads the table People into class Person
		/// </summary>
		/// <param name="results">Person</param>
		/// <param name="row"></param>
        public override Person LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Person();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.LastName = GetRowData<string>(dataRow, PersonColumnNames.LastName.ToString()); 	
			domain.FirstName = GetRowData<string>(dataRow, PersonColumnNames.FirstName.ToString()); 	
			domain.MatcherPersonId = GetRowData<int?>(dataRow, PersonColumnNames.MatcherPersonId.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Person></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Person> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetTransactionReader(), id, IdColumn, SetChildrenTransactions);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Person entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetTransactionReader(), entity.Id
				, TransactionColumnNames.PersonId.ToString()
				, SetChildrenTransactions);

			QueryResultForChildrenOnly(new List<Person>() { entity });

			GetTransactionReader().SetAllChildrenForExisting(entity.Transactions);
				
		}

		public override void SetAllChildrenForExisting(IList<Person> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetTransactionReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), TransactionColumnNames.PersonId.ToString()
				, SetChildrenTransactions);

					
			QueryResultForChildrenOnly(entities);

			GetTransactionReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Transactions).ToList());
					
		}
    }
}
		