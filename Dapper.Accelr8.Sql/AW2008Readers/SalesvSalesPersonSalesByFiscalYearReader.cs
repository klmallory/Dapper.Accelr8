
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
    public class SalesvSalesPersonSalesByFiscalYearReader : EntityReader<int, SalesvSalesPersonSalesByFiscalYear>
    {
        public SalesvSalesPersonSalesByFiscalYearReader(
            SalesvSalesPersonSalesByFiscalYearTableInfo tableInfo
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
		/// Loads the table Sales.vSalesPersonSalesByFiscalYears into class SalesvSalesPersonSalesByFiscalYear
		/// </summary>
		/// <param name="results">SalesvSalesPersonSalesByFiscalYear</param>
		/// <param name="row"></param>
        public override SalesvSalesPersonSalesByFiscalYear LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesvSalesPersonSalesByFiscalYear();
			domain.Loaded = false;

				domain.SalesPersonID = GetRowData<int?>(dataRow, "SalesPersonID"); 
      		domain.FullName = GetRowData<string>(dataRow, "FullName"); 
      		domain.JobTitle = GetRowData<string>(dataRow, "JobTitle"); 
      		domain.SalesTerritory = GetRowData<object>(dataRow, "SalesTerritory"); 
      		domain._n_2002 = GetRowData<decimal?>(dataRow, "2002"); 
      		domain._n_2003 = GetRowData<decimal?>(dataRow, "2003"); 
      		domain._n_2004 = GetRowData<decimal?>(dataRow, "2004"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesvSalesPersonSalesByFiscalYear></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesvSalesPersonSalesByFiscalYear> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesvSalesPersonSalesByFiscalYear entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesvSalesPersonSalesByFiscalYear> entities)
        {
					
		}
    }
}
		