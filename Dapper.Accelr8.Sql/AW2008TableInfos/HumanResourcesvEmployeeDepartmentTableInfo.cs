
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
	public enum HumanResourcesvEmployeeDepartmentColumnNames
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
		public HumanResourcesvEmployeeDepartmentTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = HumanResourcesvEmployeeDepartmentColumnNames.BusinessEntityID.ToString();
			//Schema = "HumanResources.vEmployeeDepartment";
			TableName = "HumanResources.vEmployeeDepartment";
			TableAlias = "humanresourcesvemployeedepartment";
			ColumnNames = typeof(HumanResourcesvEmployeeDepartmentColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		