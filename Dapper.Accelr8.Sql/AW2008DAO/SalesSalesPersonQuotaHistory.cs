
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
	public class SalesSalesPersonQuotaHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public SalesSalesPersonQuotaHistory()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(SalesSalesPersonQuotaHistory dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.QuotaDate,
						
				}
			};
		}

			
			protected int _businessEntityID;
		public int BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected DateTime _quotaDate;
		public DateTime QuotaDate 
		{ 
			get { return _quotaDate; }
			set 
			{ 
				_quotaDate = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
		
		
		protected decimal _salesQuota;
		public decimal SalesQuota 
		{ 
			get { return _salesQuota; }
			set 
			{ 
				_salesQuota = value;  
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
		 
	//From Foreign Key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID	
		protected SalesSalesPerson _salesSalesPerson;
		public virtual SalesSalesPerson SalesSalesPerson 
		{ 
			get { return _salesSalesPerson; }
			set 
			{ 
				_salesSalesPerson = value;  
				IsDirty = true;
			}
		} 
				}
}

		