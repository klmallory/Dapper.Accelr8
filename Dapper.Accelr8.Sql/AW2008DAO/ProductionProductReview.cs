
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
	public partial class ProductionProductReview : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProductReview()
		{			
			IsDirty = false; 
			_reviewDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
			
		protected object _reviewerName;
		public object ReviewerName 
		{ 
			get { return _reviewerName; }
			set 
			{ 
				_reviewerName = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _reviewDate;
		public DateTime ReviewDate 
		{ 
			get { return _reviewDate; }
			set 
			{ 
				_reviewDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emailAddress;
		public string EmailAddress 
		{ 
			get { return _emailAddress; }
			set 
			{ 
				_emailAddress = value;  
				IsDirty = true;
			}
		} 
			
		protected int _rating;
		public int Rating 
		{ 
			get { return _rating; }
			set 
			{ 
				_rating = value;  
				IsDirty = true;
			}
		} 
			
		protected string _comments;
		public string Comments 
		{ 
			get { return _comments; }
			set 
			{ 
				_comments = value;  
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
		 
	//From Foreign Key FK_ProductReview_Product_ProductID	
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

		