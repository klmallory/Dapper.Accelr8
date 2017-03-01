
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
	public enum ProductionvProductAndDescriptionColumnNames
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
		public ProductionvProductAndDescriptionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = ProductionvProductAndDescriptionColumnNames.ProductID.ToString();
			//Schema = "Production.vProductAndDescription";
			TableName = "Production.vProductAndDescription";
			TableAlias = "productionvproductanddescription";
			ColumnNames = typeof(ProductionvProductAndDescriptionColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		