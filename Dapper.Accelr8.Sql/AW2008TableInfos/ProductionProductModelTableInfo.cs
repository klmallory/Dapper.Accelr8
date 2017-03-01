
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
	public enum ProductionProductModelColumnNames
	{	
		ProductModelID, 	
		Name, 	
		CatalogDescription, 	
		Instructions, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionProductModelCascadeNames
	{	
		productionproductmodelillustration, 	
		productionproductmodelproductdescriptionculture, 	
		productionproduct, 	
		}

	public class ProductionProductModelTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionProductModelTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionProductModelColumnNames.ProductModelID.ToString();
			//Schema = "Production.ProductModel";
			TableName = "Production.ProductModel";
			TableAlias = "productionproductmodel";
			ColumnNames = typeof(ProductionProductModelColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		