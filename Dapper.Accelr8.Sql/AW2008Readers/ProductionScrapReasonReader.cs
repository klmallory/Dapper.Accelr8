
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
    public class ProductionScrapReasonReader : EntityReader<short, ProductionScrapReason>
    {
        public ProductionScrapReasonReader(
            ProductionScrapReasonTableInfo tableInfo
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
				//Is CompoundKey False
		protected static IEntityReader<int , ProductionWorkOrder> GetProductionWorkOrderReader()
		{
			return s_loc8r.GetReader<int , ProductionWorkOrder>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionWorkOrder on the parent on ProductionWorkOrders.
		/// From foriegn key FK_WorkOrder_ScrapReason_ScrapReasonID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionWorkOrders(IList<ProductionScrapReason> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionWorkOrder

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionWorkOrder>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionWorkOrders = typedChildren.Where(b =>  b.ScrapReasonID == r.Id ).ToList();
				r.ProductionWorkOrders.ToList().ForEach(b => { b.Loaded = false; b.ProductionScrapReason = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.ScrapReason into class ProductionScrapReason
		/// </summary>
		/// <param name="results">ProductionScrapReason</param>
		/// <param name="row"></param>
        public override ProductionScrapReason LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionScrapReason();
			domain.Loaded = false;

			domain.Id = GetRowData<short>(dataRow, "ScrapReasonID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified short Id.
		/// </summary>
		/// <param name="results">IEntityReader<short, ProductionScrapReason></param>
		/// <param name="id">short</param>
        public override IEntityReader<short, ProductionScrapReason> WithAllChildrenForExisting(ProductionScrapReason existing)
        {
						WithChildForParentValues(GetProductionWorkOrderReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ScrapReasonID",  }
				, SetChildrenProductionWorkOrders);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionScrapReason entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionWorkOrderReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ScrapReasonID",  }
				, SetChildrenProductionWorkOrders);

			
QueryResultForChildrenOnly(new List<ProductionScrapReason>() { entity });
			entity.Loaded = false;
			GetProductionWorkOrderReader().SetAllChildrenForExisting(entity.ProductionWorkOrders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionScrapReason> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionWorkOrderReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ScrapReasonID",  }
				, SetChildrenProductionWorkOrders);

					
			QueryResultForChildrenOnly(entities);

			GetProductionWorkOrderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionWorkOrders).ToList());
					
		}
    }
}
		