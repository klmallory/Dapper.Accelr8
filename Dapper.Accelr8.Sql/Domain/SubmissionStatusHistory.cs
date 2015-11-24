
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
	public class SubmissionStatusHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public SubmissionStatusHistory()
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
			
		protected string _transmissionStatus;
		public string TransmissionStatus 
		{ 
			get { return _transmissionStatus; }
			set 
			{ 
				_transmissionStatus = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _statusDate;
		public DateTime StatusDate 
		{ 
			get { return _statusDate; }
			set 
			{ 
				_statusDate = value;  
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

		