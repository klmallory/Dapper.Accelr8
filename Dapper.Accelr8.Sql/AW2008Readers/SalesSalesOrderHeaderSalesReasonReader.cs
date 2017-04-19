
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
    public class SalesSalesOrderHeaderSalesReasonReader : EntityReader<CompoundKey, SalesSalesOrderHeaderSalesReason>
    {
        public SalesSalesOrderHeaderSalesReasonReader(
            SalesSalesOrderHeaderSalesReasonTableInfo tableInfo
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
		/// Loads the table Sales.SalesOrderHeaderSalesReason into class SalesSalesOrderHeaderSalesReason
		/// </summary>
		/// <param name="results">SalesSalesOrderHeaderSalesReason</param>
		/// <param name="row"></param>
        public override SalesSalesOrderHeaderSalesReason LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSalesOrderHeaderSalesReason();
			domain.Loaded = false;

			domain.SalesOrderID = GetRowData<int>(dataRow, "SalesOrderID"); 
      		domain.SalesReasonID = GetRowData<int>(dataRow, "SalesReasonID"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      				domain.Id = SalesSalesOrderHeaderSalesReason.GetCompoundKeyFor(domain); 
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified CompoundKey Id.
		/// </summary>
		/// <param name="results">IEntityReader<CompoundKey, SalesSalesOrderHeaderSalesReason></param>
		/// <param name="id">CompoundKey</param>
        public override IEntityReader<CompoundKey, SalesSalesOrderHeaderSalesReason> WithAllChildrenForExisting(SalesSalesOrderHeaderSalesReason existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesSalesOrderHeaderSalesReason entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesOrderHeaderSalesReason> entities)
        {
					
		}
    }
}
		