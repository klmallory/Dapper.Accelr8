
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
	public enum HumanResourcesDepartmentFieldNames
	{	
		Id, 	
		Name, 	
		GroupName, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesDepartmentCascadeNames
	{	
		humanresourcesemployeedepartmenthistories, 	
		}

	public class HumanResourcesDepartmentTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> HumanResourcesDepartmentColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesDepartmentFieldNames.Id, "DepartmentID" }, 
						{ (int)HumanResourcesDepartmentFieldNames.Name, "Name" }, 
						{ (int)HumanResourcesDepartmentFieldNames.GroupName, "GroupName" }, 
						{ (int)HumanResourcesDepartmentFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesDepartmentIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesDepartmentFieldNames.Id, "DepartmentID" }, 
				};

		public HumanResourcesDepartmentTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "HumanResources";
			TableName = "HumanResources.Department";
			TableAlias = "humanresourcesdepartment";
			Columns = HumanResourcesDepartmentColumnNames;
			IdColumns = HumanResourcesDepartmentIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		