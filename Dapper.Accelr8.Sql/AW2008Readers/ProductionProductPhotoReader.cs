
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
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , ProductionProductProductPhoto> _productionProductProductPhotoReader;
		protected static IEntityReader<int , ProductionProductProductPhoto> GetProductionProductProductPhotoReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionProductProductPhoto>>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionProductProductPhoto on the parent on ProductionProductProductPhotos.
		/// From foriegn key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionProductProductPhotos(IList<ProductionProductPhoto> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionProductProductPhoto

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionProductProductPhoto>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionProductProductPhotos = typedChildren.Where(b => b.ProductionProductProductPhoto == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
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
        public override IEntityReader<int, ProductionProductPhoto> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetProductionProductProductPhotoReader(), id, IdColumn, SetChildrenProductionProductProductPhotos);
			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionProductPhoto entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetProductionProductProductPhotoReader(), entity.Id
				, ProductionProductProductPhotoColumnNames.ProductPhotoID.ToString()
				, SetChildrenProductionProductProductPhotos);

			QueryResultForChildrenOnly(new List<ProductionProductPhoto>() { entity });
			entity.Loaded = false;
			GetProductionProductProductPhotoReader().SetAllChildrenForExisting(entity.ProductionProductProductPhotos);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductPhoto> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetProductionProductProductPhotoReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionProductProductPhotoColumnNames.ProductPhotoID.ToString()
				, SetChildrenProductionProductProductPhotos);

					
			QueryResultForChildrenOnly(entities);

			GetProductionProductProductPhotoReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionProductProductPhotos).ToList());
					
		}
    }
}
		