
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
    public class HumanResourcesJobCandidateReader : EntityReader<int, HumanResourcesJobCandidate>
    {
        public HumanResourcesJobCandidateReader(
            HumanResourcesJobCandidateTableInfo tableInfo
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
		//Parent Count 1
		
			/// <summary>
		/// Loads the table HumanResources.JobCandidate into class HumanResourcesJobCandidate
		/// </summary>
		/// <param name="results">HumanResourcesJobCandidate</param>
		/// <param name="row"></param>
        public override HumanResourcesJobCandidate LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesJobCandidate();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "JobCandidateID"); 
      		domain.BusinessEntityID = GetRowData<int?>(dataRow, "BusinessEntityID"); 
      		domain.Resume = GetRowData<string>(dataRow, "Resume"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, HumanResourcesJobCandidate></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, HumanResourcesJobCandidate> WithAllChildrenForExisting(HumanResourcesJobCandidate existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(HumanResourcesJobCandidate entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesJobCandidate> entities)
        {
					
		}
    }
}
		