
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
    public class ProductionProductModelIllustrationWriter : EntityWriter<CompoundKey, ProductionProductModelIllustration>
    {
        public ProductionProductModelIllustrationWriter
			(ProductionProductModelIllustrationTableInfo tableInfo
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

		
		static IEntityWriter<int, ProductionProductModel> GetProductionProductModelWriter()
		{ return s_loc8r.GetWriter<int, ProductionProductModel>(); }
		static IEntityWriter<int, ProductionIllustration> GetProductionIllustrationWriter()
		{ return s_loc8r.GetWriter<int, ProductionIllustration>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductModelIllustration entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductModelIllustrationFieldNames)f.Key)
                {
                    
					case ProductionProductModelIllustrationFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductModelIllustration entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductModelIllustration_ProductModel_ProductModelID
			var productionProductModel249 = GetProductionProductModelWriter();
		if ((_cascades.Contains(ProductionProductModelIllustrationCascadeNames.productionproductmodel_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProductModel != null)
			if (Cascade(productionProductModel249, entity.ProductionProductModel, context))
				WithParent(productionProductModel249, entity);

			//From Foreign Key FK_ProductModelIllustration_Illustration_IllustrationID
			var productionIllustration250 = GetProductionIllustrationWriter();
		if ((_cascades.Contains(ProductionProductModelIllustrationCascadeNames.productionillustration_p.ToString()) || _cascades.Contains("all")) && entity.ProductionIllustration != null)
			if (Cascade(productionIllustration250, entity.ProductionIllustration, context))
				WithParent(productionIllustration250, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductModelIllustration entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductModelIllustration_ProductModel_ProductModelID
			if (entity.ProductionProductModel != null)
				entity.ProductModelID = entity.ProductionProductModel.Id;

			//From Foreign Key FK_ProductModelIllustration_Illustration_IllustrationID
			if (entity.ProductionIllustration != null)
				entity.IllustrationID = entity.ProductionIllustration.Id;

		}

		protected override void RemoveRelations(ProductionProductModelIllustration entity, ScriptContext context)
        {
				}
	}
}
		