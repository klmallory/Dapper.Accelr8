
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
    public class ProductionIllustrationReader : EntityReader<int, ProductionIllustration>
    {
        public ProductionIllustrationReader(
            ProductionIllustrationTableInfo tableInfo
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
		protected static IEntityReader<CompoundKey , ProductionProductModelIllustration> GetProductionProductModelIllustrationReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductModelIllustration>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProductModelIllustration on the parent on ProductionProductModelIllustrations.
		/// From foriegn key FK_ProductModelIllustration_Illustration_IllustrationID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductModelIllustrations(IList<ProductionIllustration> results, IList<object> children)
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
				

				r.ProductionProductModelIllustrations = typedChildren.Where(b =>  b.IllustrationID == r.Id ).ToList();
				r.ProductionProductModelIllustrations.ToList().ForEach(b => { b.Loaded = false; b.ProductionIllustration = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.Illustration into class ProductionIllustration
		/// </summary>
		/// <param name="results">ProductionIllustration</param>
		/// <param name="row"></param>
        public override ProductionIllustration LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionIllustration();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "IllustrationID"); 
      		domain.Diagram = GetRowData<string>(dataRow, "Diagram"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionIllustration></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionIllustration> WithAllChildrenForExisting(ProductionIllustration existing)
        {
						WithChildForParentValues(GetProductionProductModelIllustrationReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "IllustrationID",  }
				, SetChildrenProductionProductModelIllustrations);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionIllustration entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionProductModelIllustrationReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "IllustrationID",  }
				, SetChildrenProductionProductModelIllustrations);

			
QueryResultForChildrenOnly(new List<ProductionIllustration>() { entity });
			entity.Loaded = false;
			GetProductionProductModelIllustrationReader().SetAllChildrenForExisting(entity.ProductionProductModelIllustrations);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionIllustration> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionProductModelIllustrationReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "IllustrationID",  }
				, SetChildrenProductionProductModelIllustrations);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductModelIllustrationReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductModelIllustrations).ToList());
					
		}
    }
}
		