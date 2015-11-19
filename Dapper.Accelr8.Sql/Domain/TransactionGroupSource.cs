

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
	public class TransactionGroupSource : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public TransactionGroupSource()
		{
			IsDirty = false;
		}
				
		protected int _transactionId;
		public int TransactionId 
		{ 
			get { return _transactionId; }
			set 
			{ 
				_transactionId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _tcn;
		public string Tcn 
		{ 
			get { return _tcn; }
			set 
			{ 
				_tcn = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _createdDate;
		public DateTime CreatedDate 
		{ 
			get { return _createdDate; }
			set 
			{ 
				_createdDate = value;  
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
			
		protected string _transactionType;
		public string TransactionType 
		{ 
			get { return _transactionType; }
			set 
			{ 
				_transactionType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _transactionStatus;
		public string TransactionStatus 
		{ 
			get { return _transactionStatus; }
			set 
			{ 
				_transactionStatus = value;  
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
			
		protected int? _transactionFieldId;
		public int? TransactionFieldId 
		{ 
			get { return _transactionFieldId; }
			set 
			{ 
				_transactionFieldId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _fieldDescriptor;
		public string FieldDescriptor 
		{ 
			get { return _fieldDescriptor; }
			set 
			{ 
				_fieldDescriptor = value;  
				IsDirty = true;
			}
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
			
		protected string _sourceKey;
		public string SourceKey 
		{ 
			get { return _sourceKey; }
			set 
			{ 
				_sourceKey = value;  
				IsDirty = true;
			}
		} 
			
		protected string _agencyName;
		public string AgencyName 
		{ 
			get { return _agencyName; }
			set 
			{ 
				_agencyName = value;  
				IsDirty = true;
			}
		} 
		
		}
}

		