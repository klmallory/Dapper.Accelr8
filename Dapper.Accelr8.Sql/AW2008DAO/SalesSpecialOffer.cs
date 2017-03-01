
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
	public partial class SalesSpecialOffer : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSpecialOffer()
		{			
			IsDirty = false; 
			_salesSpecialOfferProducts = new List<SalesSpecialOfferProduct>();
		_startDate = (DateTime)SqlDateTime.MinValue;
		_endDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
			
		protected decimal _discountPct;
		public decimal DiscountPct 
		{ 
			get { return _discountPct; }
			set 
			{ 
				_discountPct = value;  
				IsDirty = true;
			}
		} 
			
		protected string _type;
		public string Type 
		{ 
			get { return _type; }
			set 
			{ 
				_type = value;  
				IsDirty = true;
			}
		} 
			
		protected string _category;
		public string Category 
		{ 
			get { return _category; }
			set 
			{ 
				_category = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _startDate;
		public DateTime StartDate 
		{ 
			get { return _startDate; }
			set 
			{ 
				_startDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _endDate;
		public DateTime EndDate 
		{ 
			get { return _endDate; }
			set 
			{ 
				_endDate = value;  
				IsDirty = true;
			}
		} 
			
		protected int _minQty;
		public int MinQty 
		{ 
			get { return _minQty; }
			set 
			{ 
				_minQty = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _maxQty;
		public int? MaxQty 
		{ 
			get { return _maxQty; }
			set 
			{ 
				_maxQty = value;  
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
		 
	//From Foreign Key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID	
		protected IList<SalesSpecialOfferProduct> _salesSpecialOfferProducts;
		public virtual IList<SalesSpecialOfferProduct> SalesSpecialOfferProducts 
		{ 
			get { return _salesSpecialOfferProducts; }
			set 
			{ 
				_salesSpecialOfferProducts = value;  
				IsDirty = true;
			}
		} 
					}
}

		