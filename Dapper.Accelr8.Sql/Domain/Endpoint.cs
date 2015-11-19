

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
	public class Endpoint : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Endpoint()
		{
			IsDirty = false;
		}
				
		protected int _serverId;
		public int ServerId 
		{ 
			get { return _serverId; }
			set 
			{ 
				_serverId = value;  
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
			
		protected byte[] _configuration;
		public byte[] Configuration 
		{ 
			get { return _configuration; }
			set 
			{ 
				_configuration = value;  
				IsDirty = true;
			}
		} 
			
		protected Server _server;
		public Server Server 
		{ 
			get { return _server; }
			set 
			{ 
				_server = value;  
				IsDirty = true;
			}
		} 
			
		protected Submission _submissions;
		public Submission Submissions 
		{ 
			get { return _submissions; }
			set 
			{ 
				_submissions = value;  
				IsDirty = true;
			}
		} 
				
		protected Client _clients;
		public Client Clients 
		{ 
			get { return _clients; }
			set 
			{ 
				_clients = value;  
				IsDirty = true;
			}
		} 
				
		protected RoutedResponse _routedResponses;
		public RoutedResponse RoutedResponses 
		{ 
			get { return _routedResponses; }
			set 
			{ 
				_routedResponses = value;  
				IsDirty = true;
			}
		} 
				
		protected AgencyEndpoint _agencyEndpoints;
		public AgencyEndpoint AgencyEndpoints 
		{ 
			get { return _agencyEndpoints; }
			set 
			{ 
				_agencyEndpoints = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		