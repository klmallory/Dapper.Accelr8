
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
	public enum HumanResourcesvEmployeeDepartmentHistoryColumnNames
	{	
		BusinessEntityID, 	
		Title, 	
		FirstName, 	
		MiddleName, 	
		LastName, 	
		Suffix, 	
		Shift, 	
		Department, 	
		GroupName, 	
		StartDate, 	
		EndDate, 	
	}

	public enum HumanResourcesvEmployeeDepartmentHistoryCascadeNames
	{	
		}

	public class HumanResourcesvEmployeeDepartmentHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public HumanResourcesvEmployeeDepartmentHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = HumanResourcesvEmployeeDepartmentHistoryColumnNames.BusinessEntityID.ToString();
			//Schema = "HumanResources.vEmployeeDepartmentHistory";
			TableName = "HumanResources.vEmployeeDepartmentHistory";
			TableAlias = "humanresourcesvemployeedepartmenthistory";
			ColumnNames = typeof(HumanResourcesvEmployeeDepartmentHistoryColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		