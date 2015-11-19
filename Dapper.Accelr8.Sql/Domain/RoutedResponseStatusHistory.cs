

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
	public class RoutedResponseStatusHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public RoutedResponseStatusHistory()
		{
			IsDirty = false;
		}
				
		protected int _routedResponseId;
		public int RoutedResponseId 
		{ 
			get { return _routedResponseId; }
			set 
			{ 
				_routedResponseId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _routedResponseStatus;
		public string RoutedResponseStatus 
		{ 
			get { return _routedResponseStatus; }
			set 
			{ 
				_routedResponseStatus = value;  
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
			
		protected RoutedResponse _routedResponse;
		public RoutedResponse RoutedResponse 
		{ 
			get { return _routedResponse; }
			set 
			{ 
				_routedResponse = value;  
				IsDirty = true;
			}
		} 
		
		}
}

		