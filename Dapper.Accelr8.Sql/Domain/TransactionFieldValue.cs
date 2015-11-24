
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
	public class TransactionFieldValue : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public TransactionFieldValue()
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
			
		protected int _transactionFieldId;
		public int TransactionFieldId 
		{ 
			get { return _transactionFieldId; }
			set 
			{ 
				_transactionFieldId = value;  
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
			
		protected TransactionField _transactionField;
		public TransactionField TransactionField 
		{ 
			get { return _transactionField; }
			set 
			{ 
				_transactionField = value;  
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

		