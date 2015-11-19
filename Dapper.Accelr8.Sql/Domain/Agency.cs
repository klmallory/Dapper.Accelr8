

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
	public class Agency : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Agency()
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
			
		protected bool _cmabi;
		public bool Cmabi 
		{ 
			get { return _cmabi; }
			set 
			{ 
				_cmabi = value;  
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
			
		protected Workspace _workspaces;
		public Workspace Workspaces 
		{ 
			get { return _workspaces; }
			set 
			{ 
				_workspaces = value;  
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

		