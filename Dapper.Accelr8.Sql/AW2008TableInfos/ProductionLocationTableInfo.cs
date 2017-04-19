
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
	public enum ProductionLocationFieldNames
	{	
		Id, 	
		Name, 	
		CostRate, 	
		Availability, 	
		ModifiedDate, 	
	}

	public enum ProductionLocationCascadeNames
	{	
		productionproductinventories, 	
		productionworkorderroutings, 	
		}

	public class ProductionLocationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionLocationColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionLocationFieldNames.Id, "LocationID" }, 
						{ (int)ProductionLocationFieldNames.Name, "Name" }, 
						{ (int)ProductionLocationFieldNames.CostRate, "CostRate" }, 
						{ (int)ProductionLocationFieldNames.Availability, "Availability" }, 
						{ (int)ProductionLocationFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionLocationIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionLocationFieldNames.Id, "LocationID" }, 
				};

		public ProductionLocationTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.Location";
			TableAlias = "productionlocation";
			Columns = ProductionLocationColumnNames;
			IdColumns = ProductionLocationIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		