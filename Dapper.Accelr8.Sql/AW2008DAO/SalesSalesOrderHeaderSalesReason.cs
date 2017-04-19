
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
	public class SalesSalesOrderHeaderSalesReason : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public SalesSalesOrderHeaderSalesReason()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(SalesSalesOrderHeaderSalesReason dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.SalesOrderID,
							dao.SalesReasonID,
						
				}
			};
		}

			
			protected int _salesOrderID;
		public int SalesOrderID 
		{ 
			get { return _salesOrderID; }
			set 
			{ 
				_salesOrderID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _salesReasonID;
		public int SalesReasonID 
		{ 
			get { return _salesReasonID; }
			set 
			{ 
				_salesReasonID = value;
				this.Id = GetCompoundKeyFor(this);

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

		