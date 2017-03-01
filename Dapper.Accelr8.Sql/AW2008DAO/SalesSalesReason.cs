
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
	public partial class SalesSalesReason : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSalesReason()
		{			
			IsDirty = false; 
			_salesSalesOrderHeaderSalesReasons = new List<SalesSalesOrderHeaderSalesReason>();
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
			
		protected object _reasonType;
		public object ReasonType 
		{ 
			get { return _reasonType; }
			set 
			{ 
				_reasonType = value;  
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
		 
	//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID	
		protected IList<SalesSalesOrderHeaderSalesReason> _salesSalesOrderHeaderSalesReasons;
		public virtual IList<SalesSalesOrderHeaderSalesReason> SalesSalesOrderHeaderSalesReasons 
		{ 
			get { return _salesSalesOrderHeaderSalesReasons; }
			set 
			{ 
				_salesSalesOrderHeaderSalesReasons = value;  
				IsDirty = true;
			}
		} 
					}
}

		