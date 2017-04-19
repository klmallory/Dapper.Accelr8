
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
    public class ProductionProductSubcategoryReader : EntityReader<int, ProductionProductSubcategory>
    {
        public ProductionProductSubcategoryReader(
            ProductionProductSubcategoryTableInfo tableInfo
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
		//Parent Count 1
				//Is CompoundKey False
		protected static IEntityReader<int , ProductionProduct> GetProductionProductReader()
		{
			return s_loc8r.GetReader<int , ProductionProduct>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProduct on the parent on ProductionProducts.
		/// From foriegn key FK_Product_ProductSubcategory_ProductSubcategoryID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProducts(IList<ProductionProductSubcategory> results, IList<object> children)
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
				

				r.ProductionProducts = typedChildren.Where(b =>  b.ProductSubcategoryID == r.Id ).ToList();
				r.ProductionProducts.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductSubcategory = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.ProductSubcategory into class ProductionProductSubcategory
		/// </summary>
		/// <param name="results">ProductionProductSubcategory</param>
		/// <param name="row"></param>
        public override ProductionProductSubcategory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProductSubcategory();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "ProductSubcategoryID"); 
      		domain.ProductCategoryID = GetRowData<int>(dataRow, "ProductCategoryID"); 
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
		/// <param name="results">IEntityReader<int, ProductionProductSubcategory></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionProductSubcategory> WithAllChildrenForExisting(ProductionProductSubcategory existing)
        {
						WithChildForParentValues(GetProductionProductReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductSubcategoryID",  }
				, SetChildrenProductionProducts);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionProductSubcategory entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionProductReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductSubcategoryID",  }
				, SetChildrenProductionProducts);

			
QueryResultForChildrenOnly(new List<ProductionProductSubcategory>() { entity });
			entity.Loaded = false;
			GetProductionProductReader().SetAllChildrenForExisting(entity.ProductionProducts);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductSubcategory> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionProductReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductSubcategoryID",  }
				, SetChildrenProductionProducts);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProducts).ToList());
					
		}
    }
}
		