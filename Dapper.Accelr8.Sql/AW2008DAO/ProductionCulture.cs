
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
	public partial class ProductionCulture : Dapper.Accelr8.Repo.Domain.BaseEntity<string>
	{
			public ProductionCulture()
		{			
			IsDirty = false; 
			_productionProductModelProductDescriptionCultures = new List<ProductionProductModelProductDescriptionCulture>();
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
		 
	//From Foreign Key FK_ProductModelProductDescriptionCulture_Culture_CultureID	
		protected IList<ProductionProductModelProductDescriptionCulture> _productionProductModelProductDescriptionCultures;
		public virtual IList<ProductionProductModelProductDescriptionCulture> ProductionProductModelProductDescriptionCultures 
		{ 
			get { return _productionProductModelProductDescriptionCultures; }
			set 
			{ 
				_productionProductModelProductDescriptionCultures = value;  
				IsDirty = true;
			}
		} 
					}
}

		