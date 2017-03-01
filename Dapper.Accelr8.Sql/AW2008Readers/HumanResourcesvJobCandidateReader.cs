
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
    public class HumanResourcesvJobCandidateReader : EntityReader<int, HumanResourcesvJobCandidate>
    {
        public HumanResourcesvJobCandidateReader(
            HumanResourcesvJobCandidateTableInfo tableInfo
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
		/// Loads the table HumanResources.vJobCandidate into class HumanResourcesvJobCandidate
		/// </summary>
		/// <param name="results">HumanResourcesvJobCandidate</param>
		/// <param name="row"></param>
        public override HumanResourcesvJobCandidate LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesvJobCandidate();
			domain.Loaded = false;

				domain.BusinessEntityID = GetRowData<int?>(dataRow, "BusinessEntityID"); 
      		domain.Name__Prefix = GetRowData<string>(dataRow, "Name.Prefix"); 
      		domain.Name__First = GetRowData<string>(dataRow, "Name.First"); 
      		domain.Name__Middle = GetRowData<string>(dataRow, "Name.Middle"); 
      		domain.Name__Last = GetRowData<string>(dataRow, "Name.Last"); 
      		domain.Name__Suffix = GetRowData<string>(dataRow, "Name.Suffix"); 
      		domain.Skills = GetRowData<string>(dataRow, "Skills"); 
      		domain.Addr__Type = GetRowData<string>(dataRow, "Addr.Type"); 
      		domain.Addr__Loc__CountryRegion = GetRowData<string>(dataRow, "Addr.Loc.CountryRegion"); 
      		domain.Addr__Loc__State = GetRowData<string>(dataRow, "Addr.Loc.State"); 
      		domain.Addr__Loc__City = GetRowData<string>(dataRow, "Addr.Loc.City"); 
      		domain.Addr__PostalCode = GetRowData<string>(dataRow, "Addr.PostalCode"); 
      		domain.EMail = GetRowData<string>(dataRow, "EMail"); 
      		domain.WebSite = GetRowData<string>(dataRow, "WebSite"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, HumanResourcesvJobCandidate></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, HumanResourcesvJobCandidate> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(HumanResourcesvJobCandidate entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesvJobCandidate> entities)
        {
					
		}
    }
}
		