

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
	public class TransactionOperationDetail : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public TransactionOperationDetail()
		{
			IsDirty = false;
		}
				
		protected int _transactionOperationHistoryId;
		public int TransactionOperationHistoryId 
		{ 
			get { return _transactionOperationHistoryId; }
			set 
			{ 
				_transactionOperationHistoryId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _operationFileName;
		public string OperationFileName 
		{ 
			get { return _operationFileName; }
			set 
			{ 
				_operationFileName = value;  
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
			
		protected string _reasonFailed;
		public string ReasonFailed 
		{ 
			get { return _reasonFailed; }
			set 
			{ 
				_reasonFailed = value;  
				IsDirty = true;
			}
		} 
			
		protected TransactionOperationHistory _transactionOperationHistory;
		public TransactionOperationHistory TransactionOperationHistory 
		{ 
			get { return _transactionOperationHistory; }
			set 
			{ 
				_transactionOperationHistory = value;  
				IsDirty = true;
			}
		} 
		
		}
}

		