

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
	public class Document : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Document()
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
			
		protected byte[] _blob;
		public byte[] Blob 
		{ 
			get { return _blob; }
			set 
			{ 
				_blob = value;  
				IsDirty = true;
			}
		} 
			
		protected string _fileType;
		public string FileType 
		{ 
			get { return _fileType; }
			set 
			{ 
				_fileType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _documentTitle;
		public string DocumentTitle 
		{ 
			get { return _documentTitle; }
			set 
			{ 
				_documentTitle = value;  
				IsDirty = true;
			}
		} 
			
		protected string _issuingAuthority;
		public string IssuingAuthority 
		{ 
			get { return _issuingAuthority; }
			set 
			{ 
				_issuingAuthority = value;  
				IsDirty = true;
			}
		} 
			
		protected string _documentNumber;
		public string DocumentNumber 
		{ 
			get { return _documentNumber; }
			set 
			{ 
				_documentNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _expirationDate;
		public DateTime? ExpirationDate 
		{ 
			get { return _expirationDate; }
			set 
			{ 
				_expirationDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _documentGroup;
		public string DocumentGroup 
		{ 
			get { return _documentGroup; }
			set 
			{ 
				_documentGroup = value;  
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

		