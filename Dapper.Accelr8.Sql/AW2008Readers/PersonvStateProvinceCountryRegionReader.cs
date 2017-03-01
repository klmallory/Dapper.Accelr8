
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
    public class PersonvStateProvinceCountryRegionReader : EntityReader<int, PersonvStateProvinceCountryRegion>
    {
        public PersonvStateProvinceCountryRegionReader(
            PersonvStateProvinceCountryRegionTableInfo tableInfo
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
		/// Loads the table Person.vStateProvinceCountryRegion into class PersonvStateProvinceCountryRegion
		/// </summary>
		/// <param name="results">PersonvStateProvinceCountryRegion</param>
		/// <param name="row"></param>
        public override PersonvStateProvinceCountryRegion LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonvStateProvinceCountryRegion();
			domain.Loaded = false;

				domain.StateProvinceID = GetRowData<int>(dataRow, "StateProvinceID"); 
      		domain.StateProvinceCode = GetRowData<string>(dataRow, "StateProvinceCode"); 
      		domain.IsOnlyStateProvinceFlag = GetRowData<object>(dataRow, "IsOnlyStateProvinceFlag"); 
      		domain.StateProvinceName = GetRowData<object>(dataRow, "StateProvinceName"); 
      		domain.TerritoryID = GetRowData<int>(dataRow, "TerritoryID"); 
      		domain.CountryRegionCode = GetRowData<string>(dataRow, "CountryRegionCode"); 
      		domain.CountryRegionName = GetRowData<object>(dataRow, "CountryRegionName"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PersonvStateProvinceCountryRegion></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonvStateProvinceCountryRegion> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(PersonvStateProvinceCountryRegion entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonvStateProvinceCountryRegion> entities)
        {
					
		}
    }
}
		