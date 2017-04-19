
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
	public class SalesCurrencyRate : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesCurrencyRate()
		{
							
			IsDirty = false; 
			_salesSalesOrderHeaders = new List<SalesSalesOrderHeader>();
		_currencyRateDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected DateTime _currencyRateDate;
		public DateTime CurrencyRateDate 
		{ 
			get { return _currencyRateDate; }
			set 
			{ 
				_currencyRateDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _fromCurrencyCode;
		public string FromCurrencyCode 
		{ 
			get { return _fromCurrencyCode; }
			set 
			{ 
				_fromCurrencyCode = value;  
				IsDirty = true;
			}
		} 
			
		protected string _toCurrencyCode;
		public string ToCurrencyCode 
		{ 
			get { return _toCurrencyCode; }
			set 
			{ 
				_toCurrencyCode = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _averageRate;
		public decimal AverageRate 
		{ 
			get { return _averageRate; }
			set 
			{ 
				_averageRate = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _endOfDayRate;
		public decimal EndOfDayRate 
		{ 
			get { return _endOfDayRate; }
			set 
			{ 
				_endOfDayRate = value;  
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
		 
	//From Foreign Key FK_CurrencyRate_Currency_FromCurrencyCode	
		protected SalesCurrency _salesCurrency1;
		public virtual SalesCurrency SalesCurrency1 
		{ 
			get { return _salesCurrency1; }
			set 
			{ 
				_salesCurrency1 = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_CurrencyRate_Currency_ToCurrencyCode	
		protected SalesCurrency _salesCurrency2;
		public virtual SalesCurrency SalesCurrency2 
		{ 
			get { return _salesCurrency2; }
			set 
			{ 
				_salesCurrency2 = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID	
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
					}
}

		