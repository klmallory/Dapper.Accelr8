
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
	public partial class ProductionWorkOrderRouting : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionWorkOrderRouting()
		{			
			IsDirty = false; 
			_scheduledStartDate = (DateTime)SqlDateTime.MinValue;
		_scheduledEndDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected short _locationID;
		public short LocationID 
		{ 
			get { return _locationID; }
			set 
			{ 
				_locationID = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _scheduledStartDate;
		public DateTime ScheduledStartDate 
		{ 
			get { return _scheduledStartDate; }
			set 
			{ 
				_scheduledStartDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _scheduledEndDate;
		public DateTime ScheduledEndDate 
		{ 
			get { return _scheduledEndDate; }
			set 
			{ 
				_scheduledEndDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _actualStartDate;
		public DateTime? ActualStartDate 
		{ 
			get { return _actualStartDate; }
			set 
			{ 
				_actualStartDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _actualEndDate;
		public DateTime? ActualEndDate 
		{ 
			get { return _actualEndDate; }
			set 
			{ 
				_actualEndDate = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _actualResourceHrs;
		public decimal? ActualResourceHrs 
		{ 
			get { return _actualResourceHrs; }
			set 
			{ 
				_actualResourceHrs = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _plannedCost;
		public decimal PlannedCost 
		{ 
			get { return _plannedCost; }
			set 
			{ 
				_plannedCost = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _actualCost;
		public decimal? ActualCost 
		{ 
			get { return _actualCost; }
			set 
			{ 
				_actualCost = value;  
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
		 
	//From Foreign Key FK_WorkOrderRouting_WorkOrder_WorkOrderID	
		protected ProductionWorkOrder _productionWorkOrder;
		public virtual ProductionWorkOrder ProductionWorkOrder 
		{ 
			get { return _productionWorkOrder; }
			set 
			{ 
				_productionWorkOrder = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_WorkOrderRouting_Location_LocationID	
		protected ProductionLocation _productionLocation;
		public virtual ProductionLocation ProductionLocation 
		{ 
			get { return _productionLocation; }
			set 
			{ 
				_productionLocation = value;  
				IsDirty = true;
			}
		} 
				}
}

		