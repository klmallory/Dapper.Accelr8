
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
	public class DatabaseLog : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public DatabaseLog()
		{
							
			IsDirty = false; 
			_postTime = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected DateTime _postTime;
		public DateTime PostTime 
		{ 
			get { return _postTime; }
			set 
			{ 
				_postTime = value;  
				IsDirty = true;
			}
		} 
			
		protected object _databaseUser;
		public object DatabaseUser 
		{ 
			get { return _databaseUser; }
			set 
			{ 
				_databaseUser = value;  
				IsDirty = true;
			}
		} 
			
		protected object _event;
		public object Event 
		{ 
			get { return _event; }
			set 
			{ 
				_event = value;  
				IsDirty = true;
			}
		} 
			
		protected object _schema;
		public object Schema 
		{ 
			get { return _schema; }
			set 
			{ 
				_schema = value;  
				IsDirty = true;
			}
		} 
			
		protected object _object;
		public object Object 
		{ 
			get { return _object; }
			set 
			{ 
				_object = value;  
				IsDirty = true;
			}
		} 
			
		protected string _tSQL;
		public string TSQL 
		{ 
			get { return _tSQL; }
			set 
			{ 
				_tSQL = value;  
				IsDirty = true;
			}
		} 
			
		protected string _xmlEvent;
		public string XmlEvent 
		{ 
			get { return _xmlEvent; }
			set 
			{ 
				_xmlEvent = value;  
				IsDirty = true;
			}
		} 
				}
}

		