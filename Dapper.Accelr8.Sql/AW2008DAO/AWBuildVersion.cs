
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
	public partial class AWBuildVersion : Dapper.Accelr8.Repo.Domain.BaseEntity<byte>
	{
			public AWBuildVersion()
		{			
			IsDirty = false; 
			_versionDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected string _database_spc_Version;
		public string Database_spc_Version 
		{ 
			get { return _database_spc_Version; }
			set 
			{ 
				_database_spc_Version = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _versionDate;
		public DateTime VersionDate 
		{ 
			get { return _versionDate; }
			set 
			{ 
				_versionDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _modifiedDate;
		public DateTime ModifiedDate 
		{ 
			get { return _modifiedDate; }
			set 
			{ 
				_modifiedDate = value;  
				IsDirty = true;
			}
		} 
				}
}

		