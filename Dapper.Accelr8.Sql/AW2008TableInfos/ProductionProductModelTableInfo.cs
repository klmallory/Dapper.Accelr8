
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
	public enum ProductionProductModelFieldNames
	{	
		Id, 	
		Name, 	
		CatalogDescription, 	
		Instructions, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionProductModelCascadeNames
	{	
		productionproductmodelillustrations, 	
		productionproductmodelproductdescriptioncultures, 	
		productionproducts, 	
		}

	public class ProductionProductModelTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductModelColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductModelFieldNames.Id, "ProductModelID" }, 
						{ (int)ProductionProductModelFieldNames.Name, "Name" }, 
						{ (int)ProductionProductModelFieldNames.CatalogDescription, "CatalogDescription" }, 
						{ (int)ProductionProductModelFieldNames.Instructions, "Instructions" }, 
						{ (int)ProductionProductModelFieldNames.rowguid, "rowguid" }, 
						{ (int)ProductionProductModelFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductModelIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductModelFieldNames.Id, "ProductModelID" }, 
				};

		public ProductionProductModelTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductModel";
			TableAlias = "productionproductmodel";
			Columns = ProductionProductModelColumnNames;
			IdColumns = ProductionProductModelIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		