

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
	public class RoutedResponse : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public RoutedResponse()
		{
			IsDirty = false;
		}
				
		protected int _responseId;
		public int ResponseId 
		{ 
			get { return _responseId; }
			set 
			{ 
				_responseId = value;  
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
			
		protected Response _response;
		public Response Response 
		{ 
			get { return _response; }
			set 
			{ 
				_response = value;  
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
			
		protected RoutedResponseStatusHistory _routedResponseStatusHistories;
		public RoutedResponseStatusHistory RoutedResponseStatusHistories 
		{ 
			get { return _routedResponseStatusHistories; }
			set 
			{ 
				_routedResponseStatusHistories = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		