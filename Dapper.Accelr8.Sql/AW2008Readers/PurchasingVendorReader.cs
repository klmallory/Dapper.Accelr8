
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
    public class PurchasingVendorReader : EntityReader<int, PurchasingVendor>
    {
        public PurchasingVendorReader(
            PurchasingVendorTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 2
		//Parent Count 1
		static IEntityReader<int , PurchasingProductVendor> _purchasingProductVendorReader;
		protected static IEntityReader<int , PurchasingProductVendor> GetPurchasingProductVendorReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingProductVendor>>();
		}

		static IEntityReader<int , PurchasingPurchaseOrderHeader> _purchasingPurchaseOrderHeaderReader;
		protected static IEntityReader<int , PurchasingPurchaseOrderHeader> GetPurchasingPurchaseOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingPurchaseOrderHeader>>();
		}

		
		/// <summary>
		/// Sets the children of type PurchasingProductVendor on the parent on PurchasingProductVendors.
		/// From foriegn key FK_ProductVendor_Vendor_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingProductVendors(IList<PurchasingVendor> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PurchasingProductVendor

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingProductVendor>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PurchasingProductVendors = typedChildren.Where(b => b.PurchasingProductVendor == r.Id).ToList();
				r.PurchasingProductVendors.ToList().ForEach(b => { b.Loaded = false; b.PurchasingVendor = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PurchasingPurchaseOrderHeader on the parent on PurchasingPurchaseOrderHeaders.
		/// From foriegn key FK_PurchaseOrderHeader_Vendor_VendorID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingPurchaseOrderHeaders(IList<PurchasingVendor> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PurchasingPurchaseOrderHeader

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingPurchaseOrderHeader>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PurchasingPurchaseOrderHeaders = typedChildren.Where(b => b.PurchasingPurchaseOrderHeader == r.Id).ToList();
				r.PurchasingPurchaseOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.PurchasingVendor = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Purchasing.Vendor into class PurchasingVendor
		/// </summary>
		/// <param name="results">PurchasingVendor</param>
		/// <param name="row"></param>
        public override PurchasingVendor LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PurchasingVendor();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.AccountNumber = GetRowData<object>(dataRow, "AccountNumber"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.CreditRating = GetRowData<byte>(dataRow, "CreditRating"); 
      		domain.PreferredVendorStatus = GetRowData<object>(dataRow, "PreferredVendorStatus"); 
      		domain.ActiveFlag = GetRowData<object>(dataRow, "ActiveFlag"); 
      		domain.PurchasingWebServiceURL = GetRowData<string>(dataRow, "PurchasingWebServiceURL"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PurchasingVendor></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PurchasingVendor> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPurchasingProductVendorReader(), id, IdColumn, SetChildrenPurchasingProductVendors);
			
			WithChildForParentId(GetPurchasingPurchaseOrderHeaderReader(), id, IdColumn, SetChildrenPurchasingPurchaseOrderHeaders);
			
            return this;
        }

        public override void SetAllChildrenForExisting(PurchasingVendor entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPurchasingProductVendorReader(), entity.Id
				, PurchasingProductVendorColumnNames.BusinessEntityID.ToString()
				, SetChildrenPurchasingProductVendors);

			WithChildForParentId(GetPurchasingPurchaseOrderHeaderReader(), entity.Id
				, PurchasingPurchaseOrderHeaderColumnNames.VendorID.ToString()
				, SetChildrenPurchasingPurchaseOrderHeaders);

			QueryResultForChildrenOnly(new List<PurchasingVendor>() { entity });
			entity.Loaded = false;
			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entity.PurchasingProductVendors);
			GetPurchasingPurchaseOrderHeaderReader().SetAllChildrenForExisting(entity.PurchasingPurchaseOrderHeaders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PurchasingVendor> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPurchasingProductVendorReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingProductVendorColumnNames.BusinessEntityID.ToString()
				, SetChildrenPurchasingProductVendors);

			WithChildForParentIds(GetPurchasingPurchaseOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingPurchaseOrderHeaderColumnNames.VendorID.ToString()
				, SetChildrenPurchasingPurchaseOrderHeaders);

					
			QueryResultForChildrenOnly(entities);

			GetPurchasingProductVendorReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingProductVendors).ToList());
			GetPurchasingPurchaseOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingPurchaseOrderHeaders).ToList());
					
		}
    }
}
		