
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
    public class HumanResourcesShiftReader : EntityReader<byte, HumanResourcesShift>
    {
        public HumanResourcesShiftReader(
            HumanResourcesShiftTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , HumanResourcesEmployeeDepartmentHistory> _humanResourcesEmployeeDepartmentHistoryReader;
		protected static IEntityReader<int , HumanResourcesEmployeeDepartmentHistory> GetHumanResourcesEmployeeDepartmentHistoryReader()
		{
			return _locator.Resolve<IEntityReader<int , HumanResourcesEmployeeDepartmentHistory>>();
		}

		
		/// <summary>
		/// Sets the children of type HumanResourcesEmployeeDepartmentHistory on the parent on HumanResourcesEmployeeDepartmentHistories.
		/// From foriegn key FK_EmployeeDepartmentHistory_Shift_ShiftID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenHumanResourcesEmployeeDepartmentHistories(IList<HumanResourcesShift> results, IList<object> children)
		{
			//Child Id Type: byte
			//Child Type: HumanResourcesEmployeeDepartmentHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<HumanResourcesEmployeeDepartmentHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.HumanResourcesEmployeeDepartmentHistories = typedChildren.Where(b => b.HumanResourcesEmployeeDepartmentHistory == r.Id).ToList();
				r.HumanResourcesEmployeeDepartmentHistories.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesShift = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table HumanResources.Shift into class HumanResourcesShift
		/// </summary>
		/// <param name="results">HumanResourcesShift</param>
		/// <param name="row"></param>
        public override HumanResourcesShift LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesShift();
			domain.Loaded = false;

			domain.Id = GetRowData<byte>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.StartTime = GetRowData<TimeSpan>(dataRow, "StartTime"); 
      		domain.EndTime = GetRowData<TimeSpan>(dataRow, "EndTime"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified byte Id.
		/// </summary>
		/// <param name="results">IEntityReader<byte, HumanResourcesShift></param>
		/// <param name="id">byte</param>
        public override IEntityReader<byte, HumanResourcesShift> WithAllChildrenForId(byte id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetHumanResourcesEmployeeDepartmentHistoryReader(), id, IdColumn, SetChildrenHumanResourcesEmployeeDepartmentHistories);
			
            return this;
        }

        public override void SetAllChildrenForExisting(HumanResourcesShift entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetHumanResourcesEmployeeDepartmentHistoryReader(), entity.Id
				, HumanResourcesEmployeeDepartmentHistoryColumnNames.ShiftID.ToString()
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);

			QueryResultForChildrenOnly(new List<HumanResourcesShift>() { entity });
			entity.Loaded = false;
			GetHumanResourcesEmployeeDepartmentHistoryReader().SetAllChildrenForExisting(entity.HumanResourcesEmployeeDepartmentHistories);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesShift> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetHumanResourcesEmployeeDepartmentHistoryReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), HumanResourcesEmployeeDepartmentHistoryColumnNames.ShiftID.ToString()
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);

					
			QueryResultForChildrenOnly(entities);

			GetHumanResourcesEmployeeDepartmentHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesEmployeeDepartmentHistories).ToList());
					
		}
    }
}
		