
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
	public class TransmissionLog : Dapper.Accelr8.Repo.Domain.BaseEntity<long>, IEntity, IHaveId<long>
	{	
		public TransmissionLog()
		{
			IsDirty = false;
		}
				
		protected int? _transactionId;
		public int? TransactionId 
		{ 
			get { return _transactionId; }
			set 
			{ 
				_transactionId = value;  
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
			
		protected int? _responseId;
		public int? ResponseId 
		{ 
			get { return _responseId; }
			set 
			{ 
				_responseId = value;  
				IsDirty = true;
			}
		} 
			
		protected Guid _executionContextId;
		public Guid ExecutionContextId 
		{ 
			get { return _executionContextId; }
			set 
			{ 
				_executionContextId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _request;
		public string Request 
		{ 
			get { return _request; }
			set 
			{ 
				_request = value;  
				IsDirty = true;
			}
		} 
			
		protected string _response;
		public string Response 
		{ 
			get { return _response; }
			set 
			{ 
				_response = value;  
				IsDirty = true;
			}
		} 
			
		protected string _requstToUrl;
		public string RequstToUrl 
		{ 
			get { return _requstToUrl; }
			set 
			{ 
				_requstToUrl = value;  
				IsDirty = true;
			}
		} 
			
		protected string _responseFromUrl;
		public string ResponseFromUrl 
		{ 
			get { return _responseFromUrl; }
			set 
			{ 
				_responseFromUrl = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _requestTime;
		public DateTime? RequestTime 
		{ 
			get { return _requestTime; }
			set 
			{ 
				_requestTime = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _responseTime;
		public DateTime? ResponseTime 
		{ 
			get { return _responseTime; }
			set 
			{ 
				_responseTime = value;  
				IsDirty = true;
			}
		} 
				}
}

		