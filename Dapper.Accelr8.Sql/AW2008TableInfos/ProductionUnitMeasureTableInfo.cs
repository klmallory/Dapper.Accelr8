
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
	public enum ProductionUnitMeasureColumnNames
	{	
		UnitMeasureCode, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum ProductionUnitMeasureCascadeNames
	{	
		purchasingproductvendor, 	
		productionproduct, 	
		}

	public class ProductionUnitMeasureTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionUnitMeasureTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionUnitMeasureColumnNames.UnitMeasureCode.ToString();
			//Schema = "Production.UnitMeasure";
			TableName = "Production.UnitMeasure";
			TableAlias = "productionunitmeasure";
			ColumnNames = typeof(ProductionUnitMeasureColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		