
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
    public class HumanResourcesShiftWriter : EntityWriter<byte, HumanResourcesShift>
    {
        public HumanResourcesShiftWriter
			(HumanResourcesShiftTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, HumanResourcesEmployeeDepartmentHistory> GetHumanResourcesEmployeeDepartmentHistoryWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesEmployeeDepartmentHistory>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, HumanResourcesShift entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((HumanResourcesShiftColumnNames)f.Key)
                {
                    
					case HumanResourcesShiftColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case HumanResourcesShiftColumnNames.StartTime:
						parms.Add(GetParamName("StartTime", actionType, taskIndex, ref count), entity.StartTime);
						break;
					case HumanResourcesShiftColumnNames.EndTime:
						parms.Add(GetParamName("EndTime", actionType, taskIndex, ref count), entity.EndTime);
						break;
					case HumanResourcesShiftColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(HumanResourcesShift entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_EmployeeDepartmentHistory_Shift_ShiftID
			var humanResourcesEmployeeDepartmentHistory371 = GetHumanResourcesEmployeeDepartmentHistoryWriter();
			if (_cascades.Contains(HumanResourcesShiftCascadeNames.humanresources.employeedepartmenthistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployeeDepartmentHistories)
					Cascade(humanResourcesEmployeeDepartmentHistory371, item, context);

			if (humanResourcesEmployeeDepartmentHistory371.Count > 0)
				WithChild(humanResourcesEmployeeDepartmentHistory371, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, HumanResourcesShift entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_EmployeeDepartmentHistory_Shift_ShiftID
			if (entity.HumanResourcesEmployeeDepartmentHistories != null && entity.HumanResourcesEmployeeDepartmentHistories.Count > 0)
				foreach (var rel in entity.HumanResourcesEmployeeDepartmentHistories)
					rel.HumanResourcesEmployeeDepartmentHistory = entity.Id;

				
		}

		protected override void RemoveRelations(HumanResourcesShift entity, ScriptContext context)
        {
					//From Foreign Key FK_EmployeeDepartmentHistory_Shift_ShiftID
			var humanResourcesEmployeeDepartmentHistory373 = GetHumanResourcesEmployeeDepartmentHistoryWriter();
			if (_cascades.Contains(HumanResourcesShiftCascadeNames.humanresources.employeedepartmenthistory.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployeeDepartmentHistories)
					CascadeDelete(humanResourcesEmployeeDepartmentHistory373, item, context);

			if (humanResourcesEmployeeDepartmentHistory373.Count > 0)
				WithChild(humanResourcesEmployeeDepartmentHistory373, entity);

				}
	}
}
		