
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
	public partial class PersonCountryRegion : Dapper.Accelr8.Repo.Domain.BaseEntity<string>
	{
			public PersonCountryRegion()
		{			
			IsDirty = false; 
			_personStateProvinces = new List<PersonStateProvince>();
		_salesCountryRegionCurrencies = new List<SalesCountryRegionCurrency>();
		_salesSalesTerritories = new List<SalesSalesTerritory>();
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
			 
	//From Foreign Key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode	
		protected IList<SalesCountryRegionCurrency> _salesCountryRegionCurrencies;
		public virtual IList<SalesCountryRegionCurrency> SalesCountryRegionCurrencies 
		{ 
			get { return _salesCountryRegionCurrencies; }
			set 
			{ 
				_salesCountryRegionCurrencies = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesTerritory_CountryRegion_CountryRegionCode	
		protected IList<SalesSalesTerritory> _salesSalesTerritories;
		public virtual IList<SalesSalesTerritory> SalesSalesTerritories 
		{ 
			get { return _salesSalesTerritories; }
			set 
			{ 
				_salesSalesTerritories = value;  
				IsDirty = true;
			}
		} 
					}
}

		