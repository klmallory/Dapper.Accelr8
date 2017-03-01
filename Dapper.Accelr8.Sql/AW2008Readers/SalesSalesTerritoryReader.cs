
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
    public class SalesSalesTerritoryReader : EntityReader<int, SalesSalesTerritory>
    {
        public SalesSalesTerritoryReader(
            SalesSalesTerritoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 5
		//Parent Count 1
		static IEntityReader<int , PersonStateProvince> _personStateProvinceReader;
		protected static IEntityReader<int , PersonStateProvince> GetPersonStateProvinceReader()
		{
			return _locator.Resolve<IEntityReader<int , PersonStateProvince>>();
		}

		static IEntityReader<int , SalesCustomer> _salesCustomerReader;
		protected static IEntityReader<int , SalesCustomer> GetSalesCustomerReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesCustomer>>();
		}

		static IEntityReader<int , SalesSalesOrderHeader> _salesSalesOrderHeaderReader;
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesOrderHeader>>();
		}

		static IEntityReader<int , SalesSalesPerson> _salesSalesPersonReader;
		protected static IEntityReader<int , SalesSalesPerson> GetSalesSalesPersonReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesPerson>>();
		}

		static IEntityReader<int , SalesSalesTerritoryHistory> _salesSalesTerritoryHistoryReader;
		protected static IEntityReader<int , SalesSalesTerritoryHistory> GetSalesSalesTerritoryHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesTerritoryHistory>>();
		}

		
		/// <summary>
		/// Sets the children of type PersonStateProvince on the parent on PersonStateProvinces.
		/// From foriegn key FK_StateProvince_SalesTerritory_TerritoryID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonStateProvinces(IList<SalesSalesTerritory> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonStateProvince

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonStateProvince>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PersonStateProvinces = typedChildren.Where(b => b.PersonStateProvince == r.Id).ToList();
				r.PersonStateProvinces.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesTerritory = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesCustomer on the parent on SalesCustomers.
		/// From foriegn key FK_Customer_SalesTerritory_TerritoryID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCustomers(IList<SalesSalesTerritory> results, IList<object> children)
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
				r.SalesCustomers.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesTerritory = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_SalesTerritory_TerritoryID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders(IList<SalesSalesTerritory> results, IList<object> children)
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
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesTerritory = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesPerson on the parent on SalesSalesPeople.
		/// From foriegn key FK_SalesPerson_SalesTerritory_TerritoryID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesPeople(IList<SalesSalesTerritory> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesPerson

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesPerson>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSalesPeople = typedChildren.Where(b => b.SalesSalesPerson == r.Id).ToList();
				r.SalesSalesPeople.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesTerritory = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesTerritoryHistory on the parent on SalesSalesTerritoryHistories.
		/// From foriegn key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesTerritoryHistories(IList<SalesSalesTerritory> results, IList<object> children)
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
				r.SalesSalesTerritoryHistories.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesTerritory = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.SalesTerritory into class SalesSalesTerritory
		/// </summary>
		/// <param name="results">SalesSalesTerritory</param>
		/// <param name="row"></param>
        public override SalesSalesTerritory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSalesTerritory();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.CountryRegionCode = GetRowData<string>(dataRow, "CountryRegionCode"); 
      		domain.Group = GetRowData<string>(dataRow, "Group"); 
      		domain.SalesYTD = GetRowData<decimal>(dataRow, "SalesYTD"); 
      		domain.SalesLastYear = GetRowData<decimal>(dataRow, "SalesLastYear"); 
      		domain.CostYTD = GetRowData<decimal>(dataRow, "CostYTD"); 
      		domain.CostLastYear = GetRowData<decimal>(dataRow, "CostLastYear"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSalesTerritory></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSalesTerritory> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPersonStateProvinceReader(), id, IdColumn, SetChildrenPersonStateProvinces);
			
			WithChildForParentId(GetSalesCustomerReader(), id, IdColumn, SetChildrenSalesCustomers);
			
			WithChildForParentId(GetSalesSalesOrderHeaderReader(), id, IdColumn, SetChildrenSalesSalesOrderHeaders);
			
			WithChildForParentId(GetSalesSalesPersonReader(), id, IdColumn, SetChildrenSalesSalesPeople);
			
			WithChildForParentId(GetSalesSalesTerritoryHistoryReader(), id, IdColumn, SetChildrenSalesSalesTerritoryHistories);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesSalesTerritory entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPersonStateProvinceReader(), entity.Id
				, PersonStateProvinceColumnNames.TerritoryID.ToString()
				, SetChildrenPersonStateProvinces);

			WithChildForParentId(GetSalesCustomerReader(), entity.Id
				, SalesCustomerColumnNames.TerritoryID.ToString()
				, SetChildrenSalesCustomers);

			WithChildForParentId(GetSalesSalesOrderHeaderReader(), entity.Id
				, SalesSalesOrderHeaderColumnNames.TerritoryID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentId(GetSalesSalesPersonReader(), entity.Id
				, SalesSalesPersonColumnNames.TerritoryID.ToString()
				, SetChildrenSalesSalesPeople);

			WithChildForParentId(GetSalesSalesTerritoryHistoryReader(), entity.Id
				, SalesSalesTerritoryHistoryColumnNames.TerritoryID.ToString()
				, SetChildrenSalesSalesTerritoryHistories);

			QueryResultForChildrenOnly(new List<SalesSalesTerritory>() { entity });
			entity.Loaded = false;
			GetPersonStateProvinceReader().SetAllChildrenForExisting(entity.PersonStateProvinces);
			GetSalesCustomerReader().SetAllChildrenForExisting(entity.SalesCustomers);
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
			GetSalesSalesPersonReader().SetAllChildrenForExisting(entity.SalesSalesPeople);
			GetSalesSalesTerritoryHistoryReader().SetAllChildrenForExisting(entity.SalesSalesTerritoryHistories);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesTerritory> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPersonStateProvinceReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PersonStateProvinceColumnNames.TerritoryID.ToString()
				, SetChildrenPersonStateProvinces);

			WithChildForParentIds(GetSalesCustomerReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesCustomerColumnNames.TerritoryID.ToString()
				, SetChildrenSalesCustomers);

			WithChildForParentIds(GetSalesSalesOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderHeaderColumnNames.TerritoryID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentIds(GetSalesSalesPersonReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesPersonColumnNames.TerritoryID.ToString()
				, SetChildrenSalesSalesPeople);

			WithChildForParentIds(GetSalesSalesTerritoryHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesTerritoryHistoryColumnNames.TerritoryID.ToString()
				, SetChildrenSalesSalesTerritoryHistories);

					
			QueryResultForChildrenOnly(entities);

			GetPersonStateProvinceReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonStateProvinces).ToList());
			GetSalesCustomerReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCustomers).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
			GetSalesSalesPersonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesPeople).ToList());
			GetSalesSalesTerritoryHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesTerritoryHistories).ToList());
					
		}
    }
}
		