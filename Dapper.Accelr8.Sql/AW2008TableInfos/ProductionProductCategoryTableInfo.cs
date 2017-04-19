
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
	public enum ProductionProductCategoryFieldNames
	{	
		Id, 	
		Name, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionProductCategoryCascadeNames
	{	
		productionproductsubcategories, 	
		}

	public class ProductionProductCategoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductCategoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductCategoryFieldNames.Id, "ProductCategoryID" }, 
						{ (int)ProductionProductCategoryFieldNames.Name, "Name" }, 
						{ (int)ProductionProductCategoryFieldNames.rowguid, "rowguid" }, 
						{ (int)ProductionProductCategoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductCategoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductCategoryFieldNames.Id, "ProductCategoryID" }, 
				};

		public ProductionProductCategoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductCategory";
			TableAlias = "productionproductcategory";
			Columns = ProductionProductCategoryColumnNames;
			IdColumns = ProductionProductCategoryIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		