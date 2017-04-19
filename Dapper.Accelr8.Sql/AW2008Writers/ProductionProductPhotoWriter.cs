
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

namespace Dapper.Accelr8.AW2008Writers
{
    public class ProductionProductPhotoWriter : EntityWriter<int, ProductionProductPhoto>
    {
        public ProductionProductPhotoWriter
			(ProductionProductPhotoTableInfo tableInfo
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

		static IEntityWriter<int, ProductionProductProductPhoto> GetProductionProductProductPhotoWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductProductPhoto>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductPhoto entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductPhotoFieldNames)f.Key)
                {
                    
					case ProductionProductPhotoFieldNames.ThumbNailPhoto:
						parms.Add(GetParamName("ThumbNailPhoto", actionType, taskIndex, ref count), entity.ThumbNailPhoto);
						break;
					case ProductionProductPhotoFieldNames.ThumbnailPhotoFileName:
						parms.Add(GetParamName("ThumbnailPhotoFileName", actionType, taskIndex, ref count), entity.ThumbnailPhotoFileName);
						break;
					case ProductionProductPhotoFieldNames.LargePhoto:
						parms.Add(GetParamName("LargePhoto", actionType, taskIndex, ref count), entity.LargePhoto);
						break;
					case ProductionProductPhotoFieldNames.LargePhotoFileName:
						parms.Add(GetParamName("LargePhotoFileName", actionType, taskIndex, ref count), entity.LargePhotoFileName);
						break;
					case ProductionProductPhotoFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductPhoto entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID
			var productionProductProductPhoto259 = GetProductionProductProductPhotoWriter();
			if (_cascades.Contains(ProductionProductPhotoCascadeNames.productionproductproductphotos.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductProductPhotos)
					Cascade(productionProductProductPhoto259, item, context);

			if (productionProductProductPhoto259.Count > 0)
				WithChild(productionProductProductPhoto259, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductPhoto entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID
			if (entity.ProductionProductProductPhotos != null && entity.ProductionProductProductPhotos.Count > 0)
				foreach (var rel in entity.ProductionProductProductPhotos)
					rel.ProductPhotoID = entity.Id;

				
		}

		protected override void RemoveRelations(ProductionProductPhoto entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID
			var productionProductProductPhoto261 = GetProductionProductProductPhotoWriter();
			if (_cascades.Contains(ProductionProductPhotoCascadeNames.productionproductproductphoto.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductProductPhotos)
					CascadeDelete(productionProductProductPhoto261, item, context);

			if (productionProductProductPhoto261.Count > 0)
				WithChild(productionProductProductPhoto261, entity);

				}
	}
}
		