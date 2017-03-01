
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
	public partial class ProductionBillOfMaterial : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionBillOfMaterial()
		{			
			IsDirty = false; 
			_startDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected int? _productAssemblyID;
		public int? ProductAssemblyID 
		{ 
			get { return _productAssemblyID; }
			set 
			{ 
				_productAssemblyID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _componentID;
		public int ComponentID 
		{ 
			get { return _componentID; }
			set 
			{ 
				_componentID = value;  
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
			
		protected DateTime? _endDate;
		public DateTime? EndDate 
		{ 
			get { return _endDate; }
			set 
			{ 
				_endDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _unitMeasureCode;
		public string UnitMeasureCode 
		{ 
			get { return _unitMeasureCode; }
			set 
			{ 
				_unitMeasureCode = value;  
				IsDirty = true;
			}
		} 
			
		protected short _bOMLevel;
		public short BOMLevel 
		{ 
			get { return _bOMLevel; }
			set 
			{ 
				_bOMLevel = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _perAssemblyQty;
		public decimal PerAssemblyQty 
		{ 
			get { return _perAssemblyQty; }
			set 
			{ 
				_perAssemblyQty = value;  
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
		protected ProductionUnitMeasure _productionUnitMeasure;
		public virtual ProductionUnitMeasure ProductionUnitMeasure 
		{ 
			get { return _productionUnitMeasure; }
			set 
			{ 
				_productionUnitMeasure = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_BillOfMaterials_Product_ProductAssemblyID	
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
		 
	//From Foreign Key FK_BillOfMaterials_Product_ComponentID	
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

		