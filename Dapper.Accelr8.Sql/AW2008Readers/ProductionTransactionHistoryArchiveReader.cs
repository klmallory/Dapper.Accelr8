
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
    public class ProductionTransactionHistoryArchiveReader : EntityReader<int, ProductionTransactionHistoryArchive>
    {
        public ProductionTransactionHistoryArchiveReader(
            ProductionTransactionHistoryArchiveTableInfo tableInfo
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
		//Parent Count 0
		
			/// <summary>
		/// Loads the table Production.TransactionHistoryArchive into class ProductionTransactionHistoryArchive
		/// </summary>
		/// <param name="results">ProductionTransactionHistoryArchive</param>
		/// <param name="row"></param>
        public override ProductionTransactionHistoryArchive LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionTransactionHistoryArchive();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "TransactionID"); 
      		domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.ReferenceOrderID = GetRowData<int>(dataRow, "ReferenceOrderID"); 
      		domain.ReferenceOrderLineID = GetRowData<int>(dataRow, "ReferenceOrderLineID"); 
      		domain.TransactionDate = GetRowData<DateTime>(dataRow, "TransactionDate"); 
      		domain.TransactionType = GetRowData<string>(dataRow, "TransactionType"); 
      		domain.Quantity = GetRowData<int>(dataRow, "Quantity"); 
      		domain.ActualCost = GetRowData<decimal>(dataRow, "ActualCost"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionTransactionHistoryArchive></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionTransactionHistoryArchive> WithAllChildrenForExisting(ProductionTransactionHistoryArchive existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionTransactionHistoryArchive entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionTransactionHistoryArchive> entities)
        {
					
		}
    }
}
		