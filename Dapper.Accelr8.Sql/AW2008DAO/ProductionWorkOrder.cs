
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
	public partial class ProductionWorkOrder : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionWorkOrder()
		{			
			IsDirty = false; 
			_productionWorkOrderRoutings = new List<ProductionWorkOrderRouting>();
		_startDate = (DateTime)SqlDateTime.MinValue;
		_dueDate = (DateTime)SqlDateTime.MinValue;
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
			
		protected int _orderQty;
		public int OrderQty 
		{ 
			get { return _orderQty; }
			set 
			{ 
				_orderQty = value;  
				IsDirty = true;
			}
		} 
			
		protected int _stockedQty;
		public int StockedQty 
		{ 
			get { return _stockedQty; }
			set 
			{ 
				_stockedQty = value;  
				IsDirty = true;
			}
		} 
			
		protected short _scrappedQty;
		public short ScrappedQty 
		{ 
			get { return _scrappedQty; }
			set 
			{ 
				_scrappedQty = value;  
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
			
		protected DateTime _dueDate;
		public DateTime DueDate 
		{ 
			get { return _dueDate; }
			set 
			{ 
				_dueDate = value;  
				IsDirty = true;
			}
		} 
			
		protected short? _scrapReasonID;
		public short? ScrapReasonID 
		{ 
			get { return _scrapReasonID; }
			set 
			{ 
				_scrapReasonID = value;  
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
		 
	//From Foreign Key FK_WorkOrder_Product_ProductID	
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
		 
	//From Foreign Key FK_WorkOrder_ScrapReason_ScrapReasonID	
		protected ProductionScrapReason _productionScrapReason;
		public virtual ProductionScrapReason ProductionScrapReason 
		{ 
			get { return _productionScrapReason; }
			set 
			{ 
				_productionScrapReason = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_WorkOrderRouting_WorkOrder_WorkOrderID	
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

		