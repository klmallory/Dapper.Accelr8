
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
	public partial class ProductionLocation : Dapper.Accelr8.Repo.Domain.BaseEntity<short>
	{
			public ProductionLocation()
		{			
			IsDirty = false; 
			_productionProductInventories = new List<ProductionProductInventory>();
		_productionWorkOrderRoutings = new List<ProductionWorkOrderRouting>();
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
			
		protected decimal _costRate;
		public decimal CostRate 
		{ 
			get { return _costRate; }
			set 
			{ 
				_costRate = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _availability;
		public decimal Availability 
		{ 
			get { return _availability; }
			set 
			{ 
				_availability = value;  
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
		protected IList<ProductionProductInventory> _productionProductInventories;
		public virtual IList<ProductionProductInventory> ProductionProductInventories 
		{ 
			get { return _productionProductInventories; }
			set 
			{ 
				_productionProductInventories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_WorkOrderRouting_Location_LocationID	
		protected IList<ProductionWorkOrderRouting> _productionWorkOrderRoutings;
		public virtual IList<ProductionWorkOrderRouting> ProductionWorkOrderRoutings 
		{ 
			get { return _productionWorkOrderRoutings; }
			set 
			{ 
				_productionWorkOrderRoutings = value;  
				IsDirty = true;
			}
		} 
					}
}

		