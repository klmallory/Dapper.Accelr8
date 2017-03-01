
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
	public partial class SalesSalesTerritory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSalesTerritory()
		{			
			IsDirty = false; 
			_personStateProvinces = new List<PersonStateProvince>();
		_salesCustomers = new List<SalesCustomer>();
		_salesSalesOrderHeaders = new List<SalesSalesOrderHeader>();
		_salesSalesPeople = new List<SalesSalesPerson>();
		_salesSalesTerritoryHistories = new List<SalesSalesTerritoryHistory>();
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
			
		protected string _countryRegionCode;
		public string CountryRegionCode 
		{ 
			get { return _countryRegionCode; }
			set 
			{ 
				_countryRegionCode = value;  
				IsDirty = true;
			}
		} 
			
		protected string _group;
		public string Group 
		{ 
			get { return _group; }
			set 
			{ 
				_group = value;  
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
			
		protected decimal _costYTD;
		public decimal CostYTD 
		{ 
			get { return _costYTD; }
			set 
			{ 
				_costYTD = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _costLastYear;
		public decimal CostLastYear 
		{ 
			get { return _costLastYear; }
			set 
			{ 
				_costLastYear = value;  
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
		 
	//From Foreign Key FK_SalesTerritory_CountryRegion_CountryRegionCode	
		protected PersonCountryRegion _personCountryRegion;
		public virtual PersonCountryRegion PersonCountryRegion 
		{ 
			get { return _personCountryRegion; }
			set 
			{ 
				_personCountryRegion = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_StateProvince_SalesTerritory_TerritoryID	
		protected IList<PersonStateProvince> _personStateProvinces;
		public virtual IList<PersonStateProvince> PersonStateProvinces 
		{ 
			get { return _personStateProvinces; }
			set 
			{ 
				_personStateProvinces = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Customer_SalesTerritory_TerritoryID	
		protected IList<SalesCustomer> _salesCustomers;
		public virtual IList<SalesCustomer> SalesCustomers 
		{ 
			get { return _salesCustomers; }
			set 
			{ 
				_salesCustomers = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID	
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
			 
	//From Foreign Key FK_SalesPerson_SalesTerritory_TerritoryID	
		protected IList<SalesSalesPerson> _salesSalesPeople;
		public virtual IList<SalesSalesPerson> SalesSalesPeople 
		{ 
			get { return _salesSalesPeople; }
			set 
			{ 
				_salesSalesPeople = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesTerritoryHistory_SalesTerritory_TerritoryID	
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
					}
}

		