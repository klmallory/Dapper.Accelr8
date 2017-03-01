
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
	public partial class SalesCurrency : Dapper.Accelr8.Repo.Domain.BaseEntity<string>
	{
			public SalesCurrency()
		{			
			IsDirty = false; 
			_salesCountryRegionCurrencies = new List<SalesCountryRegionCurrency>();
		_salesCurrencyRates = new List<SalesCurrencyRate>();
		_salesCurrencyRates = new List<SalesCurrencyRate>();
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
		 
	//From Foreign Key FK_CountryRegionCurrency_Currency_CurrencyCode	
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
			 
	//From Foreign Key FK_CurrencyRate_Currency_FromCurrencyCode	
		protected IList<SalesCurrencyRate> _salesCurrencyRates;
		public virtual IList<SalesCurrencyRate> SalesCurrencyRates 
		{ 
			get { return _salesCurrencyRates; }
			set 
			{ 
				_salesCurrencyRates = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_CurrencyRate_Currency_ToCurrencyCode	
		protected IList<SalesCurrencyRate> _salesCurrencyRates;
		public virtual IList<SalesCurrencyRate> SalesCurrencyRates 
		{ 
			get { return _salesCurrencyRates; }
			set 
			{ 
				_salesCurrencyRates = value;  
				IsDirty = true;
			}
		} 
					}
}

		