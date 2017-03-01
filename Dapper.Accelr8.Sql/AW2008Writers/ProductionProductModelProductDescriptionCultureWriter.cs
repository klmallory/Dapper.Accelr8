
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
    public class ProductionProductModelProductDescriptionCultureWriter : EntityWriter<int, ProductionProductModelProductDescriptionCulture>
    {
        public ProductionProductModelProductDescriptionCultureWriter
			(ProductionProductModelProductDescriptionCultureTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, ProductionProductModel> GetProductionProductModelWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProductModel>>(); }
		static IEntityWriter<string, ProductionCulture> GetProductionCultureWriter()
		{ return _locator.Resolve<IEntityWriter<string, ProductionCulture>>(); }
		static IEntityWriter<int, ProductionProductDescription> GetProductionProductDescriptionWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProductDescription>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductModelProductDescriptionCulture entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductModelProductDescriptionCultureColumnNames)f.Key)
                {
                    
					case ProductionProductModelProductDescriptionCultureColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductModelProductDescriptionCulture entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID
			var productionProductModel253 = GetProductionProductModelWriter();
		if ((_cascades.Contains(ProductionProductModelProductDescriptionCultureCascadeNames.productionproductmodel.ToString()) || _cascades.Contains("all")) && entity.ProductionProductModel != null)
			if (Cascade(productionProductModel253, entity.ProductionProductModel, context))
				WithParent(productionProductModel253, entity);

			//From Foreign Key FK_ProductModelProductDescriptionCulture_Culture_CultureID
			var productionCulture254 = GetProductionCultureWriter();
		if ((_cascades.Contains(ProductionProductModelProductDescriptionCultureCascadeNames.productionculture.ToString()) || _cascades.Contains("all")) && entity.ProductionCulture != null)
			if (Cascade(productionCulture254, entity.ProductionCulture, context))
				WithParent(productionCulture254, entity);

			//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID
			var productionProductDescription255 = GetProductionProductDescriptionWriter();
		if ((_cascades.Contains(ProductionProductModelProductDescriptionCultureCascadeNames.productionproductdescription.ToString()) || _cascades.Contains("all")) && entity.ProductionProductDescription != null)
			if (Cascade(productionProductDescription255, entity.ProductionProductDescription, context))
				WithParent(productionProductDescription255, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductModelProductDescriptionCulture entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID
			if (entity.ProductionProductModel != null)
				entity.ProductionProductModelProductDescriptionCulture = entity.ProductionProductModel.Id;

			//From Foreign Key FK_ProductModelProductDescriptionCulture_Culture_CultureID
			if (entity.ProductionCulture != null)
				entity.ProductionProductModelProductDescriptionCulture = entity.ProductionCulture.Id;

			//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID
			if (entity.ProductionProductDescription != null)
				entity.ProductionProductModelProductDescriptionCulture = entity.ProductionProductDescription.Id;

		}

		protected override void RemoveRelations(ProductionProductModelProductDescriptionCulture entity, ScriptContext context)
        {
				}
	}
}
		