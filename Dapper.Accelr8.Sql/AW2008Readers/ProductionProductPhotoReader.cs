
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
    public class ProductionProductPhotoReader : EntityReader<int, ProductionProductPhoto>
    {
        public ProductionProductPhotoReader(
            ProductionProductPhotoTableInfo tableInfo
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
		protected static IEntityReader<CompoundKey , ProductionProductProductPhoto> GetProductionProductProductPhotoReader()
		{
			return s_loc8r.GetReader<CompoundKey , ProductionProductProductPhoto>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProductProductPhoto on the parent on ProductionProductProductPhotos.
		/// From foriegn key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductProductPhotos(IList<ProductionProductPhoto> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: ProductionProductProductPhoto

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductProductPhoto>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.ProductionProductProductPhotos = typedChildren.Where(b =>  b.ProductPhotoID == r.Id ).ToList();
				r.ProductionProductProductPhotos.ToList().ForEach(b => { b.Loaded = false; b.ProductionProductPhoto = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.ProductPhoto into class ProductionProductPhoto
		/// </summary>
		/// <param name="results">ProductionProductPhoto</param>
		/// <param name="row"></param>
        public override ProductionProductPhoto LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProductPhoto();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "ProductPhotoID"); 
      		domain.ThumbNailPhoto = GetRowData<byte[]>(dataRow, "ThumbNailPhoto"); 
      		domain.ThumbnailPhotoFileName = GetRowData<string>(dataRow, "ThumbnailPhotoFileName"); 
      		domain.LargePhoto = GetRowData<byte[]>(dataRow, "LargePhoto"); 
      		domain.LargePhotoFileName = GetRowData<string>(dataRow, "LargePhotoFileName"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionProductPhoto></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionProductPhoto> WithAllChildrenForExisting(ProductionProductPhoto existing)
        {
						WithChildForParentValues(GetProductionProductProductPhotoReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ProductPhotoID",  }
				, SetChildrenProductionProductProductPhotos);
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionProductPhoto entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetProductionProductProductPhotoReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ProductPhotoID",  }
				, SetChildrenProductionProductProductPhotos);

			
QueryResultForChildrenOnly(new List<ProductionProductPhoto>() { entity });
			entity.Loaded = false;
			GetProductionProductProductPhotoReader().SetAllChildrenForExisting(entity.ProductionProductProductPhotos);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductPhoto> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetProductionProductProductPhotoReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ProductPhotoID",  }
				, SetChildrenProductionProductProductPhotos);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductProductPhotoReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductProductPhotos).ToList());
					
		}
    }
}
		