
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
	public enum ProductionScrapReasonFieldNames
	{	
		Id, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum ProductionScrapReasonCascadeNames
	{	
		productionworkorders, 	
		}

	public class ProductionScrapReasonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionScrapReasonColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionScrapReasonFieldNames.Id, "ScrapReasonID" }, 
						{ (int)ProductionScrapReasonFieldNames.Name, "Name" }, 
						{ (int)ProductionScrapReasonFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionScrapReasonIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionScrapReasonFieldNames.Id, "ScrapReasonID" }, 
				};

		public ProductionScrapReasonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ScrapReason";
			TableAlias = "productionscrapreason";
			Columns = ProductionScrapReasonColumnNames;
			IdColumns = ProductionScrapReasonIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		