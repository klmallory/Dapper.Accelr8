
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
    public class ProductionCultureReader : EntityReader<string, ProductionCulture>
    {
        public ProductionCultureReader(
            ProductionCultureTableInfo tableInfo
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
		/// From foriegn key FK_ProductModelProductDescriptionCulture_Culture_CultureID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductModelProductDescriptionCultures(IList<ProductionCulture> results, IList<object> children)
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
				

				r.ProductionProductModelProductDescriptionCultures = typedChildren.Where(b =>  b.CultureID == r.Id ).ToList();
				r.ProductionProductModelProductDescriptionCultures.ToList().ForEach(b => { b.Loaded = false; b.ProductionCulture = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.Culture into class ProductionCulture
		/// </summary>
		/// <param name="results">ProductionCulture</param>
		/// <param name="row"></param>
        public override ProductionCulture LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionCulture();
			domain.Loaded = false;

			domain.Id = GetRowData<string>(dataRow, "CultureID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified string Id.
		/// </summary>
		/// <param name="results">IEntityReader<string, ProductionCulture></param>
		/// <param name="id">string</param>
        public override IEntityReader<string, ProductionCulture> WithAllChildrenForExisting(ProductionCulture existing)
        {
						WithChildForParentValues(GetProductionProductModelProductDescriptionCultureReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "CultureID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionCulture entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionProductModelProductDescriptionCultureReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "CultureID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);

			
QueryResultForChildrenOnly(new List<ProductionCulture>() { entity });
			entity.Loaded = false;
			GetProductionProductModelProductDescriptionCultureReader().SetAllChildrenForExisting(entity.ProductionProductModelProductDescriptionCultures);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionCulture> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionProductModelProductDescriptionCultureReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "CultureID",  }
				, SetChildrenProductionProductModelProductDescriptionCultures);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductModelProductDescriptionCultureReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductModelProductDescriptionCultures).ToList());
					
		}
    }
}
		