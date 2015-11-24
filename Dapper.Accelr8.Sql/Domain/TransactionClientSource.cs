
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
	public class TransactionClientSource : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public TransactionClientSource()
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
			
		protected int? _submissionCnt;
		public int? SubmissionCnt 
		{ 
			get { return _submissionCnt; }
			set 
			{ 
				_submissionCnt = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _clientId;
		public int? ClientId 
		{ 
			get { return _clientId; }
			set 
			{ 
				_clientId = value;  
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
			
		protected int? _sourceId;
		public int? SourceId 
		{ 
			get { return _sourceId; }
			set 
			{ 
				_sourceId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _sourceClient;
		public string SourceClient 
		{ 
			get { return _sourceClient; }
			set 
			{ 
				_sourceClient = value;  
				IsDirty = true;
			}
		} 
			
		protected string _sourceName;
		public string SourceName 
		{ 
			get { return _sourceName; }
			set 
			{ 
				_sourceName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _filepath;
		public string Filepath 
		{ 
			get { return _filepath; }
			set 
			{ 
				_filepath = value;  
				IsDirty = true;
			}
		} 
				}
}

		