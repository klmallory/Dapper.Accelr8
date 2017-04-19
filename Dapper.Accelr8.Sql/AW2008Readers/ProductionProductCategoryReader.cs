
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
    public class ProductionProductCategoryReader : EntityReader<int, ProductionProductCategory>
    {
        public ProductionProductCategoryReader(
            ProductionProductCategoryTableInfo tableInfo
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
		protected static IEntityReader<int , ProductionProductSubcategory> GetProductionProductSubcategoryReader()
		{
			return s_loc8r.GetReader<int , ProductionProductSubcategory>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProductSubcategory on the parent on ProductionProductSubcategories.
		/// From foriegn key FK_ProductSubcategory_ProductCategory_ProductCategoryID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductSubcategories(IList<ProductionProductCategory> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionProductSubcategory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductSubcategory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductSubcategories = typedChildren.Where(b =>  b.ProductCategoryID == r.Id ).ToList();
				r.ProductionProductSubcategories.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductCategory = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.ProductCategory into class ProductionProductCategory
		/// </summary>
		/// <param name="results">ProductionProductCategory</param>
		/// <param name="row"></param>
        public override ProductionProductCategory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProductCategory();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "ProductCategoryID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionProductCategory></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionProductCategory> WithAllChildrenForExisting(ProductionProductCategory existing)
        {
						WithChildForParentValues(GetProductionProductSubcategoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductCategoryID",  }
				, SetChildrenProductionProductSubcategories);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionProductCategory entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionProductSubcategoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductCategoryID",  }
				, SetChildrenProductionProductSubcategories);

			
QueryResultForChildrenOnly(new List<ProductionProductCategory>() { entity });
			entity.Loaded = false;
			GetProductionProductSubcategoryReader().SetAllChildrenForExisting(entity.ProductionProductSubcategories);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductCategory> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionProductSubcategoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductCategoryID",  }
				, SetChildrenProductionProductSubcategories);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductSubcategoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductSubcategories).ToList());
					
		}
    }
}
		