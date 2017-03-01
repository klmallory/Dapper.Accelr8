
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
    public class HumanResourcesEmployeeDepartmentHistoryWriter : EntityWriter<int, HumanResourcesEmployeeDepartmentHistory>
    {
        public HumanResourcesEmployeeDepartmentHistoryWriter
			(HumanResourcesEmployeeDepartmentHistoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<short, HumanResourcesDepartment> GetHumanResourcesDepartmentWriter()
		{ return _locator.Resolve<IEntityWriter<short, HumanResourcesDepartment>>(); }
		static IEntityWriter<int, HumanResourcesEmployee> GetHumanResourcesEmployeeWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesEmployee>>(); }
		static IEntityWriter<byte, HumanResourcesShift> GetHumanResourcesShiftWriter()
		{ return _locator.Resolve<IEntityWriter<byte, HumanResourcesShift>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, HumanResourcesEmployeeDepartmentHistory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((HumanResourcesEmployeeDepartmentHistoryColumnNames)f.Key)
                {
                    
					case HumanResourcesEmployeeDepartmentHistoryColumnNames.EndDate:
						parms.Add(GetParamName("EndDate", actionType, taskIndex, ref count), entity.EndDate);
						break;
					case HumanResourcesEmployeeDepartmentHistoryColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(HumanResourcesEmployeeDepartmentHistory entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_EmployeeDepartmentHistory_Department_DepartmentID
			var humanResourcesDepartment125 = GetHumanResourcesDepartmentWriter();
		if ((_cascades.Contains(HumanResourcesEmployeeDepartmentHistoryCascadeNames.humanresourcesdepartment.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesDepartment != null)
			if (Cascade(humanResourcesDepartment125, entity.HumanResourcesDepartment, context))
				WithParent(humanResourcesDepartment125, entity);

			//From Foreign Key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID
			var humanResourcesEmployee126 = GetHumanResourcesEmployeeWriter();
		if ((_cascades.Contains(HumanResourcesEmployeeDepartmentHistoryCascadeNames.humanresourcesemployee.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesEmployee != null)
			if (Cascade(humanResourcesEmployee126, entity.HumanResourcesEmployee, context))
				WithParent(humanResourcesEmployee126, entity);

			//From Foreign Key FK_EmployeeDepartmentHistory_Shift_ShiftID
			var humanResourcesShift127 = GetHumanResourcesShiftWriter();
		if ((_cascades.Contains(HumanResourcesEmployeeDepartmentHistoryCascadeNames.humanresourcesshift.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesShift != null)
			if (Cascade(humanResourcesShift127, entity.HumanResourcesShift, context))
				WithParent(humanResourcesShift127, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, HumanResourcesEmployeeDepartmentHistory entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_EmployeeDepartmentHistory_Department_DepartmentID
			if (entity.HumanResourcesDepartment != null)
				entity.HumanResourcesEmployeeDepartmentHistory = entity.HumanResourcesDepartment.Id;

			//From Foreign Key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID
			if (entity.HumanResourcesEmployee != null)
				entity.HumanResourcesEmployeeDepartmentHistory = entity.HumanResourcesEmployee.Id;

			//From Foreign Key FK_EmployeeDepartmentHistory_Shift_ShiftID
			if (entity.HumanResourcesShift != null)
				entity.HumanResourcesEmployeeDepartmentHistory = entity.HumanResourcesShift.Id;

		}

		protected override void RemoveRelations(HumanResourcesEmployeeDepartmentHistory entity, ScriptContext context)
        {
				}
	}
}
		