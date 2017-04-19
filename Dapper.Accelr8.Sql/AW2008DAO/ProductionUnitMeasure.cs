
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
	public class ProductionUnitMeasure : Dapper.Accelr8.Repo.Domain.BaseEntity<string>
	{
			public ProductionUnitMeasure()
		{
							
			IsDirty = false; 
			_productionBillOfMaterials = new List<ProductionBillOfMaterial>();
		_productionProducts1 = new List<ProductionProduct>();
		_productionProducts2 = new List<ProductionProduct>();
		_purchasingProductVendors = new List<PurchasingProductVendor>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
		 
	//From Foreign Key FK_BillOfMaterials_UnitMeasure_UnitMeasureCode	
		protected IList<ProductionBillOfMaterial> _productionBillOfMaterials;
		public virtual IList<ProductionBillOfMaterial> ProductionBillOfMaterials 
		{ 
			get { return _productionBillOfMaterials; }
			set 
			{ 
				_productionBillOfMaterials = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Product_UnitMeasure_SizeUnitMeasureCode	
		protected IList<ProductionProduct> _productionProducts1;
		public virtual IList<ProductionProduct> ProductionProducts1 
		{ 
			get { return _productionProducts1; }
			set 
			{ 
				_productionProducts1 = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Product_UnitMeasure_WeightUnitMeasureCode	
		protected IList<ProductionProduct> _productionProducts2;
		public virtual IList<ProductionProduct> ProductionProducts2 
		{ 
			get { return _productionProducts2; }
			set 
			{ 
				_productionProducts2 = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ProductVendor_UnitMeasure_UnitMeasureCode	
		protected IList<PurchasingProductVendor> _purchasingProductVendors;
		public virtual IList<PurchasingProductVendor> PurchasingProductVendors 
		{ 
			get { return _purchasingProductVendors; }
			set 
			{ 
				_purchasingProductVendors = value;  
				IsDirty = true;
			}
		} 
					}
}

		