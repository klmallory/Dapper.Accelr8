

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
		static IEntityReader<int , TransactionFieldValue> _transactionFieldValueReader;
		static IEntityReader<int , TransactionFieldValue> GetTransactionFieldValueReader()
		{
			if (_transactionFieldValueReader == null)
				_transactionFieldValueReader = _locator.Resolve<IEntityReader<int , TransactionFieldValue>>();

			return _transactionFieldValueReader;
		}

		static IEntityReader<int , Document> _documentReader;
		static IEntityReader<int , Document> GetDocumentReader()
		{
			if (_documentReader == null)
				_documentReader = _locator.Resolve<IEntityReader<int , Document>>();

			return _documentReader;
		}

		static IEntityReader<int , EnrollmentMnemonicValue> _enrollmentMnemonicValueReader;
		static IEntityReader<int , EnrollmentMnemonicValue> GetEnrollmentMnemonicValueReader()
		{
			if (_enrollmentMnemonicValueReader == null)
				_enrollmentMnemonicValueReader = _locator.Resolve<IEntityReader<int , EnrollmentMnemonicValue>>();

			return _enrollmentMnemonicValueReader;
		}

		static IEntityReader<int , Submission> _submissionReader;
		static IEntityReader<int , Submission> GetSubmissionReader()
		{
			if (_submissionReader == null)
				_submissionReader = _locator.Resolve<IEntityReader<int , Submission>>();

			return _submissionReader;
		}

		static IEntityReader<int , TransactionFilePath> _transactionFilePathReader;
		static IEntityReader<int , TransactionFilePath> GetTransactionFilePathReader()
		{
			if (_transactionFilePathReader == null)
				_transactionFilePathReader = _locator.Resolve<IEntityReader<int , TransactionFilePath>>();

			return _transactionFilePathReader;
		}

		static IEntityReader<int , Biometric> _biometricReader;
		static IEntityReader<int , Biometric> GetBiometricReader()
		{
			if (_biometricReader == null)
				_biometricReader = _locator.Resolve<IEntityReader<int , Biometric>>();

			return _biometricReader;
		}

		static IEntityReader<int , TransactionStatusHistory> _transactionStatusHistoryReader;
		static IEntityReader<int , TransactionStatusHistory> GetTransactionStatusHistoryReader()
		{
			if (_transactionStatusHistoryReader == null)
				_transactionStatusHistoryReader = _locator.Resolve<IEntityReader<int , TransactionStatusHistory>>();

			return _transactionStatusHistoryReader;
		}

		static IEntityReader<int , TransactionGroup> _transactionGroupReader;
		static IEntityReader<int , TransactionGroup> GetTransactionGroupReader()
		{
			if (_transactionGroupReader == null)
				_transactionGroupReader = _locator.Resolve<IEntityReader<int , TransactionGroup>>();

			return _transactionGroupReader;
		}

		
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
				r.TransactionFieldValues = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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
				r.Documents = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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
				r.EnrollmentMnemonicValues = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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
				r.Submissions = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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
				r.TransactionFilePaths = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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
				r.Biometrics = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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
				r.TransactionStatusHistories = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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
				r.TransactionGroups = typedChildren.Where(b => b.TransactionId == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.PersonId = GetRowData<int?>(dataRow, TransactionColumnNames.PersonId.ToString()); 	
			domain.WorkspaceId = GetRowData<int?>(dataRow, TransactionColumnNames.WorkspaceId.ToString()); 	
			domain.ClientId = GetRowData<int?>(dataRow, TransactionColumnNames.ClientId.ToString()); 	
			domain.Tcn = GetRowData<string>(dataRow, TransactionColumnNames.TCN.ToString()); 	
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

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Transaction></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Transaction> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetTransactionFieldValueReader(), id, IdColumn, SetChildrenTransactionFieldValues);
			
			WithChildForParentId(GetDocumentReader(), id, IdColumn, SetChildrenDocuments);
			
			WithChildForParentId(GetEnrollmentMnemonicValueReader(), id, IdColumn, SetChildrenEnrollmentMnemonicValues);
			
			WithChildForParentId(GetSubmissionReader(), id, IdColumn, SetChildrenSubmissions);
			
			WithChildForParentId(GetTransactionFilePathReader(), id, IdColumn, SetChildrenTransactionFilePaths);
			
			WithChildForParentId(GetBiometricReader(), id, IdColumn, SetChildrenBiometrics);
			
			WithChildForParentId(GetTransactionStatusHistoryReader(), id, IdColumn, SetChildrenTransactionStatusHistories);
			
			WithChildForParentId(GetTransactionGroupReader(), id, IdColumn, SetChildrenTransactionGroups);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Transaction entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetTransactionFieldValueReader(), entity.Id
				, TransactionFieldValueColumnNames.TransactionId.ToString()
				, SetChildrenTransactionFieldValues);

			WithChildForParentId(GetDocumentReader(), entity.Id
				, DocumentColumnNames.TransactionID.ToString()
				, SetChildrenDocuments);

			WithChildForParentId(GetEnrollmentMnemonicValueReader(), entity.Id
				, EnrollmentMnemonicValueColumnNames.TransactionId.ToString()
				, SetChildrenEnrollmentMnemonicValues);

			WithChildForParentId(GetSubmissionReader(), entity.Id
				, SubmissionColumnNames.TransactionId.ToString()
				, SetChildrenSubmissions);

			WithChildForParentId(GetTransactionFilePathReader(), entity.Id
				, TransactionFilePathColumnNames.TransactionId.ToString()
				, SetChildrenTransactionFilePaths);

			WithChildForParentId(GetBiometricReader(), entity.Id
				, BiometricColumnNames.TransactionId.ToString()
				, SetChildrenBiometrics);

			WithChildForParentId(GetTransactionStatusHistoryReader(), entity.Id
				, TransactionStatusHistoryColumnNames.TransactionId.ToString()
				, SetChildrenTransactionStatusHistories);

			WithChildForParentId(GetTransactionGroupReader(), entity.Id
				, TransactionGroupColumnNames.TransactionId.ToString()
				, SetChildrenTransactionGroups);

			QueryResultForChildrenOnly(new List<Transaction>() { entity });

			GetTransactionFieldValueReader().SetAllChildrenForExisting(entity.TransactionFieldValues);
			GetDocumentReader().SetAllChildrenForExisting(entity.Documents);
			GetEnrollmentMnemonicValueReader().SetAllChildrenForExisting(entity.EnrollmentMnemonicValues);
			GetSubmissionReader().SetAllChildrenForExisting(entity.Submissions);
			GetTransactionFilePathReader().SetAllChildrenForExisting(entity.TransactionFilePaths);
			GetBiometricReader().SetAllChildrenForExisting(entity.Biometrics);
			GetTransactionStatusHistoryReader().SetAllChildrenForExisting(entity.TransactionStatusHistories);
			GetTransactionGroupReader().SetAllChildrenForExisting(entity.TransactionGroups);
				
		}

		public override void SetAllChildrenForExisting(IList<Transaction> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetTransactionFieldValueReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), TransactionFieldValueColumnNames.TransactionId.ToString()
				, SetChildrenTransactionFieldValues);

			WithChildForParentIds(GetDocumentReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), DocumentColumnNames.TransactionID.ToString()
				, SetChildrenDocuments);

			WithChildForParentIds(GetEnrollmentMnemonicValueReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), EnrollmentMnemonicValueColumnNames.TransactionId.ToString()
				, SetChildrenEnrollmentMnemonicValues);

			WithChildForParentIds(GetSubmissionReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), SubmissionColumnNames.TransactionId.ToString()
				, SetChildrenSubmissions);

			WithChildForParentIds(GetTransactionFilePathReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), TransactionFilePathColumnNames.TransactionId.ToString()
				, SetChildrenTransactionFilePaths);

			WithChildForParentIds(GetBiometricReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), BiometricColumnNames.TransactionId.ToString()
				, SetChildrenBiometrics);

			WithChildForParentIds(GetTransactionStatusHistoryReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), TransactionStatusHistoryColumnNames.TransactionId.ToString()
				, SetChildrenTransactionStatusHistories);

			WithChildForParentIds(GetTransactionGroupReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), TransactionGroupColumnNames.TransactionId.ToString()
				, SetChildrenTransactionGroups);

					
			QueryResultForChildrenOnly(entities);

			GetTransactionFieldValueReader().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionFieldValues).ToList());
			GetDocumentReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Documents).ToList());
			GetEnrollmentMnemonicValueReader().SetAllChildrenForExisting(entities.SelectMany(e => e.EnrollmentMnemonicValues).ToList());
			GetSubmissionReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Submissions).ToList());
			GetTransactionFilePathReader().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionFilePaths).ToList());
			GetBiometricReader().SetAllChildrenForExisting(entities.SelectMany(e => e.Biometrics).ToList());
			GetTransactionStatusHistoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionStatusHistories).ToList());
			GetTransactionGroupReader().SetAllChildrenForExisting(entities.SelectMany(e => e.TransactionGroups).ToList());
					
		}
    }
}
		