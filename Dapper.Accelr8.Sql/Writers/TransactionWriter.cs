
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
    public class TransactionWriter : EntityWriter<int, Transaction>
    {
        public TransactionWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , TransactionFieldValue> GetTransactionFieldValueWriter()
		{ return _locator.Resolve<IEntityWriter<int , TransactionFieldValue>>(); }
		static IEntityWriter<int , Document> GetDocumentWriter()
		{ return _locator.Resolve<IEntityWriter<int , Document>>(); }
		static IEntityWriter<int , EnrollmentMnemonicValue> GetEnrollmentMnemonicValueWriter()
		{ return _locator.Resolve<IEntityWriter<int , EnrollmentMnemonicValue>>(); }
		static IEntityWriter<int , Submission> GetSubmissionWriter()
		{ return _locator.Resolve<IEntityWriter<int , Submission>>(); }
		static IEntityWriter<int , TransactionFilePath> GetTransactionFilePathWriter()
		{ return _locator.Resolve<IEntityWriter<int , TransactionFilePath>>(); }
		static IEntityWriter<int , Biometric> GetBiometricWriter()
		{ return _locator.Resolve<IEntityWriter<int , Biometric>>(); }
		static IEntityWriter<int , TransactionStatusHistory> GetTransactionStatusHistoryWriter()
		{ return _locator.Resolve<IEntityWriter<int , TransactionStatusHistory>>(); }
		static IEntityWriter<int , TransactionGroup> GetTransactionGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , TransactionGroup>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Transaction entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(TransactionColumnNames.TransactionId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(TransactionColumnNames.PersonId.ToString(), actionType, taskIndex, count), entity.PersonId);
			parms.Add(GetParamName(TransactionColumnNames.WorkspaceId.ToString(), actionType, taskIndex, count), entity.WorkspaceId);
			parms.Add(GetParamName(TransactionColumnNames.ClientId.ToString(), actionType, taskIndex, count), entity.ClientId);
			parms.Add(GetParamName(TransactionColumnNames.TCN.ToString(), actionType, taskIndex, count), entity.Tcn);
			parms.Add(GetParamName(TransactionColumnNames.OriginatingAgencyId.ToString(), actionType, taskIndex, count), entity.OriginatingAgencyId);
			parms.Add(GetParamName(TransactionColumnNames.DestinationAgencyId.ToString(), actionType, taskIndex, count), entity.DestinationAgencyId);
			parms.Add(GetParamName(TransactionColumnNames.Filepath.ToString(), actionType, taskIndex, count), entity.Filepath);
			parms.Add(GetParamName(TransactionColumnNames.CreatedDate.ToString(), actionType, taskIndex, count), entity.CreatedDate);
			parms.Add(GetParamName(TransactionColumnNames.TransactionType.ToString(), actionType, taskIndex, count), entity.TransactionType);
			parms.Add(GetParamName(TransactionColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(TransactionColumnNames.AgencySpecId.ToString(), actionType, taskIndex, count), entity.AgencySpecId);
			parms.Add(GetParamName(TransactionColumnNames.UserId.ToString(), actionType, taskIndex, count), entity.UserId);
			parms.Add(GetParamName(TransactionColumnNames.TransactionStatus.ToString(), actionType, taskIndex, count), entity.TransactionStatus);
			parms.Add(GetParamName(TransactionColumnNames.SourceId.ToString(), actionType, taskIndex, count), entity.SourceId);
			parms.Add(GetParamName(TransactionColumnNames.CaptureWorkflowName.ToString(), actionType, taskIndex, count), entity.CaptureWorkflowName);
			parms.Add(GetParamName(TransactionColumnNames.PhotoCaptureWorkflowName.ToString(), actionType, taskIndex, count), entity.PhotoCaptureWorkflowName);
			parms.Add(GetParamName(TransactionColumnNames.DocumentCaptureWorkflowName.ToString(), actionType, taskIndex, count), entity.DocumentCaptureWorkflowName);
			parms.Add(GetParamName(TransactionColumnNames.WorkstationId.ToString(), actionType, taskIndex, count), entity.WorkstationId);
					
			return parms;
        }


		protected override void CascadeRelations(Transaction entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_TransactionFieldValues_Transactions
			var transactionFieldValue = GetTransactionFieldValueWriter();
			if (_cascades.Contains(TransactionCascadeNames.transactionfieldvalue.ToString()))
				foreach (var item in entity.TransactionFieldValues)
					Cascade(transactionFieldValue, item, context);

			if (transactionFieldValue.Count > 0)
				WithChild(transactionFieldValue, entity);

			//From Foreign Key FK_Documents_Transactions
			var document = GetDocumentWriter();
			if (_cascades.Contains(TransactionCascadeNames.document.ToString()))
				foreach (var item in entity.Documents)
					Cascade(document, item, context);

			if (document.Count > 0)
				WithChild(document, entity);

			//From Foreign Key FK_EnrollmentMnemonicValues_Transactions
			var enrollmentMnemonicValue = GetEnrollmentMnemonicValueWriter();
			if (_cascades.Contains(TransactionCascadeNames.enrollmentmnemonicvalue.ToString()))
				foreach (var item in entity.EnrollmentMnemonicValues)
					Cascade(enrollmentMnemonicValue, item, context);

			if (enrollmentMnemonicValue.Count > 0)
				WithChild(enrollmentMnemonicValue, entity);

			//From Foreign Key FK_Submissions_Transactions
			var submission = GetSubmissionWriter();
			if (_cascades.Contains(TransactionCascadeNames.submission.ToString()))
				foreach (var item in entity.Submissions)
					Cascade(submission, item, context);

			if (submission.Count > 0)
				WithChild(submission, entity);

			//From Foreign Key FK_TransactionFilePaths_Transactions
			var transactionFilePath = GetTransactionFilePathWriter();
			if (_cascades.Contains(TransactionCascadeNames.transactionfilepath.ToString()))
				foreach (var item in entity.TransactionFilePaths)
					Cascade(transactionFilePath, item, context);

			if (transactionFilePath.Count > 0)
				WithChild(transactionFilePath, entity);

			//From Foreign Key FK_Biometrics_Transactions
			var biometric = GetBiometricWriter();
			if (_cascades.Contains(TransactionCascadeNames.biometric.ToString()))
				foreach (var item in entity.Biometrics)
					Cascade(biometric, item, context);

			if (biometric.Count > 0)
				WithChild(biometric, entity);

			//From Foreign Key FK_TransactionStatusHistory_Transactions
			var transactionStatusHistory = GetTransactionStatusHistoryWriter();
			if (_cascades.Contains(TransactionCascadeNames.transactionstatushistory.ToString()))
				foreach (var item in entity.TransactionStatusHistories)
					Cascade(transactionStatusHistory, item, context);

			if (transactionStatusHistory.Count > 0)
				WithChild(transactionStatusHistory, entity);

			//From Foreign Key FK_TransactionGroups_Transactions
			var transactionGroup = GetTransactionGroupWriter();
			if (_cascades.Contains(TransactionCascadeNames.transactiongroup.ToString()))
				foreach (var item in entity.TransactionGroups)
					Cascade(transactionGroup, item, context);

			if (transactionGroup.Count > 0)
				WithChild(transactionGroup, entity);

		
        }


	}
}
		