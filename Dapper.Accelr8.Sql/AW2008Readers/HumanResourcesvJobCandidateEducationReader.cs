
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
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008Readers
{
    public class HumanResourcesvJobCandidateEducationReader : EntityReader<int, HumanResourcesvJobCandidateEducation>
    {
        public HumanResourcesvJobCandidateEducationReader(
            HumanResourcesvJobCandidateEducationTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 0
		//Parent Count 0
		
			/// <summary>
		/// Loads the table HumanResources.vJobCandidateEducation into class HumanResourcesvJobCandidateEducation
		/// </summary>
		/// <param name="results">HumanResourcesvJobCandidateEducation</param>
		/// <param name="row"></param>
        public override HumanResourcesvJobCandidateEducation LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesvJobCandidateEducation();
			domain.Loaded = false;

			domain.JobCandidateID = GetRowData<int>(dataRow, "JobCandidateID"); 
      		domain.Edu__Level = GetRowData<string>(dataRow, "Edu.Level"); 
      		domain.Edu__StartDate = GetRowData<DateTime?>(dataRow, "Edu.StartDate"); 
      		domain.Edu__EndDate = GetRowData<DateTime?>(dataRow, "Edu.EndDate"); 
      		domain.Edu__Degree = GetRowData<string>(dataRow, "Edu.Degree"); 
      		domain.Edu__Major = GetRowData<string>(dataRow, "Edu.Major"); 
      		domain.Edu__Minor = GetRowData<string>(dataRow, "Edu.Minor"); 
      		domain.Edu__GPA = GetRowData<string>(dataRow, "Edu.GPA"); 
      		domain.Edu__GPAScale = GetRowData<string>(dataRow, "Edu.GPAScale"); 
      		domain.Edu__School = GetRowData<string>(dataRow, "Edu.School"); 
      		domain.Edu__Loc__CountryRegion = GetRowData<string>(dataRow, "Edu.Loc.CountryRegion"); 
      		domain.Edu__Loc__State = GetRowData<string>(dataRow, "Edu.Loc.State"); 
      		domain.Edu__Loc__City = GetRowData<string>(dataRow, "Edu.Loc.City"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, HumanResourcesvJobCandidateEducation></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, HumanResourcesvJobCandidateEducation> WithAllChildrenForExisting(HumanResourcesvJobCandidateEducation existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(HumanResourcesvJobCandidateEducation entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesvJobCandidateEducation> entities)
        {
					
		}
    }
}
		