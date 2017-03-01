
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
	public partial class ProductionIllustration : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionIllustration()
		{			
			IsDirty = false; 
			_productionProductModelIllustrations = new List<ProductionProductModelIllustration>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected string _diagram;
		public string Diagram 
		{ 
			get { return _diagram; }
			set 
			{ 
				_diagram = value;  
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
		 
	//From Foreign Key FK_ProductModelIllustration_Illustration_IllustrationID	
		protected IList<ProductionProductModelIllustration> _productionProductModelIllustrations;
		public virtual IList<ProductionProductModelIllustration> ProductionProductModelIllustrations 
		{ 
			get { return _productionProductModelIllustrations; }
			set 
			{ 
				_productionProductModelIllustrations = value;  
				IsDirty = true;
			}
		} 
					}
}

		