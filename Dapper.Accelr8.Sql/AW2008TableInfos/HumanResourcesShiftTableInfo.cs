
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
	public enum HumanResourcesShiftFieldNames
	{	
		Id, 	
		Name, 	
		StartTime, 	
		EndTime, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesShiftCascadeNames
	{	
		humanresourcesemployeedepartmenthistories, 	
		}

	public class HumanResourcesShiftTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> HumanResourcesShiftColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesShiftFieldNames.Id, "ShiftID" }, 
						{ (int)HumanResourcesShiftFieldNames.Name, "Name" }, 
						{ (int)HumanResourcesShiftFieldNames.StartTime, "StartTime" }, 
						{ (int)HumanResourcesShiftFieldNames.EndTime, "EndTime" }, 
						{ (int)HumanResourcesShiftFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesShiftIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesShiftFieldNames.Id, "ShiftID" }, 
				};

		public HumanResourcesShiftTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "HumanResources";
			TableName = "HumanResources.Shift";
			TableAlias = "humanresourcesshift";
			Columns = HumanResourcesShiftColumnNames;
			IdColumns = HumanResourcesShiftIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		