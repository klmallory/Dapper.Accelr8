
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
	public partial class ProductionProductProductPhoto : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProductProductPhoto()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected object _primary;
		public object Primary 
		{ 
			get { return _primary; }
			set 
			{ 
				_primary = value;  
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
		 
	//From Foreign Key FK_ProductProductPhoto_ProductPhoto_ProductPhotoID	
		protected ProductionProductPhoto _productionProductPhoto;
		public virtual ProductionProductPhoto ProductionProductPhoto 
		{ 
			get { return _productionProductPhoto; }
			set 
			{ 
				_productionProductPhoto = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_ProductProductPhoto_Product_ProductID	
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

		