
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
	public enum HumanResourcesvEmployeeDepartmentFieldNames
	{	
		BusinessEntityID, 	
		Title, 	
		FirstName, 	
		MiddleName, 	
		LastName, 	
		Suffix, 	
		JobTitle, 	
		Department, 	
		GroupName, 	
		StartDate, 	
	}

	public enum HumanResourcesvEmployeeDepartmentCascadeNames
	{	
		}

	public class HumanResourcesvEmployeeDepartmentTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> HumanResourcesvEmployeeDepartmentColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesvEmployeeDepartmentFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.Title, "Title" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.FirstName, "FirstName" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.MiddleName, "MiddleName" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.LastName, "LastName" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.Suffix, "Suffix" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.JobTitle, "JobTitle" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.Department, "Department" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.GroupName, "GroupName" }, 
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.StartDate, "StartDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesvEmployeeDepartmentIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)HumanResourcesvEmployeeDepartmentFieldNames.BusinessEntityID, "BusinessEntityID" }, 
				};

		public HumanResourcesvEmployeeDepartmentTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "HumanResources";
			TableName = "HumanResources.vEmployeeDepartment";
			TableAlias = "humanresourcesvemployeedepartment";
			Columns = HumanResourcesvEmployeeDepartmentColumnNames;
			IdColumns = HumanResourcesvEmployeeDepartmentIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		