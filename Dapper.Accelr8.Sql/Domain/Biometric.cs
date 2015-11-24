
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
	public class Biometric : Dapper.Accelr8.Repo.Domain.BaseEntity<int>, IEntity, IHaveId<int>
	{	
		public Biometric()
		{
			IsDirty = false;
		}
				
		protected int _transactionId;
		public int TransactionId 
		{ 
			get { return _transactionId; }
			set 
			{ 
				_transactionId = value;  
				IsDirty = true;
			}
		} 
			
		protected string _fingerPosition;
		public string FingerPosition 
		{ 
			get { return _fingerPosition; }
			set 
			{ 
				_fingerPosition = value;  
				IsDirty = true;
			}
		} 
			
		protected int _quality;
		public int Quality 
		{ 
			get { return _quality; }
			set 
			{ 
				_quality = value;  
				IsDirty = true;
			}
		} 
			
		protected string _modality;
		public string Modality 
		{ 
			get { return _modality; }
			set 
			{ 
				_modality = value;  
				IsDirty = true;
			}
		} 
			
		protected Transaction _transaction;
		public Transaction Transaction 
		{ 
			get { return _transaction; }
			set 
			{ 
				_transaction = value;  
				IsDirty = true;
			}
		} 
				}
}

		