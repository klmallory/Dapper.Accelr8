
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
	public enum HumanResourcesvJobCandidateEducationColumnNames
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
		public HumanResourcesvJobCandidateEducationTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = HumanResourcesvJobCandidateEducationColumnNames.JobCandidateID.ToString();
			//Schema = "HumanResources.vJobCandidateEducation";
			TableName = "HumanResources.vJobCandidateEducation";
			TableAlias = "humanresourcesvjobcandidateeducation";
			ColumnNames = typeof(HumanResourcesvJobCandidateEducationColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		