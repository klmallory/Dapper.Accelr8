
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
	public class AuditTrail : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public AuditTrail()
		{
			IsDirty = false;
		}
				
		protected string _userName;
		public string UserName 
		{ 
			get { return _userName; }
			set 
			{ 
				_userName = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _auditDate;
		public DateTime AuditDate 
		{ 
			get { return _auditDate; }
			set 
			{ 
				_auditDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _action;
		public string Action 
		{ 
			get { return _action; }
			set 
			{ 
				_action = value;  
				IsDirty = true;
			}
		} 
			
		protected string _area;
		public string Area 
		{ 
			get { return _area; }
			set 
			{ 
				_area = value;  
				IsDirty = true;
			}
		} 
			
		protected string _detail;
		public string Detail 
		{ 
			get { return _detail; }
			set 
			{ 
				_detail = value;  
				IsDirty = true;
			}
		} 
				}
}

		