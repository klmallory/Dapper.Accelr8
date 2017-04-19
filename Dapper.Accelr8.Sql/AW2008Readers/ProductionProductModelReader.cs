
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
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 3
		//Parent Count 0
				//Is CompoundKey False
		protected static IEntityReader<int , ProductionProduct> GetProductionProductReader()
		{
			return s_loc8r.GetReader<int , ProductionProduct>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , ProductionProductModelIllustration> GetProductionProductModelIllustrationReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductModelIllustration>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , ProductionProductModelProductDescriptionCulture> GetProductionProductModelProductDescriptionCultureReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductModelProductDescriptionCulture>();
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
				

				r.ProductionProducts = typedChildren.Where(b =>  b.ProductModelID == r.Id ).ToList();
				r.ProductionProducts.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductModel = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type ProductionProductModelIllustration on the parent on ProductionProductModelIllustrations.
		/// From foriegn key FK_ProductModelIllustration_ProductModel_ProductModelID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductModelIllustrations(IList<ProductionProductModel> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: ProductionProductModelIllustration

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductModelIllustration>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductModelIllustrations = typedChildren.Where(b =>  b.ProductModelID == r.Id ).ToList();
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
			//Child Id Type: CompoundKey
			//Child Type: ProductionProductModelProductDescriptionCulture

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductModelProductDescriptionCulture>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductModelProductDescriptionCultures = typedChildren.Where(b =>  b.ProductModelID == r.Id ).ToList();
				r.ProductionProductModelProductDescriptionCultures.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductModel = r; b.Loaded = true; });
				
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

			domain.Id = GetRowData<int>(dataRow, "ProductModelID"); 
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
        public override IEntityReader<int, ProductionProductModel> WithAllChildrenForExisting(ProductionProductModel existing)
        {
						WithChildForParentValues(GetProductionProductReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProducts);
						WithChildForParentValues(GetProductionProductModelIllustrationReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProductModelIllustrations);
						WithChildForParentValues(GetProductionProductModelProductDescriptionCultureReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionProductModel entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionProductReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProducts);

						WithChildForParentValues(GetProductionProductModelIllustrationReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProductModelIllustrations);

						WithChildForParentValues(GetProductionProductModelProductDescriptionCultureReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);

			
QueryResultForChildrenOnly(new List<ProductionProductModel>() { entity });
			entity.Loaded = false;
			GetProductionProductReader().SetAllChildrenForExisting(entity.ProductionProducts);
			GetProductionProductModelIllustrationReader().SetAllChildrenForExisting(entity.ProductionProductModelIllustrations);
			GetProductionProductModelProductDescriptionCultureReader().SetAllChildrenForExisting(entity.ProductionProductModelProductDescriptionCultures);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductModel> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionProductReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProducts);

			WithChildForParentsValues(GetProductionProductModelIllustrationReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProductModelIllustrations);

			WithChildForParentsValues(GetProductionProductModelProductDescriptionCultureReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductModelID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProducts).ToList());
			GetProductionProductModelIllustrationReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductModelIllustrations).ToList());
			GetProductionProductModelProductDescriptionCultureReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductModelProductDescriptionCultures).ToList());
					
		}
    }
}
		