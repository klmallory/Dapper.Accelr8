
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
    public class ProductionProductDocumentWriter : EntityWriter<int, ProductionProductDocument>
    {
        public ProductionProductDocumentWriter
			(ProductionProductDocumentTableInfo tableInfo
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
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductDocument entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductDocumentColumnNames)f.Key)
                {
                    
					case ProductionProductDocumentColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductDocument entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductDocument_Product_ProductID
			var productionProduct232 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionProductDocumentCascadeNames.productionproduct.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct232, entity.ProductionProduct, context))
				WithParent(productionProduct232, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductDocument entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductDocument_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductionProductDocument = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(ProductionProductDocument entity, ScriptContext context)
        {
				}
	}
}
		