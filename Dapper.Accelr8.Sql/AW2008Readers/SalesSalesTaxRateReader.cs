
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
    public class SalesSalesTaxRateReader : EntityReader<int, SalesSalesTaxRate>
    {
        public SalesSalesTaxRateReader(
            SalesSalesTaxRateTableInfo tableInfo
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
		//Parent Count 1
		
			/// <summary>
		/// Loads the table Sales.SalesTaxRate into class SalesSalesTaxRate
		/// </summary>
		/// <param name="results">SalesSalesTaxRate</param>
		/// <param name="row"></param>
        public override SalesSalesTaxRate LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSalesTaxRate();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "SalesTaxRateID"); 
      		domain.StateProvinceID = GetRowData<int>(dataRow, "StateProvinceID"); 
      		domain.TaxType = GetRowData<byte>(dataRow, "TaxType"); 
      		domain.TaxRate = GetRowData<decimal>(dataRow, "TaxRate"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSalesTaxRate></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSalesTaxRate> WithAllChildrenForExisting(SalesSalesTaxRate existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesSalesTaxRate entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesTaxRate> entities)
        {
					
		}
    }
}
		