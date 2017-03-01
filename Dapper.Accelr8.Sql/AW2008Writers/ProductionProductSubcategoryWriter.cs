
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
    public class ProductionProductSubcategoryWriter : EntityWriter<int, ProductionProductSubcategory>
    {
        public ProductionProductSubcategoryWriter
			(ProductionProductSubcategoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProduct>>(); }
		
		static IEntityWriter<int, ProductionProductCategory> GetProductionProductCategoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProductCategory>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductSubcategory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductSubcategoryColumnNames)f.Key)
                {
                    
					case ProductionProductSubcategoryColumnNames.ProductCategoryID:
						parms.Add(GetParamName("ProductCategoryID", actionType, taskIndex, ref count), entity.ProductCategoryID);
						break;
					case ProductionProductSubcategoryColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case ProductionProductSubcategoryColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case ProductionProductSubcategoryColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductSubcategory entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Product_ProductSubcategory_ProductSubcategoryID
			var productionProduct268 = GetProductionProductWriter();
			if (_cascades.Contains(ProductionProductSubcategoryCascadeNames.production.product.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProducts)
					Cascade(productionProduct268, item, context);

			if (productionProduct268.Count > 0)
				WithChild(productionProduct268, entity);

		
		
			//From Foreign Key FK_ProductSubcategory_ProductCategory_ProductCategoryID
			var productionProductCategory269 = GetProductionProductCategoryWriter();
		if ((_cascades.Contains(ProductionProductSubcategoryCascadeNames.productionproductcategory.ToString()) || _cascades.Contains("all")) && entity.ProductionProductCategory != null)
			if (Cascade(productionProductCategory269, entity.ProductionProductCategory, context))
				WithParent(productionProductCategory269, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductSubcategory entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Product_ProductSubcategory_ProductSubcategoryID
			if (entity.ProductionProducts != null && entity.ProductionProducts.Count > 0)
				foreach (var rel in entity.ProductionProducts)
					rel.ProductionProduct = entity.Id;

				
			//From Foreign Key FK_ProductSubcategory_ProductCategory_ProductCategoryID
			if (entity.ProductionProductCategory != null)
				entity.ProductionProductSubcategory = entity.ProductionProductCategory.Id;

		}

		protected override void RemoveRelations(ProductionProductSubcategory entity, ScriptContext context)
        {
					//From Foreign Key FK_Product_ProductSubcategory_ProductSubcategoryID
			var productionProduct272 = GetProductionProductWriter();
			if (_cascades.Contains(ProductionProductSubcategoryCascadeNames.production.product.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProducts)
					CascadeDelete(productionProduct272, item, context);

			if (productionProduct272.Count > 0)
				WithChild(productionProduct272, entity);

				}
	}
}
		