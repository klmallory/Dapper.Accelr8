
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
    public class ProductionProductCategoryWriter : EntityWriter<int, ProductionProductCategory>
    {
        public ProductionProductCategoryWriter
			(ProductionProductCategoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, ProductionProductSubcategory> GetProductionProductSubcategoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProductSubcategory>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductCategory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductCategoryColumnNames)f.Key)
                {
                    
					case ProductionProductCategoryColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case ProductionProductCategoryColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case ProductionProductCategoryColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductCategory entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductSubcategory_ProductCategory_ProductCategoryID
			var productionProductSubcategory224 = GetProductionProductSubcategoryWriter();
			if (_cascades.Contains(ProductionProductCategoryCascadeNames.production.productsubcategory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductSubcategories)
					Cascade(productionProductSubcategory224, item, context);

			if (productionProductSubcategory224.Count > 0)
				WithChild(productionProductSubcategory224, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductCategory entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductSubcategory_ProductCategory_ProductCategoryID
			if (entity.ProductionProductSubcategories != null && entity.ProductionProductSubcategories.Count > 0)
				foreach (var rel in entity.ProductionProductSubcategories)
					rel.ProductionProductSubcategory = entity.Id;

				
		}

		protected override void RemoveRelations(ProductionProductCategory entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductSubcategory_ProductCategory_ProductCategoryID
			var productionProductSubcategory226 = GetProductionProductSubcategoryWriter();
			if (_cascades.Contains(ProductionProductCategoryCascadeNames.production.productsubcategory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductSubcategories)
					CascadeDelete(productionProductSubcategory226, item, context);

			if (productionProductSubcategory226.Count > 0)
				WithChild(productionProductSubcategory226, entity);

				}
	}
}
		