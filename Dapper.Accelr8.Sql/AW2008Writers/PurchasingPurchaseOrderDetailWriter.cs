
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
    public class PurchasingPurchaseOrderDetailWriter : EntityWriter<CompoundKey, PurchasingPurchaseOrderDetail>
    {
        public PurchasingPurchaseOrderDetailWriter
			(PurchasingPurchaseOrderDetailTableInfo tableInfo
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

		
		static IEntityWriter<int, PurchasingPurchaseOrderHeader> GetPurchasingPurchaseOrderHeaderWriter()
		{ return s_loc8r.GetWriter<int, PurchasingPurchaseOrderHeader>(); }
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PurchasingPurchaseOrderDetail entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PurchasingPurchaseOrderDetailFieldNames)f.Key)
                {
                    
					case PurchasingPurchaseOrderDetailFieldNames.DueDate:
						parms.Add(GetParamName("DueDate", actionType, taskIndex, ref count), entity.DueDate);
						break;
					case PurchasingPurchaseOrderDetailFieldNames.OrderQty:
						parms.Add(GetParamName("OrderQty", actionType, taskIndex, ref count), entity.OrderQty);
						break;
					case PurchasingPurchaseOrderDetailFieldNames.ProductID:
						parms.Add(GetParamName("ProductID", actionType, taskIndex, ref count), entity.ProductID);
						break;
					case PurchasingPurchaseOrderDetailFieldNames.UnitPrice:
						parms.Add(GetParamName("UnitPrice", actionType, taskIndex, ref count), entity.UnitPrice);
						break;
					case PurchasingPurchaseOrderDetailFieldNames.LineTotal:
						parms.Add(GetParamName("LineTotal", actionType, taskIndex, ref count), entity.LineTotal);
						break;
					case PurchasingPurchaseOrderDetailFieldNames.ReceivedQty:
						parms.Add(GetParamName("ReceivedQty", actionType, taskIndex, ref count), entity.ReceivedQty);
						break;
					case PurchasingPurchaseOrderDetailFieldNames.RejectedQty:
						parms.Add(GetParamName("RejectedQty", actionType, taskIndex, ref count), entity.RejectedQty);
						break;
					case PurchasingPurchaseOrderDetailFieldNames.StockedQty:
						parms.Add(GetParamName("StockedQty", actionType, taskIndex, ref count), entity.StockedQty);
						break;
					case PurchasingPurchaseOrderDetailFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PurchasingPurchaseOrderDetail entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID
			var purchasingPurchaseOrderHeader279 = GetPurchasingPurchaseOrderHeaderWriter();
		if ((_cascades.Contains(PurchasingPurchaseOrderDetailCascadeNames.purchasingpurchaseorderheader_p.ToString()) || _cascades.Contains("all")) && entity.PurchasingPurchaseOrderHeader != null)
			if (Cascade(purchasingPurchaseOrderHeader279, entity.PurchasingPurchaseOrderHeader, context))
				WithParent(purchasingPurchaseOrderHeader279, entity);

			//From Foreign Key FK_PurchaseOrderDetail_Product_ProductID
			var productionProduct280 = GetProductionProductWriter();
		if ((_cascades.Contains(PurchasingPurchaseOrderDetailCascadeNames.productionproduct_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct280, entity.ProductionProduct, context))
				WithParent(productionProduct280, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PurchasingPurchaseOrderDetail entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID
			if (entity.PurchasingPurchaseOrderHeader != null)
				entity.PurchaseOrderID = entity.PurchasingPurchaseOrderHeader.Id;

			//From Foreign Key FK_PurchaseOrderDetail_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductID = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(PurchasingPurchaseOrderDetail entity, ScriptContext context)
        {
				}
	}
}
		