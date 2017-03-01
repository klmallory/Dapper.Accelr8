
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
    public class ProductionvProductModelCatalogDescriptionReader : EntityReader<int, ProductionvProductModelCatalogDescription>
    {
        public ProductionvProductModelCatalogDescriptionReader(
            ProductionvProductModelCatalogDescriptionTableInfo tableInfo
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
		/// Loads the table Production.vProductModelCatalogDescription into class ProductionvProductModelCatalogDescription
		/// </summary>
		/// <param name="results">ProductionvProductModelCatalogDescription</param>
		/// <param name="row"></param>
        public override ProductionvProductModelCatalogDescription LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionvProductModelCatalogDescription();
			domain.Loaded = false;

				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.Summary = GetRowData<string>(dataRow, "Summary"); 
      		domain.Manufacturer = GetRowData<string>(dataRow, "Manufacturer"); 
      		domain.Copyright = GetRowData<string>(dataRow, "Copyright"); 
      		domain.ProductURL = GetRowData<string>(dataRow, "ProductURL"); 
      		domain.WarrantyPeriod = GetRowData<string>(dataRow, "WarrantyPeriod"); 
      		domain.WarrantyDescription = GetRowData<string>(dataRow, "WarrantyDescription"); 
      		domain.NoOfYears = GetRowData<string>(dataRow, "NoOfYears"); 
      		domain.MaintenanceDescription = GetRowData<string>(dataRow, "MaintenanceDescription"); 
      		domain.Wheel = GetRowData<string>(dataRow, "Wheel"); 
      		domain.Saddle = GetRowData<string>(dataRow, "Saddle"); 
      		domain.Pedal = GetRowData<string>(dataRow, "Pedal"); 
      		domain.BikeFrame = GetRowData<string>(dataRow, "BikeFrame"); 
      		domain.Crankset = GetRowData<string>(dataRow, "Crankset"); 
      		domain.PictureAngle = GetRowData<string>(dataRow, "PictureAngle"); 
      		domain.PictureSize = GetRowData<string>(dataRow, "PictureSize"); 
      		domain.ProductPhotoID = GetRowData<string>(dataRow, "ProductPhotoID"); 
      		domain.Material = GetRowData<string>(dataRow, "Material"); 
      		domain.Color = GetRowData<string>(dataRow, "Color"); 
      		domain.ProductLine = GetRowData<string>(dataRow, "ProductLine"); 
      		domain.Style = GetRowData<string>(dataRow, "Style"); 
      		domain.RiderExperience = GetRowData<string>(dataRow, "RiderExperience"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionvProductModelCatalogDescription></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionvProductModelCatalogDescription> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionvProductModelCatalogDescription entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionvProductModelCatalogDescription> entities)
        {
					
		}
    }
}
		