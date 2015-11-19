

using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfo;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.Readers
{
    public class WorkspaceReader : EntityReader<int, Workspace>
    {
        public WorkspaceReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 4
		//Parent Count 1

		/// <summary>
		/// Sets the children of type DefaultValue on the parent on DefaultValues.
		/// From foriegn key FK_DefaultValues_Workspaces
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenDefaultValues(IList<Workspace> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: DefaultValue

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<DefaultValue>();

			foreach (var r in results)
			{
				r.DefaultValues = typedChildren.Where(b => b.DefaultValueId == r.Id).ToList();
				r.DefaultValues.ToList().ForEach(b => b.Workspace = r);
			}
		}

		/// <summary>
		/// Sets the children of type WorkspaceGroup on the parent on WorkspaceGroups.
		/// From foriegn key FK_WorkspaceGroups_Workspaces
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenWorkspaceGroups(IList<Workspace> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: WorkspaceGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<WorkspaceGroup>();

			foreach (var r in results)
			{
				r.WorkspaceGroups = typedChildren.Where(b => b.WorkspaceGroupId == r.Id).ToList();
				r.WorkspaceGroups.ToList().ForEach(b => b.Workspace = r);
			}
		}

		/// <summary>
		/// Sets the children of type Transaction on the parent on Transactions.
		/// From foriegn key FK_Transactions_Workspaces
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactions(IList<Workspace> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Transaction

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Transaction>();

			foreach (var r in results)
			{
				r.Transactions = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
				r.Transactions.ToList().ForEach(b => b.Workspace = r);
			}
		}

		/// <summary>
		/// Sets the children of type BiographicGroup on the parent on BiographicGroups.
		/// From foriegn key FK_BiographicGroups_Workspaces
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenBiographicGroups(IList<Workspace> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: BiographicGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<BiographicGroup>();

			foreach (var r in results)
			{
				r.BiographicGroups = typedChildren.Where(b => b.BiographicGroupId == r.Id).ToList();
				r.BiographicGroups.ToList().ForEach(b => b.Workspace = r);
			}
		}

			/// <summary>
		/// Loads the table Workspaces into class Workspace
		/// </summary>
		/// <param name="results">Workspace</param>
		/// <param name="row"></param>
        public override Workspace LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Workspace();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.Name = GetRowData<string>(dataRow, WorkspaceColumnNames.Name.ToString()); 	
			domain.Description = GetRowData<string>(dataRow, WorkspaceColumnNames.Description.ToString()); 	
			domain.TransactionType = GetRowData<string>(dataRow, WorkspaceColumnNames.TransactionType.ToString()); 	
			domain.CaptureProfile = GetRowData<string>(dataRow, WorkspaceColumnNames.CaptureProfile.ToString()); 	
			domain.ORI = GetRowData<string>(dataRow, WorkspaceColumnNames.ORI.ToString()); 	
			domain.DAI = GetRowData<string>(dataRow, WorkspaceColumnNames.DAI.ToString()); 	
			domain.AgencyId = GetRowData<int>(dataRow, WorkspaceColumnNames.AgencyId.ToString()); 	
			domain.TCNFormat = GetRowData<string>(dataRow, WorkspaceColumnNames.TCNFormat.ToString()); 	
			domain.Incrementor = GetRowData<int?>(dataRow, WorkspaceColumnNames.Incrementor.ToString()); 	
			domain.AllowCopyTo = GetRowData<bool?>(dataRow, WorkspaceColumnNames.AllowCopyTo.ToString()); 	
			domain.PhotoCaptureProfile = GetRowData<string>(dataRow, WorkspaceColumnNames.PhotoCaptureProfile.ToString()); 	
			domain.ReuseTCN = GetRowData<bool?>(dataRow, WorkspaceColumnNames.ReuseTCN.ToString()); 	
			domain.ShowPhotoProfile = GetRowData<bool?>(dataRow, WorkspaceColumnNames.ShowPhotoProfile.ToString()); 	
			domain.ShowDocumentProfile = GetRowData<bool?>(dataRow, WorkspaceColumnNames.ShowDocumentProfile.ToString()); 	
			domain.DocumentCaptureProfile = GetRowData<string>(dataRow, WorkspaceColumnNames.DocumentCaptureProfile.ToString()); 	
			domain.AgencyConfigKey = GetRowData<string>(dataRow, WorkspaceColumnNames.AgencyConfigKey.ToString()); 	
			domain.ReuseTCNText = GetRowData<string>(dataRow, WorkspaceColumnNames.ReuseTCNText.ToString()); 	
			domain.ReuseTCNYesAction = GetRowData<bool?>(dataRow, WorkspaceColumnNames.ReuseTCNYesAction.ToString()); 	
			domain.AllowBioImport = GetRowData<bool?>(dataRow, WorkspaceColumnNames.AllowBioImport.ToString()); 	
			domain.UsePreface = GetRowData<bool?>(dataRow, WorkspaceColumnNames.UsePreface.ToString()); 	
			domain.EnforceCompliance = GetRowData<bool?>(dataRow, WorkspaceColumnNames.EnforceCompliance.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, Workspace> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , DefaultValues>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , WorkspaceGroups>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , BiographicGroups>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Workspace entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , DefaultValues>(), id, IdField, SetChildrenDefaultValues);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , WorkspaceGroups>(), id, IdField, SetChildrenWorkspaceGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildrenTransactions);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , BiographicGroups>(), id, IdField, SetChildrenBiographicGroups);
			QueryResultForChildrenOnly(new List<Workspace>() { entity });

			_locator.Resolve<IEntityReader<int , DefaultValues>().SetAllChildrenForExisting(entity.DefaultValues);
			_locator.Resolve<IEntityReader<int , WorkspaceGroups>().SetAllChildrenForExisting(entity.WorkspaceGroups);
			_locator.Resolve<IEntityReader<int , Transactions>().SetAllChildrenForExisting(entity.Transactions);
			_locator.Resolve<IEntityReader<int , BiographicGroups>().SetAllChildrenForExisting(entity.BiographicGroups);
				
		}

		public override void SetAllChildrenForExisting(IList<Workspace> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , DefaultValues>(), id, IdField, SetChildrenDefaultValues);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , WorkspaceGroups>(), id, IdField, SetChildrenWorkspaceGroups);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Transactions>(), id, IdField, SetChildrenTransactions);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , BiographicGroups>(), id, IdField, SetChildrenBiographicGroups);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, DefaultValues>().SetAllChildrenForExisting(entities.SelectMany(e => e.DefaultValues));
			_locator.Resolve<IEntityReader<int, WorkspaceGroups>().SetAllChildrenForExisting(entities.SelectMany(e => e.WorkspaceGroups));
			_locator.Resolve<IEntityReader<int, Transactions>().SetAllChildrenForExisting(entities.SelectMany(e => e.Transactions));
			_locator.Resolve<IEntityReader<int, BiographicGroups>().SetAllChildrenForExisting(entities.SelectMany(e => e.BiographicGroups));
					
		}
    }
}
		