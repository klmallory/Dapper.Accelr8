
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
    public class ProductionvProductModelInstructionReader : EntityReader<int, ProductionvProductModelInstruction>
    {
        public ProductionvProductModelInstructionReader(
            ProductionvProductModelInstructionTableInfo tableInfo
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
		/// Loads the table Production.vProductModelInstructions into class ProductionvProductModelInstruction
		/// </summary>
		/// <param name="results">ProductionvProductModelInstruction</param>
		/// <param name="row"></param>
        public override ProductionvProductModelInstruction LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionvProductModelInstruction();
			domain.Loaded = false;

			domain.ProductModelID = GetRowData<int>(dataRow, "ProductModelID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.Instructions = GetRowData<string>(dataRow, "Instructions"); 
      		domain.LocationID = GetRowData<int?>(dataRow, "LocationID"); 
      		domain.SetupHours = GetRowData<decimal?>(dataRow, "SetupHours"); 
      		domain.MachineHours = GetRowData<decimal?>(dataRow, "MachineHours"); 
      		domain.LaborHours = GetRowData<decimal?>(dataRow, "LaborHours"); 
      		domain.LotSize = GetRowData<int?>(dataRow, "LotSize"); 
      		domain.Step = GetRowData<string>(dataRow, "Step"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionvProductModelInstruction></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionvProductModelInstruction> WithAllChildrenForExisting(ProductionvProductModelInstruction existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(ProductionvProductModelInstruction entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionvProductModelInstruction> entities)
        {
					
		}
    }
}
		