
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
    public class ProductionWorkOrderRoutingReader : EntityReader<int, ProductionWorkOrderRouting>
    {
        public ProductionWorkOrderRoutingReader(
            ProductionWorkOrderRoutingTableInfo tableInfo
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
		/// Loads the table Production.WorkOrderRouting into class ProductionWorkOrderRouting
		/// </summary>
		/// <param name="results">ProductionWorkOrderRouting</param>
		/// <param name="row"></param>
        public override ProductionWorkOrderRouting LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionWorkOrderRouting();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.LocationID = GetRowData<short>(dataRow, "LocationID"); 
      		domain.ScheduledStartDate = GetRowData<DateTime>(dataRow, "ScheduledStartDate"); 
      		domain.ScheduledEndDate = GetRowData<DateTime>(dataRow, "ScheduledEndDate"); 
      		domain.ActualStartDate = GetRowData<DateTime?>(dataRow, "ActualStartDate"); 
      		domain.ActualEndDate = GetRowData<DateTime?>(dataRow, "ActualEndDate"); 
      		domain.ActualResourceHrs = GetRowData<decimal?>(dataRow, "ActualResourceHrs"); 
      		domain.PlannedCost = GetRowData<decimal>(dataRow, "PlannedCost"); 
      		domain.ActualCost = GetRowData<decimal?>(dataRow, "ActualCost"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionWorkOrderRouting></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionWorkOrderRouting> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
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
		