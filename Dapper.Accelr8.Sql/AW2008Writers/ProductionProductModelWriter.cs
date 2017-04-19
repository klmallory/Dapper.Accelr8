
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
    public class ProductionProductModelWriter : EntityWriter<int, ProductionProductModel>
    {
        public ProductionProductModelWriter
			(ProductionProductModelTableInfo tableInfo
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

		static IEntityWriter<int, ProductionProductModelIllustration> GetProductionProductModelIllustrationWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductModelIllustration>(); }
		static IEntityWriter<int, ProductionProductModelProductDescriptionCulture> GetProductionProductModelProductDescriptionCultureWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductModelProductDescriptionCulture>(); }
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductModel entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductModelFieldNames)f.Key)
                {
                    
					case ProductionProductModelFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case ProductionProductModelFieldNames.CatalogDescription:
						parms.Add(GetParamName("CatalogDescription", actionType, taskIndex, ref count), entity.CatalogDescription);
						break;
					case ProductionProductModelFieldNames.Instructions:
						parms.Add(GetParamName("Instructions", actionType, taskIndex, ref count), entity.Instructions);
						break;
					case ProductionProductModelFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case ProductionProductModelFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductModel entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductModelIllustration_ProductModel_ProductModelID
			var productionProductModelIllustration240 = GetProductionProductModelIllustrationWriter();
			if (_cascades.Contains(ProductionProductModelCascadeNames.productionproductmodelillustrations.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductModelIllustrations)
					Cascade(productionProductModelIllustration240, item, context);

			if (productionProductModelIllustration240.Count > 0)
				WithChild(productionProductModelIllustration240, entity);

			//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID
			var productionProductModelProductDescriptionCulture241 = GetProductionProductModelProductDescriptionCultureWriter();
			if (_cascades.Contains(ProductionProductModelCascadeNames.productionproductmodelproductdescriptioncultures.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductModelProductDescriptionCultures)
					Cascade(productionProductModelProductDescriptionCulture241, item, context);

			if (productionProductModelProductDescriptionCulture241.Count > 0)
				WithChild(productionProductModelProductDescriptionCulture241, entity);

			//From Foreign Key FK_Product_ProductModel_ProductModelID
			var productionProduct242 = GetProductionProductWriter();
			if (_cascades.Contains(ProductionProductModelCascadeNames.productionproducts.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProducts)
					Cascade(productionProduct242, item, context);

			if (productionProduct242.Count > 0)
				WithChild(productionProduct242, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductModel entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductModelIllustration_ProductModel_ProductModelID
			if (entity.ProductionProductModelIllustrations != null && entity.ProductionProductModelIllustrations.Count > 0)
				foreach (var rel in entity.ProductionProductModelIllustrations)
					rel.ProductModelID = entity.Id;

			//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID
			if (entity.ProductionProductModelProductDescriptionCultures != null && entity.ProductionProductModelProductDescriptionCultures.Count > 0)
				foreach (var rel in entity.ProductionProductModelProductDescriptionCultures)
					rel.ProductModelID = entity.Id;

			//From Foreign Key FK_Product_ProductModel_ProductModelID
			if (entity.ProductionProducts != null && entity.ProductionProducts.Count > 0)
				foreach (var rel in entity.ProductionProducts)
					rel.ProductModelID = entity.Id;

				
		}

		protected override void RemoveRelations(ProductionProductModel entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductModelIllustration_ProductModel_ProductModelID
			var productionProductModelIllustration246 = GetProductionProductModelIllustrationWriter();
			if (_cascades.Contains(ProductionProductModelCascadeNames.productionproductmodelillustration.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductModelIllustrations)
					CascadeDelete(productionProductModelIllustration246, item, context);

			if (productionProductModelIllustration246.Count > 0)
				WithChild(productionProductModelIllustration246, entity);

					//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID
			var productionProductModelProductDescriptionCulture247 = GetProductionProductModelProductDescriptionCultureWriter();
			if (_cascades.Contains(ProductionProductModelCascadeNames.productionproductmodelproductdescriptionculture.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductModelProductDescriptionCultures)
					CascadeDelete(productionProductModelProductDescriptionCulture247, item, context);

			if (productionProductModelProductDescriptionCulture247.Count > 0)
				WithChild(productionProductModelProductDescriptionCulture247, entity);

					//From Foreign Key FK_Product_ProductModel_ProductModelID
			var productionProduct248 = GetProductionProductWriter();
			if (_cascades.Contains(ProductionProductModelCascadeNames.productionproduct.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProducts)
					CascadeDelete(productionProduct248, item, context);

			if (productionProduct248.Count > 0)
				WithChild(productionProduct248, entity);

				}
	}
}
		