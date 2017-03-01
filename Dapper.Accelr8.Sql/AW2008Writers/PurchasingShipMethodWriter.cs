
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
    public class PurchasingShipMethodWriter : EntityWriter<int, PurchasingShipMethod>
    {
        public PurchasingShipMethodWriter
			(PurchasingShipMethodTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, PurchasingPurchaseOrderHeader> GetPurchasingPurchaseOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingPurchaseOrderHeader>>(); }
		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderHeader>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PurchasingShipMethod entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PurchasingShipMethodColumnNames)f.Key)
                {
                    
					case PurchasingShipMethodColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case PurchasingShipMethodColumnNames.ShipBase:
						parms.Add(GetParamName("ShipBase", actionType, taskIndex, ref count), entity.ShipBase);
						break;
					case PurchasingShipMethodColumnNames.ShipRate:
						parms.Add(GetParamName("ShipRate", actionType, taskIndex, ref count), entity.ShipRate);
						break;
					case PurchasingShipMethodColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PurchasingShipMethodColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PurchasingShipMethod entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID
			var purchasingPurchaseOrderHeader374 = GetPurchasingPurchaseOrderHeaderWriter();
			if (_cascades.Contains(PurchasingShipMethodCascadeNames.purchasing.purchaseorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderHeaders)
					Cascade(purchasingPurchaseOrderHeader374, item, context);

			if (purchasingPurchaseOrderHeader374.Count > 0)
				WithChild(purchasingPurchaseOrderHeader374, entity);

			//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID
			var salesSalesOrderHeader375 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(PurchasingShipMethodCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					Cascade(salesSalesOrderHeader375, item, context);

			if (salesSalesOrderHeader375.Count > 0)
				WithChild(salesSalesOrderHeader375, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PurchasingShipMethod entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID
			if (entity.PurchasingPurchaseOrderHeaders != null && entity.PurchasingPurchaseOrderHeaders.Count > 0)
				foreach (var rel in entity.PurchasingPurchaseOrderHeaders)
					rel.PurchasingPurchaseOrderHeader = entity.Id;

			//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID
			if (entity.SalesSalesOrderHeaders != null && entity.SalesSalesOrderHeaders.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaders)
					rel.SalesSalesOrderHeader = entity.Id;

				
		}

		protected override void RemoveRelations(PurchasingShipMethod entity, ScriptContext context)
        {
					//From Foreign Key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID
			var purchasingPurchaseOrderHeader378 = GetPurchasingPurchaseOrderHeaderWriter();
			if (_cascades.Contains(PurchasingShipMethodCascadeNames.purchasing.purchaseorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderHeaders)
					CascadeDelete(purchasingPurchaseOrderHeader378, item, context);

			if (purchasingPurchaseOrderHeader378.Count > 0)
				WithChild(purchasingPurchaseOrderHeader378, entity);

					//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID
			var salesSalesOrderHeader379 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(PurchasingShipMethodCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					CascadeDelete(salesSalesOrderHeader379, item, context);

			if (salesSalesOrderHeader379.Count > 0)
				WithChild(salesSalesOrderHeader379, entity);

				}
	}
}
		