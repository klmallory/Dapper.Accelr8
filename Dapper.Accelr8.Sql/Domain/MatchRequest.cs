

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
	public class MatchRequest : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public MatchRequest()
		{
			IsDirty = false;
		}
				
		protected int _submissionId;
		public int SubmissionId 
		{ 
			get { return _submissionId; }
			set 
			{ 
				_submissionId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _abisRequestId;
		public string AbisRequestId 
		{ 
			get { return _abisRequestId; }
			set 
			{ 
				_abisRequestId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _abisOperation;
		public string AbisOperation 
		{ 
			get { return _abisOperation; }
			set 
			{ 
				_abisOperation = value;  
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
			
		protected string _personId;
		public string PersonId 
		{ 
			get { return _personId; }
			set 
			{ 
				_personId = value;  
				IsDirty = true;
			}
		} 
			
		protected Submission _submission;
		public Submission Submission 
		{ 
			get { return _submission; }
			set 
			{ 
				_submission = value;  
				IsDirty = true;
			}
		} 
		
		}
}

		