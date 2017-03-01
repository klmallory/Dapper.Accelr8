
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
	public enum HumanResourcesvJobCandidateEmploymentColumnNames
	{	
		JobCandidateID, 	
		Emp__StartDate, 	
		Emp__EndDate, 	
		Emp__OrgName, 	
		Emp__JobTitle, 	
		Emp__Responsibility, 	
		Emp__FunctionCategory, 	
		Emp__IndustryCategory, 	
		Emp__Loc__CountryRegion, 	
		Emp__Loc__State, 	
		Emp__Loc__City, 	
	}

	public enum HumanResourcesvJobCandidateEmploymentCascadeNames
	{	
		}

	public class HumanResourcesvJobCandidateEmploymentTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public HumanResourcesvJobCandidateEmploymentTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = HumanResourcesvJobCandidateEmploymentColumnNames.JobCandidateID.ToString();
			//Schema = "HumanResources.vJobCandidateEmployment";
			TableName = "HumanResources.vJobCandidateEmployment";
			TableAlias = "humanresourcesvjobcandidateemployment";
			ColumnNames = typeof(HumanResourcesvJobCandidateEmploymentColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		