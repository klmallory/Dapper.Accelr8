
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
    public class ProductionWorkOrderRoutingReader : EntityReader<CompoundKey, ProductionWorkOrderRouting>
    {
        public ProductionWorkOrderRoutingReader(
            ProductionWorkOrderRoutingTableInfo tableInfo
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
		/// Loads the table Production.WorkOrderRouting into class ProductionWorkOrderRouting
		/// </summary>
		/// <param name="results">ProductionWorkOrderRouting</param>
		/// <param name="row"></param>
        public override ProductionWorkOrderRouting LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionWorkOrderRouting();
			domain.Loaded = false;

			domain.WorkOrderID = GetRowData<int>(dataRow, "WorkOrderID"); 
      		domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.OperationSequence = GetRowData<short>(dataRow, "OperationSequence"); 
      		domain.LocationID = GetRowData<short>(dataRow, "LocationID"); 
      		domain.ScheduledStartDate = GetRowData<DateTime>(dataRow, "ScheduledStartDate"); 
      		domain.ScheduledEndDate = GetRowData<DateTime>(dataRow, "ScheduledEndDate"); 
      		domain.ActualStartDate = GetRowData<DateTime?>(dataRow, "ActualStartDate"); 
      		domain.ActualEndDate = GetRowData<DateTime?>(dataRow, "ActualEndDate"); 
      		domain.ActualResourceHrs = GetRowData<decimal?>(dataRow, "ActualResourceHrs"); 
      		domain.PlannedCost = GetRowData<decimal>(dataRow, "PlannedCost"); 
      		domain.ActualCost = GetRowData<decimal?>(dataRow, "ActualCost"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      				domain.Id = ProductionWorkOrderRouting.GetCompoundKeyFor(domain); 
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified CompoundKey Id.
		/// </summary>
		/// <param name="results">IEntityReader<CompoundKey, ProductionWorkOrderRouting></param>
		/// <param name="id">CompoundKey</param>
        public override IEntityReader<CompoundKey, ProductionWorkOrderRouting> WithAllChildrenForExisting(ProductionWorkOrderRouting existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionWorkOrderRouting entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionWorkOrderRouting> entities)
        {
					
		}
    }
}
		