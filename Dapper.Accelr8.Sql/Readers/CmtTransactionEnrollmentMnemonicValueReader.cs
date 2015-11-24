

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
    public class CmtTransactionEnrollmentMnemonicValueReader : EntityReader<int, CmtTransactionEnrollmentMnemonicValue>
    {
        public CmtTransactionEnrollmentMnemonicValueReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 0
		
			/// <summary>
		/// Loads the table CMT_TransactionEnrollmentMnemonicValues into class CmtTransactionEnrollmentMnemonicValue
		/// </summary>
		/// <param name="results">CmtTransactionEnrollmentMnemonicValue</param>
		/// <param name="row"></param>
        public override CmtTransactionEnrollmentMnemonicValue LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new CmtTransactionEnrollmentMnemonicValue();

			
			domain.TransactionId = GetRowData<int>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.TransactionId.ToString()); 	
			domain.PersonId = GetRowData<int?>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.PersonId.ToString()); 	
			domain.WorkspaceId = GetRowData<int?>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.WorkspaceId.ToString()); 	
			domain.Tcn = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.TCN.ToString()); 	
			domain.OriginatingAgencyId = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.OriginatingAgencyId.ToString()); 	
			domain.DestinationAgencyId = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.DestinationAgencyId.ToString()); 	
			domain.DestinationAgencyName = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.DestinationAgencyName.ToString()); 	
			domain.Filepath = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.Filepath.ToString()); 	
			domain.CreatedDate = GetRowData<DateTime>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.CreatedDate.ToString()); 	
			domain.TransactionType = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.TransactionType.ToString()); 	
			domain.Name = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.Name.ToString()); 	
			domain.UserId = GetRowData<int?>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.UserId.ToString()); 	
			domain.Username = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.Username.ToString()); 	
			domain.TransactionStatus = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.TransactionStatus.ToString()); 	
			domain.StatusDate = GetRowData<DateTime?>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.StatusDate.ToString()); 	
			domain.CaptureWorkflowName = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.CaptureWorkflowName.ToString()); 	
			domain.PhotoCaptureWorkflowName = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.PhotoCaptureWorkflowName.ToString()); 	
			domain.DocumentCaptureWorkflowName = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.DocumentCaptureWorkflowName.ToString()); 	
			domain.EnrollmentMnemonicValueEntry = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.EnrollmentMnemonicValueEntry.ToString()); 	
			domain.EnrollmentMnemonicDescription = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.EnrollmentMnemonicDescription.ToString()); 	
			domain.MnemonicCode = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.MnemonicCode.ToString()); 	
			domain.SubmissionId = GetRowData<int?>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.SubmissionId.ToString()); 	
			domain.SubmissionSpcStatus = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.Submission_spc_Status.ToString()); 	
			domain.Tcr = GetRowData<string>(dataRow, CmtTransactionEnrollmentMnemonicValueColumnNames.TCR.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, CmtTransactionEnrollmentMnemonicValue></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, CmtTransactionEnrollmentMnemonicValue> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(CmtTransactionEnrollmentMnemonicValue entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<CmtTransactionEnrollmentMnemonicValue> entities)
        {
					
		}
    }
}
		