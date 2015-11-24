
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
	public enum BiographicGroupColumnNames
	{	
		BiographicGroupId, 	
		Name, 	
		WorkspaceId, 	
	}

	public enum BiographicGroupCascadeNames
	{	
		
		workspace, 	
	}

	public class BiographicGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public BiographicGroupTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = BiographicGroupColumnNames.BiographicGroupId.ToString();
			TableName = "BiographicGroups";
			TableAlias = "biographicgroup";
			ColumnNames = Enum.GetNames(typeof(BiographicGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_BiographicGroups_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as BiographicGroup);

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
					ParentField = BiographicGroupColumnNames.BiographicGroupId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		