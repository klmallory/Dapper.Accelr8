
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
	public class Response : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public Response()
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
			
		protected DateTime _dateReceived;
		public DateTime DateReceived 
		{ 
			get { return _dateReceived; }
			set 
			{ 
				_dateReceived = value;  
				IsDirty = true;
			}
		} 
			
		protected string _filePath;
		public string FilePath 
		{ 
			get { return _filePath; }
			set 
			{ 
				_filePath = value;  
				IsDirty = true;
			}
		} 
			
		protected string _responseType;
		public string ResponseType 
		{ 
			get { return _responseType; }
			set 
			{ 
				_responseType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _tcr;
		public string Tcr 
		{ 
			get { return _tcr; }
			set 
			{ 
				_tcr = value;  
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
			
		protected int? _agencyId;
		public int? AgencyId 
		{ 
			get { return _agencyId; }
			set 
			{ 
				_agencyId = value;  
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
			
		protected IList<RoutedResponse> _routedResponses;
		public IList<RoutedResponse> RoutedResponses 
		{ 
			get { return _routedResponses; }
			set 
			{ 
				_routedResponses = value;  
				IsDirty = true;
			}
		} 
					}
}

		