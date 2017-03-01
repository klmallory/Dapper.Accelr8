
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
	public partial class ProductionProductInventory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProductInventory()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected string _shelf;
		public string Shelf 
		{ 
			get { return _shelf; }
			set 
			{ 
				_shelf = value;  
				IsDirty = true;
			}
		} 
			
		protected byte _bin;
		public byte Bin 
		{ 
			get { return _bin; }
			set 
			{ 
				_bin = value;  
				IsDirty = true;
			}
		} 
			
		protected short _quantity;
		public short Quantity 
		{ 
			get { return _quantity; }
			set 
			{ 
				_quantity = value;  
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
		 
	//From Foreign Key FK_ProductInventory_Location_LocationID	
		protected ProductionLocation _productionLocation;
		public virtual ProductionLocation ProductionLocation 
		{ 
			get { return _productionLocation; }
			set 
			{ 
				_productionLocation = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_ProductInventory_Product_ProductID	
		protected ProductionProduct _productionProduct;
		public virtual ProductionProduct ProductionProduct 
		{ 
			get { return _productionProduct; }
			set 
			{ 
				_productionProduct = value;  
				IsDirty = true;
			}
		} 
				}
}

		