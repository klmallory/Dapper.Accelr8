

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
	public class Client : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Client()
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
			
		protected bool _isActive;
		public bool IsActive 
		{ 
			get { return _isActive; }
			set 
			{ 
				_isActive = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emailAddress;
		public string EmailAddress 
		{ 
			get { return _emailAddress; }
			set 
			{ 
				_emailAddress = value;  
				IsDirty = true;
			}
		} 
			
		protected string _address1;
		public string Address1 
		{ 
			get { return _address1; }
			set 
			{ 
				_address1 = value;  
				IsDirty = true;
			}
		} 
			
		protected string _address2;
		public string Address2 
		{ 
			get { return _address2; }
			set 
			{ 
				_address2 = value;  
				IsDirty = true;
			}
		} 
			
		protected string _city;
		public string City 
		{ 
			get { return _city; }
			set 
			{ 
				_city = value;  
				IsDirty = true;
			}
		} 
			
		protected string _state;
		public string State 
		{ 
			get { return _state; }
			set 
			{ 
				_state = value;  
				IsDirty = true;
			}
		} 
			
		protected string _zip;
		public string Zip 
		{ 
			get { return _zip; }
			set 
			{ 
				_zip = value;  
				IsDirty = true;
			}
		} 
			
		protected string _country;
		public string Country 
		{ 
			get { return _country; }
			set 
			{ 
				_country = value;  
				IsDirty = true;
			}
		} 
			
		protected string _phone;
		public string Phone 
		{ 
			get { return _phone; }
			set 
			{ 
				_phone = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _groupId;
		public int? GroupId 
		{ 
			get { return _groupId; }
			set 
			{ 
				_groupId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _originatingAgencyId;
		public string OriginatingAgencyId 
		{ 
			get { return _originatingAgencyId; }
			set 
			{ 
				_originatingAgencyId = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _endpointId;
		public int? EndpointId 
		{ 
			get { return _endpointId; }
			set 
			{ 
				_endpointId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _contactName;
		public string ContactName 
		{ 
			get { return _contactName; }
			set 
			{ 
				_contactName = value;  
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

		