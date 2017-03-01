
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
    public class SalesCountryRegionCurrencyReader : EntityReader<string, SalesCountryRegionCurrency>
    {
        public SalesCountryRegionCurrencyReader(
            SalesCountryRegionCurrencyTableInfo tableInfo
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
		/// Loads the table Sales.CountryRegionCurrency into class SalesCountryRegionCurrency
		/// </summary>
		/// <param name="results">SalesCountryRegionCurrency</param>
		/// <param name="row"></param>
        public override SalesCountryRegionCurrency LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesCountryRegionCurrency();
			domain.Loaded = false;

			domain.Id = GetRowData<string>(dataRow, IdColumn);
				domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified string Id.
		/// </summary>
		/// <param name="results">IEntityReader<string, SalesCountryRegionCurrency></param>
		/// <param name="id">string</param>
        public override IEntityReader<string, SalesCountryRegionCurrency> WithAllChildrenForId(string id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesCountryRegionCurrency entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesCountryRegionCurrency> entities)
        {
					
		}
    }
}
		