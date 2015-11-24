
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum WorkspaceGroupColumnNames
	{	
		WorkspaceGroupId, 	
		WorkspaceId, 	
		GroupId, 	
	}

	public enum WorkspaceGroupCascadeNames
	{	
		
		group, 	
		workspace, 	
	}

	public class WorkspaceGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public WorkspaceGroupTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = WorkspaceGroupColumnNames.WorkspaceGroupId.ToString();
			TableName = "WorkspaceGroups";
			TableAlias = "workspacegroup";
			ColumnNames = Enum.GetNames(typeof(WorkspaceGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_WorkspaceGroups_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as WorkspaceGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = WorkspaceGroupColumnNames.WorkspaceGroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_WorkspaceGroups_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as WorkspaceGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Workspace = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = WorkspaceColumnNames.WorkspaceId.ToString(),
					Operator = Operator.Equals,
					ParentField = WorkspaceGroupColumnNames.WorkspaceGroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		