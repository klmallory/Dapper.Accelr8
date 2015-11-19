

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
	public class TransactionOperationHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public TransactionOperationHistory()
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
			
		protected DateTime? _timestamp;
		public DateTime? Timestamp 
		{ 
			get { return _timestamp; }
			set 
			{ 
				_timestamp = value;  
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
			
		protected int? _transactionCount;
		public int? TransactionCount 
		{ 
			get { return _transactionCount; }
			set 
			{ 
				_transactionCount = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _transactionSuccessCount;
		public int? TransactionSuccessCount 
		{ 
			get { return _transactionSuccessCount; }
			set 
			{ 
				_transactionSuccessCount = value;  
				IsDirty = true;
			}
		} 
			
		protected string _status;
		public string Status 
		{ 
			get { return _status; }
			set 
			{ 
				_status = value;  
				IsDirty = true;
			}
		} 
			
		protected string _operationType;
		public string OperationType 
		{ 
			get { return _operationType; }
			set 
			{ 
				_operationType = value;  
				IsDirty = true;
			}
		} 
			
		protected TransactionOperationDetail _transactionOperationDetails;
		public TransactionOperationDetail TransactionOperationDetails 
		{ 
			get { return _transactionOperationDetails; }
			set 
			{ 
				_transactionOperationDetails = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		