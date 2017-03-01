
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
    public class ProductionProductReviewWriter : EntityWriter<int, ProductionProductReview>
    {
        public ProductionProductReviewWriter
			(ProductionProductReviewTableInfo tableInfo
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductReview entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductReviewColumnNames)f.Key)
                {
                    
					case ProductionProductReviewColumnNames.ProductID:
						parms.Add(GetParamName("ProductID", actionType, taskIndex, ref count), entity.ProductID);
						break;
					case ProductionProductReviewColumnNames.ReviewerName:
						parms.Add(GetParamName("ReviewerName", actionType, taskIndex, ref count), entity.ReviewerName);
						break;
					case ProductionProductReviewColumnNames.ReviewDate:
						parms.Add(GetParamName("ReviewDate", actionType, taskIndex, ref count), entity.ReviewDate);
						break;
					case ProductionProductReviewColumnNames.EmailAddress:
						parms.Add(GetParamName("EmailAddress", actionType, taskIndex, ref count), entity.EmailAddress);
						break;
					case ProductionProductReviewColumnNames.Rating:
						parms.Add(GetParamName("Rating", actionType, taskIndex, ref count), entity.Rating);
						break;
					case ProductionProductReviewColumnNames.Comments:
						parms.Add(GetParamName("Comments", actionType, taskIndex, ref count), entity.Comments);
						break;
					case ProductionProductReviewColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductReview entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductReview_Product_ProductID
			var productionProduct266 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionProductReviewCascadeNames.productionproduct.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct266, entity.ProductionProduct, context))
				WithParent(productionProduct266, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductReview entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductReview_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductionProductReview = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(ProductionProductReview entity, ScriptContext context)
        {
				}
	}
}
		