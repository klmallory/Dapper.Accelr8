
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
	public enum HumanResourcesvEmployeeDepartmentHistoryFieldNames
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
	
		public static readonly IDictionary<int, string> HumanResourcesvEmployeeDepartmentHistoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.Title, "Title" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.FirstName, "FirstName" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.MiddleName, "MiddleName" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.LastName, "LastName" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.Suffix, "Suffix" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.Shift, "Shift" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.Department, "Department" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.GroupName, "GroupName" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.StartDate, "StartDate" }, 
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.EndDate, "EndDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesvEmployeeDepartmentHistoryIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)HumanResourcesvEmployeeDepartmentHistoryFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public HumanResourcesvEmployeeDepartmentHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "HumanResources";
			TableName = "HumanResources.vEmployeeDepartmentHistory";
			TableAlias = "humanresourcesvemployeedepartmenthistory";
			Columns = HumanResourcesvEmployeeDepartmentHistoryColumnNames;
			IdColumns = HumanResourcesvEmployeeDepartmentHistoryIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		