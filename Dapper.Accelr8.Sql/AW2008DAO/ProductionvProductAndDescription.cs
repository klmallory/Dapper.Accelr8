
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
	public class ProductionvProductAndDescription : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionvProductAndDescription()
		{
							
			IsDirty = false; 
			}


	
		
		protected int _productID;
		public int ProductID 
		{ 
			get { return _productID; }
			set 
			{ 
				_productID = value;  
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
			
		protected object _productModel;
		public object ProductModel 
		{ 
			get { return _productModel; }
			set 
			{ 
				_productModel = value;  
				IsDirty = true;
			}
		} 
			
		protected string _cultureID;
		public string CultureID 
		{ 
			get { return _cultureID; }
			set 
			{ 
				_cultureID = value;  
				IsDirty = true;
			}
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
				}
}

		