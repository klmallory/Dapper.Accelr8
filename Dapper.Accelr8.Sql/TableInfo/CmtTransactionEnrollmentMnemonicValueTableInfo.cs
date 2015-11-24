
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
	public enum CmtTransactionEnrollmentMnemonicValueColumnNames
	{	
		TransactionId, 	
		PersonId, 	
		WorkspaceId, 	
		TCN, 	
		OriginatingAgencyId, 	
		DestinationAgencyId, 	
		DestinationAgencyName, 	
		Filepath, 	
		CreatedDate, 	
		TransactionType, 	
		Name, 	
		UserId, 	
		Username, 	
		TransactionStatus, 	
		StatusDate, 	
		CaptureWorkflowName, 	
		PhotoCaptureWorkflowName, 	
		DocumentCaptureWorkflowName, 	
		EnrollmentMnemonicValueEntry, 	
		EnrollmentMnemonicDescription, 	
		MnemonicCode, 	
		SubmissionId, 	
		Submission_spc_Status, 	
		TCR, 	
	}

	public enum CmtTransactionEnrollmentMnemonicValueCascadeNames
	{	
		
	}

	public class CmtTransactionEnrollmentMnemonicValueTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public CmtTransactionEnrollmentMnemonicValueTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = CmtTransactionEnrollmentMnemonicValueColumnNames.TransactionId.ToString();
			TableName = "CMT_TransactionEnrollmentMnemonicValues";
			TableAlias = "cmt_transactionenrollmentmnemonicvalue";
			ColumnNames = Enum.GetNames(typeof(CmtTransactionEnrollmentMnemonicValueColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		