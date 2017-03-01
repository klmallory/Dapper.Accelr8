
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
    public class HumanResourcesEmployeePayHistoryWriter : EntityWriter<int, HumanResourcesEmployeePayHistory>
    {
        public HumanResourcesEmployeePayHistoryWriter
			(HumanResourcesEmployeePayHistoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, HumanResourcesEmployee> GetHumanResourcesEmployeeWriter()
		{ return _locator.Resolve<IEntityWriter<int, HumanResourcesEmployee>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, HumanResourcesEmployeePayHistory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((HumanResourcesEmployeePayHistoryColumnNames)f.Key)
                {
                    
					case HumanResourcesEmployeePayHistoryColumnNames.Rate:
						parms.Add(GetParamName("Rate", actionType, taskIndex, ref count), entity.Rate);
						break;
					case HumanResourcesEmployeePayHistoryColumnNames.PayFrequency:
						parms.Add(GetParamName("PayFrequency", actionType, taskIndex, ref count), entity.PayFrequency);
						break;
					case HumanResourcesEmployeePayHistoryColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(HumanResourcesEmployeePayHistory entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_EmployeePayHistory_Employee_BusinessEntityID
			var humanResourcesEmployee131 = GetHumanResourcesEmployeeWriter();
		if ((_cascades.Contains(HumanResourcesEmployeePayHistoryCascadeNames.humanresourcesemployee.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesEmployee != null)
			if (Cascade(humanResourcesEmployee131, entity.HumanResourcesEmployee, context))
				WithParent(humanResourcesEmployee131, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, HumanResourcesEmployeePayHistory entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_EmployeePayHistory_Employee_BusinessEntityID
			if (entity.HumanResourcesEmployee != null)
				entity.HumanResourcesEmployeePayHistory = entity.HumanResourcesEmployee.Id;

		}

		protected override void RemoveRelations(HumanResourcesEmployeePayHistory entity, ScriptContext context)
        {
				}
	}
}
		