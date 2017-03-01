
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
	public partial class SalesShoppingCartItem : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesShoppingCartItem()
		{			
			IsDirty = false; 
			_dateCreated = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected string _shoppingCartID;
		public string ShoppingCartID 
		{ 
			get { return _shoppingCartID; }
			set 
			{ 
				_shoppingCartID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _quantity;
		public int Quantity 
		{ 
			get { return _quantity; }
			set 
			{ 
				_quantity = value;  
				IsDirty = true;
			}
		} 
			
		protected int _productID;
		public int ProductID 
		{ 
			get { return _productID; }
			set 
			{ 
				_productID = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _dateCreated;
		public DateTime DateCreated 
		{ 
			get { return _dateCreated; }
			set 
			{ 
				_dateCreated = value;  
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
		 
	//From Foreign Key FK_ShoppingCartItem_Product_ProductID	
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

		