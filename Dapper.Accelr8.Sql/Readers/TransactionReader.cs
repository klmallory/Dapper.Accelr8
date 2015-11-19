

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
    public class TransactionReader : EntityReader<int, Transaction>
    {
        public TransactionReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 8
		//Parent Count 6

		/// <summary>
		/// Sets the children of type TransactionFieldValue on the parent on TransactionFieldValues.
		/// From foriegn key FK_TransactionFieldValues_Transactions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactionFieldValues(IList<Transaction> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: TransactionFieldValue

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<TransactionFieldValue>();

			foreach (var r in results)
			{
				r.TransactionFieldValues = typedChildren.Where(b => b.TransactionFieldValueId == r.Id).ToList();
				r.TransactionFieldValues.ToList().ForEach(b => b.Transaction = r);
			}
		}

		/// <summary>
		/// Sets the children of type Document on the parent on Documents.
		/// From foriegn key FK_Documents_Transactions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenDocuments(IList<Transaction> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Document

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Document>();

			foreach (var r in results)
			{
				r.Documents = typedChildren.Where(b => b.DocumentId == r.Id).ToList();
				r.Documents.ToList().ForEach(b => b.Transaction = r);
			}
		}

		/// <summary>
		/// Sets the children of type EnrollmentMnemonicValue on the parent on EnrollmentMnemonicValues.
		/// From foriegn key FK_EnrollmentMnemonicValues_Transactions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenEnrollmentMnemonicValues(IList<Transaction> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: EnrollmentMnemonicValue

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<EnrollmentMnemonicValue>();

			foreach (var r in results)
			{
				r.EnrollmentMnemonicValues = typedChildren.Where(b => b.EnrollmentMnemonicValueId == r.Id).ToList();
				r.EnrollmentMnemonicValues.ToList().ForEach(b => b.Transaction = r);
			}
		}

		/// <summary>
		/// Sets the children of type Submission on the parent on Submissions.
		/// From foriegn key FK_Submissions_Transactions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenSubmissions(IList<Transaction> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Submission

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Submission>();

			foreach (var r in results)
			{
				r.Submissions = typedChildren.Where(b => b.SubmissionId == r.Id).ToList();
				r.Submissions.ToList().ForEach(b => b.Transaction = r);
			}
		}

		/// <summary>
		/// Sets the children of type TransactionFilePath on the parent on TransactionFilePaths.
		/// From foriegn key FK_TransactionFilePaths_Transactions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactionFilePaths(IList<Transaction> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: TransactionFilePath

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<TransactionFilePath>();

			foreach (var r in results)
			{
				r.TransactionFilePaths = typedChildren.Where(b => b.TransactionFilePathId == r.Id).ToList();
				r.TransactionFilePaths.ToList().ForEach(b => b.Transaction = r);
			}
		}

		/// <summary>
		/// Sets the children of type Biometric on the parent on Biometrics.
		/// From foriegn key FK_Biometrics_Transactions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenBiometrics(IList<Transaction> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: Biometric

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<Biometric>();

			foreach (var r in results)
			{
				r.Biometrics = typedChildren.Where(b => b.BiometricId == r.Id).ToList();
				r.Biometrics.ToList().ForEach(b => b.Transaction = r);
			}
		}

		/// <summary>
		/// Sets the children of type TransactionStatusHistory on the parent on TransactionStatusHistories.
		/// From foriegn key FK_TransactionStatusHistory_Transactions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactionStatusHistories(IList<Transaction> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: TransactionStatusHistory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<TransactionStatusHistory>();

			foreach (var r in results)
			{
				r.TransactionStatusHistories = typedChildren.Where(b => b.TransactionStatusHistoryID == r.Id).ToList();
				r.TransactionStatusHistories.ToList().ForEach(b => b.Transaction = r);
			}
		}

		/// <summary>
		/// Sets the children of type TransactionGroup on the parent on TransactionGroups.
		/// From foriegn key FK_TransactionGroups_Transactions
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenTransactionGroups(IList<Transaction> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: TransactionGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<TransactionGroup>();

			foreach (var r in results)
			{
				r.TransactionGroups = typedChildren.Where(b => b.TransactionGroupId == r.Id).ToList();
				r.TransactionGroups.ToList().ForEach(b => b.Transaction = r);
			}
		}

			/// <summary>
		/// Loads the table Transactions into class Transaction
		/// </summary>
		/// <param name="results">Transaction</param>
		/// <param name="row"></param>
        public override Transaction LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Transaction();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.PersonId = GetRowData<int?>(dataRow, TransactionColumnNames.PersonId.ToString()); 	
			domain.WorkspaceId = GetRowData<int?>(dataRow, TransactionColumnNames.WorkspaceId.ToString()); 	
			domain.ClientId = GetRowData<int?>(dataRow, TransactionColumnNames.ClientId.ToString()); 	
			domain.TCN = GetRowData<string>(dataRow, TransactionColumnNames.TCN.ToString()); 	
			domain.OriginatingAgencyId = GetRowData<string>(dataRow, TransactionColumnNames.OriginatingAgencyId.ToString()); 	
			domain.DestinationAgencyId = GetRowData<string>(dataRow, TransactionColumnNames.DestinationAgencyId.ToString()); 	
			domain.Filepath = GetRowData<string>(dataRow, TransactionColumnNames.Filepath.ToString()); 	
			domain.CreatedDate = GetRowData<DateTime>(dataRow, TransactionColumnNames.CreatedDate.ToString()); 	
			domain.TransactionType = GetRowData<string>(dataRow, TransactionColumnNames.TransactionType.ToString()); 	
			domain.Name = GetRowData<string>(dataRow, TransactionColumnNames.Name.ToString()); 	
			domain.AgencySpecId = GetRowData<int>(dataRow, TransactionColumnNames.AgencySpecId.ToString()); 	
			domain.UserId = GetRowData<int?>(dataRow, TransactionColumnNames.UserId.ToString()); 	
			domain.TransactionStatus = GetRowData<string>(dataRow, TransactionColumnNames.TransactionStatus.ToString()); 	
			domain.SourceId = GetRowData<int?>(dataRow, TransactionColumnNames.SourceId.ToString()); 	
			domain.CaptureWorkflowName = GetRowData<string>(dataRow, TransactionColumnNames.CaptureWorkflowName.ToString()); 	
			domain.PhotoCaptureWorkflowName = GetRowData<string>(dataRow, TransactionColumnNames.PhotoCaptureWorkflowName.ToString()); 	
			domain.DocumentCaptureWorkflowName = GetRowData<string>(dataRow, TransactionColumnNames.DocumentCaptureWorkflowName.ToString()); 	
			domain.WorkstationId = GetRowData<string>(dataRow, TransactionColumnNames.WorkstationId.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, Transaction> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFieldValues>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Documents>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , EnrollmentMnemonicValues>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFilePaths>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Biometrics>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionStatusHistory>(), id, IdField, SetChildren);
			
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionGroups>(), id, IdField, SetChildren);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Transaction entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFieldValues>(), id, IdField, SetChildrenTransactionFieldValues);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Documents>(), id, IdField, SetChildrenDocuments);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , EnrollmentMnemonicValues>(), id, IdField, SetChildrenEnrollmentMnemonicValues);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildrenSubmissions);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFilePaths>(), id, IdField, SetChildrenTransactionFilePaths);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Biometrics>(), id, IdField, SetChildrenBiometrics);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionStatusHistory>(), id, IdField, SetChildrenTransactionStatusHistories);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionGroups>(), id, IdField, SetChildrenTransactionGroups);
			QueryResultForChildrenOnly(new List<Transaction>() { entity });

			_locator.Resolve<IEntityReader<int , TransactionFieldValues>().SetAllChildrenForExisting(entity.TransactionFieldValues);
			_locator.Resolve<IEntityReader<int , Documents>().SetAllChildrenForExisting(entity.Documents);
			_locator.Resolve<IEntityReader<int , EnrollmentMnemonicValues>().SetAllChildrenForExisting(entity.EnrollmentMnemonicValues);
			_locator.Resolve<IEntityReader<int , Submissions>().SetAllChildrenForExisting(entity.Submissions);
			_locator.Resolve<IEntityReader<int , TransactionFilePaths>().SetAllChildrenForExisting(entity.TransactionFilePaths);
			_locator.Resolve<IEntityReader<int , Biometrics>().SetAllChildrenForExisting(entity.Biometrics);
			_locator.Resolve<IEntityReader<int , TransactionStatusHistory>().SetAllChildrenForExisting(entity.TransactionStatusHistories);
			_locator.Resolve<IEntityReader<int , TransactionGroups>().SetAllChildrenForExisting(entity.TransactionGroups);
				
		}

		public override void SetAllChildrenForExisting(IList<Transaction> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFieldValues>(), id, IdField, SetChildrenTransactionFieldValues);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Documents>(), id, IdField, SetChildrenDocuments);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , EnrollmentMnemonicValues>(), id, IdField, SetChildrenEnrollmentMnemonicValues);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Submissions>(), id, IdField, SetChildrenSubmissions);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionFilePaths>(), id, IdField, SetChildrenTransactionFilePaths);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , Biometrics>(), id, IdField, SetChildrenBiometrics);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionStatusHistory>(), id, IdField, SetChildrenTransactionStatusHistories);
			WithChildForParentId(_locator.Resolve<IEntityReader<int , TransactionGroups>(), id, IdField, SetChildrenTransactionGroups);
					
			QueryResultForChildrenOnly(entities);

			_locator.Resolve<IEntityReader<int, TransactionFieldValues>().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionFieldValues));
			_locator.Resolve<IEntityReader<int, Documents>().SetAllChildrenForExisting(entities.SelectMany(e => e.Documents));
			_locator.Resolve<IEntityReader<int, EnrollmentMnemonicValues>().SetAllChildrenForExisting(entities.SelectMany(e => e.EnrollmentMnemonicValues));
			_locator.Resolve<IEntityReader<int, Submissions>().SetAllChildrenForExisting(entities.SelectMany(e => e.Submissions));
			_locator.Resolve<IEntityReader<int, TransactionFilePaths>().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionFilePaths));
			_locator.Resolve<IEntityReader<int, Biometrics>().SetAllChildrenForExisting(entities.SelectMany(e => e.Biometrics));
			_locator.Resolve<IEntityReader<int, TransactionStatusHistory>().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionStatusHistories));
			_locator.Resolve<IEntityReader<int, TransactionGroups>().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionGroups));
					
		}
    }
}
		