
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
	public class ProductionvProductModelCatalogDescription : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionvProductModelCatalogDescription()
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
			
		protected string _summary;
		public string Summary 
		{ 
			get { return _summary; }
			set 
			{ 
				_summary = value;  
				IsDirty = true;
			}
		} 
			
		protected string _manufacturer;
		public string Manufacturer 
		{ 
			get { return _manufacturer; }
			set 
			{ 
				_manufacturer = value;  
				IsDirty = true;
			}
		} 
			
		protected string _copyright;
		public string Copyright 
		{ 
			get { return _copyright; }
			set 
			{ 
				_copyright = value;  
				IsDirty = true;
			}
		} 
			
		protected string _productURL;
		public string ProductURL 
		{ 
			get { return _productURL; }
			set 
			{ 
				_productURL = value;  
				IsDirty = true;
			}
		} 
			
		protected string _warrantyPeriod;
		public string WarrantyPeriod 
		{ 
			get { return _warrantyPeriod; }
			set 
			{ 
				_warrantyPeriod = value;  
				IsDirty = true;
			}
		} 
			
		protected string _warrantyDescription;
		public string WarrantyDescription 
		{ 
			get { return _warrantyDescription; }
			set 
			{ 
				_warrantyDescription = value;  
				IsDirty = true;
			}
		} 
			
		protected string _noOfYears;
		public string NoOfYears 
		{ 
			get { return _noOfYears; }
			set 
			{ 
				_noOfYears = value;  
				IsDirty = true;
			}
		} 
			
		protected string _maintenanceDescription;
		public string MaintenanceDescription 
		{ 
			get { return _maintenanceDescription; }
			set 
			{ 
				_maintenanceDescription = value;  
				IsDirty = true;
			}
		} 
			
		protected string _wheel;
		public string Wheel 
		{ 
			get { return _wheel; }
			set 
			{ 
				_wheel = value;  
				IsDirty = true;
			}
		} 
			
		protected string _saddle;
		public string Saddle 
		{ 
			get { return _saddle; }
			set 
			{ 
				_saddle = value;  
				IsDirty = true;
			}
		} 
			
		protected string _pedal;
		public string Pedal 
		{ 
			get { return _pedal; }
			set 
			{ 
				_pedal = value;  
				IsDirty = true;
			}
		} 
			
		protected string _bikeFrame;
		public string BikeFrame 
		{ 
			get { return _bikeFrame; }
			set 
			{ 
				_bikeFrame = value;  
				IsDirty = true;
			}
		} 
			
		protected string _crankset;
		public string Crankset 
		{ 
			get { return _crankset; }
			set 
			{ 
				_crankset = value;  
				IsDirty = true;
			}
		} 
			
		protected string _pictureAngle;
		public string PictureAngle 
		{ 
			get { return _pictureAngle; }
			set 
			{ 
				_pictureAngle = value;  
				IsDirty = true;
			}
		} 
			
		protected string _pictureSize;
		public string PictureSize 
		{ 
			get { return _pictureSize; }
			set 
			{ 
				_pictureSize = value;  
				IsDirty = true;
			}
		} 
			
		protected string _productPhotoID;
		public string ProductPhotoID 
		{ 
			get { return _productPhotoID; }
			set 
			{ 
				_productPhotoID = value;  
				IsDirty = true;
			}
		} 
			
		protected string _material;
		public string Material 
		{ 
			get { return _material; }
			set 
			{ 
				_material = value;  
				IsDirty = true;
			}
		} 
			
		protected string _color;
		public string Color 
		{ 
			get { return _color; }
			set 
			{ 
				_color = value;  
				IsDirty = true;
			}
		} 
			
		protected string _productLine;
		public string ProductLine 
		{ 
			get { return _productLine; }
			set 
			{ 
				_productLine = value;  
				IsDirty = true;
			}
		} 
			
		protected string _style;
		public string Style 
		{ 
			get { return _style; }
			set 
			{ 
				_style = value;  
				IsDirty = true;
			}
		} 
			
		protected string _riderExperience;
		public string RiderExperience 
		{ 
			get { return _riderExperience; }
			set 
			{ 
				_riderExperience = value;  
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

		