
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
    public class SalesSpecialOfferProductWriter : EntityWriter<CompoundKey, SalesSpecialOfferProduct>
    {
        public SalesSpecialOfferProductWriter
			(SalesSpecialOfferProductTableInfo tableInfo
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

		static IEntityWriter<int, SalesSalesOrderDetail> GetSalesSalesOrderDetailWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesOrderDetail>(); }
		
		static IEntityWriter<int, SalesSpecialOffer> GetSalesSpecialOfferWriter()
		{ return s_loc8r.GetWriter<int, SalesSpecialOffer>(); }
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSpecialOfferProduct entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSpecialOfferProductFieldNames)f.Key)
                {
                    
					case SalesSpecialOfferProductFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSpecialOfferProductFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSpecialOfferProduct entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			var salesSalesOrderDetail385 = GetSalesSalesOrderDetailWriter();
			if (_cascades.Contains(SalesSpecialOfferProductCascadeNames.salessalesorderdetails1.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderDetails1s)
					Cascade(salesSalesOrderDetail385, item, context);

			if (salesSalesOrderDetail385.Count > 0)
				WithChild(salesSalesOrderDetail385, entity);

			//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			var salesSalesOrderDetail386 = GetSalesSalesOrderDetailWriter();
			if (_cascades.Contains(SalesSpecialOfferProductCascadeNames.salessalesorderdetails2.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderDetails2s)
					Cascade(salesSalesOrderDetail386, item, context);

			if (salesSalesOrderDetail386.Count > 0)
				WithChild(salesSalesOrderDetail386, entity);

		
		
			//From Foreign Key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID
			var salesSpecialOffer387 = GetSalesSpecialOfferWriter();
		if ((_cascades.Contains(SalesSpecialOfferProductCascadeNames.salesspecialoffer_p.ToString()) || _cascades.Contains("all")) && entity.SalesSpecialOffer != null)
			if (Cascade(salesSpecialOffer387, entity.SalesSpecialOffer, context))
				WithParent(salesSpecialOffer387, entity);

			//From Foreign Key FK_SpecialOfferProduct_Product_ProductID
			var productionProduct388 = GetProductionProductWriter();
		if ((_cascades.Contains(SalesSpecialOfferProductCascadeNames.productionproduct_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct388, entity.ProductionProduct, context))
				WithParent(productionProduct388, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSpecialOfferProduct entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			if (entity.SalesSalesOrderDetails != null && entity.SalesSalesOrderDetails.Count > 0)
				foreach (var rel in entity.SalesSalesOrderDetails)
					rel.SpecialOfferID = entity.SpecialOfferID;

			//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			if (entity.SalesSalesOrderDetails != null && entity.SalesSalesOrderDetails.Count > 0)
				foreach (var rel in entity.SalesSalesOrderDetails)
					rel.ProductID = entity.ProductID;

				
			//From Foreign Key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID
			if (entity.SalesSpecialOffer != null)
				entity.SpecialOfferID = entity.SalesSpecialOffer.Id;

			//From Foreign Key FK_SpecialOfferProduct_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductID = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(SalesSpecialOfferProduct entity, ScriptContext context)
        {
					//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			var salesSalesOrderDetail393 = GetSalesSalesOrderDetailWriter();
			if (_cascades.Contains(SalesSpecialOfferProductCascadeNames.salessalesorderdetail.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderDetails)
					CascadeDelete(salesSalesOrderDetail393, item, context);

			if (salesSalesOrderDetail393.Count > 0)
				WithChild(salesSalesOrderDetail393, entity);

					//From Foreign Key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
			var salesSalesOrderDetail394 = GetSalesSalesOrderDetailWriter();
			if (_cascades.Contains(SalesSpecialOfferProductCascadeNames.salessalesorderdetail.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderDetails)
					CascadeDelete(salesSalesOrderDetail394, item, context);

			if (salesSalesOrderDetail394.Count > 0)
				WithChild(salesSalesOrderDetail394, entity);

				}
	}
}
		