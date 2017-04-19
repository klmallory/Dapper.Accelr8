
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
	public class ErrorLog : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ErrorLog()
		{
							
			IsDirty = false; 
			_errorTime = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected DateTime _errorTime;
		public DateTime ErrorTime 
		{ 
			get { return _errorTime; }
			set 
			{ 
				_errorTime = value;  
				IsDirty = true;
			}
		} 
			
		protected object _userName;
		public object UserName 
		{ 
			get { return _userName; }
			set 
			{ 
				_userName = value;  
				IsDirty = true;
			}
		} 
			
		protected int _errorNumber;
		public int ErrorNumber 
		{ 
			get { return _errorNumber; }
			set 
			{ 
				_errorNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _errorSeverity;
		public int? ErrorSeverity 
		{ 
			get { return _errorSeverity; }
			set 
			{ 
				_errorSeverity = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _errorState;
		public int? ErrorState 
		{ 
			get { return _errorState; }
			set 
			{ 
				_errorState = value;  
				IsDirty = true;
			}
		} 
			
		protected string _errorProcedure;
		public string ErrorProcedure 
		{ 
			get { return _errorProcedure; }
			set 
			{ 
				_errorProcedure = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _errorLine;
		public int? ErrorLine 
		{ 
			get { return _errorLine; }
			set 
			{ 
				_errorLine = value;  
				IsDirty = true;
			}
		} 
			
		protected string _errorMessage;
		public string ErrorMessage 
		{ 
			get { return _errorMessage; }
			set 
			{ 
				_errorMessage = value;  
				IsDirty = true;
			}
		} 
				}
}

		