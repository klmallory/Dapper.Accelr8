
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
	public enum HumanResourcesShiftColumnNames
	{	
		ShiftID, 	
		Name, 	
		StartTime, 	
		EndTime, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesShiftCascadeNames
	{	
		humanresourcesemployeedepartmenthistory, 	
		}

	public class HumanResourcesShiftTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public HumanResourcesShiftTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = HumanResourcesShiftColumnNames.ShiftID.ToString();
			//Schema = "HumanResources.Shift";
			TableName = "HumanResources.Shift";
			TableAlias = "humanresourcesshift";
			ColumnNames = typeof(HumanResourcesShiftColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		