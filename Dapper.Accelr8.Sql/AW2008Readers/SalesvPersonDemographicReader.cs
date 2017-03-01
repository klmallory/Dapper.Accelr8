
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
    public class SalesvPersonDemographicReader : EntityReader<int, SalesvPersonDemographic>
    {
        public SalesvPersonDemographicReader(
            SalesvPersonDemographicTableInfo tableInfo
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
		/// Loads the table Sales.vPersonDemographics into class SalesvPersonDemographic
		/// </summary>
		/// <param name="results">SalesvPersonDemographic</param>
		/// <param name="row"></param>
        public override SalesvPersonDemographic LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesvPersonDemographic();
			domain.Loaded = false;

				domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.TotalPurchaseYTD = GetRowData<decimal?>(dataRow, "TotalPurchaseYTD"); 
      		domain.DateFirstPurchase = GetRowData<DateTime?>(dataRow, "DateFirstPurchase"); 
      		domain.BirthDate = GetRowData<DateTime?>(dataRow, "BirthDate"); 
      		domain.MaritalStatus = GetRowData<string>(dataRow, "MaritalStatus"); 
      		domain.YearlyIncome = GetRowData<string>(dataRow, "YearlyIncome"); 
      		domain.Gender = GetRowData<string>(dataRow, "Gender"); 
      		domain.TotalChildren = GetRowData<int?>(dataRow, "TotalChildren"); 
      		domain.NumberChildrenAtHome = GetRowData<int?>(dataRow, "NumberChildrenAtHome"); 
      		domain.Education = GetRowData<string>(dataRow, "Education"); 
      		domain.Occupation = GetRowData<string>(dataRow, "Occupation"); 
      		domain.HomeOwnerFlag = GetRowData<bool?>(dataRow, "HomeOwnerFlag"); 
      		domain.NumberCarsOwned = GetRowData<int?>(dataRow, "NumberCarsOwned"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesvPersonDemographic></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesvPersonDemographic> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesvPersonDemographic entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesvPersonDemographic> entities)
        {
					
		}
    }
}
		