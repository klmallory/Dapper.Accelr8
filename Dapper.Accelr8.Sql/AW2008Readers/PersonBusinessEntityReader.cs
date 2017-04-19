
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
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 5
		//Parent Count 0
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PersonBusinessEntityAddress> GetPersonBusinessEntityAddressReader()
		{
			return s_loc8r.GetReader<CompoundKey , PersonBusinessEntityAddress>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PersonBusinessEntityContact> GetPersonBusinessEntityContactReader()
		{
			return s_loc8r.GetReader<CompoundKey , PersonBusinessEntityContact>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , PersonPerson> GetPersonPersonReader()
		{
			return s_loc8r.GetReader<int , PersonPerson>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesStore> GetSalesStoreReader()
		{
			return s_loc8r.GetReader<int , SalesStore>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , PurchasingVendor> GetPurchasingVendorReader()
		{
			return s_loc8r.GetReader<int , PurchasingVendor>();
		}

		
		/// <summary>
		/// Sets the children of type PersonBusinessEntityAddress on the parent on PersonBusinessEntityAddresses.
		/// From foriegn key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityAddresses(IList<PersonBusinessEntity> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: PersonBusinessEntityAddress

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonBusinessEntityAddress>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PersonBusinessEntityAddresses = typedChildren.Where(b =>  b.BusinessEntityID == r.Id ).ToList();
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
			//Child Id Type: CompoundKey
			//Child Type: PersonBusinessEntityContact

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonBusinessEntityContact>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PersonBusinessEntityContacts = typedChildren.Where(b =>  b.BusinessEntityID == r.Id ).ToList();
				r.PersonBusinessEntityContacts.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				
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
				

				r.PersonPeople = typedChildren.Where(b =>  b.Id == r.Id ).ToList();
				r.PersonPeople.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
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
				

				r.SalesStores = typedChildren.Where(b =>  b.Id == r.Id ).ToList();
				r.SalesStores.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				
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
				

				r.PurchasingVendors = typedChildren.Where(b =>  b.Id == r.Id ).ToList();
				r.PurchasingVendors.ToList().ForEach(b => { b.Loaded = false; b.PersonBusinessEntity = r; b.Loaded = true; });
				
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

			domain.Id = GetRowData<int>(dataRow, "BusinessEntityID"); 
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
        public override IEntityReader<int, PersonBusinessEntity> WithAllChildrenForExisting(PersonBusinessEntity existing)
        {
						WithChildForParentValues(GetPersonBusinessEntityAddressReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonBusinessEntityAddresses);
						WithChildForParentValues(GetPersonBusinessEntityContactReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonBusinessEntityContacts);
						WithChildForParentValues(GetPersonPersonReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenPersonPeople);
						WithChildForParentValues(GetSalesStoreReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenSalesStores);
						WithChildForParentValues(GetPurchasingVendorReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenPurchasingVendors);
			
            return this;
        }


        public override void SetAllChildrenForExisting(PersonBusinessEntity entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetPersonBusinessEntityAddressReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonBusinessEntityAddresses);

						WithChildForParentValues(GetPersonBusinessEntityContactReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonBusinessEntityContacts);

						WithChildForParentValues(GetPersonPersonReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenPersonPeople);

						WithChildForParentValues(GetSalesStoreReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenSalesStores);

						WithChildForParentValues(GetPurchasingVendorReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenPurchasingVendors);

			
QueryResultForChildrenOnly(new List<PersonBusinessEntity>() { entity });
			entity.Loaded = false;
			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entity.PersonBusinessEntityAddresses);
			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entity.PersonBusinessEntityContacts);
			GetPersonPersonReader().SetAllChildrenForExisting(entity.PersonPeople);
			GetSalesStoreReader().SetAllChildrenForExisting(entity.SalesStores);
			GetPurchasingVendorReader().SetAllChildrenForExisting(entity.PurchasingVendors);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonBusinessEntity> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetPersonBusinessEntityAddressReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonBusinessEntityAddresses);

			WithChildForParentsValues(GetPersonBusinessEntityContactReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonBusinessEntityContacts);

			WithChildForParentsValues(GetPersonPersonReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "Id",  }
				, SetChildrenPersonPeople);

			WithChildForParentsValues(GetSalesStoreReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "Id",  }
				, SetChildrenSalesStores);

			WithChildForParentsValues(GetPurchasingVendorReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "Id",  }
				, SetChildrenPurchasingVendors);

					
			QueryResultForChildrenOnly(entities);

			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityAddresses).ToList());
			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityContacts).ToList());
			GetPersonPersonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonPeople).ToList());
			GetSalesStoreReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesStores).ToList());
			GetPurchasingVendorReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingVendors).ToList());
					
		}
    }
}
		