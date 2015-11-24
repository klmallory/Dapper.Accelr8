
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
	public class UsersGroup : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public UsersGroup()
		{
			IsDirty = false;
		}
				
		protected int _userId;
		public int UserId 
		{ 
			get { return _userId; }
			set 
			{ 
				_userId = value;  
				IsDirty = true;
			}
		} 
			
		protected int _groupId;
		public int GroupId 
		{ 
			get { return _groupId; }
			set 
			{ 
				_groupId = value;  
				IsDirty = true;
			}
		} 
			
		protected Group _group;
		public Group Group 
		{ 
			get { return _group; }
			set 
			{ 
				_group = value;  
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

		