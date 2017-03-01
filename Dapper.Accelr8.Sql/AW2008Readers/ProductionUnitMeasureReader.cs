
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
    public class ProductionUnitMeasureReader : EntityReader<string, ProductionUnitMeasure>
    {
        public ProductionUnitMeasureReader(
            ProductionUnitMeasureTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 3
		//Parent Count 0
		static IEntityReader<int , PurchasingProductVendor> _purchasingProductVendorReader;
		protected static IEntityReader<int , PurchasingProductVendor> GetPurchasingProductVendorReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingProductVendor>>();
		}

		static IEntityReader<int , ProductionProduct> _productionProductReader;
		protected static IEntityReader<int , ProductionProduct> GetProductionProductReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProduct>>();
		}

		
		/// <summary>
		/// Sets the children of type PurchasingProductVendor on the parent on PurchasingProductVendors.
		/// From foriegn key FK_ProductVendor_UnitMeasure_UnitMeasureCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingProductVendors(IList<ProductionUnitMeasure> results, IList<object> children)
		{
			//Child Id Type: string
			//Child Type: PurchasingProductVendor

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingProductVendor>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PurchasingProductVendors = typedChildren.Where(b => b.PurchasingProductVendor == r.Id).ToList();
				r.PurchasingProductVendors.ToList().ForEach(b => { b.Loaded = false; b.ProductionUnitMeasure = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProduct on the parent on ProductionProducts.
		/// From foriegn key FK_Product_UnitMeasure_SizeUnitMeasureCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProducts(IList<ProductionUnitMeasure> results, IList<object> children)
		{
			//Child Id Type: string
			//Child Type: ProductionProduct

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProduct>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProducts = typedChildren.Where(b => b.ProductionProduct == r.Id).ToList();
				r.ProductionProducts.ToList().ForEach(b => { b.Loaded = false; b.ProductionUnitMeasure = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProduct on the parent on ProductionProducts.
		/// From foriegn key FK_Product_UnitMeasure_WeightUnitMeasureCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProducts(IList<ProductionUnitMeasure> results, IList<object> children)
		{
			//Child Id Type: string
			//Child Type: ProductionProduct

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProduct>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProducts = typedChildren.Where(b => b.ProductionProduct == r.Id).ToList();
				r.ProductionProducts.ToList().ForEach(b => { b.Loaded = false; b.ProductionUnitMeasure = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.UnitMeasure into class ProductionUnitMeasure
		/// </summary>
		/// <param name="results">ProductionUnitMeasure</param>
		/// <param name="row"></param>
        public override ProductionUnitMeasure LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionUnitMeasure();
			domain.Loaded = false;

			domain.Id = GetRowData<string>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified string Id.
		/// </summary>
		/// <param name="results">IEntityReader<string, ProductionUnitMeasure></param>
		/// <param name="id">string</param>
        public override IEntityReader<string, ProductionUnitMeasure> WithAllChildrenForId(string id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPurchasingProductVendorReader(), id, IdColumn, SetChildrenPurchasingProductVendors);
			
			WithChildForParentId(GetProductionProductReader(), id, IdColumn, SetChildrenProductionProducts);
			
			WithChildForParentId(GetProductionProductReader(), id, IdColumn, SetChildrenProductionProducts);
			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionUnitMeasure entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPurchasingProductVendorReader(), entity.Id
				, PurchasingProductVendorColumnNames.UnitMeasureCode.ToString()
				, SetChildrenPurchasingProductVendors);

			WithChildForParentId(GetProductionProductReader(), entity.Id
				, ProductionProductColumnNames.SizeUnitMeasureCode.ToString()
				, SetChildrenProductionProducts);

			WithChildForParentId(GetProductionProductReader(), entity.Id
				, ProductionProductColumnNames.WeightUnitMeasureCode.ToString()
				, SetChildrenProductionProducts);

			QueryResultForChildrenOnly(new List<ProductionUnitMeasure>() { entity });
			entity.Loaded = false;
			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entity.PurchasingProductVendors);
			GetProductionProductReader().SetAllChildrenForExisting(entity.ProductionProducts);
			GetProductionProductReader().SetAllChildrenForExisting(entity.ProductionProducts);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionUnitMeasure> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPurchasingProductVendorReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingProductVendorColumnNames.UnitMeasureCode.ToString()
				, SetChildrenPurchasingProductVendors);

			WithChildForParentIds(GetProductionProductReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductColumnNames.SizeUnitMeasureCode.ToString()
				, SetChildrenProductionProducts);

			WithChildForParentIds(GetProductionProductReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductColumnNames.WeightUnitMeasureCode.ToString()
				, SetChildrenProductionProducts);

					
			QueryResultForChildrenOnly(entities);

			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingProductVendors).ToList());
			GetProductionProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProducts).ToList());
			GetProductionProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProducts).ToList());
					
		}
    }
}
		