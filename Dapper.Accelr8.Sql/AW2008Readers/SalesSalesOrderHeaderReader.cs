
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
    public class SalesSalesOrderHeaderReader : EntityReader<int, SalesSalesOrderHeader>
    {
        public SalesSalesOrderHeaderReader(
            SalesSalesOrderHeaderTableInfo tableInfo
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

		//Child Count 2
		//Parent Count 8
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesSalesOrderDetail> GetSalesSalesOrderDetailReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesSalesOrderDetail>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesSalesOrderHeaderSalesReason> GetSalesSalesOrderHeaderSalesReasonReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesSalesOrderHeaderSalesReason>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSalesOrderDetail on the parent on SalesSalesOrderDetails.
		/// From foriegn key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderDetails(IList<SalesSalesOrderHeader> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesSalesOrderDetail

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderDetail>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesOrderDetails = typedChildren.Where(b =>  b.SalesOrderID == r.Id ).ToList();
				r.SalesSalesOrderDetails.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesOrderHeader = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesOrderHeaderSalesReason on the parent on SalesSalesOrderHeaderSalesReasons.
		/// From foriegn key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaderSalesReasons(IList<SalesSalesOrderHeader> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesSalesOrderHeaderSalesReason

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderHeaderSalesReason>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesOrderHeaderSalesReasons = typedChildren.Where(b =>  b.SalesOrderID == r.Id ).ToList();
				r.SalesSalesOrderHeaderSalesReasons.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesOrderHeader = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.SalesOrderHeader into class SalesSalesOrderHeader
		/// </summary>
		/// <param name="results">SalesSalesOrderHeader</param>
		/// <param name="row"></param>
        public override SalesSalesOrderHeader LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSalesOrderHeader();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "SalesOrderID"); 
      		domain.RevisionNumber = GetRowData<byte>(dataRow, "RevisionNumber"); 
      		domain.OrderDate = GetRowData<DateTime>(dataRow, "OrderDate"); 
      		domain.DueDate = GetRowData<DateTime>(dataRow, "DueDate"); 
      		domain.ShipDate = GetRowData<DateTime?>(dataRow, "ShipDate"); 
      		domain.Status = GetRowData<byte>(dataRow, "Status"); 
      		domain.OnlineOrderFlag = GetRowData<object>(dataRow, "OnlineOrderFlag"); 
      		domain.SalesOrderNumber = GetRowData<string>(dataRow, "SalesOrderNumber"); 
      		domain.PurchaseOrderNumber = GetRowData<object>(dataRow, "PurchaseOrderNumber"); 
      		domain.AccountNumber = GetRowData<object>(dataRow, "AccountNumber"); 
      		domain.CustomerID = GetRowData<int>(dataRow, "CustomerID"); 
      		domain.SalesPersonID = GetRowData<int?>(dataRow, "SalesPersonID"); 
      		domain.TerritoryID = GetRowData<int?>(dataRow, "TerritoryID"); 
      		domain.BillToAddressID = GetRowData<int>(dataRow, "BillToAddressID"); 
      		domain.ShipToAddressID = GetRowData<int>(dataRow, "ShipToAddressID"); 
      		domain.ShipMethodID = GetRowData<int>(dataRow, "ShipMethodID"); 
      		domain.CreditCardID = GetRowData<int?>(dataRow, "CreditCardID"); 
      		domain.CreditCardApprovalCode = GetRowData<string>(dataRow, "CreditCardApprovalCode"); 
      		domain.CurrencyRateID = GetRowData<int?>(dataRow, "CurrencyRateID"); 
      		domain.SubTotal = GetRowData<decimal>(dataRow, "SubTotal"); 
      		domain.TaxAmt = GetRowData<decimal>(dataRow, "TaxAmt"); 
      		domain.Freight = GetRowData<decimal>(dataRow, "Freight"); 
      		domain.TotalDue = GetRowData<decimal>(dataRow, "TotalDue"); 
      		domain.Comment = GetRowData<string>(dataRow, "Comment"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSalesOrderHeader></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSalesOrderHeader> WithAllChildrenForExisting(SalesSalesOrderHeader existing)
        {
						WithChildForParentValues(GetSalesSalesOrderDetailReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "SalesOrderID",  }
				, SetChildrenSalesSalesOrderDetails);
						WithChildForParentValues(GetSalesSalesOrderHeaderSalesReasonReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "SalesOrderID",  }
				, SetChildrenSalesSalesOrderHeaderSalesReasons);
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesSalesOrderHeader entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetSalesSalesOrderDetailReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "SalesOrderID",  }
				, SetChildrenSalesSalesOrderDetails);

						WithChildForParentValues(GetSalesSalesOrderHeaderSalesReasonReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "SalesOrderID",  }
				, SetChildrenSalesSalesOrderHeaderSalesReasons);

			
QueryResultForChildrenOnly(new List<SalesSalesOrderHeader>() { entity });
			entity.Loaded = false;
			GetSalesSalesOrderDetailReader().SetAllChildrenForExisting(entity.SalesSalesOrderDetails);
			GetSalesSalesOrderHeaderSalesReasonReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaderSalesReasons);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesOrderHeader> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetSalesSalesOrderDetailReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "SalesOrderID",  }
				, SetChildrenSalesSalesOrderDetails);

			WithChildForParentsValues(GetSalesSalesOrderHeaderSalesReasonReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "SalesOrderID",  }
				, SetChildrenSalesSalesOrderHeaderSalesReasons);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSalesOrderDetailReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderDetails).ToList());
			GetSalesSalesOrderHeaderSalesReasonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaderSalesReasons).ToList());
					
		}
    }
}
		