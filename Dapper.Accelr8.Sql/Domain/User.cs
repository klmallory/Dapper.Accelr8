

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
	public class User : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public User()
		{
			IsDirty = false;
		}
				
		protected string _username;
		public string Username 
		{ 
			get { return _username; }
			set 
			{ 
				_username = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _applicationId;
		public int? ApplicationId 
		{ 
			get { return _applicationId; }
			set 
			{ 
				_applicationId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _displayLanguage;
		public string DisplayLanguage 
		{ 
			get { return _displayLanguage; }
			set 
			{ 
				_displayLanguage = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _isDisabled;
		public bool? IsDisabled 
		{ 
			get { return _isDisabled; }
			set 
			{ 
				_isDisabled = value;  
				IsDirty = true;
			}
		} 
			
		protected Application _application;
		public Application Application 
		{ 
			get { return _application; }
			set 
			{ 
				_application = value;  
				IsDirty = true;
			}
		} 
			
		protected License _licenses;
		public License Licenses 
		{ 
			get { return _licenses; }
			set 
			{ 
				_licenses = value;  
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
				
		protected Transaction _transactions;
		public Transaction Transactions 
		{ 
			get { return _transactions; }
			set 
			{ 
				_transactions = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		