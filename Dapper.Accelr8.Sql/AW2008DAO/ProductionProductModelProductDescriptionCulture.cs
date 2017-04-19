
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
	public class ProductionProductModelProductDescriptionCulture : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public ProductionProductModelProductDescriptionCulture()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(ProductionProductModelProductDescriptionCulture dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.ProductModelID,
							dao.ProductDescriptionID,
							dao.CultureID,
						
				}
			};
		}

			
			protected int _productModelID;
		public int ProductModelID 
		{ 
			get { return _productModelID; }
			set 
			{ 
				_productModelID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _productDescriptionID;
		public int ProductDescriptionID 
		{ 
			get { return _productDescriptionID; }
			set 
			{ 
				_productDescriptionID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected string _cultureID;
		public string CultureID 
		{ 
			get { return _cultureID; }
			set 
			{ 
				_cultureID = value;
				this.Id = GetCompoundKeyFor(this);

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
		 
	//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID	
		protected ProductionProductModel _productionProductModel;
		public virtual ProductionProductModel ProductionProductModel 
		{ 
			get { return _productionProductModel; }
			set 
			{ 
				_productionProductModel = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_ProductModelProductDescriptionCulture_Culture_CultureID	
		protected ProductionCulture _productionCulture;
		public virtual ProductionCulture ProductionCulture 
		{ 
			get { return _productionCulture; }
			set 
			{ 
				_productionCulture = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID	
		protected ProductionProductDescription _productionProductDescription;
		public virtual ProductionProductDescription ProductionProductDescription 
		{ 
			get { return _productionProductDescription; }
			set 
			{ 
				_productionProductDescription = value;  
				IsDirty = true;
			}
		} 
				}
}

		