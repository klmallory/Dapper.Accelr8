

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
    public class ClientReader : EntityReader<int, Client>
    {
        public ClientReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 1
		//Parent Count 2

		/// <summary>
		/// Sets the children of type Transaction on the parent on Transactions.
		/// From foriegn key FK_Transactions_Clients
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactions(IList<Client> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Transaction

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Transaction>();

			foreach (var r in results)
			{
				r.Transactions = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
				r.Transactions.ToList().ForEach(b => b.Client = r);
			}
		}

			/// <summary>
		/// Loads the table Clients into class Client
		/// </summary>
		/// <param name="results">Client</param>
		/// <param name="row"></param>
        public override Client LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Client();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.Name = GetRowData<string>(dataRow, ClientColumnNames.Name.ToString()); 	
			domain.Description = GetRowData<string>(dataRow, ClientColumnNames.Description.ToString()); 	
			domain.IsActive = GetRowData<bool>(dataRow, ClientColumnNames.IsActive.ToString()); 	
			domain.EmailAddress = GetRowData<string>(dataRow, ClientColumnNames.EmailAddress.ToString()); 	
			domain.Address1 = GetRowData<string>(dataRow, ClientColumnNames.Address1.ToString()); 	
			domain.Address2 = GetRowData<string>(dataRow, ClientColumnNames.Address2.ToString()); 	
			domain.City = GetRowData<string>(dataRow, ClientColumnNames.City.ToString()); 	
			domain.State = GetRowData<string>(dataRow, ClientColumnNames.State.ToString()); 	
			domain.Zip = GetRowData<string>(dataRow, ClientColumnNames.Zip.ToString()); 	
			domain.Country = GetRowData<string>(dataRow, ClientColumnNames.Country.ToString()); 	
			domain.Phone = GetRowData<string>(dataRow, ClientColumnNames.Phone.ToString()); 	
			domain.GroupId = GetRowData<int?>(dataRow, ClientColumnNames.GroupId.ToString()); 	
			domain.OriginatingAgencyId = GetRowData<string>(dataRow, ClientColumnNames.OriginatingAgencyId.ToString()); 	
			domain.EndpointId = GetRowData<int?>(dataRow, ClientColumnNames.EndpointId.ToString()); 	
			domain.ContactName = GetRowData<string>(dataRow, ClientColumnNames.ContactName.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, Client> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Client entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildrenTransactions);
			QueryResultForChildrenOnly(new List<Client>() { entity });

			_locator.Resolve<IEntityReader<int , Transactions>().SetAllChildrenForExisting(entity.Transactions);
				
		}

		public override void SetAllChildrenForExisting(IList<Client> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildrenTransactions);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, Transactions>().SetAllChildrenForExisting(entities.SelectMany(e => e.Transactions));
					
		}
    }
}
		