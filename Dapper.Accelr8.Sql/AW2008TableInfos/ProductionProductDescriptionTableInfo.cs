
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
	public enum ProductionProductDescriptionFieldNames
	{	
		Id, 	
		Description, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionProductDescriptionCascadeNames
	{	
		productionproductmodelproductdescriptioncultures, 	
		}

	public class ProductionProductDescriptionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductDescriptionColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductDescriptionFieldNames.Id, "ProductDescriptionID" }, 
						{ (int)ProductionProductDescriptionFieldNames.Description, "Description" }, 
						{ (int)ProductionProductDescriptionFieldNames.rowguid, "rowguid" }, 
						{ (int)ProductionProductDescriptionFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductDescriptionIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductDescriptionFieldNames.Id, "ProductDescriptionID" }, 
				};

		public ProductionProductDescriptionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductDescription";
			TableAlias = "productionproductdescription";
			Columns = ProductionProductDescriptionColumnNames;
			IdColumns = ProductionProductDescriptionIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		