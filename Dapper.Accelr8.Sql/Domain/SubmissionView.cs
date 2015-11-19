

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
	public class SubmissionView : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public SubmissionView()
		{
			IsDirty = false;
		}
				
		protected int _submissionId;
		public int SubmissionId 
		{ 
			get { return _submissionId; }
			set 
			{ 
				_submissionId = value;  
				IsDirty = true;
			}
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
			
		protected int? _endpointId;
		public int? EndpointId 
		{ 
			get { return _endpointId; }
			set 
			{ 
				_endpointId = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _agencyId;
		public int? AgencyId 
		{ 
			get { return _agencyId; }
			set 
			{ 
				_agencyId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _status;
		public string Status 
		{ 
			get { return _status; }
			set 
			{ 
				_status = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _responseCount;
		public int? ResponseCount 
		{ 
			get { return _responseCount; }
			set 
			{ 
				_responseCount = value;  
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
			
		protected string _destination;
		public string Destination 
		{ 
			get { return _destination; }
			set 
			{ 
				_destination = value;  
				IsDirty = true;
			}
		} 
		
		}
}

		