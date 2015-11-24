
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
	public class WorkspaceGroup : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public WorkspaceGroup()
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
			
		protected int _groupId;
		public int GroupId 
		{ 
			get { return _groupId; }
			set 
			{ 
				_groupId = value;  
				IsDirty = true;
			}
		} 
			
		protected Group _group;
		public Group Group 
		{ 
			get { return _group; }
			set 
			{ 
				_group = value;  
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

		