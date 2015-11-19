

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
	public class TransactionField : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{	
		public TransactionField()
		{
			IsDirty = false;
		}
				
		protected string _fieldDescriptor;
		public string FieldDescriptor 
		{ 
			get { return _fieldDescriptor; }
			set 
			{ 
				_fieldDescriptor = value;  
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
			
		protected bool _isVisible;
		public bool IsVisible 
		{ 
			get { return _isVisible; }
			set 
			{ 
				_isVisible = value;  
				IsDirty = true;
			}
		} 
			
		protected bool? _isStandardField;
		public bool? IsStandardField 
		{ 
			get { return _isStandardField; }
			set 
			{ 
				_isStandardField = value;  
				IsDirty = true;
			}
		} 
			
		protected string _dataType;
		public string DataType 
		{ 
			get { return _dataType; }
			set 
			{ 
				_dataType = value;  
				IsDirty = true;
			}
		} 
			
		protected TransactionFieldValue _transactionFieldValues;
		public TransactionFieldValue TransactionFieldValues 
		{ 
			get { return _transactionFieldValues; }
			set 
			{ 
				_transactionFieldValues = value;  
				IsDirty = true;
			}
		} 
			
		}
}

		