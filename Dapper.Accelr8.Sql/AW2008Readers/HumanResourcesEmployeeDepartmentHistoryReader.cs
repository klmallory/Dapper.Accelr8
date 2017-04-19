
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
    public class HumanResourcesEmployeeDepartmentHistoryReader : EntityReader<CompoundKey, HumanResourcesEmployeeDepartmentHistory>
    {
        public HumanResourcesEmployeeDepartmentHistoryReader(
            HumanResourcesEmployeeDepartmentHistoryTableInfo tableInfo
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
		//Parent Count 3
		
			/// <summary>
		/// Loads the table HumanResources.EmployeeDepartmentHistory into class HumanResourcesEmployeeDepartmentHistory
		/// </summary>
		/// <param name="results">HumanResourcesEmployeeDepartmentHistory</param>
		/// <param name="row"></param>
        public override HumanResourcesEmployeeDepartmentHistory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesEmployeeDepartmentHistory();
			domain.Loaded = false;

			domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.DepartmentID = GetRowData<short>(dataRow, "DepartmentID"); 
      		domain.ShiftID = GetRowData<byte>(dataRow, "ShiftID"); 
      		domain.StartDate = GetRowData<DateTime>(dataRow, "StartDate"); 
      		domain.EndDate = GetRowData<DateTime?>(dataRow, "EndDate"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      				domain.Id = HumanResourcesEmployeeDepartmentHistory.GetCompoundKeyFor(domain); 
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified CompoundKey Id.
		/// </summary>
		/// <param name="results">IEntityReader<CompoundKey, HumanResourcesEmployeeDepartmentHistory></param>
		/// <param name="id">CompoundKey</param>
        public override IEntityReader<CompoundKey, HumanResourcesEmployeeDepartmentHistory> WithAllChildrenForExisting(HumanResourcesEmployeeDepartmentHistory existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(HumanResourcesEmployeeDepartmentHistory entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesEmployeeDepartmentHistory> entities)
        {
					
		}
    }
}
		