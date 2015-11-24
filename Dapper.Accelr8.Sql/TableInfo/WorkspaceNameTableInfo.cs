
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
	public enum WorkspaceNameColumnNames
	{	
		WorkspaceNameId, 	
		WorkspaceId, 	
		Language, 	
		Name, 	
	}

	public enum WorkspaceNameCascadeNames
	{	
		
		workspace, 	
	}

	public class WorkspaceNameTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public WorkspaceNameTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = WorkspaceNameColumnNames.WorkspaceNameId.ToString();
			TableName = "WorkspaceName";
			TableAlias = "workspacename";
			ColumnNames = Enum.GetNames(typeof(WorkspaceNameColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_WorkspaceName_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as WorkspaceName);

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
					ParentField = WorkspaceNameColumnNames.WorkspaceNameId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		