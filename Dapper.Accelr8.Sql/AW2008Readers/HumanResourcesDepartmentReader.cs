
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
    public class HumanResourcesDepartmentReader : EntityReader<short, HumanResourcesDepartment>
    {
        public HumanResourcesDepartmentReader(
            HumanResourcesDepartmentTableInfo tableInfo
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

		//Child Count 1
		//Parent Count 0
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , HumanResourcesEmployeeDepartmentHistory> GetHumanResourcesEmployeeDepartmentHistoryReader()
		{
			return s_loc8r.GetReader<CompoundKey , HumanResourcesEmployeeDepartmentHistory>();
		}

		
		/// <summary>
		/// Sets the children of type HumanResourcesEmployeeDepartmentHistory on the parent on HumanResourcesEmployeeDepartmentHistories.
		/// From foriegn key FK_EmployeeDepartmentHistory_Department_DepartmentID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenHumanResourcesEmployeeDepartmentHistories(IList<HumanResourcesDepartment> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: HumanResourcesEmployeeDepartmentHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<HumanResourcesEmployeeDepartmentHistory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.HumanResourcesEmployeeDepartmentHistories = typedChildren.Where(b =>  b.DepartmentID == r.Id ).ToList();
				r.HumanResourcesEmployeeDepartmentHistories.ToList().ForEach(b => { b.Loaded = false; b.HumanResourcesDepartment = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table HumanResources.Department into class HumanResourcesDepartment
		/// </summary>
		/// <param name="results">HumanResourcesDepartment</param>
		/// <param name="row"></param>
        public override HumanResourcesDepartment LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new HumanResourcesDepartment();
			domain.Loaded = false;

			domain.Id = GetRowData<short>(dataRow, "DepartmentID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.GroupName = GetRowData<object>(dataRow, "GroupName"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified short Id.
		/// </summary>
		/// <param name="results">IEntityReader<short, HumanResourcesDepartment></param>
		/// <param name="id">short</param>
        public override IEntityReader<short, HumanResourcesDepartment> WithAllChildrenForExisting(HumanResourcesDepartment existing)
        {
						WithChildForParentValues(GetHumanResourcesEmployeeDepartmentHistoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "DepartmentID",  }
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);
			
            return this;
        }


        public override void SetAllChildrenForExisting(HumanResourcesDepartment entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetHumanResourcesEmployeeDepartmentHistoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "DepartmentID",  }
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);

			
QueryResultForChildrenOnly(new List<HumanResourcesDepartment>() { entity });
			entity.Loaded = false;
			GetHumanResourcesEmployeeDepartmentHistoryReader().SetAllChildrenForExisting(entity.HumanResourcesEmployeeDepartmentHistories);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<HumanResourcesDepartment> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetHumanResourcesEmployeeDepartmentHistoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "DepartmentID",  }
				, SetChildrenHumanResourcesEmployeeDepartmentHistories);

					
			QueryResultForChildrenOnly(entities);

			GetHumanResourcesEmployeeDepartmentHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesEmployeeDepartmentHistories).ToList());
					
		}
    }
}
		