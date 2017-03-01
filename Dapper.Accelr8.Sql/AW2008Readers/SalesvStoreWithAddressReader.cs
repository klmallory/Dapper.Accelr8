
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
    public class SalesvStoreWithAddressReader : EntityReader<int, SalesvStoreWithAddress>
    {
        public SalesvStoreWithAddressReader(
            SalesvStoreWithAddressTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 0
		//Parent Count 0
		
			/// <summary>
		/// Loads the table Sales.vStoreWithAddresses into class SalesvStoreWithAddress
		/// </summary>
		/// <param name="results">SalesvStoreWithAddress</param>
		/// <param name="row"></param>
        public override SalesvStoreWithAddress LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesvStoreWithAddress();
			domain.Loaded = false;

				domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.AddressType = GetRowData<object>(dataRow, "AddressType"); 
      		domain.AddressLine1 = GetRowData<string>(dataRow, "AddressLine1"); 
      		domain.AddressLine2 = GetRowData<string>(dataRow, "AddressLine2"); 
      		domain.City = GetRowData<string>(dataRow, "City"); 
      		domain.StateProvinceName = GetRowData<object>(dataRow, "StateProvinceName"); 
      		domain.PostalCode = GetRowData<string>(dataRow, "PostalCode"); 
      		domain.CountryRegionName = GetRowData<object>(dataRow, "CountryRegionName"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesvStoreWithAddress></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesvStoreWithAddress> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesvStoreWithAddress entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesvStoreWithAddress> entities)
        {
					
		}
    }
}
		