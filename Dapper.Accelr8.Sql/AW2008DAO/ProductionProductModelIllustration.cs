
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
	public partial class ProductionProductModelIllustration : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProductModelIllustration()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
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

		