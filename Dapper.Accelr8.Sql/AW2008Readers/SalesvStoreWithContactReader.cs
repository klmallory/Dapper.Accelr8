
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
    public class SalesvStoreWithContactReader : EntityReader<int, SalesvStoreWithContact>
    {
        public SalesvStoreWithContactReader(
            SalesvStoreWithContactTableInfo tableInfo
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
		/// Loads the table Sales.vStoreWithContacts into class SalesvStoreWithContact
		/// </summary>
		/// <param name="results">SalesvStoreWithContact</param>
		/// <param name="row"></param>
        public override SalesvStoreWithContact LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesvStoreWithContact();
			domain.Loaded = false;

				domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ContactType = GetRowData<object>(dataRow, "ContactType"); 
      		domain.Title = GetRowData<string>(dataRow, "Title"); 
      		domain.FirstName = GetRowData<object>(dataRow, "FirstName"); 
      		domain.MiddleName = GetRowData<object>(dataRow, "MiddleName"); 
      		domain.LastName = GetRowData<object>(dataRow, "LastName"); 
      		domain.Suffix = GetRowData<string>(dataRow, "Suffix"); 
      		domain.PhoneNumber = GetRowData<object>(dataRow, "PhoneNumber"); 
      		domain.PhoneNumberType = GetRowData<object>(dataRow, "PhoneNumberType"); 
      		domain.EmailAddress = GetRowData<string>(dataRow, "EmailAddress"); 
      		domain.EmailPromotion = GetRowData<int>(dataRow, "EmailPromotion"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesvStoreWithContact></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesvStoreWithContact> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesvStoreWithContact entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesvStoreWithContact> entities)
        {
					
		}
    }
}
		