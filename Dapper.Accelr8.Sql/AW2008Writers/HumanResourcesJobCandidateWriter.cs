
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
    public class HumanResourcesJobCandidateWriter : EntityWriter<int, HumanResourcesJobCandidate>
    {
        public HumanResourcesJobCandidateWriter
			(HumanResourcesJobCandidateTableInfo tableInfo
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
        protected override IDictionary<string, object> GetParams(ActionType actionType, HumanResourcesJobCandidate entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((HumanResourcesJobCandidateColumnNames)f.Key)
                {
                    
					case HumanResourcesJobCandidateColumnNames.BusinessEntityID:
						parms.Add(GetParamName("BusinessEntityID", actionType, taskIndex, ref count), entity.BusinessEntityID);
						break;
					case HumanResourcesJobCandidateColumnNames.Resume:
						parms.Add(GetParamName("Resume", actionType, taskIndex, ref count), entity.Resume);
						break;
					case HumanResourcesJobCandidateColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(HumanResourcesJobCandidate entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_JobCandidate_Employee_BusinessEntityID
			var humanResourcesEmployee136 = GetHumanResourcesEmployeeWriter();
		if ((_cascades.Contains(HumanResourcesJobCandidateCascadeNames.humanresourcesemployee.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesEmployee != null)
			if (Cascade(humanResourcesEmployee136, entity.HumanResourcesEmployee, context))
				WithParent(humanResourcesEmployee136, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, HumanResourcesJobCandidate entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_JobCandidate_Employee_BusinessEntityID
			if (entity.HumanResourcesEmployee != null)
				entity.HumanResourcesJobCandidate = entity.HumanResourcesEmployee.Id;

		}

		protected override void RemoveRelations(HumanResourcesJobCandidate entity, ScriptContext context)
        {
				}
	}
}
		