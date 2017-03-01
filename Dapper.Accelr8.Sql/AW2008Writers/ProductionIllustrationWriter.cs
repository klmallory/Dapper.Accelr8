
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
    public class ProductionIllustrationWriter : EntityWriter<int, ProductionIllustration>
    {
        public ProductionIllustrationWriter
			(ProductionIllustrationTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, ProductionProductModelIllustration> GetProductionProductModelIllustrationWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProductModelIllustration>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionIllustration entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionIllustrationColumnNames)f.Key)
                {
                    
					case ProductionIllustrationColumnNames.Diagram:
						parms.Add(GetParamName("Diagram", actionType, taskIndex, ref count), entity.Diagram);
						break;
					case ProductionIllustrationColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionIllustration entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductModelIllustration_Illustration_IllustrationID
			var productionProductModelIllustration133 = GetProductionProductModelIllustrationWriter();
			if (_cascades.Contains(ProductionIllustrationCascadeNames.production.productmodelillustration.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductModelIllustrations)
					Cascade(productionProductModelIllustration133, item, context);

			if (productionProductModelIllustration133.Count > 0)
				WithChild(productionProductModelIllustration133, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionIllustration entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductModelIllustration_Illustration_IllustrationID
			if (entity.ProductionProductModelIllustrations != null && entity.ProductionProductModelIllustrations.Count > 0)
				foreach (var rel in entity.ProductionProductModelIllustrations)
					rel.ProductionProductModelIllustration = entity.Id;

				
		}

		protected override void RemoveRelations(ProductionIllustration entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductModelIllustration_Illustration_IllustrationID
			var productionProductModelIllustration135 = GetProductionProductModelIllustrationWriter();
			if (_cascades.Contains(ProductionIllustrationCascadeNames.production.productmodelillustration.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionProductModelIllustrations)
					CascadeDelete(productionProductModelIllustration135, item, context);

			if (productionProductModelIllustration135.Count > 0)
				WithChild(productionProductModelIllustration135, entity);

				}
	}
}
		