
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
	public enum SalesvPersonDemographicFieldNames
	{	
		BusinessEntityID, 	
		TotalPurchaseYTD, 	
		DateFirstPurchase, 	
		BirthDate, 	
		MaritalStatus, 	
		YearlyIncome, 	
		Gender, 	
		TotalChildren, 	
		NumberChildrenAtHome, 	
		Education, 	
		Occupation, 	
		HomeOwnerFlag, 	
		NumberCarsOwned, 	
	}

	public enum SalesvPersonDemographicCascadeNames
	{	
		}

	public class SalesvPersonDemographicTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesvPersonDemographicColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesvPersonDemographicFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesvPersonDemographicFieldNames.TotalPurchaseYTD, "TotalPurchaseYTD" }, 
						{ (int)SalesvPersonDemographicFieldNames.DateFirstPurchase, "DateFirstPurchase" }, 
						{ (int)SalesvPersonDemographicFieldNames.BirthDate, "BirthDate" }, 
						{ (int)SalesvPersonDemographicFieldNames.MaritalStatus, "MaritalStatus" }, 
						{ (int)SalesvPersonDemographicFieldNames.YearlyIncome, "YearlyIncome" }, 
						{ (int)SalesvPersonDemographicFieldNames.Gender, "Gender" }, 
						{ (int)SalesvPersonDemographicFieldNames.TotalChildren, "TotalChildren" }, 
						{ (int)SalesvPersonDemographicFieldNames.NumberChildrenAtHome, "NumberChildrenAtHome" }, 
						{ (int)SalesvPersonDemographicFieldNames.Education, "Education" }, 
						{ (int)SalesvPersonDemographicFieldNames.Occupation, "Occupation" }, 
						{ (int)SalesvPersonDemographicFieldNames.HomeOwnerFlag, "HomeOwnerFlag" }, 
						{ (int)SalesvPersonDemographicFieldNames.NumberCarsOwned, "NumberCarsOwned" }, 
				};	

		public static readonly IDictionary<int, string> SalesvPersonDemographicIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)SalesvPersonDemographicFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public SalesvPersonDemographicTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Sales";
			TableName = "Sales.vPersonDemographics";
			TableAlias = "salesvpersondemographic";
			Columns = SalesvPersonDemographicColumnNames;
			IdColumns = SalesvPersonDemographicIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		