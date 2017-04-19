
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
    public class PurchasingProductVendorReader : EntityReader<CompoundKey, PurchasingProductVendor>
    {
        public PurchasingProductVendorReader(
            PurchasingProductVendorTableInfo tableInfo
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
		//Parent Count 3
		
			/// <summary>
		/// Loads the table Purchasing.ProductVendor into class PurchasingProductVendor
		/// </summary>
		/// <param name="results">PurchasingProductVendor</param>
		/// <param name="row"></param>
        public override PurchasingProductVendor LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PurchasingProductVendor();
			domain.Loaded = false;

			domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.AverageLeadTime = GetRowData<int>(dataRow, "AverageLeadTime"); 
      		domain.StandardPrice = GetRowData<decimal>(dataRow, "StandardPrice"); 
      		domain.LastReceiptCost = GetRowData<decimal?>(dataRow, "LastReceiptCost"); 
      		domain.LastReceiptDate = GetRowData<DateTime?>(dataRow, "LastReceiptDate"); 
      		domain.MinOrderQty = GetRowData<int>(dataRow, "MinOrderQty"); 
      		domain.MaxOrderQty = GetRowData<int>(dataRow, "MaxOrderQty"); 
      		domain.OnOrderQty = GetRowData<int?>(dataRow, "OnOrderQty"); 
      		domain.UnitMeasureCode = GetRowData<string>(dataRow, "UnitMeasureCode"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      				domain.Id = PurchasingProductVendor.GetCompoundKeyFor(domain); 
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified CompoundKey Id.
		/// </summary>
		/// <param name="results">IEntityReader<CompoundKey, PurchasingProductVendor></param>
		/// <param name="id">CompoundKey</param>
        public override IEntityReader<CompoundKey, PurchasingProductVendor> WithAllChildrenForExisting(PurchasingProductVendor existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(PurchasingProductVendor entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PurchasingProductVendor> entities)
        {
					
		}
    }
}
		