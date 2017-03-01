
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
    public class ProductionProductModelReader : EntityReader<int, ProductionProductModel>
    {
        public ProductionProductModelReader(
            ProductionProductModelTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 3
		//Parent Count 0
		static IEntityReader<int , ProductionProductModelIllustration> _productionProductModelIllustrationReader;
		protected static IEntityReader<int , ProductionProductModelIllustration> GetProductionProductModelIllustrationReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductModelIllustration>>();
		}

		static IEntityReader<int , ProductionProductModelProductDescriptionCulture> _productionProductModelProductDescriptionCultureReader;
		protected static IEntityReader<int , ProductionProductModelProductDescriptionCulture> GetProductionProductModelProductDescriptionCultureReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductModelProductDescriptionCulture>>();
		}

		static IEntityReader<int , ProductionProduct> _productionProductReader;
		protected static IEntityReader<int , ProductionProduct> GetProductionProductReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProduct>>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProductModelIllustration on the parent on ProductionProductModelIllustrations.
		/// From foriegn key FK_ProductModelIllustration_ProductModel_ProductModelID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductModelIllustrations(IList<ProductionProductModel> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionProductModelIllustration

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductModelIllustration>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductModelIllustrations = typedChildren.Where(b => b.ProductionProductModelIllustration == r.Id).ToList();
				r.ProductionProductModelIllustrations.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductModel = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProductModelProductDescriptionCulture on the parent on ProductionProductModelProductDescriptionCultures.
		/// From foriegn key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductModelProductDescriptionCultures(IList<ProductionProductModel> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionProductModelProductDescriptionCulture

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductModelProductDescriptionCulture>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductModelProductDescriptionCultures = typedChildren.Where(b => b.ProductionProductModelProductDescriptionCulture == r.Id).ToList();
				r.ProductionProductModelProductDescriptionCultures.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductModel = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProduct on the parent on ProductionProducts.
		/// From foriegn key FK_Product_ProductModel_ProductModelID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProducts(IList<ProductionProductModel> results, IList<object> children)
		{
			//Child Id Type: int
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
				r.ProductionProducts.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductModel = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.ProductModel into class ProductionProductModel
		/// </summary>
		/// <param name="results">ProductionProductModel</param>
		/// <param name="row"></param>
        public override ProductionProductModel LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProductModel();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.CatalogDescription = GetRowData<string>(dataRow, "CatalogDescription"); 
      		domain.Instructions = GetRowData<string>(dataRow, "Instructions"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionProductModel></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionProductModel> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetProductionProductModelIllustrationReader(), id, IdColumn, SetChildrenProductionProductModelIllustrations);
			
			WithChildForParentId(GetProductionProductModelProductDescriptionCultureReader(), id, IdColumn, SetChildrenProductionProductModelProductDescriptionCultures);
			
			WithChildForParentId(GetProductionProductReader(), id, IdColumn, SetChildrenProductionProducts);
			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionProductModel entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetProductionProductModelIllustrationReader(), entity.Id
				, ProductionProductModelIllustrationColumnNames.ProductModelID.ToString()
				, SetChildrenProductionProductModelIllustrations);

			WithChildForParentId(GetProductionProductModelProductDescriptionCultureReader(), entity.Id
				, ProductionProductModelProductDescriptionCultureColumnNames.ProductModelID.ToString()
				, SetChildrenProductionProductModelProductDescriptionCultures);

			WithChildForParentId(GetProductionProductReader(), entity.Id
				, ProductionProductColumnNames.ProductModelID.ToString()
				, SetChildrenProductionProducts);

			QueryResultForChildrenOnly(new List<ProductionProductModel>() { entity });
			entity.Loaded = false;
			GetProductionProductModelIllustrationReader().SetAllChildrenForExisting(entity.ProductionProductModelIllustrations);
			GetProductionProductModelProductDescriptionCultureReader().SetAllChildrenForExisting(entity.ProductionProductModelProductDescriptionCultures);
			GetProductionProductReader().SetAllChildrenForExisting(entity.ProductionProducts);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductModel> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetProductionProductModelIllustrationReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductModelIllustrationColumnNames.ProductModelID.ToString()
				, SetChildrenProductionProductModelIllustrations);

			WithChildForParentIds(GetProductionProductModelProductDescriptionCultureReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductModelProductDescriptionCultureColumnNames.ProductModelID.ToString()
				, SetChildrenProductionProductModelProductDescriptionCultures);

			WithChildForParentIds(GetProductionProductReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductColumnNames.ProductModelID.ToString()
				, SetChildrenProductionProducts);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductModelIllustrationReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductModelIllustrations).ToList());
			GetProductionProductModelProductDescriptionCultureReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductModelProductDescriptionCultures).ToList());
			GetProductionProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProducts).ToList());
					
		}
    }
}
		