
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
    public class ProductionLocationReader : EntityReader<short, ProductionLocation>
    {
        public ProductionLocationReader(
            ProductionLocationTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 2
		//Parent Count 0
		static IEntityReader<int , ProductionProductInventory> _productionProductInventoryReader;
		protected static IEntityReader<int , ProductionProductInventory> GetProductionProductInventoryReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductInventory>>();
		}

		static IEntityReader<int , ProductionWorkOrderRouting> _productionWorkOrderRoutingReader;
		protected static IEntityReader<int , ProductionWorkOrderRouting> GetProductionWorkOrderRoutingReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionWorkOrderRouting>>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProductInventory on the parent on ProductionProductInventories.
		/// From foriegn key FK_ProductInventory_Location_LocationID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductInventories(IList<ProductionLocation> results, IList<object> children)
		{
			//Child Id Type: short
			//Child Type: ProductionProductInventory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductInventory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductInventories = typedChildren.Where(b => b.ProductionProductInventory == r.Id).ToList();
				r.ProductionProductInventories.ToList().ForEach(b => { b.Loaded = false; b.ProductionLocation = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionWorkOrderRouting on the parent on ProductionWorkOrderRoutings.
		/// From foriegn key FK_WorkOrderRouting_Location_LocationID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionWorkOrderRoutings(IList<ProductionLocation> results, IList<object> children)
		{
			//Child Id Type: short
			//Child Type: ProductionWorkOrderRouting

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionWorkOrderRouting>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionWorkOrderRoutings = typedChildren.Where(b => b.ProductionWorkOrderRouting == r.Id).ToList();
				r.ProductionWorkOrderRoutings.ToList().ForEach(b => { b.Loaded = false; b.ProductionLocation = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.Location into class ProductionLocation
		/// </summary>
		/// <param name="results">ProductionLocation</param>
		/// <param name="row"></param>
        public override ProductionLocation LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionLocation();
			domain.Loaded = false;

			domain.Id = GetRowData<short>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.CostRate = GetRowData<decimal>(dataRow, "CostRate"); 
      		domain.Availability = GetRowData<decimal>(dataRow, "Availability"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified short Id.
		/// </summary>
		/// <param name="results">IEntityReader<short, ProductionLocation></param>
		/// <param name="id">short</param>
        public override IEntityReader<short, ProductionLocation> WithAllChildrenForId(short id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetProductionProductInventoryReader(), id, IdColumn, SetChildrenProductionProductInventories);
			
			WithChildForParentId(GetProductionWorkOrderRoutingReader(), id, IdColumn, SetChildrenProductionWorkOrderRoutings);
			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionLocation entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetProductionProductInventoryReader(), entity.Id
				, ProductionProductInventoryColumnNames.LocationID.ToString()
				, SetChildrenProductionProductInventories);

			WithChildForParentId(GetProductionWorkOrderRoutingReader(), entity.Id
				, ProductionWorkOrderRoutingColumnNames.LocationID.ToString()
				, SetChildrenProductionWorkOrderRoutings);

			QueryResultForChildrenOnly(new List<ProductionLocation>() { entity });
			entity.Loaded = false;
			GetProductionProductInventoryReader().SetAllChildrenForExisting(entity.ProductionProductInventories);
			GetProductionWorkOrderRoutingReader().SetAllChildrenForExisting(entity.ProductionWorkOrderRoutings);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionLocation> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetProductionProductInventoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductInventoryColumnNames.LocationID.ToString()
				, SetChildrenProductionProductInventories);

			WithChildForParentIds(GetProductionWorkOrderRoutingReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionWorkOrderRoutingColumnNames.LocationID.ToString()
				, SetChildrenProductionWorkOrderRoutings);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductInventoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductInventories).ToList());
			GetProductionWorkOrderRoutingReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionWorkOrderRoutings).ToList());
					
		}
    }
}
		