

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
	public class Person : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public Person()
		{
			IsDirty = false;
		}
				
		protected string _lastName;
		public string LastName 
		{ 
			get { return _lastName; }
			set 
			{ 
				_lastName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _firstName;
		public string FirstName 
		{ 
			get { return _firstName; }
			set 
			{ 
				_firstName = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _matcherPersonId;
		public int? MatcherPersonId 
		{ 
			get { return _matcherPersonId; }
			set 
			{ 
				_matcherPersonId = value;  
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

		