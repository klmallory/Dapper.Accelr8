
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
	public class ProductionProductModelIllustration : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public ProductionProductModelIllustration()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(ProductionProductModelIllustration dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.ProductModelID,
							dao.IllustrationID,
						
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
			
			protected int _illustrationID;
		public int IllustrationID 
		{ 
			get { return _illustrationID; }
			set 
			{ 
				_illustrationID = value;
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
		 
	//From Foreign Key FK_ProductModelIllustration_ProductModel_ProductModelID	
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
		 
	//From Foreign Key FK_ProductModelIllustration_Illustration_IllustrationID	
		protected ProductionIllustration _productionIllustration;
		public virtual ProductionIllustration ProductionIllustration 
		{ 
			get { return _productionIllustration; }
			set 
			{ 
				_productionIllustration = value;  
				IsDirty = true;
			}
		} 
				}
}

		