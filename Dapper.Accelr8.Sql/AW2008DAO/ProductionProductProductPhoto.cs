
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
	public class ProductionProductProductPhoto : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public ProductionProductProductPhoto()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(ProductionProductProductPhoto dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.ProductID,
							dao.ProductPhotoID,
						
				}
			};
		}

			
			protected int _productID;
		public int ProductID 
		{ 
			get { return _productID; }
			set 
			{ 
				_productID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _productPhotoID;
		public int ProductPhotoID 
		{ 
			get { return _productPhotoID; }
			set 
			{ 
				_productPhotoID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
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

		