
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
    public class ProductionProductInventoryReader : EntityReader<CompoundKey, ProductionProductInventory>
    {
        public ProductionProductInventoryReader(
            ProductionProductInventoryTableInfo tableInfo
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
		//Parent Count 2
		
			/// <summary>
		/// Loads the table Production.ProductInventory into class ProductionProductInventory
		/// </summary>
		/// <param name="results">ProductionProductInventory</param>
		/// <param name="row"></param>
        public override ProductionProductInventory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionProductInventory();
			domain.Loaded = false;

			domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.LocationID = GetRowData<short>(dataRow, "LocationID"); 
      		domain.Shelf = GetRowData<string>(dataRow, "Shelf"); 
      		domain.Bin = GetRowData<byte>(dataRow, "Bin"); 
      		domain.Quantity = GetRowData<short>(dataRow, "Quantity"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      				domain.Id = ProductionProductInventory.GetCompoundKeyFor(domain); 
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified CompoundKey Id.
		/// </summary>
		/// <param name="results">IEntityReader<CompoundKey, ProductionProductInventory></param>
		/// <param name="id">CompoundKey</param>
        public override IEntityReader<CompoundKey, ProductionProductInventory> WithAllChildrenForExisting(ProductionProductInventory existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionProductInventory entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionProductInventory> entities)
        {
					
		}
    }
}
		