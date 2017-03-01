
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
	public enum SalesvPersonDemographicColumnNames
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
		public SalesvPersonDemographicTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = SalesvPersonDemographicColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.vPersonDemographics";
			TableName = "Sales.vPersonDemographics";
			TableAlias = "salesvpersondemographic";
			ColumnNames = typeof(SalesvPersonDemographicColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		