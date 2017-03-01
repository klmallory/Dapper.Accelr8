
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
        { }

		//Child Count 3
		//Parent Count 1
		static IEntityReader<int , PersonBusinessEntityAddress> _personBusinessEntityAddressReader;
		protected static IEntityReader<int , PersonBusinessEntityAddress> GetPersonBusinessEntityAddressReader()
		{
			return _locator.Resolve<IEntityReader<int , PersonBusinessEntityAddress>>();
		}

		static IEntityReader<int , SalesSalesOrderHeader> _salesSalesOrderHeaderReader;
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesOrderHeader>>();
		}

		
		/// <summary>
		/// Sets the children of type PersonBusinessEntityAddress on the parent on PersonBusinessEntityAddresses.
		/// From foriegn key FK_BusinessEntityAddress_Address_AddressID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityAddresses(IList<PersonAddress> results, IList<object> children)
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
		public void SetChildrenSalesSalesOrderHeaders(IList<PersonAddress> results, IList<object> children)
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
				r.SalesSalesOrderHeaders = typedChildren.Where(b => b.SalesSalesOrderHeader == r.Id).ToList();
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.PersonAddress = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_Address_ShipToAddressID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders(IList<PersonAddress> results, IList<object> children)
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
				r.SalesSalesOrderHeaders = typedChildren.Where(b => b.SalesSalesOrderHeader == r.Id).ToList();
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.PersonAddress = r; b.Loaded = true; });
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
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
        public override IEntityReader<int, PersonAddress> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPersonBusinessEntityAddressReader(), id, IdColumn, SetChildrenPersonBusinessEntityAddresses);
			
			WithChildForParentId(GetSalesSalesOrderHeaderReader(), id, IdColumn, SetChildrenSalesSalesOrderHeaders);
			
			WithChildForParentId(GetSalesSalesOrderHeaderReader(), id, IdColumn, SetChildrenSalesSalesOrderHeaders);
			
            return this;
        }

        public override void SetAllChildrenForExisting(PersonAddress entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPersonBusinessEntityAddressReader(), entity.Id
				, PersonBusinessEntityAddressColumnNames.AddressID.ToString()
				, SetChildrenPersonBusinessEntityAddresses);

			WithChildForParentId(GetSalesSalesOrderHeaderReader(), entity.Id
				, SalesSalesOrderHeaderColumnNames.BillToAddressID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentId(GetSalesSalesOrderHeaderReader(), entity.Id
				, SalesSalesOrderHeaderColumnNames.ShipToAddressID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

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

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPersonBusinessEntityAddressReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PersonBusinessEntityAddressColumnNames.AddressID.ToString()
				, SetChildrenPersonBusinessEntityAddresses);

			WithChildForParentIds(GetSalesSalesOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderHeaderColumnNames.BillToAddressID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentIds(GetSalesSalesOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderHeaderColumnNames.ShipToAddressID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

					
			QueryResultForChildrenOnly(entities);

			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityAddresses).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
					
		}
    }
}
		