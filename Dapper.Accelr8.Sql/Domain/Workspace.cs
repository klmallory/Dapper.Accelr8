

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
	public class Workspace : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Workspace()
		{
			IsDirty = false;
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
			
		protected string _description;
		public string Description 
		{ 
			get { return _description; }
			set 
			{ 
				_description = value;  
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
			
		protected string _captureProfile;
		public string CaptureProfile 
		{ 
			get { return _captureProfile; }
			set 
			{ 
				_captureProfile = value;  
				IsDirty = true;
			}
		} 
			
		protected string _ori;
		public string Ori 
		{ 
			get { return _ori; }
			set 
			{ 
				_ori = value;  
				IsDirty = true;
			}
		} 
			
		protected string _dai;
		public string Dai 
		{ 
			get { return _dai; }
			set 
			{ 
				_dai = value;  
				IsDirty = true;
			}
		} 
			
		protected int _agencyId;
		public int AgencyId 
		{ 
			get { return _agencyId; }
			set 
			{ 
				_agencyId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _tcnFormat;
		public string TcnFormat 
		{ 
			get { return _tcnFormat; }
			set 
			{ 
				_tcnFormat = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _incrementor;
		public int? Incrementor 
		{ 
			get { return _incrementor; }
			set 
			{ 
				_incrementor = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _allowCopyTo;
		public bool? AllowCopyTo 
		{ 
			get { return _allowCopyTo; }
			set 
			{ 
				_allowCopyTo = value;  
				IsDirty = true;
			}
		} 
			
		protected string _photoCaptureProfile;
		public string PhotoCaptureProfile 
		{ 
			get { return _photoCaptureProfile; }
			set 
			{ 
				_photoCaptureProfile = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _reuseTcn;
		public bool? ReuseTcn 
		{ 
			get { return _reuseTcn; }
			set 
			{ 
				_reuseTcn = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _showPhotoProfile;
		public bool? ShowPhotoProfile 
		{ 
			get { return _showPhotoProfile; }
			set 
			{ 
				_showPhotoProfile = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _showDocumentProfile;
		public bool? ShowDocumentProfile 
		{ 
			get { return _showDocumentProfile; }
			set 
			{ 
				_showDocumentProfile = value;  
				IsDirty = true;
			}
		} 
			
		protected string _documentCaptureProfile;
		public string DocumentCaptureProfile 
		{ 
			get { return _documentCaptureProfile; }
			set 
			{ 
				_documentCaptureProfile = value;  
				IsDirty = true;
			}
		} 
			
		protected string _agencyConfigKey;
		public string AgencyConfigKey 
		{ 
			get { return _agencyConfigKey; }
			set 
			{ 
				_agencyConfigKey = value;  
				IsDirty = true;
			}
		} 
			
		protected string _reuseTcnText;
		public string ReuseTcnText 
		{ 
			get { return _reuseTcnText; }
			set 
			{ 
				_reuseTcnText = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _reuseTcnYesAction;
		public bool? ReuseTcnYesAction 
		{ 
			get { return _reuseTcnYesAction; }
			set 
			{ 
				_reuseTcnYesAction = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _allowBioImport;
		public bool? AllowBioImport 
		{ 
			get { return _allowBioImport; }
			set 
			{ 
				_allowBioImport = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _usePreface;
		public bool? UsePreface 
		{ 
			get { return _usePreface; }
			set 
			{ 
				_usePreface = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _enforceCompliance;
		public bool? EnforceCompliance 
		{ 
			get { return _enforceCompliance; }
			set 
			{ 
				_enforceCompliance = value;  
				IsDirty = true;
			}
		} 
			
		protected Agency _agency;
		public Agency Agency 
		{ 
			get { return _agency; }
			set 
			{ 
				_agency = value;  
				IsDirty = true;
			}
		} 
			
		protected DefaultValue _defaultValues;
		public DefaultValue DefaultValues 
		{ 
			get { return _defaultValues; }
			set 
			{ 
				_defaultValues = value;  
				IsDirty = true;
			}
		} 
				
		protected WorkspaceGroup _workspaceGroups;
		public WorkspaceGroup WorkspaceGroups 
		{ 
			get { return _workspaceGroups; }
			set 
			{ 
				_workspaceGroups = value;  
				IsDirty = true;
			}
		} 
				
		protected Transaction _transactions;
		public Transaction Transactions 
		{ 
			get { return _transactions; }
			set 
			{ 
				_transactions = value;  
				IsDirty = true;
			}
		} 
				
		protected BiographicGroup _biographicGroups;
		public BiographicGroup BiographicGroups 
		{ 
			get { return _biographicGroups; }
			set 
			{ 
				_biographicGroups = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		