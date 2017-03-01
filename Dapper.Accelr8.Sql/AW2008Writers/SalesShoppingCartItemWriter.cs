
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
    public class SalesShoppingCartItemWriter : EntityWriter<int, SalesShoppingCartItem>
    {
        public SalesShoppingCartItemWriter
			(SalesShoppingCartItemTableInfo tableInfo
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesShoppingCartItem entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesShoppingCartItemColumnNames)f.Key)
                {
                    
					case SalesShoppingCartItemColumnNames.ShoppingCartID:
						parms.Add(GetParamName("ShoppingCartID", actionType, taskIndex, ref count), entity.ShoppingCartID);
						break;
					case SalesShoppingCartItemColumnNames.Quantity:
						parms.Add(GetParamName("Quantity", actionType, taskIndex, ref count), entity.Quantity);
						break;
					case SalesShoppingCartItemColumnNames.ProductID:
						parms.Add(GetParamName("ProductID", actionType, taskIndex, ref count), entity.ProductID);
						break;
					case SalesShoppingCartItemColumnNames.DateCreated:
						parms.Add(GetParamName("DateCreated", actionType, taskIndex, ref count), entity.DateCreated);
						break;
					case SalesShoppingCartItemColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesShoppingCartItem entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ShoppingCartItem_Product_ProductID
			var productionProduct380 = GetProductionProductWriter();
		if ((_cascades.Contains(SalesShoppingCartItemCascadeNames.productionproduct.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct380, entity.ProductionProduct, context))
				WithParent(productionProduct380, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesShoppingCartItem entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ShoppingCartItem_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.SalesShoppingCartItem = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(SalesShoppingCartItem entity, ScriptContext context)
        {
				}
	}
}
		