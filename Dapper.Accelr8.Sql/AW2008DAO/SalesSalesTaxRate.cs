
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
	public partial class SalesSalesTaxRate : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSalesTaxRate()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected int _stateProvinceID;
		public int StateProvinceID 
		{ 
			get { return _stateProvinceID; }
			set 
			{ 
				_stateProvinceID = value;  
				IsDirty = true;
			}
		} 
			
		protected byte _taxType;
		public byte TaxType 
		{ 
			get { return _taxType; }
			set 
			{ 
				_taxType = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _taxRate;
		public decimal TaxRate 
		{ 
			get { return _taxRate; }
			set 
			{ 
				_taxRate = value;  
				IsDirty = true;
			}
		} 
			
		protected object _name;
		public object Name 
		{ 
			get { return _name; }
			set 
			{ 
				_name = value;  
				IsDirty = true;
			}
		} 
			
		protected Guid _rowguid;
		public Guid rowguid 
		{ 
			get { return _rowguid; }
			set 
			{ 
				_rowguid = value;  
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
		 
	//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID	
		protected PersonStateProvince _personStateProvince;
		public virtual PersonStateProvince PersonStateProvince 
		{ 
			get { return _personStateProvince; }
			set 
			{ 
				_personStateProvince = value;  
				IsDirty = true;
			}
		} 
				}
}

		