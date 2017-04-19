
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
	public enum ProductionProductPhotoFieldNames
	{	
		Id, 	
		ThumbNailPhoto, 	
		ThumbnailPhotoFileName, 	
		LargePhoto, 	
		LargePhotoFileName, 	
		ModifiedDate, 	
	}

	public enum ProductionProductPhotoCascadeNames
	{	
		productionproductproductphotos, 	
		}

	public class ProductionProductPhotoTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductPhotoColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductPhotoFieldNames.Id, "ProductPhotoID" }, 
						{ (int)ProductionProductPhotoFieldNames.ThumbNailPhoto, "ThumbNailPhoto" }, 
						{ (int)ProductionProductPhotoFieldNames.ThumbnailPhotoFileName, "ThumbnailPhotoFileName" }, 
						{ (int)ProductionProductPhotoFieldNames.LargePhoto, "LargePhoto" }, 
						{ (int)ProductionProductPhotoFieldNames.LargePhotoFileName, "LargePhotoFileName" }, 
						{ (int)ProductionProductPhotoFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductPhotoIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductPhotoFieldNames.Id, "ProductPhotoID" }, 
				};

		public ProductionProductPhotoTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductPhoto";
			TableAlias = "productionproductphoto";
			Columns = ProductionProductPhotoColumnNames;
			IdColumns = ProductionProductPhotoIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		