
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
    public class PurchasingPurchaseOrderHeaderWriter : EntityWriter<int, PurchasingPurchaseOrderHeader>
    {
        public PurchasingPurchaseOrderHeaderWriter
			(PurchasingPurchaseOrderHeaderTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, PurchasingPurchaseOrderDetail> GetPurchasingPurchaseOrderDetailWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingPurchaseOrderDetail>>(); }
		
		static IEntityWriter<int, PurchasingVendor> GetPurchasingVendorWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingVendor>>(); }
		static IEntityWriter<int, HumanResourcesEmployee> GetHumanResourcesEmployeeWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesEmployee>>(); }
		static IEntityWriter<int, PurchasingShipMethod> GetPurchasingShipMethodWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingShipMethod>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PurchasingPurchaseOrderHeader entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PurchasingPurchaseOrderHeaderColumnNames)f.Key)
                {
                    
					case PurchasingPurchaseOrderHeaderColumnNames.RevisionNumber:
						parms.Add(GetParamName("RevisionNumber", actionType, taskIndex, ref count), entity.RevisionNumber);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.Status:
						parms.Add(GetParamName("Status", actionType, taskIndex, ref count), entity.Status);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.EmployeeID:
						parms.Add(GetParamName("EmployeeID", actionType, taskIndex, ref count), entity.EmployeeID);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.VendorID:
						parms.Add(GetParamName("VendorID", actionType, taskIndex, ref count), entity.VendorID);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.ShipMethodID:
						parms.Add(GetParamName("ShipMethodID", actionType, taskIndex, ref count), entity.ShipMethodID);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.OrderDate:
						parms.Add(GetParamName("OrderDate", actionType, taskIndex, ref count), entity.OrderDate);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.ShipDate:
						parms.Add(GetParamName("ShipDate", actionType, taskIndex, ref count), entity.ShipDate);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.SubTotal:
						parms.Add(GetParamName("SubTotal", actionType, taskIndex, ref count), entity.SubTotal);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.TaxAmt:
						parms.Add(GetParamName("TaxAmt", actionType, taskIndex, ref count), entity.TaxAmt);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.Freight:
						parms.Add(GetParamName("Freight", actionType, taskIndex, ref count), entity.Freight);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.TotalDue:
						parms.Add(GetParamName("TotalDue", actionType, taskIndex, ref count), entity.TotalDue);
						break;
					case PurchasingPurchaseOrderHeaderColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PurchasingPurchaseOrderHeader entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID
			var purchasingPurchaseOrderDetail283 = GetPurchasingPurchaseOrderDetailWriter();
			if (_cascades.Contains(PurchasingPurchaseOrderHeaderCascadeNames.purchasing.purchaseorderdetail.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderDetails)
					Cascade(purchasingPurchaseOrderDetail283, item, context);

			if (purchasingPurchaseOrderDetail283.Count > 0)
				WithChild(purchasingPurchaseOrderDetail283, entity);

		
		
			//From Foreign Key FK_PurchaseOrderHeader_Vendor_VendorID
			var purchasingVendor284 = GetPurchasingVendorWriter();
		if ((_cascades.Contains(PurchasingPurchaseOrderHeaderCascadeNames.purchasingvendor.ToString()) || _cascades.Contains("all")) && entity.PurchasingVendor != null)
			if (Cascade(purchasingVendor284, entity.PurchasingVendor, context))
				WithParent(purchasingVendor284, entity);

			//From Foreign Key FK_PurchaseOrderHeader_Employee_EmployeeID
			var humanResourcesEmployee285 = GetHumanResourcesEmployeeWriter();
		if ((_cascades.Contains(PurchasingPurchaseOrderHeaderCascadeNames.humanresourcesemployee.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesEmployee != null)
			if (Cascade(humanResourcesEmployee285, entity.HumanResourcesEmployee, context))
				WithParent(humanResourcesEmployee285, entity);

			//From Foreign Key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID
			var purchasingShipMethod286 = GetPurchasingShipMethodWriter();
		if ((_cascades.Contains(PurchasingPurchaseOrderHeaderCascadeNames.purchasingshipmethod.ToString()) || _cascades.Contains("all")) && entity.PurchasingShipMethod != null)
			if (Cascade(purchasingShipMethod286, entity.PurchasingShipMethod, context))
				WithParent(purchasingShipMethod286, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PurchasingPurchaseOrderHeader entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID
			if (entity.PurchasingPurchaseOrderDetails != null && entity.PurchasingPurchaseOrderDetails.Count > 0)
				foreach (var rel in entity.PurchasingPurchaseOrderDetails)
					rel.PurchasingPurchaseOrderDetail = entity.Id;

				
			//From Foreign Key FK_PurchaseOrderHeader_Vendor_VendorID
			if (entity.PurchasingVendor != null)
				entity.PurchasingPurchaseOrderHeader = entity.PurchasingVendor.Id;

			//From Foreign Key FK_PurchaseOrderHeader_Employee_EmployeeID
			if (entity.HumanResourcesEmployee != null)
				entity.PurchasingPurchaseOrderHeader = entity.HumanResourcesEmployee.Id;

			//From Foreign Key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID
			if (entity.PurchasingShipMethod != null)
				entity.PurchasingPurchaseOrderHeader = entity.PurchasingShipMethod.Id;

		}

		protected override void RemoveRelations(PurchasingPurchaseOrderHeader entity, ScriptContext context)
        {
					//From Foreign Key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID
			var purchasingPurchaseOrderDetail291 = GetPurchasingPurchaseOrderDetailWriter();
			if (_cascades.Contains(PurchasingPurchaseOrderHeaderCascadeNames.purchasing.purchaseorderdetail.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderDetails)
					CascadeDelete(purchasingPurchaseOrderDetail291, item, context);

			if (purchasingPurchaseOrderDetail291.Count > 0)
				WithChild(purchasingPurchaseOrderDetail291, entity);

				}
	}
}
		