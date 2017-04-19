
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
    public class SalesSalesOrderDetailReader : EntityReader<CompoundKey, SalesSalesOrderDetail>
    {
        public SalesSalesOrderDetailReader(
            SalesSalesOrderDetailTableInfo tableInfo
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

		//Child Count 0
		//Parent Count 2
		
			/// <summary>
		/// Loads the table Sales.SalesOrderDetail into class SalesSalesOrderDetail
		/// </summary>
		/// <param name="results">SalesSalesOrderDetail</param>
		/// <param name="row"></param>
        public override SalesSalesOrderDetail LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSalesOrderDetail();
			domain.Loaded = false;

			domain.SalesOrderID = GetRowData<int>(dataRow, "SalesOrderID"); 
      		domain.SalesOrderDetailID = GetRowData<int>(dataRow, "SalesOrderDetailID"); 
      		domain.CarrierTrackingNumber = GetRowData<string>(dataRow, "CarrierTrackingNumber"); 
      		domain.OrderQty = GetRowData<short>(dataRow, "OrderQty"); 
      		domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.SpecialOfferID = GetRowData<int>(dataRow, "SpecialOfferID"); 
      		domain.UnitPrice = GetRowData<decimal>(dataRow, "UnitPrice"); 
      		domain.UnitPriceDiscount = GetRowData<decimal>(dataRow, "UnitPriceDiscount"); 
      		domain.LineTotal = GetRowData<decimal>(dataRow, "LineTotal"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      				domain.Id = SalesSalesOrderDetail.GetCompoundKeyFor(domain); 
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified CompoundKey Id.
		/// </summary>
		/// <param name="results">IEntityReader<CompoundKey, SalesSalesOrderDetail></param>
		/// <param name="id">CompoundKey</param>
        public override IEntityReader<CompoundKey, SalesSalesOrderDetail> WithAllChildrenForExisting(SalesSalesOrderDetail existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesSalesOrderDetail entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesOrderDetail> entities)
        {
					
		}
    }
}
		