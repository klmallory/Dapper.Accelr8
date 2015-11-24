
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
	public class License : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public License()
		{
			IsDirty = false;
		}
				
		protected string _licenseType;
		public string LicenseType 
		{ 
			get { return _licenseType; }
			set 
			{ 
				_licenseType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _computerName;
		public string ComputerName 
		{ 
			get { return _computerName; }
			set 
			{ 
				_computerName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _macAddress;
		public string MacAddress 
		{ 
			get { return _macAddress; }
			set 
			{ 
				_macAddress = value;  
				IsDirty = true;
			}
		} 
			
		protected string _deviceSerialNum;
		public string DeviceSerialNum 
		{ 
			get { return _deviceSerialNum; }
			set 
			{ 
				_deviceSerialNum = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _userId;
		public int? UserId 
		{ 
			get { return _userId; }
			set 
			{ 
				_userId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _workstationId;
		public string WorkstationId 
		{ 
			get { return _workstationId; }
			set 
			{ 
				_workstationId = value;  
				IsDirty = true;
			}
		} 
			
		protected User _user;
		public User User 
		{ 
			get { return _user; }
			set 
			{ 
				_user = value;  
				IsDirty = true;
			}
		} 
				}
}

		