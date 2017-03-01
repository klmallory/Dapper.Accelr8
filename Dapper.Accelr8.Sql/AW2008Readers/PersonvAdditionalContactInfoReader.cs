
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
    public class PersonvAdditionalContactInfoReader : EntityReader<int, PersonvAdditionalContactInfo>
    {
        public PersonvAdditionalContactInfoReader(
            PersonvAdditionalContactInfoTableInfo tableInfo
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
		/// Loads the table Person.vAdditionalContactInfo into class PersonvAdditionalContactInfo
		/// </summary>
		/// <param name="results">PersonvAdditionalContactInfo</param>
		/// <param name="row"></param>
        public override PersonvAdditionalContactInfo LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonvAdditionalContactInfo();
			domain.Loaded = false;

				domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.FirstName = GetRowData<object>(dataRow, "FirstName"); 
      		domain.MiddleName = GetRowData<object>(dataRow, "MiddleName"); 
      		domain.LastName = GetRowData<object>(dataRow, "LastName"); 
      		domain.TelephoneNumber = GetRowData<string>(dataRow, "TelephoneNumber"); 
      		domain.TelephoneSpecialInstructions = GetRowData<string>(dataRow, "TelephoneSpecialInstructions"); 
      		domain.Street = GetRowData<string>(dataRow, "Street"); 
      		domain.City = GetRowData<string>(dataRow, "City"); 
      		domain.StateProvince = GetRowData<string>(dataRow, "StateProvince"); 
      		domain.PostalCode = GetRowData<string>(dataRow, "PostalCode"); 
      		domain.CountryRegion = GetRowData<string>(dataRow, "CountryRegion"); 
      		domain.HomeAddressSpecialInstructions = GetRowData<string>(dataRow, "HomeAddressSpecialInstructions"); 
      		domain.EMailAddress = GetRowData<string>(dataRow, "EMailAddress"); 
      		domain.EMailSpecialInstructions = GetRowData<string>(dataRow, "EMailSpecialInstructions"); 
      		domain.EMailTelephoneNumber = GetRowData<string>(dataRow, "EMailTelephoneNumber"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PersonvAdditionalContactInfo></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonvAdditionalContactInfo> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(PersonvAdditionalContactInfo entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonvAdditionalContactInfo> entities)
        {
					
		}
    }
}
		