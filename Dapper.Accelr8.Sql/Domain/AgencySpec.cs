
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
	public class AgencySpec : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public AgencySpec()
		{
			IsDirty = false;
		}
				
		protected string _specKey;
		public string SpecKey 
		{ 
			get { return _specKey; }
			set 
			{ 
				_specKey = value;  
				IsDirty = true;
			}
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
			
		protected string _fileDefinitionPath;
		public string FileDefinitionPath 
		{ 
			get { return _fileDefinitionPath; }
			set 
			{ 
				_fileDefinitionPath = value;  
				IsDirty = true;
			}
		} 
			
		protected IList<Agency> _agencies;
		public IList<Agency> Agencies 
		{ 
			get { return _agencies; }
			set 
			{ 
				_agencies = value;  
				IsDirty = true;
			}
		} 
				
		protected IList<Transaction> _transactions;
		public IList<Transaction> Transactions 
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

		