

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
	public class EnrollmentMnemonicValue : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public EnrollmentMnemonicValue()
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
			
		protected string _enrollmentMnemonicValueEntry;
		public string EnrollmentMnemonicValueEntry 
		{ 
			get { return _enrollmentMnemonicValueEntry; }
			set 
			{ 
				_enrollmentMnemonicValueEntry = value;  
				IsDirty = true;
			}
		} 
			
		protected string _enrollmentMnemonicType;
		public string EnrollmentMnemonicType 
		{ 
			get { return _enrollmentMnemonicType; }
			set 
			{ 
				_enrollmentMnemonicType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _enrollmentMnemonicDescription;
		public string EnrollmentMnemonicDescription 
		{ 
			get { return _enrollmentMnemonicDescription; }
			set 
			{ 
				_enrollmentMnemonicDescription = value;  
				IsDirty = true;
			}
		} 
			
		protected string _mnemonicCode;
		public string MnemonicCode 
		{ 
			get { return _mnemonicCode; }
			set 
			{ 
				_mnemonicCode = value;  
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

		