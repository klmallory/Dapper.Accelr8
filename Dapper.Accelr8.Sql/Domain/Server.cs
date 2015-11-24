
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
	public class Server : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public Server()
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
			
		protected string _direction;
		public string Direction 
		{ 
			get { return _direction; }
			set 
			{ 
				_direction = value;  
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
			
		protected string _protocol;
		public string Protocol 
		{ 
			get { return _protocol; }
			set 
			{ 
				_protocol = value;  
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
			
		protected IList<Endpoint> _endpoints;
		public IList<Endpoint> Endpoints 
		{ 
			get { return _endpoints; }
			set 
			{ 
				_endpoints = value;  
				IsDirty = true;
			}
		} 
					}
}

		