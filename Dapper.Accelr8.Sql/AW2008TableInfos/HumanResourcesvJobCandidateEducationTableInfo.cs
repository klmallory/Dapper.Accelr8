
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
	public enum HumanResourcesvJobCandidateEducationFieldNames
	{	
		JobCandidateID, 	
		Edu__Level, 	
		Edu__StartDate, 	
		Edu__EndDate, 	
		Edu__Degree, 	
		Edu__Major, 	
		Edu__Minor, 	
		Edu__GPA, 	
		Edu__GPAScale, 	
		Edu__School, 	
		Edu__Loc__CountryRegion, 	
		Edu__Loc__State, 	
		Edu__Loc__City, 	
	}

	public enum HumanResourcesvJobCandidateEducationCascadeNames
	{	
		}

	public class HumanResourcesvJobCandidateEducationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> HumanResourcesvJobCandidateEducationColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesvJobCandidateEducationFieldNames.JobCandidateID, "JobCandidateID" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__Level, "Edu.Level" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__StartDate, "Edu.StartDate" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__EndDate, "Edu.EndDate" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__Degree, "Edu.Degree" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__Major, "Edu.Major" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__Minor, "Edu.Minor" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__GPA, "Edu.GPA" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__GPAScale, "Edu.GPAScale" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__School, "Edu.School" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__Loc__CountryRegion, "Edu.Loc.CountryRegion" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__Loc__State, "Edu.Loc.State" }, 
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.Edu__Loc__City, "Edu.Loc.City" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesvJobCandidateEducationIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)HumanResourcesvJobCandidateEducationFieldNames.JobCandidateID, "JobCandidateID" }, 
				};

		public HumanResourcesvJobCandidateEducationTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "HumanResources";
			TableName = "HumanResources.vJobCandidateEducation";
			TableAlias = "humanresourcesvjobcandidateeducation";
			Columns = HumanResourcesvJobCandidateEducationColumnNames;
			IdColumns = HumanResourcesvJobCandidateEducationIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		