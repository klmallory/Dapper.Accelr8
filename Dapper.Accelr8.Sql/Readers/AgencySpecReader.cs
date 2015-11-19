

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
				r.Agencies = typedChildren.Where(b => b.AgencyId == r.Id).ToList();
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
				r.Transactions = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.SpecKey = GetRowData<string>(dataRow, AgencySpecColumnNames.SpecKey.ToString()); 	
			domain.Name = GetRowData<string>(dataRow, AgencySpecColumnNames.Name.ToString()); 	
			domain.FileDefinitionPath = GetRowData<string>(dataRow, AgencySpecColumnNames.FileDefinitionPath.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, AgencySpec> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Agencies>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(AgencySpec entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Agencies>(), id, IdField, SetChildrenAgencies);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildrenTransactions);
			QueryResultForChildrenOnly(new List<AgencySpec>() { entity });

			_locator.Resolve<IEntityReader<int , Agencies>().SetAllChildrenForExisting(entity.Agencies);
			_locator.Resolve<IEntityReader<int , Transactions>().SetAllChildrenForExisting(entity.Transactions);
				
		}

		public override void SetAllChildrenForExisting(IList<AgencySpec> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , Agencies>(), id, IdField, SetChildrenAgencies);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildrenTransactions);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, Agencies>().SetAllChildrenForExisting(entities.SelectMany(e => e.Agencies));
			_locator.Resolve<IEntityReader<int, Transactions>().SetAllChildrenForExisting(entities.SelectMany(e => e.Transactions));
					
		}
    }
}
		