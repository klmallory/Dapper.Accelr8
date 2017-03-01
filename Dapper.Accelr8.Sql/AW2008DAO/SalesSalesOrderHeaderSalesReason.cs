
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
	public partial class SalesSalesOrderHeaderSalesReason : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSalesOrderHeaderSalesReason()
		{			
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
		 
	//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID	
		protected SalesSalesOrderHeader _salesSalesOrderHeader;
		public virtual SalesSalesOrderHeader SalesSalesOrderHeader 
		{ 
			get { return _salesSalesOrderHeader; }
			set 
			{ 
				_salesSalesOrderHeader = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID	
		protected SalesSalesReason _salesSalesReason;
		public virtual SalesSalesReason SalesSalesReason 
		{ 
			get { return _salesSalesReason; }
			set 
			{ 
				_salesSalesReason = value;  
				IsDirty = true;
			}
		} 
				}
}

		