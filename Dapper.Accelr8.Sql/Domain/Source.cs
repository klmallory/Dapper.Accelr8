

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
	public class Source : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Source()
		{
			IsDirty = false;
		}
				
		protected string _name;
		public string Name 
		{ 
			get { return _name; }
			set 
			{ 
				_name = value;  
				IsDirty = true;
			}
		} 
			
		protected string _sourceKey;
		public string SourceKey 
		{ 
			get { return _sourceKey; }
			set 
			{ 
				_sourceKey = value;  
				IsDirty = true;
			}
		} 
			
		protected string _description;
		public string Description 
		{ 
			get { return _description; }
			set 
			{ 
				_description = value;  
				IsDirty = true;
			}
		} 
			
		protected Transaction _transactions;
		public Transaction Transactions 
		{ 
			get { return _transactions; }
			set 
			{ 
				_transactions = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		