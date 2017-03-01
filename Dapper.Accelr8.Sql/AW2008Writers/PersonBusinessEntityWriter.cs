
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
    public class PersonBusinessEntityWriter : EntityWriter<int, PersonBusinessEntity>
    {
        public PersonBusinessEntityWriter
			(PersonBusinessEntityTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, SalesStore> GetSalesStoreWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesStore>>(); }
		static IEntityWriter<int, PersonBusinessEntityAddress> GetPersonBusinessEntityAddressWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonBusinessEntityAddress>>(); }
		static IEntityWriter<int, PersonBusinessEntityContact> GetPersonBusinessEntityContactWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonBusinessEntityContact>>(); }
		static IEntityWriter<int, PurchasingVendor> GetPurchasingVendorWriter()
		{ return _locator.Resolve<IEntityWriter<int, PurchasingVendor>>(); }
		static IEntityWriter<int, PersonPerson> GetPersonPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonPerson>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonBusinessEntity entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonBusinessEntityColumnNames)f.Key)
                {
                    
					case PersonBusinessEntityColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonBusinessEntityColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonBusinessEntity entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Store_BusinessEntity_BusinessEntityID
			var salesStore21 = GetSalesStoreWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.sales.store.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesStores)
					Cascade(salesStore21, item, context);

			if (salesStore21.Count > 0)
				WithChild(salesStore21, entity);

			//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
			var personBusinessEntityAddress22 = GetPersonBusinessEntityAddressWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.person.businessentityaddress.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityAddresses)
					Cascade(personBusinessEntityAddress22, item, context);

			if (personBusinessEntityAddress22.Count > 0)
				WithChild(personBusinessEntityAddress22, entity);

			//From Foreign Key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID
			var personBusinessEntityContact23 = GetPersonBusinessEntityContactWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.person.businessentitycontact.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityContacts)
					Cascade(personBusinessEntityContact23, item, context);

			if (personBusinessEntityContact23.Count > 0)
				WithChild(personBusinessEntityContact23, entity);

			//From Foreign Key FK_Vendor_BusinessEntity_BusinessEntityID
			var purchasingVendor24 = GetPurchasingVendorWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.purchasing.vendor.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingVendors)
					Cascade(purchasingVendor24, item, context);

			if (purchasingVendor24.Count > 0)
				WithChild(purchasingVendor24, entity);

			//From Foreign Key FK_Person_BusinessEntity_BusinessEntityID
			var personPerson25 = GetPersonPersonWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.person.person.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonPeople)
					Cascade(personPerson25, item, context);

			if (personPerson25.Count > 0)
				WithChild(personPerson25, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonBusinessEntity entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Store_BusinessEntity_BusinessEntityID
			if (entity.SalesStores != null && entity.SalesStores.Count > 0)
				foreach (var rel in entity.SalesStores)
					rel.SalesStore = entity.Id;

			//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
			if (entity.PersonBusinessEntityAddresses != null && entity.PersonBusinessEntityAddresses.Count > 0)
				foreach (var rel in entity.PersonBusinessEntityAddresses)
					rel.PersonBusinessEntityAddress = entity.Id;

			//From Foreign Key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID
			if (entity.PersonBusinessEntityContacts != null && entity.PersonBusinessEntityContacts.Count > 0)
				foreach (var rel in entity.PersonBusinessEntityContacts)
					rel.PersonBusinessEntityContact = entity.Id;

			//From Foreign Key FK_Vendor_BusinessEntity_BusinessEntityID
			if (entity.PurchasingVendors != null && entity.PurchasingVendors.Count > 0)
				foreach (var rel in entity.PurchasingVendors)
					rel.PurchasingVendor = entity.Id;

			//From Foreign Key FK_Person_BusinessEntity_BusinessEntityID
			if (entity.PersonPeople != null && entity.PersonPeople.Count > 0)
				foreach (var rel in entity.PersonPeople)
					rel.PersonPerson = entity.Id;

				
		}

		protected override void RemoveRelations(PersonBusinessEntity entity, ScriptContext context)
        {
					//From Foreign Key FK_Store_BusinessEntity_BusinessEntityID
			var salesStore31 = GetSalesStoreWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.sales.store.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesStores)
					CascadeDelete(salesStore31, item, context);

			if (salesStore31.Count > 0)
				WithChild(salesStore31, entity);

					//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
			var personBusinessEntityAddress32 = GetPersonBusinessEntityAddressWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.person.businessentityaddress.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityAddresses)
					CascadeDelete(personBusinessEntityAddress32, item, context);

			if (personBusinessEntityAddress32.Count > 0)
				WithChild(personBusinessEntityAddress32, entity);

					//From Foreign Key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID
			var personBusinessEntityContact33 = GetPersonBusinessEntityContactWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.person.businessentitycontact.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityContacts)
					CascadeDelete(personBusinessEntityContact33, item, context);

			if (personBusinessEntityContact33.Count > 0)
				WithChild(personBusinessEntityContact33, entity);

					//From Foreign Key FK_Vendor_BusinessEntity_BusinessEntityID
			var purchasingVendor34 = GetPurchasingVendorWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.purchasing.vendor.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PurchasingVendors)
					CascadeDelete(purchasingVendor34, item, context);

			if (purchasingVendor34.Count > 0)
				WithChild(purchasingVendor34, entity);

					//From Foreign Key FK_Person_BusinessEntity_BusinessEntityID
			var personPerson35 = GetPersonPersonWriter();
			if (_cascades.Contains(PersonBusinessEntityCascadeNames.person.person.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonPeople)
					CascadeDelete(personPerson35, item, context);

			if (personPerson35.Count > 0)
				WithChild(personPerson35, entity);

				}
	}
}
		