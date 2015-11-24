
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

namespace Dapper.Accelr8.Domain
{
	public class Transaction : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public Transaction()
		{
			IsDirty = false;
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
			
		protected int? _clientId;
		public int? ClientId 
		{ 
			get { return _clientId; }
			set 
			{ 
				_clientId = value;  
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
			
		protected int _agencySpecId;
		public int AgencySpecId 
		{ 
			get { return _agencySpecId; }
			set 
			{ 
				_agencySpecId = value;  
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
			
		protected int? _sourceId;
		public int? SourceId 
		{ 
			get { return _sourceId; }
			set 
			{ 
				_sourceId = value;  
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
			
		protected string _workstationId;
		public string WorkstationId 
		{ 
			get { return _workstationId; }
			set 
			{ 
				_workstationId = value;  
				IsDirty = true;
			}
		} 
			
		protected Person _person;
		public Person Person 
		{ 
			get { return _person; }
			set 
			{ 
				_person = value;  
				IsDirty = true;
			}
		} 
			
		protected User _user;
		public User User 
		{ 
			get { return _user; }
			set 
			{ 
				_user = value;  
				IsDirty = true;
			}
		} 
			
		protected Client _client;
		public Client Client 
		{ 
			get { return _client; }
			set 
			{ 
				_client = value;  
				IsDirty = true;
			}
		} 
			
		protected Workspace _workspace;
		public Workspace Workspace 
		{ 
			get { return _workspace; }
			set 
			{ 
				_workspace = value;  
				IsDirty = true;
			}
		} 
			
		protected AgencySpec _agencySpec;
		public AgencySpec AgencySpec 
		{ 
			get { return _agencySpec; }
			set 
			{ 
				_agencySpec = value;  
				IsDirty = true;
			}
		} 
			
		protected Source _source;
		public Source Source 
		{ 
			get { return _source; }
			set 
			{ 
				_source = value;  
				IsDirty = true;
			}
		} 
			
		protected IList<TransactionFieldValue> _transactionFieldValues;
		public IList<TransactionFieldValue> TransactionFieldValues 
		{ 
			get { return _transactionFieldValues; }
			set 
			{ 
				_transactionFieldValues = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<Document> _documents;
		public IList<Document> Documents 
		{ 
			get { return _documents; }
			set 
			{ 
				_documents = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<EnrollmentMnemonicValue> _enrollmentMnemonicValues;
		public IList<EnrollmentMnemonicValue> EnrollmentMnemonicValues 
		{ 
			get { return _enrollmentMnemonicValues; }
			set 
			{ 
				_enrollmentMnemonicValues = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<Submission> _submissions;
		public IList<Submission> Submissions 
		{ 
			get { return _submissions; }
			set 
			{ 
				_submissions = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<TransactionFilePath> _transactionFilePaths;
		public IList<TransactionFilePath> TransactionFilePaths 
		{ 
			get { return _transactionFilePaths; }
			set 
			{ 
				_transactionFilePaths = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<Biometric> _biometrics;
		public IList<Biometric> Biometrics 
		{ 
			get { return _biometrics; }
			set 
			{ 
				_biometrics = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<TransactionStatusHistory> _transactionStatusHistories;
		public IList<TransactionStatusHistory> TransactionStatusHistories 
		{ 
			get { return _transactionStatusHistories; }
			set 
			{ 
				_transactionStatusHistories = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<TransactionGroup> _transactionGroups;
		public IList<TransactionGroup> TransactionGroups 
		{ 
			get { return _transactionGroups; }
			set 
			{ 
				_transactionGroups = value;  
				IsDirty = true;
			}
		} 
					}
}

		