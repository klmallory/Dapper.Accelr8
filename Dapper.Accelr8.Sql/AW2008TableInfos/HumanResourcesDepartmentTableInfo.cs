
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
	public enum HumanResourcesDepartmentColumnNames
	{	
		DepartmentID, 	
		Name, 	
		GroupName, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesDepartmentCascadeNames
	{	
		humanresourcesemployeedepartmenthistory, 	
		}

	public class HumanResourcesDepartmentTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public HumanResourcesDepartmentTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = HumanResourcesDepartmentColumnNames.DepartmentID.ToString();
			//Schema = "HumanResources.Department";
			TableName = "HumanResources.Department";
			TableAlias = "humanresourcesdepartment";
			ColumnNames = typeof(HumanResourcesDepartmentColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		