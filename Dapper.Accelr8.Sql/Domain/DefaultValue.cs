

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
	public class DefaultValue : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public DefaultValue()
		{
			IsDirty = false;
		}
				
		protected int? _workspaceId;
		public int? WorkspaceId 
		{ 
			get { return _workspaceId; }
			set 
			{ 
				_workspaceId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _value;
		public string Value 
		{ 
			get { return _value; }
			set 
			{ 
				_value = value;  
				IsDirty = true;
			}
		} 
			
		protected string _mnemonic;
		public string Mnemonic 
		{ 
			get { return _mnemonic; }
			set 
			{ 
				_mnemonic = value;  
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

		