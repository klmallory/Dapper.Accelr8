
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
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , ProductionWorkOrder> _productionWorkOrderReader;
		protected static IEntityReader<int , ProductionWorkOrder> GetProductionWorkOrderReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionWorkOrder>>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionWorkOrder on the parent on ProductionWorkOrders.
		/// From foriegn key FK_WorkOrder_ScrapReason_ScrapReasonID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionWorkOrders(IList<ProductionScrapReason> results, IList<object> children)
		{
			//Child Id Type: short
			//Child Type: ProductionWorkOrder

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionWorkOrder>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionWorkOrders = typedChildren.Where(b => b.ProductionWorkOrder == r.Id).ToList();
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

			domain.Id = GetRowData<short>(dataRow, IdColumn);
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
        public override IEntityReader<short, ProductionScrapReason> WithAllChildrenForId(short id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetProductionWorkOrderReader(), id, IdColumn, SetChildrenProductionWorkOrders);
			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionScrapReason entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetProductionWorkOrderReader(), entity.Id
				, ProductionWorkOrderColumnNames.ScrapReasonID.ToString()
				, SetChildrenProductionWorkOrders);

			QueryResultForChildrenOnly(new List<ProductionScrapReason>() { entity });
			entity.Loaded = false;
			GetProductionWorkOrderReader().SetAllChildrenForExisting(entity.ProductionWorkOrders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionScrapReason> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetProductionWorkOrderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionWorkOrderColumnNames.ScrapReasonID.ToString()
				, SetChildrenProductionWorkOrders);

					
			QueryResultForChildrenOnly(entities);

			GetProductionWorkOrderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionWorkOrders).ToList());
					
		}
    }
}
		