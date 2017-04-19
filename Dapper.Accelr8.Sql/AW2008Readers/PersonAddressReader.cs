
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
    public class PersonAddressReader : EntityReader<int, PersonAddress>
    {
        public PersonAddressReader(
            PersonAddressTableInfo tableInfo
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

		//Child Count 3
		//Parent Count 1
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PersonBusinessEntityAddress> GetPersonBusinessEntityAddressReader()
		{
			return s_loc8r.GetReader<CompoundKey , PersonBusinessEntityAddress>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return s_loc8r.GetReader<int , SalesSalesOrderHeader>();
		}

		
		/// <summary>
		/// Sets the children of type PersonBusinessEntityAddress on the parent on PersonBusinessEntityAddresses.
		/// From foriegn key FK_BusinessEntityAddress_Address_AddressID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityAddresses(IList<PersonAddress> results, IList<object> children)
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
				

				r.PersonBusinessEntityAddresses = typedChildren.Where(b =>  b.AddressID == r.Id ).ToList();
				r.PersonBusinessEntityAddresses.ToList().ForEach(b => { b.Loaded = false; b.PersonAddress = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_Address_BillToAddressID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders1(IList<PersonAddress> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesOrderHeader

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderHeader>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesOrderHeaders1 = typedChildren.Where(b =>  b.BillToAddressID == r.Id ).ToList();
				r.SalesSalesOrderHeaders1.ToList().ForEach(b => { b.Loaded = false; b.PersonAddress1 = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_Address_ShipToAddressID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders2(IList<PersonAddress> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesOrderHeader

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderHeader>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesOrderHeaders2 = typedChildren.Where(b =>  b.ShipToAddressID == r.Id ).ToList();
				r.SalesSalesOrderHeaders2.ToList().ForEach(b => { b.Loaded = false; b.PersonAddress2 = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Person.Address into class PersonAddress
		/// </summary>
		/// <param name="results">PersonAddress</param>
		/// <param name="row"></param>
        public override PersonAddress LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonAddress();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "AddressID"); 
      		domain.AddressLine1 = GetRowData<string>(dataRow, "AddressLine1"); 
      		domain.AddressLine2 = GetRowData<string>(dataRow, "AddressLine2"); 
      		domain.City = GetRowData<string>(dataRow, "City"); 
      		domain.StateProvinceID = GetRowData<int>(dataRow, "StateProvinceID"); 
      		domain.PostalCode = GetRowData<string>(dataRow, "PostalCode"); 
      		domain.SpatialLocation = GetRowData<object>(dataRow, "SpatialLocation"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PersonAddress></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonAddress> WithAllChildrenForExisting(PersonAddress existing)
        {
						WithChildForParentValues(GetPersonBusinessEntityAddressReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "AddressID",  }
				, SetChildrenPersonBusinessEntityAddresses);
						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BillToAddressID",  }
				, SetChildrenSalesSalesOrderHeaders1);
						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ShipToAddressID",  }
				, SetChildrenSalesSalesOrderHeaders2);
			
            return this;
        }


        public override void SetAllChildrenForExisting(PersonAddress entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetPersonBusinessEntityAddressReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "AddressID",  }
				, SetChildrenPersonBusinessEntityAddresses);

						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BillToAddressID",  }
				, SetChildrenSalesSalesOrderHeaders1);

						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ShipToAddressID",  }
				, SetChildrenSalesSalesOrderHeaders2);

			
QueryResultForChildrenOnly(new List<PersonAddress>() { entity });
			entity.Loaded = false;
			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entity.PersonBusinessEntityAddresses);
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonAddress> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetPersonBusinessEntityAddressReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "AddressID",  }
				, SetChildrenPersonBusinessEntityAddresses);

			WithChildForParentsValues(GetSalesSalesOrderHeaderReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BillToAddressID",  }
				, SetChildrenSalesSalesOrderHeaders1);

			WithChildForParentsValues(GetSalesSalesOrderHeaderReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ShipToAddressID",  }
				, SetChildrenSalesSalesOrderHeaders2);

					
			QueryResultForChildrenOnly(entities);

			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityAddresses).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders1).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders2).ToList());
					
		}
    }
}
		