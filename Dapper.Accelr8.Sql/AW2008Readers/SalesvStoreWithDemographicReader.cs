
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
    public class SalesvStoreWithDemographicReader : EntityReader<int, SalesvStoreWithDemographic>
    {
        public SalesvStoreWithDemographicReader(
            SalesvStoreWithDemographicTableInfo tableInfo
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
		/// Loads the table Sales.vStoreWithDemographics into class SalesvStoreWithDemographic
		/// </summary>
		/// <param name="results">SalesvStoreWithDemographic</param>
		/// <param name="row"></param>
        public override SalesvStoreWithDemographic LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesvStoreWithDemographic();
			domain.Loaded = false;

				domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.AnnualSales = GetRowData<decimal?>(dataRow, "AnnualSales"); 
      		domain.AnnualRevenue = GetRowData<decimal?>(dataRow, "AnnualRevenue"); 
      		domain.BankName = GetRowData<string>(dataRow, "BankName"); 
      		domain.BusinessType = GetRowData<string>(dataRow, "BusinessType"); 
      		domain.YearOpened = GetRowData<int?>(dataRow, "YearOpened"); 
      		domain.Specialty = GetRowData<string>(dataRow, "Specialty"); 
      		domain.SquareFeet = GetRowData<int?>(dataRow, "SquareFeet"); 
      		domain.Brands = GetRowData<string>(dataRow, "Brands"); 
      		domain.Internet = GetRowData<string>(dataRow, "Internet"); 
      		domain.NumberEmployees = GetRowData<int?>(dataRow, "NumberEmployees"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesvStoreWithDemographic></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesvStoreWithDemographic> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesvStoreWithDemographic entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesvStoreWithDemographic> entities)
        {
					
		}
    }
}
		