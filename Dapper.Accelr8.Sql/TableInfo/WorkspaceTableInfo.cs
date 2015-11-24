
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
	public enum WorkspaceColumnNames
	{	
		WorkspaceId, 	
		Name, 	
		Description, 	
		TransactionType, 	
		CaptureProfile, 	
		ORI, 	
		DAI, 	
		AgencyId, 	
		TCNFormat, 	
		Incrementor, 	
		AllowCopyTo, 	
		PhotoCaptureProfile, 	
		ReuseTCN, 	
		ShowPhotoProfile, 	
		ShowDocumentProfile, 	
		DocumentCaptureProfile, 	
		AgencyConfigKey, 	
		ReuseTCNText, 	
		ReuseTCNYesAction, 	
		AllowBioImport, 	
		UsePreface, 	
		EnforceCompliance, 	
	}

	public enum WorkspaceCascadeNames
	{	
		defaultvalue, 	
		workspacegroup, 	
		workspacename, 	
		transaction, 	
		biographicgroup, 	
		
		agency, 	
	}

	public class WorkspaceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public WorkspaceTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = WorkspaceColumnNames.WorkspaceId.ToString();
			TableName = "Workspaces";
			TableAlias = "workspace";
			ColumnNames = Enum.GetNames(typeof(WorkspaceColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Workspaces_Agencies
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Agency))),
			TableName = "Agencies",
			Alias = TableAlias + "_" + "agency",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Agency));
					var st = (entity as Workspace);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Agency = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = AgencyColumnNames.AgencyId.ToString(),
					Operator = Operator.Equals,
					ParentField = WorkspaceColumnNames.WorkspaceId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		