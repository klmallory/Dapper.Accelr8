
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
    public class PurchasingShipMethodReader : EntityReader<int, PurchasingShipMethod>
    {
        public PurchasingShipMethodReader(
            PurchasingShipMethodTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 2
		//Parent Count 0
		static IEntityReader<int , PurchasingPurchaseOrderHeader> _purchasingPurchaseOrderHeaderReader;
		protected static IEntityReader<int , PurchasingPurchaseOrderHeader> GetPurchasingPurchaseOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingPurchaseOrderHeader>>();
		}

		static IEntityReader<int , SalesSalesOrderHeader> _salesSalesOrderHeaderReader;
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesOrderHeader>>();
		}

		
		/// <summary>
		/// Sets the children of type PurchasingPurchaseOrderHeader on the parent on PurchasingPurchaseOrderHeaders.
		/// From foriegn key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingPurchaseOrderHeaders(IList<PurchasingShipMethod> results, IList<object> children)
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
				r.PurchasingPurchaseOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.PurchasingShipMethod = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_ShipMethod_ShipMethodID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders(IList<PurchasingShipMethod> results, IList<object> children)
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
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.PurchasingShipMethod = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Purchasing.ShipMethod into class PurchasingShipMethod
		/// </summary>
		/// <param name="results">PurchasingShipMethod</param>
		/// <param name="row"></param>
        public override PurchasingShipMethod LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PurchasingShipMethod();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ShipBase = GetRowData<decimal>(dataRow, "ShipBase"); 
      		domain.ShipRate = GetRowData<decimal>(dataRow, "ShipRate"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PurchasingShipMethod></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PurchasingShipMethod> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPurchasingPurchaseOrderHeaderReader(), id, IdColumn, SetChildrenPurchasingPurchaseOrderHeaders);
			
			WithChildForParentId(GetSalesSalesOrderHeaderReader(), id, IdColumn, SetChildrenSalesSalesOrderHeaders);
			
            return this;
        }

        public override void SetAllChildrenForExisting(PurchasingShipMethod entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPurchasingPurchaseOrderHeaderReader(), entity.Id
				, PurchasingPurchaseOrderHeaderColumnNames.ShipMethodID.ToString()
				, SetChildrenPurchasingPurchaseOrderHeaders);

			WithChildForParentId(GetSalesSalesOrderHeaderReader(), entity.Id
				, SalesSalesOrderHeaderColumnNames.ShipMethodID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			QueryResultForChildrenOnly(new List<PurchasingShipMethod>() { entity });
			entity.Loaded = false;
			GetPurchasingPurchaseOrderHeaderReader().SetAllChildrenForExisting(entity.PurchasingPurchaseOrderHeaders);
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PurchasingShipMethod> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPurchasingPurchaseOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingPurchaseOrderHeaderColumnNames.ShipMethodID.ToString()
				, SetChildrenPurchasingPurchaseOrderHeaders);

			WithChildForParentIds(GetSalesSalesOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderHeaderColumnNames.ShipMethodID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

					
			QueryResultForChildrenOnly(entities);

			GetPurchasingPurchaseOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingPurchaseOrderHeaders).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
					
		}
    }
}
		