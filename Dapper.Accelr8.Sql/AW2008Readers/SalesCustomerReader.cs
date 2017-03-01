
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
    public class SalesCustomerReader : EntityReader<int, SalesCustomer>
    {
        public SalesCustomerReader(
            SalesCustomerTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 3
		static IEntityReader<int , SalesSalesOrderHeader> _salesSalesOrderHeaderReader;
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesOrderHeader>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_Customer_CustomerID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders(IList<SalesCustomer> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesOrderHeader

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderHeader>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSalesOrderHeaders = typedChildren.Where(b => b.SalesSalesOrderHeader == r.Id).ToList();
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.SalesCustomer = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.Customer into class SalesCustomer
		/// </summary>
		/// <param name="results">SalesCustomer</param>
		/// <param name="row"></param>
        public override SalesCustomer LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesCustomer();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.PersonID = GetRowData<int?>(dataRow, "PersonID"); 
      		domain.StoreID = GetRowData<int?>(dataRow, "StoreID"); 
      		domain.TerritoryID = GetRowData<int?>(dataRow, "TerritoryID"); 
      		domain.AccountNumber = GetRowData<string>(dataRow, "AccountNumber"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesCustomer></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesCustomer> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesSalesOrderHeaderReader(), id, IdColumn, SetChildrenSalesSalesOrderHeaders);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesCustomer entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesSalesOrderHeaderReader(), entity.Id
				, SalesSalesOrderHeaderColumnNames.CustomerID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			QueryResultForChildrenOnly(new List<SalesCustomer>() { entity });
			entity.Loaded = false;
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesCustomer> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesSalesOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderHeaderColumnNames.CustomerID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
					
		}
    }
}
		