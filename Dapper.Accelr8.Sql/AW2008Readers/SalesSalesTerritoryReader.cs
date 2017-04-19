
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
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 5
		//Parent Count 1
				//Is CompoundKey False
		protected static IEntityReader<int , SalesCustomer> GetSalesCustomerReader()
		{
			return s_loc8r.GetReader<int , SalesCustomer>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return s_loc8r.GetReader<int , SalesSalesOrderHeader>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesSalesPerson> GetSalesSalesPersonReader()
		{
			return s_loc8r.GetReader<int , SalesSalesPerson>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesSalesTerritoryHistory> GetSalesSalesTerritoryHistoryReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesSalesTerritoryHistory>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , PersonStateProvince> GetPersonStateProvinceReader()
		{
			return s_loc8r.GetReader<int , PersonStateProvince>();
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
				

				r.SalesCustomers = typedChildren.Where(b =>  b.TerritoryID == r.Id ).ToList();
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
				

				r.SalesSalesOrderHeaders = typedChildren.Where(b =>  b.TerritoryID == r.Id ).ToList();
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
				

				r.SalesSalesPeople = typedChildren.Where(b =>  b.TerritoryID == r.Id ).ToList();
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
			//Child Id Type: CompoundKey
			//Child Type: SalesSalesTerritoryHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesTerritoryHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesTerritoryHistories = typedChildren.Where(b =>  b.TerritoryID == r.Id ).ToList();
				r.SalesSalesTerritoryHistories.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesTerritory = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
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
				

				r.PersonStateProvinces = typedChildren.Where(b =>  b.TerritoryID == r.Id ).ToList();
				r.PersonStateProvinces.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesTerritory = r; b.Loaded = true; });
				
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

			domain.Id = GetRowData<int>(dataRow, "TerritoryID"); 
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
        public override IEntityReader<int, SalesSalesTerritory> WithAllChildrenForExisting(SalesSalesTerritory existing)
        {
						WithChildForParentValues(GetSalesCustomerReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesCustomers);
						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesOrderHeaders);
						WithChildForParentValues(GetSalesSalesPersonReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesPeople);
						WithChildForParentValues(GetSalesSalesTerritoryHistoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesTerritoryHistories);
						WithChildForParentValues(GetPersonStateProvinceReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenPersonStateProvinces);
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesSalesTerritory entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetSalesCustomerReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesCustomers);

						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesOrderHeaders);

						WithChildForParentValues(GetSalesSalesPersonReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesPeople);

						WithChildForParentValues(GetSalesSalesTerritoryHistoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesTerritoryHistories);

						WithChildForParentValues(GetPersonStateProvinceReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "TerritoryID",  }
				, SetChildrenPersonStateProvinces);

			
QueryResultForChildrenOnly(new List<SalesSalesTerritory>() { entity });
			entity.Loaded = false;
			GetSalesCustomerReader().SetAllChildrenForExisting(entity.SalesCustomers);
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
			GetSalesSalesPersonReader().SetAllChildrenForExisting(entity.SalesSalesPeople);
			GetSalesSalesTerritoryHistoryReader().SetAllChildrenForExisting(entity.SalesSalesTerritoryHistories);
			GetPersonStateProvinceReader().SetAllChildrenForExisting(entity.PersonStateProvinces);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesTerritory> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetSalesCustomerReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesCustomers);

			WithChildForParentsValues(GetSalesSalesOrderHeaderReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentsValues(GetSalesSalesPersonReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesPeople);

			WithChildForParentsValues(GetSalesSalesTerritoryHistoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "TerritoryID",  }
				, SetChildrenSalesSalesTerritoryHistories);

			WithChildForParentsValues(GetPersonStateProvinceReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "TerritoryID",  }
				, SetChildrenPersonStateProvinces);

					
			QueryResultForChildrenOnly(entities);

			GetSalesCustomerReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCustomers).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
			GetSalesSalesPersonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesPeople).ToList());
			GetSalesSalesTerritoryHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesTerritoryHistories).ToList());
			GetPersonStateProvinceReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonStateProvinces).ToList());
					
		}
    }
}
		