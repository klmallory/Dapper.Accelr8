
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
	public enum HumanResourcesvJobCandidateEmploymentFieldNames
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
	
		public static readonly IDictionary<int, string> HumanResourcesvJobCandidateEmploymentColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.JobCandidateID, "JobCandidateID" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__StartDate, "Emp.StartDate" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__EndDate, "Emp.EndDate" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__OrgName, "Emp.OrgName" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__JobTitle, "Emp.JobTitle" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__Responsibility, "Emp.Responsibility" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__FunctionCategory, "Emp.FunctionCategory" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__IndustryCategory, "Emp.IndustryCategory" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__Loc__CountryRegion, "Emp.Loc.CountryRegion" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__Loc__State, "Emp.Loc.State" }, 
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.Emp__Loc__City, "Emp.Loc.City" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesvJobCandidateEmploymentIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)HumanResourcesvJobCandidateEmploymentFieldNames.JobCandidateID, "JobCandidateID" }, 
				};

		public HumanResourcesvJobCandidateEmploymentTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "HumanResources";
			TableName = "HumanResources.vJobCandidateEmployment";
			TableAlias = "humanresourcesvjobcandidateemployment";
			Columns = HumanResourcesvJobCandidateEmploymentColumnNames;
			IdColumns = HumanResourcesvJobCandidateEmploymentIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		