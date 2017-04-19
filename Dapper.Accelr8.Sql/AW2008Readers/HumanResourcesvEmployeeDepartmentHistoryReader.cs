
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
    public class HumanResourcesvEmployeeDepartmentHistoryReader : EntityReader<int, HumanResourcesvEmployeeDepartmentHistory>
    {
        public HumanResourcesvEmployeeDepartmentHistoryReader(
            HumanResourcesvEmployeeDepartmentHistoryTableInfo tableInfo
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
		/// Loads the table HumanResources.vEmployeeDepartmentHistory into class HumanResourcesvEmployeeDepartmentHistory
		/// </summary>
		/// <param name="results">HumanResourcesvEmployeeDepartmentHistory</param>
		/// <param name="row"></param>
        public override HumanResourcesvEmployeeDepartmentHistory LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesvEmployeeDepartmentHistory();
			domain.Loaded = false;

			domain.BusinessEntityID = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.Title = GetRowData<string>(dataRow, "Title"); 
      		domain.FirstName = GetRowData<object>(dataRow, "FirstName"); 
      		domain.MiddleName = GetRowData<object>(dataRow, "MiddleName"); 
      		domain.LastName = GetRowData<object>(dataRow, "LastName"); 
      		domain.Suffix = GetRowData<string>(dataRow, "Suffix"); 
      		domain.Shift = GetRowData<object>(dataRow, "Shift"); 
      		domain.Department = GetRowData<object>(dataRow, "Department"); 
      		domain.GroupName = GetRowData<object>(dataRow, "GroupName"); 
      		domain.StartDate = GetRowData<DateTime>(dataRow, "StartDate"); 
      		domain.EndDate = GetRowData<DateTime?>(dataRow, "EndDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, HumanResourcesvEmployeeDepartmentHistory></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, HumanResourcesvEmployeeDepartmentHistory> WithAllChildrenForExisting(HumanResourcesvEmployeeDepartmentHistory existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(HumanResourcesvEmployeeDepartmentHistory entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesvEmployeeDepartmentHistory> entities)
        {
					
		}
    }
}
		