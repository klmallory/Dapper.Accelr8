
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
    public class SalesSalesOrderHeaderWriter : EntityWriter<int, SalesSalesOrderHeader>
    {
        public SalesSalesOrderHeaderWriter
			(SalesSalesOrderHeaderTableInfo tableInfo
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
		static IEntityWriter<int, SalesSalesOrderHeaderSalesReason> GetSalesSalesOrderHeaderSalesReasonWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesOrderHeaderSalesReason>(); }
		
		static IEntityWriter<int, PersonAddress> GetPersonAddressWriter()
		{ return s_loc8r.GetWriter<int, PersonAddress>(); }
		static IEntityWriter<int, SalesCreditCard> GetSalesCreditCardWriter()
		{ return s_loc8r.GetWriter<int, SalesCreditCard>(); }
		static IEntityWriter<int, SalesCurrencyRate> GetSalesCurrencyRateWriter()
		{ return s_loc8r.GetWriter<int, SalesCurrencyRate>(); }
		static IEntityWriter<int, SalesCustomer> GetSalesCustomerWriter()
		{ return s_loc8r.GetWriter<int, SalesCustomer>(); }
		static IEntityWriter<int, SalesSalesPerson> GetSalesSalesPersonWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesPerson>(); }
		static IEntityWriter<int, SalesSalesTerritory> GetSalesSalesTerritoryWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesTerritory>(); }
		static IEntityWriter<int, PurchasingShipMethod> GetPurchasingShipMethodWriter()
		{ return s_loc8r.GetWriter<int, PurchasingShipMethod>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesOrderHeader entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesOrderHeaderFieldNames)f.Key)
                {
                    
					case SalesSalesOrderHeaderFieldNames.RevisionNumber:
						parms.Add(GetParamName("RevisionNumber", actionType, taskIndex, ref count), entity.RevisionNumber);
						break;
					case SalesSalesOrderHeaderFieldNames.OrderDate:
						parms.Add(GetParamName("OrderDate", actionType, taskIndex, ref count), entity.OrderDate);
						break;
					case SalesSalesOrderHeaderFieldNames.DueDate:
						parms.Add(GetParamName("DueDate", actionType, taskIndex, ref count), entity.DueDate);
						break;
					case SalesSalesOrderHeaderFieldNames.ShipDate:
						parms.Add(GetParamName("ShipDate", actionType, taskIndex, ref count), entity.ShipDate);
						break;
					case SalesSalesOrderHeaderFieldNames.Status:
						parms.Add(GetParamName("Status", actionType, taskIndex, ref count), entity.Status);
						break;
					case SalesSalesOrderHeaderFieldNames.OnlineOrderFlag:
						parms.Add(GetParamName("OnlineOrderFlag", actionType, taskIndex, ref count), entity.OnlineOrderFlag);
						break;
					case SalesSalesOrderHeaderFieldNames.SalesOrderNumber:
						parms.Add(GetParamName("SalesOrderNumber", actionType, taskIndex, ref count), entity.SalesOrderNumber);
						break;
					case SalesSalesOrderHeaderFieldNames.PurchaseOrderNumber:
						parms.Add(GetParamName("PurchaseOrderNumber", actionType, taskIndex, ref count), entity.PurchaseOrderNumber);
						break;
					case SalesSalesOrderHeaderFieldNames.AccountNumber:
						parms.Add(GetParamName("AccountNumber", actionType, taskIndex, ref count), entity.AccountNumber);
						break;
					case SalesSalesOrderHeaderFieldNames.CustomerID:
						parms.Add(GetParamName("CustomerID", actionType, taskIndex, ref count), entity.CustomerID);
						break;
					case SalesSalesOrderHeaderFieldNames.SalesPersonID:
						parms.Add(GetParamName("SalesPersonID", actionType, taskIndex, ref count), entity.SalesPersonID);
						break;
					case SalesSalesOrderHeaderFieldNames.TerritoryID:
						parms.Add(GetParamName("TerritoryID", actionType, taskIndex, ref count), entity.TerritoryID);
						break;
					case SalesSalesOrderHeaderFieldNames.BillToAddressID:
						parms.Add(GetParamName("BillToAddressID", actionType, taskIndex, ref count), entity.BillToAddressID);
						break;
					case SalesSalesOrderHeaderFieldNames.ShipToAddressID:
						parms.Add(GetParamName("ShipToAddressID", actionType, taskIndex, ref count), entity.ShipToAddressID);
						break;
					case SalesSalesOrderHeaderFieldNames.ShipMethodID:
						parms.Add(GetParamName("ShipMethodID", actionType, taskIndex, ref count), entity.ShipMethodID);
						break;
					case SalesSalesOrderHeaderFieldNames.CreditCardID:
						parms.Add(GetParamName("CreditCardID", actionType, taskIndex, ref count), entity.CreditCardID);
						break;
					case SalesSalesOrderHeaderFieldNames.CreditCardApprovalCode:
						parms.Add(GetParamName("CreditCardApprovalCode", actionType, taskIndex, ref count), entity.CreditCardApprovalCode);
						break;
					case SalesSalesOrderHeaderFieldNames.CurrencyRateID:
						parms.Add(GetParamName("CurrencyRateID", actionType, taskIndex, ref count), entity.CurrencyRateID);
						break;
					case SalesSalesOrderHeaderFieldNames.SubTotal:
						parms.Add(GetParamName("SubTotal", actionType, taskIndex, ref count), entity.SubTotal);
						break;
					case SalesSalesOrderHeaderFieldNames.TaxAmt:
						parms.Add(GetParamName("TaxAmt", actionType, taskIndex, ref count), entity.TaxAmt);
						break;
					case SalesSalesOrderHeaderFieldNames.Freight:
						parms.Add(GetParamName("Freight", actionType, taskIndex, ref count), entity.Freight);
						break;
					case SalesSalesOrderHeaderFieldNames.TotalDue:
						parms.Add(GetParamName("TotalDue", actionType, taskIndex, ref count), entity.TotalDue);
						break;
					case SalesSalesOrderHeaderFieldNames.Comment:
						parms.Add(GetParamName("Comment", actionType, taskIndex, ref count), entity.Comment);
						break;
					case SalesSalesOrderHeaderFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSalesOrderHeaderFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesOrderHeader entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
			var salesSalesOrderDetail298 = GetSalesSalesOrderDetailWriter();
			if (_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salessalesorderdetails.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderDetails)
					Cascade(salesSalesOrderDetail298, item, context);

			if (salesSalesOrderDetail298.Count > 0)
				WithChild(salesSalesOrderDetail298, entity);

			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			var salesSalesOrderHeaderSalesReason299 = GetSalesSalesOrderHeaderSalesReasonWriter();
			if (_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salessalesorderheadersalesreasons.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaderSalesReasons)
					Cascade(salesSalesOrderHeaderSalesReason299, item, context);

			if (salesSalesOrderHeaderSalesReason299.Count > 0)
				WithChild(salesSalesOrderHeaderSalesReason299, entity);

		
		
			//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID
			var personAddress300 = GetPersonAddressWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.personaddress1_p.ToString()) || _cascades.Contains("all")) && entity.PersonAddress1 != null)
			if (Cascade(personAddress300, entity.PersonAddress1, context))
				WithParent(personAddress300, entity);

			//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID
			var personAddress301 = GetPersonAddressWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.personaddress2_p.ToString()) || _cascades.Contains("all")) && entity.PersonAddress2 != null)
			if (Cascade(personAddress301, entity.PersonAddress2, context))
				WithParent(personAddress301, entity);

			//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID
			var salesCreditCard302 = GetSalesCreditCardWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salescreditcard_p.ToString()) || _cascades.Contains("all")) && entity.SalesCreditCard != null)
			if (Cascade(salesCreditCard302, entity.SalesCreditCard, context))
				WithParent(salesCreditCard302, entity);

			//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
			var salesCurrencyRate303 = GetSalesCurrencyRateWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salescurrencyrate_p.ToString()) || _cascades.Contains("all")) && entity.SalesCurrencyRate != null)
			if (Cascade(salesCurrencyRate303, entity.SalesCurrencyRate, context))
				WithParent(salesCurrencyRate303, entity);

			//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID
			var salesCustomer304 = GetSalesCustomerWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salescustomer_p.ToString()) || _cascades.Contains("all")) && entity.SalesCustomer != null)
			if (Cascade(salesCustomer304, entity.SalesCustomer, context))
				WithParent(salesCustomer304, entity);

			//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID
			var salesSalesPerson305 = GetSalesSalesPersonWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salessalesperson_p.ToString()) || _cascades.Contains("all")) && entity.SalesSalesPerson != null)
			if (Cascade(salesSalesPerson305, entity.SalesSalesPerson, context))
				WithParent(salesSalesPerson305, entity);

			//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID
			var salesSalesTerritory306 = GetSalesSalesTerritoryWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salessalesterritory_p.ToString()) || _cascades.Contains("all")) && entity.SalesSalesTerritory != null)
			if (Cascade(salesSalesTerritory306, entity.SalesSalesTerritory, context))
				WithParent(salesSalesTerritory306, entity);

			//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID
			var purchasingShipMethod307 = GetPurchasingShipMethodWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.purchasingshipmethod_p.ToString()) || _cascades.Contains("all")) && entity.PurchasingShipMethod != null)
			if (Cascade(purchasingShipMethod307, entity.PurchasingShipMethod, context))
				WithParent(purchasingShipMethod307, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesOrderHeader entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
			if (entity.SalesSalesOrderDetails != null && entity.SalesSalesOrderDetails.Count > 0)
				foreach (var rel in entity.SalesSalesOrderDetails)
					rel.SalesOrderID = entity.Id;

			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			if (entity.SalesSalesOrderHeaderSalesReasons != null && entity.SalesSalesOrderHeaderSalesReasons.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaderSalesReasons)
					rel.SalesOrderID = entity.Id;

				
			//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID
			if (entity.PersonAddress1 != null)
				entity.BillToAddressID = entity.PersonAddress1.Id;

			//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID
			if (entity.PersonAddress2 != null)
				entity.ShipToAddressID = entity.PersonAddress2.Id;

			//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID
			if (entity.SalesCreditCard != null)
				entity.CreditCardID = entity.SalesCreditCard.Id;

			//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
			if (entity.SalesCurrencyRate != null)
				entity.CurrencyRateID = entity.SalesCurrencyRate.Id;

			//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID
			if (entity.SalesCustomer != null)
				entity.CustomerID = entity.SalesCustomer.Id;

			//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID
			if (entity.SalesSalesPerson != null)
				entity.SalesPersonID = entity.SalesSalesPerson.Id;

			//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID
			if (entity.SalesSalesTerritory != null)
				entity.TerritoryID = entity.SalesSalesTerritory.Id;

			//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID
			if (entity.PurchasingShipMethod != null)
				entity.ShipMethodID = entity.PurchasingShipMethod.Id;

		}

		protected override void RemoveRelations(SalesSalesOrderHeader entity, ScriptContext context)
        {
					//From Foreign Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
			var salesSalesOrderDetail318 = GetSalesSalesOrderDetailWriter();
			if (_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salessalesorderdetail.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderDetails)
					CascadeDelete(salesSalesOrderDetail318, item, context);

			if (salesSalesOrderDetail318.Count > 0)
				WithChild(salesSalesOrderDetail318, entity);

					//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			var salesSalesOrderHeaderSalesReason319 = GetSalesSalesOrderHeaderSalesReasonWriter();
			if (_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salessalesorderheadersalesreason.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaderSalesReasons)
					CascadeDelete(salesSalesOrderHeaderSalesReason319, item, context);

			if (salesSalesOrderHeaderSalesReason319.Count > 0)
				WithChild(salesSalesOrderHeaderSalesReason319, entity);

				}
	}
}
		