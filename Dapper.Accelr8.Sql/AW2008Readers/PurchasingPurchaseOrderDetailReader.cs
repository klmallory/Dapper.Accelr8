
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
    public class PurchasingPurchaseOrderDetailReader : EntityReader<int, PurchasingPurchaseOrderDetail>
    {
        public PurchasingPurchaseOrderDetailReader(
            PurchasingPurchaseOrderDetailTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 0
		//Parent Count 2
		
			/// <summary>
		/// Loads the table Purchasing.PurchaseOrderDetail into class PurchasingPurchaseOrderDetail
		/// </summary>
		/// <param name="results">PurchasingPurchaseOrderDetail</param>
		/// <param name="row"></param>
        public override PurchasingPurchaseOrderDetail LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PurchasingPurchaseOrderDetail();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.DueDate = GetRowData<DateTime>(dataRow, "DueDate"); 
      		domain.OrderQty = GetRowData<short>(dataRow, "OrderQty"); 
      		domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.UnitPrice = GetRowData<decimal>(dataRow, "UnitPrice"); 
      		domain.LineTotal = GetRowData<decimal>(dataRow, "LineTotal"); 
      		domain.ReceivedQty = GetRowData<decimal>(dataRow, "ReceivedQty"); 
      		domain.RejectedQty = GetRowData<decimal>(dataRow, "RejectedQty"); 
      		domain.StockedQty = GetRowData<decimal>(dataRow, "StockedQty"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PurchasingPurchaseOrderDetail></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PurchasingPurchaseOrderDetail> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(PurchasingPurchaseOrderDetail entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PurchasingPurchaseOrderDetail> entities)
        {
					
		}
    }
}
		