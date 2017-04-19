
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
    public class SalesSalesReasonReader : EntityReader<int, SalesSalesReason>
    {
        public SalesSalesReasonReader(
            SalesSalesReasonTableInfo tableInfo
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

		//Child Count 1
		//Parent Count 0
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesSalesOrderHeaderSalesReason> GetSalesSalesOrderHeaderSalesReasonReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesSalesOrderHeaderSalesReason>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSalesOrderHeaderSalesReason on the parent on SalesSalesOrderHeaderSalesReasons.
		/// From foriegn key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaderSalesReasons(IList<SalesSalesReason> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesSalesOrderHeaderSalesReason

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderHeaderSalesReason>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesOrderHeaderSalesReasons = typedChildren.Where(b =>  b.SalesReasonID == r.Id ).ToList();
				r.SalesSalesOrderHeaderSalesReasons.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesReason = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.SalesReason into class SalesSalesReason
		/// </summary>
		/// <param name="results">SalesSalesReason</param>
		/// <param name="row"></param>
        public override SalesSalesReason LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSalesReason();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "SalesReasonID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ReasonType = GetRowData<object>(dataRow, "ReasonType"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSalesReason></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSalesReason> WithAllChildrenForExisting(SalesSalesReason existing)
        {
						WithChildForParentValues(GetSalesSalesOrderHeaderSalesReasonReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "SalesReasonID",  }
				, SetChildrenSalesSalesOrderHeaderSalesReasons);
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesSalesReason entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetSalesSalesOrderHeaderSalesReasonReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "SalesReasonID",  }
				, SetChildrenSalesSalesOrderHeaderSalesReasons);

			
QueryResultForChildrenOnly(new List<SalesSalesReason>() { entity });
			entity.Loaded = false;
			GetSalesSalesOrderHeaderSalesReasonReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaderSalesReasons);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesReason> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetSalesSalesOrderHeaderSalesReasonReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "SalesReasonID",  }
				, SetChildrenSalesSalesOrderHeaderSalesReasons);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSalesOrderHeaderSalesReasonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaderSalesReasons).ToList());
					
		}
    }
}
		