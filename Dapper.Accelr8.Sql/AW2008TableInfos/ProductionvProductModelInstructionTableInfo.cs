
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
	public enum ProductionvProductModelInstructionColumnNames
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
		public ProductionvProductModelInstructionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = ProductionvProductModelInstructionColumnNames.ProductModelID.ToString();
			//Schema = "Production.vProductModelInstructions";
			TableName = "Production.vProductModelInstructions";
			TableAlias = "productionvproductmodelinstruction";
			ColumnNames = typeof(ProductionvProductModelInstructionColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		