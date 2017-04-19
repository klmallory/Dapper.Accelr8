
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
	public class PersonStateProvince : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonStateProvince()
		{
							
			IsDirty = false; 
			_personAddresses = new List<PersonAddress>();
		_salesSalesTaxRates = new List<SalesSalesTaxRate>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected string _stateProvinceCode;
		public string StateProvinceCode 
		{ 
			get { return _stateProvinceCode; }
			set 
			{ 
				_stateProvinceCode = value;  
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
			
		protected object _isOnlyStateProvinceFlag;
		public object IsOnlyStateProvinceFlag 
		{ 
			get { return _isOnlyStateProvinceFlag; }
			set 
			{ 
				_isOnlyStateProvinceFlag = value;  
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
			
		protected int _territoryID;
		public int TerritoryID 
		{ 
			get { return _territoryID; }
			set 
			{ 
				_territoryID = value;  
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
		 
	//From Foreign Key FK_StateProvince_CountryRegion_CountryRegionCode	
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
		 
	//From Foreign Key FK_Address_StateProvince_StateProvinceID	
		protected IList<PersonAddress> _personAddresses;
		public virtual IList<PersonAddress> PersonAddresses 
		{ 
			get { return _personAddresses; }
			set 
			{ 
				_personAddresses = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesTaxRate_StateProvince_StateProvinceID	
		protected IList<SalesSalesTaxRate> _salesSalesTaxRates;
		public virtual IList<SalesSalesTaxRate> SalesSalesTaxRates 
		{ 
			get { return _salesSalesTaxRates; }
			set 
			{ 
				_salesSalesTaxRates = value;  
				IsDirty = true;
			}
		} 
					}
}

		