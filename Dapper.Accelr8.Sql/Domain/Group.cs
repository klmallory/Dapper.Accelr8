
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
	public class Group : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
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
			
		protected IList<UsersGroup> _usersGroups;
		public IList<UsersGroup> UsersGroups 
		{ 
			get { return _usersGroups; }
			set 
			{ 
				_usersGroups = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<WorkspaceGroup> _workspaceGroups;
		public IList<WorkspaceGroup> WorkspaceGroups 
		{ 
			get { return _workspaceGroups; }
			set 
			{ 
				_workspaceGroups = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<PrinterGroup> _printerGroups;
		public IList<PrinterGroup> PrinterGroups 
		{ 
			get { return _printerGroups; }
			set 
			{ 
				_printerGroups = value;  
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
				
		protected IList<TransactionGroup> _transactionGroups;
		public IList<TransactionGroup> TransactionGroups 
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

		