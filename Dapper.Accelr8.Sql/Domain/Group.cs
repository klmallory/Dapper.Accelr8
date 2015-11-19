

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
	public class Group : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Group()
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
			
		protected bool? _isDefault;
		public bool? IsDefault 
		{ 
			get { return _isDefault; }
			set 
			{ 
				_isDefault = value;  
				IsDirty = true;
			}
		} 
			
		protected UsersGroup _usersGroups;
		public UsersGroup UsersGroups 
		{ 
			get { return _usersGroups; }
			set 
			{ 
				_usersGroups = value;  
				IsDirty = true;
			}
		} 
				
		protected WorkspaceGroup _workspaceGroups;
		public WorkspaceGroup WorkspaceGroups 
		{ 
			get { return _workspaceGroups; }
			set 
			{ 
				_workspaceGroups = value;  
				IsDirty = true;
			}
		} 
				
		protected PrinterGroup _printerGroups;
		public PrinterGroup PrinterGroups 
		{ 
			get { return _printerGroups; }
			set 
			{ 
				_printerGroups = value;  
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
				
		protected TransactionGroup _transactionGroups;
		public TransactionGroup TransactionGroups 
		{ 
			get { return _transactionGroups; }
			set 
			{ 
				_transactionGroups = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		