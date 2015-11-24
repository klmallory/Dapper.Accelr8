

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
    public class AgencySpecReader : EntityReader<int, AgencySpec>
    {
        public AgencySpecReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 2
		//Parent Count 0
		static IEntityReader<int , Agency> _agencyReader;
		static IEntityReader<int , Agency> GetAgencyReader()
		{
			if (_agencyReader == null)
				_agencyReader = _locator.Resolve<IEntityReader<int , Agency>>();

			return _agencyReader;
		}

		static IEntityReader<int , Transaction> _transactionReader;
		static IEntityReader<int , Transaction> GetTransactionReader()
		{
			if (_transactionReader == null)
				_transactionReader = _locator.Resolve<IEntityReader<int , Transaction>>();

			return _transactionReader;
		}

		
		/// <summary>
		/// Sets the children of type Agency on the parent on Agencies.
		/// From foriegn key FK_Agencies_AgencySpecs_AgencySpecId
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenAgencies(IList<AgencySpec> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Agency

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Agency>();

			foreach (var r in results)
			{
				r.Agencies = typedChildren.Where(b => b.AgencySpecId == r.Id).ToList();
				r.Agencies.ToList().ForEach(b => b.AgencySpec = r);
			}
		}

		/// <summary>
		/// Sets the children of type Transaction on the parent on Transactions.
		/// From foriegn key FK_Transactions_AgencySpecs
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactions(IList<AgencySpec> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Transaction

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Transaction>();

			foreach (var r in results)
			{
				r.Transactions = typedChildren.Where(b => b.AgencySpecId == r.Id).ToList();
				r.Transactions.ToList().ForEach(b => b.AgencySpec = r);
			}
		}

			/// <summary>
		/// Loads the table AgencySpecs into class AgencySpec
		/// </summary>
		/// <param name="results">AgencySpec</param>
		/// <param name="row"></param>
        public override AgencySpec LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new AgencySpec();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.SpecKey = GetRowData<string>(dataRow, AgencySpecColumnNames.SpecKey.ToString()); 	
			domain.Name = GetRowData<string>(dataRow, AgencySpecColumnNames.Name.ToString()); 	
			domain.FileDefinitionPath = GetRowData<string>(dataRow, AgencySpecColumnNames.FileDefinitionPath.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, AgencySpec></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, AgencySpec> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetAgencyReader(), id, IdColumn, SetChildrenAgencies);
			
			WithChildForParentId(GetTransactionReader(), id, IdColumn, SetChildrenTransactions);
			
            return this;
        }

        public override void SetAllChildrenForExisting(AgencySpec entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetAgencyReader(), entity.Id
				, AgencyColumnNames.AgencySpecId.ToString()
				, SetChildrenAgencies);

			WithChildForParentId(GetTransactionReader(), entity.Id
				, TransactionColumnNames.AgencySpecId.ToString()
				, SetChildrenTransactions);

			QueryResultForChildrenOnly(new List<AgencySpec>() { entity });

			GetAgencyReader().SetAllChildrenForExisting(entity.Agencies);
			GetTransactionReader().SetAllChildrenForExisting(entity.Transactions);
				
		}

		public override void SetAllChildrenForExisting(IList<AgencySpec> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetAgencyReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), AgencyColumnNames.AgencySpecId.ToString()
				, SetChildrenAgencies);

			WithChildForParentIds(GetTransactionReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), TransactionColumnNames.AgencySpecId.ToString()
				, SetChildrenTransactions);

					
			QueryResultForChildrenOnly(entities);

			GetAgencyReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Agencies).ToList());
			GetTransactionReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Transactions).ToList());
					
		}
    }
}
		