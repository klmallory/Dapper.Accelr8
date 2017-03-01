
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
	public enum SalesvStoreWithDemographicColumnNames
	{	
		BusinessEntityID, 	
		Name, 	
		AnnualSales, 	
		AnnualRevenue, 	
		BankName, 	
		BusinessType, 	
		YearOpened, 	
		Specialty, 	
		SquareFeet, 	
		Brands, 	
		Internet, 	
		NumberEmployees, 	
	}

	public enum SalesvStoreWithDemographicCascadeNames
	{	
		}

	public class SalesvStoreWithDemographicTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesvStoreWithDemographicTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = SalesvStoreWithDemographicColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.vStoreWithDemographics";
			TableName = "Sales.vStoreWithDemographics";
			TableAlias = "salesvstorewithdemographic";
			ColumnNames = typeof(SalesvStoreWithDemographicColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		