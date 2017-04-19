
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
	public enum ProductionUnitMeasureFieldNames
	{	
		Id, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum ProductionUnitMeasureCascadeNames
	{	
		purchasingproductvendors, 	
		productionproducts1, 	
		}

	public class ProductionUnitMeasureTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionUnitMeasureColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionUnitMeasureFieldNames.Id, "UnitMeasureCode" }, 
						{ (int)ProductionUnitMeasureFieldNames.Name, "Name" }, 
						{ (int)ProductionUnitMeasureFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionUnitMeasureIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionUnitMeasureFieldNames.Id, "UnitMeasureCode" }, 
				};

		public ProductionUnitMeasureTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.UnitMeasure";
			TableAlias = "productionunitmeasure";
			Columns = ProductionUnitMeasureColumnNames;
			IdColumns = ProductionUnitMeasureIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		