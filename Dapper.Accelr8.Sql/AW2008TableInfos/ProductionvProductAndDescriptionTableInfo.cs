
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
	public enum ProductionvProductAndDescriptionFieldNames
	{	
		ProductID, 	
		Name, 	
		ProductModel, 	
		CultureID, 	
		Description, 	
	}

	public enum ProductionvProductAndDescriptionCascadeNames
	{	
		}

	public class ProductionvProductAndDescriptionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionvProductAndDescriptionColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionvProductAndDescriptionFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionvProductAndDescriptionFieldNames.Name, "Name" }, 
						{ (int)ProductionvProductAndDescriptionFieldNames.ProductModel, "ProductModel" }, 
						{ (int)ProductionvProductAndDescriptionFieldNames.CultureID, "CultureID" }, 
						{ (int)ProductionvProductAndDescriptionFieldNames.Description, "Description" }, 
				};	

		public static readonly IDictionary<int, string> ProductionvProductAndDescriptionIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)ProductionvProductAndDescriptionFieldNames.ProductID, "ProductID" }, 
				};

		public ProductionvProductAndDescriptionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Production";
			TableName = "Production.vProductAndDescription";
			TableAlias = "productionvproductanddescription";
			Columns = ProductionvProductAndDescriptionColumnNames;
			IdColumns = ProductionvProductAndDescriptionIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		