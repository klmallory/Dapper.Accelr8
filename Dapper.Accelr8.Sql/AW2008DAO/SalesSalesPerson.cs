
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
	public class SalesSalesPerson : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSalesPerson()
		{
							
			IsDirty = false; 
			_salesSalesOrderHeaders = new List<SalesSalesOrderHeader>();
		_salesSalesPersonQuotaHistories = new List<SalesSalesPersonQuotaHistory>();
		_salesSalesTerritoryHistories = new List<SalesSalesTerritoryHistory>();
		_salesStores = new List<SalesStore>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected int? _territoryID;
		public int? TerritoryID 
		{ 
			get { return _territoryID; }
			set 
			{ 
				_territoryID = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal? _salesQuota;
		public decimal? SalesQuota 
		{ 
			get { return _salesQuota; }
			set 
			{ 
				_salesQuota = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _bonus;
		public decimal Bonus 
		{ 
			get { return _bonus; }
			set 
			{ 
				_bonus = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _commissionPct;
		public decimal CommissionPct 
		{ 
			get { return _commissionPct; }
			set 
			{ 
				_commissionPct = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _salesYTD;
		public decimal SalesYTD 
		{ 
			get { return _salesYTD; }
			set 
			{ 
				_salesYTD = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _salesLastYear;
		public decimal SalesLastYear 
		{ 
			get { return _salesLastYear; }
			set 
			{ 
				_salesLastYear = value;  
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
		 
	//From Foreign Key FK_SalesPerson_Employee_BusinessEntityID	
		protected HumanResourcesEmployee _humanResourcesEmployee;
		public virtual HumanResourcesEmployee HumanResourcesEmployee 
		{ 
			get { return _humanResourcesEmployee; }
			set 
			{ 
				_humanResourcesEmployee = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesPerson_SalesTerritory_TerritoryID	
		protected SalesSalesTerritory _salesSalesTerritory;
		public virtual SalesSalesTerritory SalesSalesTerritory 
		{ 
			get { return _salesSalesTerritory; }
			set 
			{ 
				_salesSalesTerritory = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID	
		protected IList<SalesSalesOrderHeader> _salesSalesOrderHeaders;
		public virtual IList<SalesSalesOrderHeader> SalesSalesOrderHeaders 
		{ 
			get { return _salesSalesOrderHeaders; }
			set 
			{ 
				_salesSalesOrderHeaders = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID	
		protected IList<SalesSalesPersonQuotaHistory> _salesSalesPersonQuotaHistories;
		public virtual IList<SalesSalesPersonQuotaHistory> SalesSalesPersonQuotaHistories 
		{ 
			get { return _salesSalesPersonQuotaHistories; }
			set 
			{ 
				_salesSalesPersonQuotaHistories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID	
		protected IList<SalesSalesTerritoryHistory> _salesSalesTerritoryHistories;
		public virtual IList<SalesSalesTerritoryHistory> SalesSalesTerritoryHistories 
		{ 
			get { return _salesSalesTerritoryHistories; }
			set 
			{ 
				_salesSalesTerritoryHistories = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Store_SalesPerson_SalesPersonID	
		protected IList<SalesStore> _salesStores;
		public virtual IList<SalesStore> SalesStores 
		{ 
			get { return _salesStores; }
			set 
			{ 
				_salesStores = value;  
				IsDirty = true;
			}
		} 
					}
}

		