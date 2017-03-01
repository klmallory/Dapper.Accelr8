
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
    public class ProductionProductProductPhotoWriter : EntityWriter<int, ProductionProductProductPhoto>
    {
        public ProductionProductProductPhotoWriter
			(ProductionProductProductPhotoTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, ProductionProductPhoto> GetProductionProductPhotoWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProductPhoto>>(); }
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProduct>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductProductPhoto entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductProductPhotoColumnNames)f.Key)
                {
                    
					case ProductionProductProductPhotoColumnNames.Primary:
						parms.Add(GetParamName("Primary", actionType, taskIndex, ref count), entity.Primary);
						break;
					case ProductionProductProductPhotoColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductProductPhoto entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID
			var productionProductPhoto262 = GetProductionProductPhotoWriter();
		if ((_cascades.Contains(ProductionProductProductPhotoCascadeNames.productionproductphoto.ToString()) || _cascades.Contains("all")) && entity.ProductionProductPhoto != null)
			if (Cascade(productionProductPhoto262, entity.ProductionProductPhoto, context))
				WithParent(productionProductPhoto262, entity);

			//From Foreign Key FK_ProductProductPhoto_Product_ProductID
			var productionProduct263 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionProductProductPhotoCascadeNames.productionproduct.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct263, entity.ProductionProduct, context))
				WithParent(productionProduct263, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductProductPhoto entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID
			if (entity.ProductionProductPhoto != null)
				entity.ProductionProductProductPhoto = entity.ProductionProductPhoto.Id;

			//From Foreign Key FK_ProductProductPhoto_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductionProductProductPhoto = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(ProductionProductProductPhoto entity, ScriptContext context)
        {
				}
	}
}
		