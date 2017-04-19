
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
	public enum ProductionvProductModelInstructionFieldNames
	{	
		ProductModelID, 	
		Name, 	
		Instructions, 	
		LocationID, 	
		SetupHours, 	
		MachineHours, 	
		LaborHours, 	
		LotSize, 	
		Step, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionvProductModelInstructionCascadeNames
	{	
		}

	public class ProductionvProductModelInstructionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionvProductModelInstructionColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionvProductModelInstructionFieldNames.ProductModelID, "ProductModelID" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.Name, "Name" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.Instructions, "Instructions" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.LocationID, "LocationID" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.SetupHours, "SetupHours" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.MachineHours, "MachineHours" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.LaborHours, "LaborHours" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.LotSize, "LotSize" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.Step, "Step" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.rowguid, "rowguid" }, 
						{ (int)ProductionvProductModelInstructionFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionvProductModelInstructionIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)ProductionvProductModelInstructionFieldNames.ProductModelID, "ProductModelID" }, 
				};

		public ProductionvProductModelInstructionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Production";
			TableName = "Production.vProductModelInstructions";
			TableAlias = "productionvproductmodelinstruction";
			Columns = ProductionvProductModelInstructionColumnNames;
			IdColumns = ProductionvProductModelInstructionIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		