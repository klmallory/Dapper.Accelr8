
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
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008TableInfos
{
	public enum ProductionvProductModelCatalogDescriptionFieldNames
	{	
		ProductModelID, 	
		Name, 	
		Summary, 	
		Manufacturer, 	
		Copyright, 	
		ProductURL, 	
		WarrantyPeriod, 	
		WarrantyDescription, 	
		NoOfYears, 	
		MaintenanceDescription, 	
		Wheel, 	
		Saddle, 	
		Pedal, 	
		BikeFrame, 	
		Crankset, 	
		PictureAngle, 	
		PictureSize, 	
		ProductPhotoID, 	
		Material, 	
		Color, 	
		ProductLine, 	
		Style, 	
		RiderExperience, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionvProductModelCatalogDescriptionCascadeNames
	{	
		}

	public class ProductionvProductModelCatalogDescriptionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionvProductModelCatalogDescriptionColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionvProductModelCatalogDescriptionFieldNames.ProductModelID, "ProductModelID" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Name, "Name" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Summary, "Summary" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Manufacturer, "Manufacturer" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Copyright, "Copyright" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.ProductURL, "ProductURL" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.WarrantyPeriod, "WarrantyPeriod" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.WarrantyDescription, "WarrantyDescription" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.NoOfYears, "NoOfYears" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.MaintenanceDescription, "MaintenanceDescription" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Wheel, "Wheel" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Saddle, "Saddle" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Pedal, "Pedal" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.BikeFrame, "BikeFrame" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Crankset, "Crankset" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.PictureAngle, "PictureAngle" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.PictureSize, "PictureSize" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.ProductPhotoID, "ProductPhotoID" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Material, "Material" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Color, "Color" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.ProductLine, "ProductLine" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.Style, "Style" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.RiderExperience, "RiderExperience" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.rowguid, "rowguid" }, 
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionvProductModelCatalogDescriptionIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)ProductionvProductModelCatalogDescriptionFieldNames.ProductModelID, "ProductModelID" }, 
				};

		public ProductionvProductModelCatalogDescriptionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Production";
			TableName = "Production.vProductModelCatalogDescription";
			TableAlias = "productionvproductmodelcatalogdescription";
			Columns = ProductionvProductModelCatalogDescriptionColumnNames;
			IdColumns = ProductionvProductModelCatalogDescriptionIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		