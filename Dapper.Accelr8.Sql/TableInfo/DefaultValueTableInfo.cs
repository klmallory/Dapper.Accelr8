
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
	public enum DefaultValueColumnNames
	{	
		DefaultValueId, 	
		WorkspaceId, 	
		Value, 	
		Mnemonic, 	
	}

	public enum DefaultValueCascadeNames
	{	
		
		workspace, 	
	}

	public class DefaultValueTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public DefaultValueTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = DefaultValueColumnNames.DefaultValueId.ToString();
			TableName = "DefaultValues";
			TableAlias = "defaultvalue";
			ColumnNames = Enum.GetNames(typeof(DefaultValueColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_DefaultValues_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as DefaultValue);

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
					ParentField = DefaultValueColumnNames.DefaultValueId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		