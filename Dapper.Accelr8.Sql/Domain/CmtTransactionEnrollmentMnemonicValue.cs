

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
	public class CmtTransactionEnrollmentMnemonicValue : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public CmtTransactionEnrollmentMnemonicValue()
		{
			IsDirty = false;
		}
				
		protected int _transactionId;
		public int TransactionId 
		{ 
			get { return _transactionId; }
			set 
			{ 
				_transactionId = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _personId;
		public int? PersonId 
		{ 
			get { return _personId; }
			set 
			{ 
				_personId = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _workspaceId;
		public int? WorkspaceId 
		{ 
			get { return _workspaceId; }
			set 
			{ 
				_workspaceId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _tcn;
		public string Tcn 
		{ 
			get { return _tcn; }
			set 
			{ 
				_tcn = value;  
				IsDirty = true;
			}
		} 
			
		protected string _originatingAgencyId;
		public string OriginatingAgencyId 
		{ 
			get { return _originatingAgencyId; }
			set 
			{ 
				_originatingAgencyId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _destinationAgencyId;
		public string DestinationAgencyId 
		{ 
			get { return _destinationAgencyId; }
			set 
			{ 
				_destinationAgencyId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _destinationAgencyName;
		public string DestinationAgencyName 
		{ 
			get { return _destinationAgencyName; }
			set 
			{ 
				_destinationAgencyName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _filepath;
		public string Filepath 
		{ 
			get { return _filepath; }
			set 
			{ 
				_filepath = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _createdDate;
		public DateTime CreatedDate 
		{ 
			get { return _createdDate; }
			set 
			{ 
				_createdDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _transactionType;
		public string TransactionType 
		{ 
			get { return _transactionType; }
			set 
			{ 
				_transactionType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _name;
		public string Name 
		{ 
			get { return _name; }
			set 
			{ 
				_name = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _userId;
		public int? UserId 
		{ 
			get { return _userId; }
			set 
			{ 
				_userId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _username;
		public string Username 
		{ 
			get { return _username; }
			set 
			{ 
				_username = value;  
				IsDirty = true;
			}
		} 
			
		protected string _transactionStatus;
		public string TransactionStatus 
		{ 
			get { return _transactionStatus; }
			set 
			{ 
				_transactionStatus = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _statusDate;
		public DateTime? StatusDate 
		{ 
			get { return _statusDate; }
			set 
			{ 
				_statusDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _captureWorkflowName;
		public string CaptureWorkflowName 
		{ 
			get { return _captureWorkflowName; }
			set 
			{ 
				_captureWorkflowName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _photoCaptureWorkflowName;
		public string PhotoCaptureWorkflowName 
		{ 
			get { return _photoCaptureWorkflowName; }
			set 
			{ 
				_photoCaptureWorkflowName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _documentCaptureWorkflowName;
		public string DocumentCaptureWorkflowName 
		{ 
			get { return _documentCaptureWorkflowName; }
			set 
			{ 
				_documentCaptureWorkflowName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _enrollmentMnemonicValueEntry;
		public string EnrollmentMnemonicValueEntry 
		{ 
			get { return _enrollmentMnemonicValueEntry; }
			set 
			{ 
				_enrollmentMnemonicValueEntry = value;  
				IsDirty = true;
			}
		} 
			
		protected string _enrollmentMnemonicDescription;
		public string EnrollmentMnemonicDescription 
		{ 
			get { return _enrollmentMnemonicDescription; }
			set 
			{ 
				_enrollmentMnemonicDescription = value;  
				IsDirty = true;
			}
		} 
			
		protected string _mnemonicCode;
		public string MnemonicCode 
		{ 
			get { return _mnemonicCode; }
			set 
			{ 
				_mnemonicCode = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _submissionId;
		public int? SubmissionId 
		{ 
			get { return _submissionId; }
			set 
			{ 
				_submissionId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _submissionStatus;
		public string SubmissionStatus 
		{ 
			get { return _submissionStatus; }
			set 
			{ 
				_submissionStatus = value;  
				IsDirty = true;
			}
		} 
			
		protected string _tcr;
		public string Tcr 
		{ 
			get { return _tcr; }
			set 
			{ 
				_tcr = value;  
				IsDirty = true;
			}
		} 
		
		}
}

		