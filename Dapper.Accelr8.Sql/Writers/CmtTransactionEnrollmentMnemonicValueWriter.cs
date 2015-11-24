
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
    public class CmtTransactionEnrollmentMnemonicValueWriter : EntityWriter<int, CmtTransactionEnrollmentMnemonicValue>
    {
        public CmtTransactionEnrollmentMnemonicValueWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, CmtTransactionEnrollmentMnemonicValue entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.TransactionId.ToString(), actionType, taskIndex, count), entity.TransactionId);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.PersonId.ToString(), actionType, taskIndex, count), entity.PersonId);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.WorkspaceId.ToString(), actionType, taskIndex, count), entity.WorkspaceId);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.TCN.ToString(), actionType, taskIndex, count), entity.Tcn);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.OriginatingAgencyId.ToString(), actionType, taskIndex, count), entity.OriginatingAgencyId);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.DestinationAgencyId.ToString(), actionType, taskIndex, count), entity.DestinationAgencyId);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.DestinationAgencyName.ToString(), actionType, taskIndex, count), entity.DestinationAgencyName);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.Filepath.ToString(), actionType, taskIndex, count), entity.Filepath);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.CreatedDate.ToString(), actionType, taskIndex, count), entity.CreatedDate);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.TransactionType.ToString(), actionType, taskIndex, count), entity.TransactionType);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.UserId.ToString(), actionType, taskIndex, count), entity.UserId);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.Username.ToString(), actionType, taskIndex, count), entity.Username);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.TransactionStatus.ToString(), actionType, taskIndex, count), entity.TransactionStatus);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.StatusDate.ToString(), actionType, taskIndex, count), entity.StatusDate);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.CaptureWorkflowName.ToString(), actionType, taskIndex, count), entity.CaptureWorkflowName);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.PhotoCaptureWorkflowName.ToString(), actionType, taskIndex, count), entity.PhotoCaptureWorkflowName);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.DocumentCaptureWorkflowName.ToString(), actionType, taskIndex, count), entity.DocumentCaptureWorkflowName);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.EnrollmentMnemonicValueEntry.ToString(), actionType, taskIndex, count), entity.EnrollmentMnemonicValueEntry);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.EnrollmentMnemonicDescription.ToString(), actionType, taskIndex, count), entity.EnrollmentMnemonicDescription);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.MnemonicCode.ToString(), actionType, taskIndex, count), entity.MnemonicCode);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.SubmissionId.ToString(), actionType, taskIndex, count), entity.SubmissionId);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.Submission_spc_Status.ToString(), actionType, taskIndex, count), entity.SubmissionSpcStatus);
			parms.Add(GetParamName(CmtTransactionEnrollmentMnemonicValueColumnNames.TCR.ToString(), actionType, taskIndex, count), entity.Tcr);
					
			return parms;
        }


		protected override void CascadeRelations(CmtTransactionEnrollmentMnemonicValue entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
        }


	}
}
		