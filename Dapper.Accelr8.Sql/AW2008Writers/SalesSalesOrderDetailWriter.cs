
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
    public class SalesSalesOrderDetailWriter : EntityWriter<int, SalesSalesOrderDetail>
    {
        public SalesSalesOrderDetailWriter
			(SalesSalesOrderDetailTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, SalesSpecialOfferProduct> GetSalesSpecialOfferProductWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSpecialOfferProduct>>(); }
		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderHeader>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesOrderDetail entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesOrderDetailColumnNames)f.Key)
                {
                    
					case SalesSalesOrderDetailColumnNames.CarrierTrackingNumber:
						parms.Add(GetParamName("CarrierTrackingNumber", actionType, taskIndex, ref count), entity.CarrierTrackingNumber);
						break;
					case SalesSalesOrderDetailColumnNames.OrderQty:
						parms.Add(GetParamName("OrderQty", actionType, taskIndex, ref count), entity.OrderQty);
						break;
					case SalesSalesOrderDetailColumnNames.ProductID:
						parms.Add(GetParamName("ProductID", actionType, taskIndex, ref count), entity.ProductID);
						break;
					case SalesSalesOrderDetailColumnNames.SpecialOfferID:
						parms.Add(GetParamName("SpecialOfferID", actionType, taskIndex, ref count), entity.SpecialOfferID);
						break;
					case SalesSalesOrderDetailColumnNames.UnitPrice:
						parms.Add(GetParamName("UnitPrice", actionType, taskIndex, ref count), entity.UnitPrice);
						break;
					case SalesSalesOrderDetailColumnNames.UnitPriceDiscount:
						parms.Add(GetParamName("UnitPriceDiscount", actionType, taskIndex, ref count), entity.UnitPriceDiscount);
						break;
					case SalesSalesOrderDetailColumnNames.LineTotal:
						parms.Add(GetParamName("LineTotal", actionType, taskIndex, ref count), entity.LineTotal);
						break;
					case SalesSalesOrderDetailColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSalesOrderDetailColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesOrderDetail entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			var salesSpecialOfferProduct292 = GetSalesSpecialOfferProductWriter();
		if ((_cascades.Contains(SalesSalesOrderDetailCascadeNames.salesspecialofferproduct.ToString()) || _cascades.Contains("all")) && entity.SalesSpecialOfferProduct != null)
			if (Cascade(salesSpecialOfferProduct292, entity.SalesSpecialOfferProduct, context))
				WithParent(salesSpecialOfferProduct292, entity);

			//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			var salesSpecialOfferProduct293 = GetSalesSpecialOfferProductWriter();
		if ((_cascades.Contains(SalesSalesOrderDetailCascadeNames.salesspecialofferproduct.ToString()) || _cascades.Contains("all")) && entity.SalesSpecialOfferProduct != null)
			if (Cascade(salesSpecialOfferProduct293, entity.SalesSpecialOfferProduct, context))
				WithParent(salesSpecialOfferProduct293, entity);

			//From Foreign Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
			var salesSalesOrderHeader294 = GetSalesSalesOrderHeaderWriter();
		if ((_cascades.Contains(SalesSalesOrderDetailCascadeNames.salessalesorderheader.ToString()) || _cascades.Contains("all")) && entity.SalesSalesOrderHeader != null)
			if (Cascade(salesSalesOrderHeader294, entity.SalesSalesOrderHeader, context))
				WithParent(salesSalesOrderHeader294, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesOrderDetail entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			if (entity.SalesSpecialOfferProduct != null)
				entity.SalesSalesOrderDetail = entity.SalesSpecialOfferProduct.SpecialOfferID;

			//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			if (entity.SalesSpecialOfferProduct != null)
				entity.SalesSalesOrderDetail = entity.SalesSpecialOfferProduct.ProductID;

			//From Foreign Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
			if (entity.SalesSalesOrderHeader != null)
				entity.SalesSalesOrderDetail = entity.SalesSalesOrderHeader.Id;

		}

		protected override void RemoveRelations(SalesSalesOrderDetail entity, ScriptContext context)
        {
				}
	}
}
		