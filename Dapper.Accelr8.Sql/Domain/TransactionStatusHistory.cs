

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
	public class TransactionStatusHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public TransactionStatusHistory()
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
			
		protected DateTime? _statusDate;
		public DateTime? StatusDate 
		{ 
			get { return _statusDate; }
			set 
			{ 
				_statusDate = value;  
				IsDirty = true;
			}
		} 
			
		protected Transaction _transaction;
		public Transaction Transaction 
		{ 
			get { return _transaction; }
			set 
			{ 
				_transaction = value;  
				IsDirty = true;
			}
		} 
		
		}
}

		