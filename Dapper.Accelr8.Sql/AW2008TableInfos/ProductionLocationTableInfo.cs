
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
	public enum ProductionLocationColumnNames
	{	
		LocationID, 	
		Name, 	
		CostRate, 	
		Availability, 	
		ModifiedDate, 	
	}

	public enum ProductionLocationCascadeNames
	{	
		productionproductinventory, 	
		productionworkorderrouting, 	
		}

	public class ProductionLocationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionLocationTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionLocationColumnNames.LocationID.ToString();
			//Schema = "Production.Location";
			TableName = "Production.Location";
			TableAlias = "productionlocation";
			ColumnNames = typeof(ProductionLocationColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		