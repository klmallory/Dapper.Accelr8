
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
	public enum ProductionScrapReasonColumnNames
	{	
		ScrapReasonID, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum ProductionScrapReasonCascadeNames
	{	
		productionworkorder, 	
		}

	public class ProductionScrapReasonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionScrapReasonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionScrapReasonColumnNames.ScrapReasonID.ToString();
			//Schema = "Production.ScrapReason";
			TableName = "Production.ScrapReason";
			TableAlias = "productionscrapreason";
			ColumnNames = typeof(ProductionScrapReasonColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		