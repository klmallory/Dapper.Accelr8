
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

namespace Dapper.Accelr8.AW2008Readers
{
    public class PersonBusinessEntityReader : EntityReader<int, PersonBusinessEntity>
    {
        public PersonBusinessEntityReader(
            PersonBusinessEntityTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 5
		//Parent Count 0
		static IEntityReader<int , SalesStore> _salesStoreReader;
		protected static IEntityReader<int , SalesStore> GetSalesStoreReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesStore>>();
		}

		static IEntityReader<int , PersonBusinessEntityAddress> _personBusinessEntityAddressReader;
		protected static IEntityReader<int , PersonBusinessEntityAddress> GetPersonBusinessEntityAddressReader()
		{
			return _locator.Resolve<IEntityReader<int , PersonBusinessEntityAddress>>();
		}

		static IEntityReader<int , PersonBusinessEntityContact> _personBusinessEntityContactReader;
		protected static IEntityReader<int , PersonBusinessEntityContact> GetPersonBusinessEntityContactReader()
		{
			return _locator.Resolve<IEntityReader<int , PersonBusinessEntityContact>>();
		}

		static IEntityReader<int , PurchasingVendor> _purchasingVendorReader;
		protected static IEntityReader<int , PurchasingVendor> GetPurchasingVendorReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingVendor>>();
		}

		static IEntityReader<int , PersonPerson> _personPersonReader;
		protected static IEntityReader<int , PersonPerson> GetPersonPersonReader()
		{
			return _locator.Resolve<IEntityReader<int , PersonPerson>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesStore on the parent on SalesStores.
		/// From foriegn key FK_Store_BusinessEntity_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesStores(IList<PersonBusinessEntity> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesStore

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesStore>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesStores = typedChildren.Where(b => b.SalesStore == r.Id).ToList();
				r.SalesStores.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PersonBusinessEntityAddress on the parent on PersonBusinessEntityAddresses.
		/// From foriegn key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityAddresses(IList<PersonBusinessEntity> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonBusinessEntityAddress

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonBusinessEntityAddress>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PersonBusinessEntityAddresses = typedChildren.Where(b => b.PersonBusinessEntityAddress == r.Id).ToList();
				r.PersonBusinessEntityAddresses.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PersonBusinessEntityContact on the parent on PersonBusinessEntityContacts.
		/// From foriegn key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityContacts(IList<PersonBusinessEntity> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonBusinessEntityContact

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonBusinessEntityContact>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PersonBusinessEntityContacts = typedChildren.Where(b => b.PersonBusinessEntityContact == r.Id).ToList();
				r.PersonBusinessEntityContacts.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PurchasingVendor on the parent on PurchasingVendors.
		/// From foriegn key FK_Vendor_BusinessEntity_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingVendors(IList<PersonBusinessEntity> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PurchasingVendor

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingVendor>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PurchasingVendors = typedChildren.Where(b => b.PurchasingVendor == r.Id).ToList();
				r.PurchasingVendors.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PersonPerson on the parent on PersonPeople.
		/// From foriegn key FK_Person_BusinessEntity_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonPeople(IList<PersonBusinessEntity> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonPerson

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonPerson>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PersonPeople = typedChildren.Where(b => b.PersonPerson == r.Id).ToList();
				r.PersonPeople.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Person.BusinessEntity into class PersonBusinessEntity
		/// </summary>
		/// <param name="results">PersonBusinessEntity</param>
		/// <param name="row"></param>
        public override PersonBusinessEntity LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonBusinessEntity();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PersonBusinessEntity></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonBusinessEntity> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesStoreReader(), id, IdColumn, SetChildrenSalesStores);
			
			WithChildForParentId(GetPersonBusinessEntityAddressReader(), id, IdColumn, SetChildrenPersonBusinessEntityAddresses);
			
			WithChildForParentId(GetPersonBusinessEntityContactReader(), id, IdColumn, SetChildrenPersonBusinessEntityContacts);
			
			WithChildForParentId(GetPurchasingVendorReader(), id, IdColumn, SetChildrenPurchasingVendors);
			
			WithChildForParentId(GetPersonPersonReader(), id, IdColumn, SetChildrenPersonPeople);
			
            return this;
        }

        public override void SetAllChildrenForExisting(PersonBusinessEntity entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesStoreReader(), entity.Id
				, SalesStoreColumnNames.BusinessEntityID.ToString()
				, SetChildrenSalesStores);

			WithChildForParentId(GetPersonBusinessEntityAddressReader(), entity.Id
				, PersonBusinessEntityAddressColumnNames.BusinessEntityID.ToString()
				, SetChildrenPersonBusinessEntityAddresses);

			WithChildForParentId(GetPersonBusinessEntityContactReader(), entity.Id
				, PersonBusinessEntityContactColumnNames.BusinessEntityID.ToString()
				, SetChildrenPersonBusinessEntityContacts);

			WithChildForParentId(GetPurchasingVendorReader(), entity.Id
				, PurchasingVendorColumnNames.BusinessEntityID.ToString()
				, SetChildrenPurchasingVendors);

			WithChildForParentId(GetPersonPersonReader(), entity.Id
				, PersonPersonColumnNames.BusinessEntityID.ToString()
				, SetChildrenPersonPeople);

			QueryResultForChildrenOnly(new List<PersonBusinessEntity>() { entity });
			entity.Loaded = false;
			GetSalesStoreReader().SetAllChildrenForExisting(entity.SalesStores);
			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entity.PersonBusinessEntityAddresses);
			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entity.PersonBusinessEntityContacts);
			GetPurchasingVendorReader().SetAllChildrenForExisting(entity.PurchasingVendors);
			GetPersonPersonReader().SetAllChildrenForExisting(entity.PersonPeople);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonBusinessEntity> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesStoreReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesStoreColumnNames.BusinessEntityID.ToString()
				, SetChildrenSalesStores);

			WithChildForParentIds(GetPersonBusinessEntityAddressReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PersonBusinessEntityAddressColumnNames.BusinessEntityID.ToString()
				, SetChildrenPersonBusinessEntityAddresses);

			WithChildForParentIds(GetPersonBusinessEntityContactReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PersonBusinessEntityContactColumnNames.BusinessEntityID.ToString()
				, SetChildrenPersonBusinessEntityContacts);

			WithChildForParentIds(GetPurchasingVendorReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingVendorColumnNames.BusinessEntityID.ToString()
				, SetChildrenPurchasingVendors);

			WithChildForParentIds(GetPersonPersonReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PersonPersonColumnNames.BusinessEntityID.ToString()
				, SetChildrenPersonPeople);

					
			QueryResultForChildrenOnly(entities);

			GetSalesStoreReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesStores).ToList());
			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityAddresses).ToList());
			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityContacts).ToList());
			GetPurchasingVendorReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingVendors).ToList());
			GetPersonPersonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonPeople).ToList());
					
		}
    }
}
		