
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

		}

		static IEntityWriter<int, SalesSalesOrderDetail> GetSalesSalesOrderDetailWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderDetail>>(); }
		static IEntityWriter<int, SalesSalesOrderHeaderSalesReason> GetSalesSalesOrderHeaderSalesReasonWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderHeaderSalesReason>>(); }
		
		static IEntityWriter<int, PersonAddress> GetPersonAddressWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonAddress>>(); }
		static IEntityWriter<int, SalesCreditCard> GetSalesCreditCardWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesCreditCard>>(); }
		static IEntityWriter<int, SalesCurrencyRate> GetSalesCurrencyRateWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesCurrencyRate>>(); }
		static IEntityWriter<int, SalesCustomer> GetSalesCustomerWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesCustomer>>(); }
		static IEntityWriter<int, SalesSalesPerson> GetSalesSalesPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesPerson>>(); }
		static IEntityWriter<int, SalesSalesTerritory> GetSalesSalesTerritoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesTerritory>>(); }
		static IEntityWriter<int, PurchasingShipMethod> GetPurchasingShipMethodWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingShipMethod>>(); }
		
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
                switch ((SalesSalesOrderHeaderColumnNames)f.Key)
                {
                    
					case SalesSalesOrderHeaderColumnNames.RevisionNumber:
						parms.Add(GetParamName("RevisionNumber", actionType, taskIndex, ref count), entity.RevisionNumber);
						break;
					case SalesSalesOrderHeaderColumnNames.OrderDate:
						parms.Add(GetParamName("OrderDate", actionType, taskIndex, ref count), entity.OrderDate);
						break;
					case SalesSalesOrderHeaderColumnNames.DueDate:
						parms.Add(GetParamName("DueDate", actionType, taskIndex, ref count), entity.DueDate);
						break;
					case SalesSalesOrderHeaderColumnNames.ShipDate:
						parms.Add(GetParamName("ShipDate", actionType, taskIndex, ref count), entity.ShipDate);
						break;
					case SalesSalesOrderHeaderColumnNames.Status:
						parms.Add(GetParamName("Status", actionType, taskIndex, ref count), entity.Status);
						break;
					case SalesSalesOrderHeaderColumnNames.OnlineOrderFlag:
						parms.Add(GetParamName("OnlineOrderFlag", actionType, taskIndex, ref count), entity.OnlineOrderFlag);
						break;
					case SalesSalesOrderHeaderColumnNames.SalesOrderNumber:
						parms.Add(GetParamName("SalesOrderNumber", actionType, taskIndex, ref count), entity.SalesOrderNumber);
						break;
					case SalesSalesOrderHeaderColumnNames.PurchaseOrderNumber:
						parms.Add(GetParamName("PurchaseOrderNumber", actionType, taskIndex, ref count), entity.PurchaseOrderNumber);
						break;
					case SalesSalesOrderHeaderColumnNames.AccountNumber:
						parms.Add(GetParamName("AccountNumber", actionType, taskIndex, ref count), entity.AccountNumber);
						break;
					case SalesSalesOrderHeaderColumnNames.CustomerID:
						parms.Add(GetParamName("CustomerID", actionType, taskIndex, ref count), entity.CustomerID);
						break;
					case SalesSalesOrderHeaderColumnNames.SalesPersonID:
						parms.Add(GetParamName("SalesPersonID", actionType, taskIndex, ref count), entity.SalesPersonID);
						break;
					case SalesSalesOrderHeaderColumnNames.TerritoryID:
						parms.Add(GetParamName("TerritoryID", actionType, taskIndex, ref count), entity.TerritoryID);
						break;
					case SalesSalesOrderHeaderColumnNames.BillToAddressID:
						parms.Add(GetParamName("BillToAddressID", actionType, taskIndex, ref count), entity.BillToAddressID);
						break;
					case SalesSalesOrderHeaderColumnNames.ShipToAddressID:
						parms.Add(GetParamName("ShipToAddressID", actionType, taskIndex, ref count), entity.ShipToAddressID);
						break;
					case SalesSalesOrderHeaderColumnNames.ShipMethodID:
						parms.Add(GetParamName("ShipMethodID", actionType, taskIndex, ref count), entity.ShipMethodID);
						break;
					case SalesSalesOrderHeaderColumnNames.CreditCardID:
						parms.Add(GetParamName("CreditCardID", actionType, taskIndex, ref count), entity.CreditCardID);
						break;
					case SalesSalesOrderHeaderColumnNames.CreditCardApprovalCode:
						parms.Add(GetParamName("CreditCardApprovalCode", actionType, taskIndex, ref count), entity.CreditCardApprovalCode);
						break;
					case SalesSalesOrderHeaderColumnNames.CurrencyRateID:
						parms.Add(GetParamName("CurrencyRateID", actionType, taskIndex, ref count), entity.CurrencyRateID);
						break;
					case SalesSalesOrderHeaderColumnNames.SubTotal:
						parms.Add(GetParamName("SubTotal", actionType, taskIndex, ref count), entity.SubTotal);
						break;
					case SalesSalesOrderHeaderColumnNames.TaxAmt:
						parms.Add(GetParamName("TaxAmt", actionType, taskIndex, ref count), entity.TaxAmt);
						break;
					case SalesSalesOrderHeaderColumnNames.Freight:
						parms.Add(GetParamName("Freight", actionType, taskIndex, ref count), entity.Freight);
						break;
					case SalesSalesOrderHeaderColumnNames.TotalDue:
						parms.Add(GetParamName("TotalDue", actionType, taskIndex, ref count), entity.TotalDue);
						break;
					case SalesSalesOrderHeaderColumnNames.Comment:
						parms.Add(GetParamName("Comment", actionType, taskIndex, ref count), entity.Comment);
						break;
					case SalesSalesOrderHeaderColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSalesOrderHeaderColumnNames.ModifiedDate:
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
			if (_cascades.Contains(SalesSalesOrderHeaderCascadeNames.sales.salesorderdetail.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderDetails)
					Cascade(salesSalesOrderDetail298, item, context);

			if (salesSalesOrderDetail298.Count > 0)
				WithChild(salesSalesOrderDetail298, entity);

			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			var salesSalesOrderHeaderSalesReason299 = GetSalesSalesOrderHeaderSalesReasonWriter();
			if (_cascades.Contains(SalesSalesOrderHeaderCascadeNames.sales.salesorderheadersalesreason.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaderSalesReasons)
					Cascade(salesSalesOrderHeaderSalesReason299, item, context);

			if (salesSalesOrderHeaderSalesReason299.Count > 0)
				WithChild(salesSalesOrderHeaderSalesReason299, entity);

		
		
			//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID
			var personAddress300 = GetPersonAddressWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.personaddress.ToString()) || _cascades.Contains("all")) && entity.PersonAddress != null)
			if (Cascade(personAddress300, entity.PersonAddress, context))
				WithParent(personAddress300, entity);

			//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID
			var personAddress301 = GetPersonAddressWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.personaddress.ToString()) || _cascades.Contains("all")) && entity.PersonAddress != null)
			if (Cascade(personAddress301, entity.PersonAddress, context))
				WithParent(personAddress301, entity);

			//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID
			var salesCreditCard302 = GetSalesCreditCardWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salescreditcard.ToString()) || _cascades.Contains("all")) && entity.SalesCreditCard != null)
			if (Cascade(salesCreditCard302, entity.SalesCreditCard, context))
				WithParent(salesCreditCard302, entity);

			//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
			var salesCurrencyRate303 = GetSalesCurrencyRateWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salescurrencyrate.ToString()) || _cascades.Contains("all")) && entity.SalesCurrencyRate != null)
			if (Cascade(salesCurrencyRate303, entity.SalesCurrencyRate, context))
				WithParent(salesCurrencyRate303, entity);

			//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID
			var salesCustomer304 = GetSalesCustomerWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salescustomer.ToString()) || _cascades.Contains("all")) && entity.SalesCustomer != null)
			if (Cascade(salesCustomer304, entity.SalesCustomer, context))
				WithParent(salesCustomer304, entity);

			//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID
			var salesSalesPerson305 = GetSalesSalesPersonWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salessalesperson.ToString()) || _cascades.Contains("all")) && entity.SalesSalesPerson != null)
			if (Cascade(salesSalesPerson305, entity.SalesSalesPerson, context))
				WithParent(salesSalesPerson305, entity);

			//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID
			var salesSalesTerritory306 = GetSalesSalesTerritoryWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.salessalesterritory.ToString()) || _cascades.Contains("all")) && entity.SalesSalesTerritory != null)
			if (Cascade(salesSalesTerritory306, entity.SalesSalesTerritory, context))
				WithParent(salesSalesTerritory306, entity);

			//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID
			var purchasingShipMethod307 = GetPurchasingShipMethodWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderCascadeNames.purchasingshipmethod.ToString()) || _cascades.Contains("all")) && entity.PurchasingShipMethod != null)
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
					rel.SalesSalesOrderDetail = entity.Id;

			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			if (entity.SalesSalesOrderHeaderSalesReasons != null && entity.SalesSalesOrderHeaderSalesReasons.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaderSalesReasons)
					rel.SalesSalesOrderHeaderSalesReason = entity.Id;

				
			//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID
			if (entity.PersonAddress != null)
				entity.SalesSalesOrderHeader = entity.PersonAddress.Id;

			//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID
			if (entity.PersonAddress != null)
				entity.SalesSalesOrderHeader = entity.PersonAddress.Id;

			//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID
			if (entity.SalesCreditCard != null)
				entity.SalesSalesOrderHeader = entity.SalesCreditCard.Id;

			//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
			if (entity.SalesCurrencyRate != null)
				entity.SalesSalesOrderHeader = entity.SalesCurrencyRate.Id;

			//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID
			if (entity.SalesCustomer != null)
				entity.SalesSalesOrderHeader = entity.SalesCustomer.Id;

			//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID
			if (entity.SalesSalesPerson != null)
				entity.SalesSalesOrderHeader = entity.SalesSalesPerson.Id;

			//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID
			if (entity.SalesSalesTerritory != null)
				entity.SalesSalesOrderHeader = entity.SalesSalesTerritory.Id;

			//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID
			if (entity.PurchasingShipMethod != null)
				entity.SalesSalesOrderHeader = entity.PurchasingShipMethod.Id;

		}

		protected override void RemoveRelations(SalesSalesOrderHeader entity, ScriptContext context)
        {
					//From Foreign Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
			var salesSalesOrderDetail318 = GetSalesSalesOrderDetailWriter();
			if (_cascades.Contains(SalesSalesOrderHeaderCascadeNames.sales.salesorderdetail.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderDetails)
					CascadeDelete(salesSalesOrderDetail318, item, context);

			if (salesSalesOrderDetail318.Count > 0)
				WithChild(salesSalesOrderDetail318, entity);

					//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			var salesSalesOrderHeaderSalesReason319 = GetSalesSalesOrderHeaderSalesReasonWriter();
			if (_cascades.Contains(SalesSalesOrderHeaderCascadeNames.sales.salesorderheadersalesreason.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaderSalesReasons)
					CascadeDelete(salesSalesOrderHeaderSalesReason319, item, context);

			if (salesSalesOrderHeaderSalesReason319.Count > 0)
				WithChild(salesSalesOrderHeaderSalesReason319, entity);

				}
	}
}
		