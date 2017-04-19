
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

namespace Dapper.Accelr8.AW2008Writers
{
    public class HumanResourcesDepartmentWriter : EntityWriter<short, HumanResourcesDepartment>
    {
        public HumanResourcesDepartmentWriter
			(HumanResourcesDepartmentTableInfo tableInfo
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

		static IEntityWriter<int, HumanResourcesEmployeeDepartmentHistory> GetHumanResourcesEmployeeDepartmentHistoryWriter()
		{ return s_loc8r.GetWriter<int, HumanResourcesEmployeeDepartmentHistory>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, HumanResourcesDepartment entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((HumanResourcesDepartmentFieldNames)f.Key)
                {
                    
					case HumanResourcesDepartmentFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case HumanResourcesDepartmentFieldNames.GroupName:
						parms.Add(GetParamName("GroupName", actionType, taskIndex, ref count), entity.GroupName);
						break;
					case HumanResourcesDepartmentFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(HumanResourcesDepartment entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_EmployeeDepartmentHistory_Department_DepartmentID
			var humanResourcesEmployeeDepartmentHistory98 = GetHumanResourcesEmployeeDepartmentHistoryWriter();
			if (_cascades.Contains(HumanResourcesDepartmentCascadeNames.humanresourcesemployeedepartmenthistories.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployeeDepartmentHistories)
					Cascade(humanResourcesEmployeeDepartmentHistory98, item, context);

			if (humanResourcesEmployeeDepartmentHistory98.Count > 0)
				WithChild(humanResourcesEmployeeDepartmentHistory98, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, HumanResourcesDepartment entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_EmployeeDepartmentHistory_Department_DepartmentID
			if (entity.HumanResourcesEmployeeDepartmentHistories != null && entity.HumanResourcesEmployeeDepartmentHistories.Count > 0)
				foreach (var rel in entity.HumanResourcesEmployeeDepartmentHistories)
					rel.DepartmentID = entity.Id;

				
		}

		protected override void RemoveRelations(HumanResourcesDepartment entity, ScriptContext context)
        {
					//From Foreign Key FK_EmployeeDepartmentHistory_Department_DepartmentID
			var humanResourcesEmployeeDepartmentHistory100 = GetHumanResourcesEmployeeDepartmentHistoryWriter();
			if (_cascades.Contains(HumanResourcesDepartmentCascadeNames.humanresourcesemployeedepartmenthistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployeeDepartmentHistories)
					CascadeDelete(humanResourcesEmployeeDepartmentHistory100, item, context);

			if (humanResourcesEmployeeDepartmentHistory100.Count > 0)
				WithChild(humanResourcesEmployeeDepartmentHistory100, entity);

				}
	}
}
		