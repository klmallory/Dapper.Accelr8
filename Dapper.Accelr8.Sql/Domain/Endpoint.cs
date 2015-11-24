
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
	public class Endpoint : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
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
				
		protected IList<Client> _clients;
		public IList<Client> Clients 
		{ 
			get { return _clients; }
			set 
			{ 
				_clients = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<RoutedResponse> _routedResponses;
		public IList<RoutedResponse> RoutedResponses 
		{ 
			get { return _routedResponses; }
			set 
			{ 
				_routedResponses = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<AgencyEndpoint> _agencyEndpoints;
		public IList<AgencyEndpoint> AgencyEndpoints 
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

		