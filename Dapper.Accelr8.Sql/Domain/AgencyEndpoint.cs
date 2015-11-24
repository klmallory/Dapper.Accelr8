
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
	public class AgencyEndpoint : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public AgencyEndpoint()
		{
			IsDirty = false;
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
			
		protected int _endpointId;
		public int EndpointId 
		{ 
			get { return _endpointId; }
			set 
			{ 
				_endpointId = value;  
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
				}
}

		