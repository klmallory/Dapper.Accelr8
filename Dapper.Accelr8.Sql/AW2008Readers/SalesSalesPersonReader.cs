
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
    public class SalesSalesPersonReader : EntityReader<int, SalesSalesPerson>
    {
        public SalesSalesPersonReader(
            SalesSalesPersonTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 4
		//Parent Count 2
		static IEntityReader<int , SalesStore> _salesStoreReader;
		protected static IEntityReader<int , SalesStore> GetSalesStoreReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesStore>>();
		}

		static IEntityReader<int , SalesSalesOrderHeader> _salesSalesOrderHeaderReader;
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesOrderHeader>>();
		}

		static IEntityReader<int , SalesSalesPersonQuotaHistory> _salesSalesPersonQuotaHistoryReader;
		protected static IEntityReader<int , SalesSalesPersonQuotaHistory> GetSalesSalesPersonQuotaHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesPersonQuotaHistory>>();
		}

		static IEntityReader<int , SalesSalesTerritoryHistory> _salesSalesTerritoryHistoryReader;
		protected static IEntityReader<int , SalesSalesTerritoryHistory> GetSalesSalesTerritoryHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesTerritoryHistory>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesStore on the parent on SalesStores.
		/// From foriegn key FK_Store_SalesPerson_SalesPersonID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesStores(IList<SalesSalesPerson> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesStore

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesStore>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesStores = typedChildren.Where(b => b.SalesStore == r.Id).ToList();
				r.SalesStores.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesPerson = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_SalesPerson_SalesPersonID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders(IList<SalesSalesPerson> results, IList<object> children)
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
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesPerson = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesPersonQuotaHistory on the parent on SalesSalesPersonQuotaHistories.
		/// From foriegn key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesPersonQuotaHistories(IList<SalesSalesPerson> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesPersonQuotaHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesPersonQuotaHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSalesPersonQuotaHistories = typedChildren.Where(b => b.SalesSalesPersonQuotaHistory == r.Id).ToList();
				r.SalesSalesPersonQuotaHistories.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesPerson = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesTerritoryHistory on the parent on SalesSalesTerritoryHistories.
		/// From foriegn key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesTerritoryHistories(IList<SalesSalesPerson> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesTerritoryHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesTerritoryHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSalesTerritoryHistories = typedChildren.Where(b => b.SalesSalesTerritoryHistory == r.Id).ToList();
				r.SalesSalesTerritoryHistories.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesPerson = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.SalesPerson into class SalesSalesPerson
		/// </summary>
		/// <param name="results">SalesSalesPerson</param>
		/// <param name="row"></param>
        public override SalesSalesPerson LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSalesPerson();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.TerritoryID = GetRowData<int?>(dataRow, "TerritoryID"); 
      		domain.SalesQuota = GetRowData<decimal?>(dataRow, "SalesQuota"); 
      		domain.Bonus = GetRowData<decimal>(dataRow, "Bonus"); 
      		domain.CommissionPct = GetRowData<decimal>(dataRow, "CommissionPct"); 
      		domain.SalesYTD = GetRowData<decimal>(dataRow, "SalesYTD"); 
      		domain.SalesLastYear = GetRowData<decimal>(dataRow, "SalesLastYear"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSalesPerson></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSalesPerson> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesStoreReader(), id, IdColumn, SetChildrenSalesStores);
			
			WithChildForParentId(GetSalesSalesOrderHeaderReader(), id, IdColumn, SetChildrenSalesSalesOrderHeaders);
			
			WithChildForParentId(GetSalesSalesPersonQuotaHistoryReader(), id, IdColumn, SetChildrenSalesSalesPersonQuotaHistories);
			
			WithChildForParentId(GetSalesSalesTerritoryHistoryReader(), id, IdColumn, SetChildrenSalesSalesTerritoryHistories);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesSalesPerson entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesStoreReader(), entity.Id
				, SalesStoreColumnNames.SalesPersonID.ToString()
				, SetChildrenSalesStores);

			WithChildForParentId(GetSalesSalesOrderHeaderReader(), entity.Id
				, SalesSalesOrderHeaderColumnNames.SalesPersonID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentId(GetSalesSalesPersonQuotaHistoryReader(), entity.Id
				, SalesSalesPersonQuotaHistoryColumnNames.BusinessEntityID.ToString()
				, SetChildrenSalesSalesPersonQuotaHistories);

			WithChildForParentId(GetSalesSalesTerritoryHistoryReader(), entity.Id
				, SalesSalesTerritoryHistoryColumnNames.BusinessEntityID.ToString()
				, SetChildrenSalesSalesTerritoryHistories);

			QueryResultForChildrenOnly(new List<SalesSalesPerson>() { entity });
			entity.Loaded = false;
			GetSalesStoreReader().SetAllChildrenForExisting(entity.SalesStores);
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
			GetSalesSalesPersonQuotaHistoryReader().SetAllChildrenForExisting(entity.SalesSalesPersonQuotaHistories);
			GetSalesSalesTerritoryHistoryReader().SetAllChildrenForExisting(entity.SalesSalesTerritoryHistories);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesPerson> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesStoreReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesStoreColumnNames.SalesPersonID.ToString()
				, SetChildrenSalesStores);

			WithChildForParentIds(GetSalesSalesOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderHeaderColumnNames.SalesPersonID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentIds(GetSalesSalesPersonQuotaHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesPersonQuotaHistoryColumnNames.BusinessEntityID.ToString()
				, SetChildrenSalesSalesPersonQuotaHistories);

			WithChildForParentIds(GetSalesSalesTerritoryHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesTerritoryHistoryColumnNames.BusinessEntityID.ToString()
				, SetChildrenSalesSalesTerritoryHistories);

					
			QueryResultForChildrenOnly(entities);

			GetSalesStoreReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesStores).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
			GetSalesSalesPersonQuotaHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesPersonQuotaHistories).ToList());
			GetSalesSalesTerritoryHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesTerritoryHistories).ToList());
					
		}
    }
}
		