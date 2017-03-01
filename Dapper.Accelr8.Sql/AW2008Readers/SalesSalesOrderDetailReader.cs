
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
    public class SalesSalesOrderDetailReader : EntityReader<int, SalesSalesOrderDetail>
    {
        public SalesSalesOrderDetailReader(
            SalesSalesOrderDetailTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 0
		//Parent Count 3
		
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.CarrierTrackingNumber = GetRowData<string>(dataRow, "CarrierTrackingNumber"); 
      		domain.OrderQty = GetRowData<short>(dataRow, "OrderQty"); 
      		domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.SpecialOfferID = GetRowData<int>(dataRow, "SpecialOfferID"); 
      		domain.UnitPrice = GetRowData<decimal>(dataRow, "UnitPrice"); 
      		domain.UnitPriceDiscount = GetRowData<decimal>(dataRow, "UnitPriceDiscount"); 
      		domain.LineTotal = GetRowData<decimal>(dataRow, "LineTotal"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSalesOrderDetail></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSalesOrderDetail> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
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
		