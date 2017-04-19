
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
	public class ProductionProductDescription : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProductDescription()
		{
							
			IsDirty = false; 
			_productionProductModelProductDescriptionCultures = new List<ProductionProductModelProductDescriptionCulture>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected string _description;
		public string Description 
		{ 
			get { return _description; }
			set 
			{ 
				_description = value;  
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
		 
	//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID	
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

		