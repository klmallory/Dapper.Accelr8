
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
	public class Submission : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public Submission()
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
			
		protected Transaction _transaction;
		public Transaction Transaction 
		{ 
			get { return _transaction; }
			set 
			{ 
				_transaction = value;  
				IsDirty = true;
			}
		} 
			
		protected Endpoint _endpoint;
		public Endpoint Endpoint 
		{ 
			get { return _endpoint; }
			set 
			{ 
				_endpoint = value;  
				IsDirty = true;
			}
		} 
			
		protected IList<SubmissionStatusHistory> _submissionStatusHistories;
		public IList<SubmissionStatusHistory> SubmissionStatusHistories 
		{ 
			get { return _submissionStatusHistories; }
			set 
			{ 
				_submissionStatusHistories = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<Response> _responses;
		public IList<Response> Responses 
		{ 
			get { return _responses; }
			set 
			{ 
				_responses = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<MatchRequest> _matchRequests;
		public IList<MatchRequest> MatchRequests 
		{ 
			get { return _matchRequests; }
			set 
			{ 
				_matchRequests = value;  
				IsDirty = true;
			}
		} 
					}
}

		