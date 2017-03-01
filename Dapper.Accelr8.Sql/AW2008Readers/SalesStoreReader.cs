
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008Readers
{
    public class SalesStoreReader : EntityReader<int, SalesStore>
    {
        public SalesStoreReader(
            SalesStoreTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 2
		static IEntityReader<int , SalesCustomer> _salesCustomerReader;
		protected static IEntityReader<int , SalesCustomer> GetSalesCustomerReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesCustomer>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesCustomer on the parent on SalesCustomers.
		/// From foriegn key FK_Customer_Store_StoreID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCustomers(IList<SalesStore> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesCustomer

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCustomer>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesCustomers = typedChildren.Where(b => b.SalesCustomer == r.Id).ToList();
				r.SalesCustomers.ToList().ForEach(b => { b.Loaded = false; b.SalesStore = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.Store into class SalesStore
		/// </summary>
		/// <param name="results">SalesStore</param>
		/// <param name="row"></param>
        public override SalesStore LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesStore();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.SalesPersonID = GetRowData<int?>(dataRow, "SalesPersonID"); 
      		domain.Demographics = GetRowData<string>(dataRow, "Demographics"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesStore></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesStore> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesCustomerReader(), id, IdColumn, SetChildrenSalesCustomers);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesStore entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesCustomerReader(), entity.Id
				, SalesCustomerColumnNames.StoreID.ToString()
				, SetChildrenSalesCustomers);

			QueryResultForChildrenOnly(new List<SalesStore>() { entity });
			entity.Loaded = false;
			GetSalesCustomerReader().SetAllChildrenForExisting(entity.SalesCustomers);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesStore> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesCustomerReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesCustomerColumnNames.StoreID.ToString()
				, SetChildrenSalesCustomers);

					
			QueryResultForChildrenOnly(entities);

			GetSalesCustomerReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCustomers).ToList());
					
		}
    }
}
		