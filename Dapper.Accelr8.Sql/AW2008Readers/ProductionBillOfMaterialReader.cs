
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
    public class ProductionBillOfMaterialReader : EntityReader<int, ProductionBillOfMaterial>
    {
        public ProductionBillOfMaterialReader(
            ProductionBillOfMaterialTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 0
		//Parent Count 3
		
			/// <summary>
		/// Loads the table Production.BillOfMaterials into class ProductionBillOfMaterial
		/// </summary>
		/// <param name="results">ProductionBillOfMaterial</param>
		/// <param name="row"></param>
        public override ProductionBillOfMaterial LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionBillOfMaterial();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.ProductAssemblyID = GetRowData<int?>(dataRow, "ProductAssemblyID"); 
      		domain.ComponentID = GetRowData<int>(dataRow, "ComponentID"); 
      		domain.StartDate = GetRowData<DateTime>(dataRow, "StartDate"); 
      		domain.EndDate = GetRowData<DateTime?>(dataRow, "EndDate"); 
      		domain.UnitMeasureCode = GetRowData<string>(dataRow, "UnitMeasureCode"); 
      		domain.BOMLevel = GetRowData<short>(dataRow, "BOMLevel"); 
      		domain.PerAssemblyQty = GetRowData<decimal>(dataRow, "PerAssemblyQty"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionBillOfMaterial></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionBillOfMaterial> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionBillOfMaterial entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionBillOfMaterial> entities)
        {
					
		}
    }
}
		