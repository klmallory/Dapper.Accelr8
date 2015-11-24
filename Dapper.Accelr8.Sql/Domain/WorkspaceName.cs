
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
	public class WorkspaceName : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public WorkspaceName()
		{
			IsDirty = false;
		}
				
		protected int _workspaceId;
		public int WorkspaceId 
		{ 
			get { return _workspaceId; }
			set 
			{ 
				_workspaceId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _language;
		public string Language 
		{ 
			get { return _language; }
			set 
			{ 
				_language = value;  
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
			
		protected Workspace _workspace;
		public Workspace Workspace 
		{ 
			get { return _workspace; }
			set 
			{ 
				_workspace = value;  
				IsDirty = true;
			}
		} 
				}
}

		