
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
    public class PurchasingVendorWriter : EntityWriter<int, PurchasingVendor>
    {
        public PurchasingVendorWriter
			(PurchasingVendorTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, PurchasingProductVendor> GetPurchasingProductVendorWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingProductVendor>>(); }
		static IEntityWriter<int, PurchasingPurchaseOrderHeader> GetPurchasingPurchaseOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingPurchaseOrderHeader>>(); }
		
		static IEntityWriter<int, PersonBusinessEntity> GetPersonBusinessEntityWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonBusinessEntity>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PurchasingVendor entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PurchasingVendorColumnNames)f.Key)
                {
                    
					case PurchasingVendorColumnNames.AccountNumber:
						parms.Add(GetParamName("AccountNumber", actionType, taskIndex, ref count), entity.AccountNumber);
						break;
					case PurchasingVendorColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case PurchasingVendorColumnNames.CreditRating:
						parms.Add(GetParamName("CreditRating", actionType, taskIndex, ref count), entity.CreditRating);
						break;
					case PurchasingVendorColumnNames.PreferredVendorStatus:
						parms.Add(GetParamName("PreferredVendorStatus", actionType, taskIndex, ref count), entity.PreferredVendorStatus);
						break;
					case PurchasingVendorColumnNames.ActiveFlag:
						parms.Add(GetParamName("ActiveFlag", actionType, taskIndex, ref count), entity.ActiveFlag);
						break;
					case PurchasingVendorColumnNames.PurchasingWebServiceURL:
						parms.Add(GetParamName("PurchasingWebServiceURL", actionType, taskIndex, ref count), entity.PurchasingWebServiceURL);
						break;
					case PurchasingVendorColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PurchasingVendor entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID
			var purchasingProductVendor423 = GetPurchasingProductVendorWriter();
			if (_cascades.Contains(PurchasingVendorCascadeNames.purchasing.productvendor.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingProductVendors)
					Cascade(purchasingProductVendor423, item, context);

			if (purchasingProductVendor423.Count > 0)
				WithChild(purchasingProductVendor423, entity);

			//From Foreign Key FK_PurchaseOrderHeader_Vendor_VendorID
			var purchasingPurchaseOrderHeader424 = GetPurchasingPurchaseOrderHeaderWriter();
			if (_cascades.Contains(PurchasingVendorCascadeNames.purchasing.purchaseorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderHeaders)
					Cascade(purchasingPurchaseOrderHeader424, item, context);

			if (purchasingPurchaseOrderHeader424.Count > 0)
				WithChild(purchasingPurchaseOrderHeader424, entity);

		
		
			//From Foreign Key FK_Vendor_BusinessEntity_BusinessEntityID
			var personBusinessEntity425 = GetPersonBusinessEntityWriter();
		if ((_cascades.Contains(PurchasingVendorCascadeNames.personbusinessentity.ToString()) || _cascades.Contains("all")) && entity.PersonBusinessEntity != null)
			if (Cascade(personBusinessEntity425, entity.PersonBusinessEntity, context))
				WithParent(personBusinessEntity425, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PurchasingVendor entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID
			if (entity.PurchasingProductVendors != null && entity.PurchasingProductVendors.Count > 0)
				foreach (var rel in entity.PurchasingProductVendors)
					rel.PurchasingProductVendor = entity.Id;

			//From Foreign Key FK_PurchaseOrderHeader_Vendor_VendorID
			if (entity.PurchasingPurchaseOrderHeaders != null && entity.PurchasingPurchaseOrderHeaders.Count > 0)
				foreach (var rel in entity.PurchasingPurchaseOrderHeaders)
					rel.PurchasingPurchaseOrderHeader = entity.Id;

				
			//From Foreign Key FK_Vendor_BusinessEntity_BusinessEntityID
			if (entity.PersonBusinessEntity != null)
				entity.PurchasingVendor = entity.PersonBusinessEntity.Id;

		}

		protected override void RemoveRelations(PurchasingVendor entity, ScriptContext context)
        {
					//From Foreign Key FK_ProductVendor_Vendor_BusinessEntityID
			var purchasingProductVendor429 = GetPurchasingProductVendorWriter();
			if (_cascades.Contains(PurchasingVendorCascadeNames.purchasing.productvendor.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingProductVendors)
					CascadeDelete(purchasingProductVendor429, item, context);

			if (purchasingProductVendor429.Count > 0)
				WithChild(purchasingProductVendor429, entity);

					//From Foreign Key FK_PurchaseOrderHeader_Vendor_VendorID
			var purchasingPurchaseOrderHeader430 = GetPurchasingPurchaseOrderHeaderWriter();
			if (_cascades.Contains(PurchasingVendorCascadeNames.purchasing.purchaseorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingPurchaseOrderHeaders)
					CascadeDelete(purchasingPurchaseOrderHeader430, item, context);

			if (purchasingPurchaseOrderHeader430.Count > 0)
				WithChild(purchasingPurchaseOrderHeader430, entity);

				}
	}
}
		