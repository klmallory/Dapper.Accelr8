

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
		static IEntityReader<int , DefaultValue> _defaultValueReader;
		static IEntityReader<int , DefaultValue> GetDefaultValueReader()
		{
			if (_defaultValueReader == null)
				_defaultValueReader = _locator.Resolve<IEntityReader<int , DefaultValue>>();

			return _defaultValueReader;
		}

		static IEntityReader<int , WorkspaceGroup> _workspaceGroupReader;
		static IEntityReader<int , WorkspaceGroup> GetWorkspaceGroupReader()
		{
			if (_workspaceGroupReader == null)
				_workspaceGroupReader = _locator.Resolve<IEntityReader<int , WorkspaceGroup>>();

			return _workspaceGroupReader;
		}

		static IEntityReader<int , Transaction> _transactionReader;
		static IEntityReader<int , Transaction> GetTransactionReader()
		{
			if (_transactionReader == null)
				_transactionReader = _locator.Resolve<IEntityReader<int , Transaction>>();

			return _transactionReader;
		}

		static IEntityReader<int , BiographicGroup> _biographicGroupReader;
		static IEntityReader<int , BiographicGroup> GetBiographicGroupReader()
		{
			if (_biographicGroupReader == null)
				_biographicGroupReader = _locator.Resolve<IEntityReader<int , BiographicGroup>>();

			return _biographicGroupReader;
		}

		
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
				r.DefaultValues = typedChildren.Where(b => b.WorkspaceId == r.Id).ToList();
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
				r.WorkspaceGroups = typedChildren.Where(b => b.WorkspaceId == r.Id).ToList();
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
				r.Transactions = typedChildren.Where(b => b.WorkspaceId == r.Id).ToList();
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
				r.BiographicGroups = typedChildren.Where(b => b.WorkspaceId == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.Name = GetRowData<string>(dataRow, WorkspaceColumnNames.Name.ToString()); 	
			domain.Description = GetRowData<string>(dataRow, WorkspaceColumnNames.Description.ToString()); 	
			domain.TransactionType = GetRowData<string>(dataRow, WorkspaceColumnNames.TransactionType.ToString()); 	
			domain.CaptureProfile = GetRowData<string>(dataRow, WorkspaceColumnNames.CaptureProfile.ToString()); 	
			domain.Ori = GetRowData<string>(dataRow, WorkspaceColumnNames.ORI.ToString()); 	
			domain.Dai = GetRowData<string>(dataRow, WorkspaceColumnNames.DAI.ToString()); 	
			domain.AgencyId = GetRowData<int>(dataRow, WorkspaceColumnNames.AgencyId.ToString()); 	
			domain.TcnFormat = GetRowData<string>(dataRow, WorkspaceColumnNames.TCNFormat.ToString()); 	
			domain.Incrementor = GetRowData<int?>(dataRow, WorkspaceColumnNames.Incrementor.ToString()); 	
			domain.AllowCopyTo = GetRowData<bool?>(dataRow, WorkspaceColumnNames.AllowCopyTo.ToString()); 	
			domain.PhotoCaptureProfile = GetRowData<string>(dataRow, WorkspaceColumnNames.PhotoCaptureProfile.ToString()); 	
			domain.ReuseTcn = GetRowData<bool?>(dataRow, WorkspaceColumnNames.ReuseTCN.ToString()); 	
			domain.ShowPhotoProfile = GetRowData<bool?>(dataRow, WorkspaceColumnNames.ShowPhotoProfile.ToString()); 	
			domain.ShowDocumentProfile = GetRowData<bool?>(dataRow, WorkspaceColumnNames.ShowDocumentProfile.ToString()); 	
			domain.DocumentCaptureProfile = GetRowData<string>(dataRow, WorkspaceColumnNames.DocumentCaptureProfile.ToString()); 	
			domain.AgencyConfigKey = GetRowData<string>(dataRow, WorkspaceColumnNames.AgencyConfigKey.ToString()); 	
			domain.ReuseTcnText = GetRowData<string>(dataRow, WorkspaceColumnNames.ReuseTCNText.ToString()); 	
			domain.ReuseTcnYesAction = GetRowData<bool?>(dataRow, WorkspaceColumnNames.ReuseTCNYesAction.ToString()); 	
			domain.AllowBioImport = GetRowData<bool?>(dataRow, WorkspaceColumnNames.AllowBioImport.ToString()); 	
			domain.UsePreface = GetRowData<bool?>(dataRow, WorkspaceColumnNames.UsePreface.ToString()); 	
			domain.EnforceCompliance = GetRowData<bool?>(dataRow, WorkspaceColumnNames.EnforceCompliance.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Workspace></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Workspace> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetDefaultValueReader(), id, IdColumn, SetChildrenDefaultValues);
			
			WithChildForParentId(GetWorkspaceGroupReader(), id, IdColumn, SetChildrenWorkspaceGroups);
			
			WithChildForParentId(GetTransactionReader(), id, IdColumn, SetChildrenTransactions);
			
			WithChildForParentId(GetBiographicGroupReader(), id, IdColumn, SetChildrenBiographicGroups);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Workspace entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetDefaultValueReader(), entity.Id
				, DefaultValueColumnNames.WorkspaceId.ToString()
				, SetChildrenDefaultValues);

			WithChildForParentId(GetWorkspaceGroupReader(), entity.Id
				, WorkspaceGroupColumnNames.WorkspaceId.ToString()
				, SetChildrenWorkspaceGroups);

			WithChildForParentId(GetTransactionReader(), entity.Id
				, TransactionColumnNames.WorkspaceId.ToString()
				, SetChildrenTransactions);

			WithChildForParentId(GetBiographicGroupReader(), entity.Id
				, BiographicGroupColumnNames.WorkspaceId.ToString()
				, SetChildrenBiographicGroups);

			QueryResultForChildrenOnly(new List<Workspace>() { entity });

			GetDefaultValueReader().SetAllChildrenForExisting(entity.DefaultValues);
			GetWorkspaceGroupReader().SetAllChildrenForExisting(entity.WorkspaceGroups);
			GetTransactionReader().SetAllChildrenForExisting(entity.Transactions);
			GetBiographicGroupReader().SetAllChildrenForExisting(entity.BiographicGroups);
				
		}

		public override void SetAllChildrenForExisting(IList<Workspace> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetDefaultValueReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), DefaultValueColumnNames.WorkspaceId.ToString()
				, SetChildrenDefaultValues);

			WithChildForParentIds(GetWorkspaceGroupReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), WorkspaceGroupColumnNames.WorkspaceId.ToString()
				, SetChildrenWorkspaceGroups);

			WithChildForParentIds(GetTransactionReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), TransactionColumnNames.WorkspaceId.ToString()
				, SetChildrenTransactions);

			WithChildForParentIds(GetBiographicGroupReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), BiographicGroupColumnNames.WorkspaceId.ToString()
				, SetChildrenBiographicGroups);

					
			QueryResultForChildrenOnly(entities);

			GetDefaultValueReader().SetAllChildrenForExisting(entities.SelectMany(e => e.DefaultValues).ToList());
			GetWorkspaceGroupReader().SetAllChildrenForExisting(entities.SelectMany(e => e.WorkspaceGroups).ToList());
			GetTransactionReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Transactions).ToList());
			GetBiographicGroupReader().SetAllChildrenForExisting(entities.SelectMany(e => e.BiographicGroups).ToList());
					
		}
    }
}
		