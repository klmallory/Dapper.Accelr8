
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
    public class SalesvIndividualCustomerReader : EntityReader<int, SalesvIndividualCustomer>
    {
        public SalesvIndividualCustomerReader(
            SalesvIndividualCustomerTableInfo tableInfo
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
		/// Loads the table Sales.vIndividualCustomer into class SalesvIndividualCustomer
		/// </summary>
		/// <param name="results">SalesvIndividualCustomer</param>
		/// <param name="row"></param>
        public override SalesvIndividualCustomer LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesvIndividualCustomer();
			domain.Loaded = false;

				domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.Title = GetRowData<string>(dataRow, "Title"); 
      		domain.FirstName = GetRowData<object>(dataRow, "FirstName"); 
      		domain.MiddleName = GetRowData<object>(dataRow, "MiddleName"); 
      		domain.LastName = GetRowData<object>(dataRow, "LastName"); 
      		domain.Suffix = GetRowData<string>(dataRow, "Suffix"); 
      		domain.PhoneNumber = GetRowData<object>(dataRow, "PhoneNumber"); 
      		domain.PhoneNumberType = GetRowData<object>(dataRow, "PhoneNumberType"); 
      		domain.EmailAddress = GetRowData<string>(dataRow, "EmailAddress"); 
      		domain.EmailPromotion = GetRowData<int>(dataRow, "EmailPromotion"); 
      		domain.AddressType = GetRowData<object>(dataRow, "AddressType"); 
      		domain.AddressLine1 = GetRowData<string>(dataRow, "AddressLine1"); 
      		domain.AddressLine2 = GetRowData<string>(dataRow, "AddressLine2"); 
      		domain.City = GetRowData<string>(dataRow, "City"); 
      		domain.StateProvinceName = GetRowData<object>(dataRow, "StateProvinceName"); 
      		domain.PostalCode = GetRowData<string>(dataRow, "PostalCode"); 
      		domain.CountryRegionName = GetRowData<object>(dataRow, "CountryRegionName"); 
      		domain.Demographics = GetRowData<string>(dataRow, "Demographics"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesvIndividualCustomer></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesvIndividualCustomer> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesvIndividualCustomer entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesvIndividualCustomer> entities)
        {
					
		}
    }
}
		