
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
    public class ProductionProductDescriptionReader : EntityReader<int, ProductionProductDescription>
    {
        public ProductionProductDescriptionReader(
            ProductionProductDescriptionTableInfo tableInfo
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
		protected static IEntityReader<CompoundKey , ProductionProductModelProductDescriptionCulture> GetProductionProductModelProductDescriptionCultureReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductModelProductDescriptionCulture>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProductModelProductDescriptionCulture on the parent on ProductionProductModelProductDescriptionCultures.
		/// From foriegn key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductModelProductDescriptionCultures(IList<ProductionProductDescription> results, IList<object> children)
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
				

				r.ProductionProductModelProductDescriptionCultures = typedChildren.Where(b =>  b.ProductDescriptionID == r.Id ).ToList();
				r.ProductionProductModelProductDescriptionCultures.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductDescription = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.ProductDescription into class ProductionProductDescription
		/// </summary>
		/// <param name="results">ProductionProductDescription</param>
		/// <param name="row"></param>
        public override ProductionProductDescription LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProductDescription();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "ProductDescriptionID"); 
      		domain.Description = GetRowData<string>(dataRow, "Description"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionProductDescription></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionProductDescription> WithAllChildrenForExisting(ProductionProductDescription existing)
        {
						WithChildForParentValues(GetProductionProductModelProductDescriptionCultureReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductDescriptionID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionProductDescription entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionProductModelProductDescriptionCultureReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductDescriptionID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);

			
QueryResultForChildrenOnly(new List<ProductionProductDescription>() { entity });
			entity.Loaded = false;
			GetProductionProductModelProductDescriptionCultureReader().SetAllChildrenForExisting(entity.ProductionProductModelProductDescriptionCultures);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductDescription> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionProductModelProductDescriptionCultureReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductDescriptionID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductModelProductDescriptionCultureReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductModelProductDescriptionCultures).ToList());
					
		}
    }
}
		