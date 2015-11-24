
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
using Dapper.Accelr8.Repo.Contracts.Writers;

namespace Dapper.Accelr8.Writers
{
    public class WorkspaceWriter : EntityWriter<int, Workspace>
    {
        public WorkspaceWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , DefaultValue> GetDefaultValueWriter()
		{ return _locator.Resolve<IEntityWriter<int , DefaultValue>>(); }
		static IEntityWriter<int , WorkspaceGroup> GetWorkspaceGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , WorkspaceGroup>>(); }
		static IEntityWriter<int , WorkspaceName> GetWorkspaceNameWriter()
		{ return _locator.Resolve<IEntityWriter<int , WorkspaceName>>(); }
		static IEntityWriter<int , Transaction> GetTransactionWriter()
		{ return _locator.Resolve<IEntityWriter<int , Transaction>>(); }
		static IEntityWriter<int , BiographicGroup> GetBiographicGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , BiographicGroup>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Workspace entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(WorkspaceColumnNames.WorkspaceId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(WorkspaceColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(WorkspaceColumnNames.Description.ToString(), actionType, taskIndex, count), entity.Description);
			parms.Add(GetParamName(WorkspaceColumnNames.TransactionType.ToString(), actionType, taskIndex, count), entity.TransactionType);
			parms.Add(GetParamName(WorkspaceColumnNames.CaptureProfile.ToString(), actionType, taskIndex, count), entity.CaptureProfile);
			parms.Add(GetParamName(WorkspaceColumnNames.ORI.ToString(), actionType, taskIndex, count), entity.Ori);
			parms.Add(GetParamName(WorkspaceColumnNames.DAI.ToString(), actionType, taskIndex, count), entity.Dai);
			parms.Add(GetParamName(WorkspaceColumnNames.AgencyId.ToString(), actionType, taskIndex, count), entity.AgencyId);
			parms.Add(GetParamName(WorkspaceColumnNames.TCNFormat.ToString(), actionType, taskIndex, count), entity.TcnFormat);
			parms.Add(GetParamName(WorkspaceColumnNames.Incrementor.ToString(), actionType, taskIndex, count), entity.Incrementor);
			parms.Add(GetParamName(WorkspaceColumnNames.AllowCopyTo.ToString(), actionType, taskIndex, count), entity.AllowCopyTo);
			parms.Add(GetParamName(WorkspaceColumnNames.PhotoCaptureProfile.ToString(), actionType, taskIndex, count), entity.PhotoCaptureProfile);
			parms.Add(GetParamName(WorkspaceColumnNames.ReuseTCN.ToString(), actionType, taskIndex, count), entity.ReuseTcn);
			parms.Add(GetParamName(WorkspaceColumnNames.ShowPhotoProfile.ToString(), actionType, taskIndex, count), entity.ShowPhotoProfile);
			parms.Add(GetParamName(WorkspaceColumnNames.ShowDocumentProfile.ToString(), actionType, taskIndex, count), entity.ShowDocumentProfile);
			parms.Add(GetParamName(WorkspaceColumnNames.DocumentCaptureProfile.ToString(), actionType, taskIndex, count), entity.DocumentCaptureProfile);
			parms.Add(GetParamName(WorkspaceColumnNames.AgencyConfigKey.ToString(), actionType, taskIndex, count), entity.AgencyConfigKey);
			parms.Add(GetParamName(WorkspaceColumnNames.ReuseTCNText.ToString(), actionType, taskIndex, count), entity.ReuseTcnText);
			parms.Add(GetParamName(WorkspaceColumnNames.ReuseTCNYesAction.ToString(), actionType, taskIndex, count), entity.ReuseTcnYesAction);
			parms.Add(GetParamName(WorkspaceColumnNames.AllowBioImport.ToString(), actionType, taskIndex, count), entity.AllowBioImport);
			parms.Add(GetParamName(WorkspaceColumnNames.UsePreface.ToString(), actionType, taskIndex, count), entity.UsePreface);
			parms.Add(GetParamName(WorkspaceColumnNames.EnforceCompliance.ToString(), actionType, taskIndex, count), entity.EnforceCompliance);
					
			return parms;
        }


		protected override void CascadeRelations(Workspace entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_DefaultValues_Workspaces
			var defaultValue = GetDefaultValueWriter();
			if (_cascades.Contains(WorkspaceCascadeNames.defaultvalue.ToString()))
				foreach (var item in entity.DefaultValues)
					Cascade(defaultValue, item, context);

			if (defaultValue.Count > 0)
				WithChild(defaultValue, entity);

			//From Foreign Key FK_WorkspaceGroups_Workspaces
			var workspaceGroup = GetWorkspaceGroupWriter();
			if (_cascades.Contains(WorkspaceCascadeNames.workspacegroup.ToString()))
				foreach (var item in entity.WorkspaceGroups)
					Cascade(workspaceGroup, item, context);

			if (workspaceGroup.Count > 0)
				WithChild(workspaceGroup, entity);

			//From Foreign Key FK_WorkspaceName_Workspaces
			var workspaceName = GetWorkspaceNameWriter();
			if (_cascades.Contains(WorkspaceCascadeNames.workspacename.ToString()))
				foreach (var item in entity.WorkspaceNames)
					Cascade(workspaceName, item, context);

			if (workspaceName.Count > 0)
				WithChild(workspaceName, entity);

			//From Foreign Key FK_Transactions_Workspaces
			var transaction = GetTransactionWriter();
			if (_cascades.Contains(WorkspaceCascadeNames.transaction.ToString()))
				foreach (var item in entity.Transactions)
					Cascade(transaction, item, context);

			if (transaction.Count > 0)
				WithChild(transaction, entity);

			//From Foreign Key FK_BiographicGroups_Workspaces
			var biographicGroup = GetBiographicGroupWriter();
			if (_cascades.Contains(WorkspaceCascadeNames.biographicgroup.ToString()))
				foreach (var item in entity.BiographicGroups)
					Cascade(biographicGroup, item, context);

			if (biographicGroup.Count > 0)
				WithChild(biographicGroup, entity);

		
        }


	}
}
		