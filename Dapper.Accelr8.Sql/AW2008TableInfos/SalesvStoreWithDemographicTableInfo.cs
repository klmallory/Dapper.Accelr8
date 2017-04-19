
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
	public enum SalesvStoreWithDemographicFieldNames
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
	
		public static readonly IDictionary<int, string> SalesvStoreWithDemographicColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesvStoreWithDemographicFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.Name, "Name" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.AnnualSales, "AnnualSales" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.AnnualRevenue, "AnnualRevenue" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.BankName, "BankName" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.BusinessType, "BusinessType" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.YearOpened, "YearOpened" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.Specialty, "Specialty" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.SquareFeet, "SquareFeet" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.Brands, "Brands" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.Internet, "Internet" }, 
						{ (int)SalesvStoreWithDemographicFieldNames.NumberEmployees, "NumberEmployees" }, 
				};	

		public static readonly IDictionary<int, string> SalesvStoreWithDemographicIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)SalesvStoreWithDemographicFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public SalesvStoreWithDemographicTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Sales";
			TableName = "Sales.vStoreWithDemographics";
			TableAlias = "salesvstorewithdemographic";
			Columns = SalesvStoreWithDemographicColumnNames;
			IdColumns = SalesvStoreWithDemographicIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		