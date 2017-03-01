
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
    public class HumanResourcesvJobCandidateEmploymentReader : EntityReader<int, HumanResourcesvJobCandidateEmployment>
    {
        public HumanResourcesvJobCandidateEmploymentReader(
            HumanResourcesvJobCandidateEmploymentTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 0
		//Parent Count 0
		
			/// <summary>
		/// Loads the table HumanResources.vJobCandidateEmployment into class HumanResourcesvJobCandidateEmployment
		/// </summary>
		/// <param name="results">HumanResourcesvJobCandidateEmployment</param>
		/// <param name="row"></param>
        public override HumanResourcesvJobCandidateEmployment LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesvJobCandidateEmployment();
			domain.Loaded = false;

				domain.Emp__StartDate = GetRowData<DateTime?>(dataRow, "Emp.StartDate"); 
      		domain.Emp__EndDate = GetRowData<DateTime?>(dataRow, "Emp.EndDate"); 
      		domain.Emp__OrgName = GetRowData<string>(dataRow, "Emp.OrgName"); 
      		domain.Emp__JobTitle = GetRowData<string>(dataRow, "Emp.JobTitle"); 
      		domain.Emp__Responsibility = GetRowData<string>(dataRow, "Emp.Responsibility"); 
      		domain.Emp__FunctionCategory = GetRowData<string>(dataRow, "Emp.FunctionCategory"); 
      		domain.Emp__IndustryCategory = GetRowData<string>(dataRow, "Emp.IndustryCategory"); 
      		domain.Emp__Loc__CountryRegion = GetRowData<string>(dataRow, "Emp.Loc.CountryRegion"); 
      		domain.Emp__Loc__State = GetRowData<string>(dataRow, "Emp.Loc.State"); 
      		domain.Emp__Loc__City = GetRowData<string>(dataRow, "Emp.Loc.City"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, HumanResourcesvJobCandidateEmployment></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, HumanResourcesvJobCandidateEmployment> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(HumanResourcesvJobCandidateEmployment entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesvJobCandidateEmployment> entities)
        {
					
		}
    }
}
		