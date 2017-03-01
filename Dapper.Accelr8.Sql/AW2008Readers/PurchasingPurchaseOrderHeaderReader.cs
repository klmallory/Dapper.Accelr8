
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
    public class PurchasingPurchaseOrderHeaderReader : EntityReader<int, PurchasingPurchaseOrderHeader>
    {
        public PurchasingPurchaseOrderHeaderReader(
            PurchasingPurchaseOrderHeaderTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 3
		static IEntityReader<int , PurchasingPurchaseOrderDetail> _purchasingPurchaseOrderDetailReader;
		protected static IEntityReader<int , PurchasingPurchaseOrderDetail> GetPurchasingPurchaseOrderDetailReader()
		{
			return _locator.Resolve<IEntityReader<int , PurchasingPurchaseOrderDetail>>();
		}

		
		/// <summary>
		/// Sets the children of type PurchasingPurchaseOrderDetail on the parent on PurchasingPurchaseOrderDetails.
		/// From foriegn key FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPurchasingPurchaseOrderDetails(IList<PurchasingPurchaseOrderHeader> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PurchasingPurchaseOrderDetail

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PurchasingPurchaseOrderDetail>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PurchasingPurchaseOrderDetails = typedChildren.Where(b => b.PurchasingPurchaseOrderDetail == r.Id).ToList();
				r.PurchasingPurchaseOrderDetails.ToList().ForEach(b => { b.Loaded = false; b.PurchasingPurchaseOrderHeader = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Purchasing.PurchaseOrderHeader into class PurchasingPurchaseOrderHeader
		/// </summary>
		/// <param name="results">PurchasingPurchaseOrderHeader</param>
		/// <param name="row"></param>
        public override PurchasingPurchaseOrderHeader LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PurchasingPurchaseOrderHeader();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.RevisionNumber = GetRowData<byte>(dataRow, "RevisionNumber"); 
      		domain.Status = GetRowData<byte>(dataRow, "Status"); 
      		domain.EmployeeID = GetRowData<int>(dataRow, "EmployeeID"); 
      		domain.VendorID = GetRowData<int>(dataRow, "VendorID"); 
      		domain.ShipMethodID = GetRowData<int>(dataRow, "ShipMethodID"); 
      		domain.OrderDate = GetRowData<DateTime>(dataRow, "OrderDate"); 
      		domain.ShipDate = GetRowData<DateTime?>(dataRow, "ShipDate"); 
      		domain.SubTotal = GetRowData<decimal>(dataRow, "SubTotal"); 
      		domain.TaxAmt = GetRowData<decimal>(dataRow, "TaxAmt"); 
      		domain.Freight = GetRowData<decimal>(dataRow, "Freight"); 
      		domain.TotalDue = GetRowData<decimal>(dataRow, "TotalDue"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PurchasingPurchaseOrderHeader></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PurchasingPurchaseOrderHeader> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPurchasingPurchaseOrderDetailReader(), id, IdColumn, SetChildrenPurchasingPurchaseOrderDetails);
			
            return this;
        }

        public override void SetAllChildrenForExisting(PurchasingPurchaseOrderHeader entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPurchasingPurchaseOrderDetailReader(), entity.Id
				, PurchasingPurchaseOrderDetailColumnNames.PurchaseOrderID.ToString()
				, SetChildrenPurchasingPurchaseOrderDetails);

			QueryResultForChildrenOnly(new List<PurchasingPurchaseOrderHeader>() { entity });
			entity.Loaded = false;
			GetPurchasingPurchaseOrderDetailReader().SetAllChildrenForExisting(entity.PurchasingPurchaseOrderDetails);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PurchasingPurchaseOrderHeader> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPurchasingPurchaseOrderDetailReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PurchasingPurchaseOrderDetailColumnNames.PurchaseOrderID.ToString()
				, SetChildrenPurchasingPurchaseOrderDetails);

					
			QueryResultForChildrenOnly(entities);

			GetPurchasingPurchaseOrderDetailReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PurchasingPurchaseOrderDetails).ToList());
					
		}
    }
}
		