
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
    public class ProductionProductDescriptionWriter : EntityWriter<int, ProductionProductDescription>
    {
        public ProductionProductDescriptionWriter
			(ProductionProductDescriptionTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, ProductionProductModelProductDescriptionCulture> GetProductionProductModelProductDescriptionCultureWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProductModelProductDescriptionCulture>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductDescription entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductDescriptionColumnNames)f.Key)
                {
                    
					case ProductionProductDescriptionColumnNames.Description:
						parms.Add(GetParamName("Description", actionType, taskIndex, ref count), entity.Description);
						break;
					case ProductionProductDescriptionColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case ProductionProductDescriptionColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductDescription entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID
			var productionProductModelProductDescriptionCulture229 = GetProductionProductModelProductDescriptionCultureWriter();
			if (_cascades.Contains(ProductionProductDescriptionCascadeNames.production.productmodelproductdescriptionculture.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductModelProductDescriptionCultures)
					Cascade(productionProductModelProductDescriptionCulture229, item, context);

			if (productionProductModelProductDescriptionCulture229.Count > 0)
				WithChild(productionProductModelProductDescriptionCulture229, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductDescription entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID
			if (entity.ProductionProductModelProductDescriptionCultures != null && entity.ProductionProductModelProductDescriptionCultures.Count > 0)
				foreach (var rel in entity.ProductionProductModelProductDescriptionCultures)
					rel.ProductionProductModelProductDescriptionCulture = entity.Id;

				
		}

		protected override void RemoveRelations(ProductionProductDescription entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID
			var productionProductModelProductDescriptionCulture231 = GetProductionProductModelProductDescriptionCultureWriter();
			if (_cascades.Contains(ProductionProductDescriptionCascadeNames.production.productmodelproductdescriptionculture.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductModelProductDescriptionCultures)
					CascadeDelete(productionProductModelProductDescriptionCulture231, item, context);

			if (productionProductModelProductDescriptionCulture231.Count > 0)
				WithChild(productionProductModelProductDescriptionCulture231, entity);

				}
	}
}
		