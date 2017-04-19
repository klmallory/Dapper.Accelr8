
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
	public class ProductionvProductModelInstruction : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionvProductModelInstruction()
		{
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected int _productModelID;
		public int ProductModelID 
		{ 
			get { return _productModelID; }
			set 
			{ 
				_productModelID = value;  
				IsDirty = true;
			}
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
			
		protected string _instructions;
		public string Instructions 
		{ 
			get { return _instructions; }
			set 
			{ 
				_instructions = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _locationID;
		public int? LocationID 
		{ 
			get { return _locationID; }
			set 
			{ 
				_locationID = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _setupHours;
		public decimal? SetupHours 
		{ 
			get { return _setupHours; }
			set 
			{ 
				_setupHours = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _machineHours;
		public decimal? MachineHours 
		{ 
			get { return _machineHours; }
			set 
			{ 
				_machineHours = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _laborHours;
		public decimal? LaborHours 
		{ 
			get { return _laborHours; }
			set 
			{ 
				_laborHours = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _lotSize;
		public int? LotSize 
		{ 
			get { return _lotSize; }
			set 
			{ 
				_lotSize = value;  
				IsDirty = true;
			}
		} 
			
		protected string _step;
		public string Step 
		{ 
			get { return _step; }
			set 
			{ 
				_step = value;  
				IsDirty = true;
			}
		} 
			
		protected Guid _rowguid;
		public Guid rowguid 
		{ 
			get { return _rowguid; }
			set 
			{ 
				_rowguid = value;  
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
				}
}

		