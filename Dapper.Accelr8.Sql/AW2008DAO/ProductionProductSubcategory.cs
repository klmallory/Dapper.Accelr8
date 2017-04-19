
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
	public class ProductionProductSubcategory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProductSubcategory()
		{
							
			IsDirty = false; 
			_productionProducts = new List<ProductionProduct>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected int _productCategoryID;
		public int ProductCategoryID 
		{ 
			get { return _productCategoryID; }
			set 
			{ 
				_productCategoryID = value;  
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
		 
	//From Foreign Key FK_ProductSubcategory_ProductCategory_ProductCategoryID	
		protected ProductionProductCategory _productionProductCategory;
		public virtual ProductionProductCategory ProductionProductCategory 
		{ 
			get { return _productionProductCategory; }
			set 
			{ 
				_productionProductCategory = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Product_ProductSubcategory_ProductSubcategoryID	
		protected IList<ProductionProduct> _productionProducts;
		public virtual IList<ProductionProduct> ProductionProducts 
		{ 
			get { return _productionProducts; }
			set 
			{ 
				_productionProducts = value;  
				IsDirty = true;
			}
		} 
					}
}

		