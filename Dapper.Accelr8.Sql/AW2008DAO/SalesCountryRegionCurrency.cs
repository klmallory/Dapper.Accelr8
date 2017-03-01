
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
	public partial class SalesCountryRegionCurrency : Dapper.Accelr8.Repo.Domain.BaseEntity<string>
	{
			public SalesCountryRegionCurrency()
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
		 
	//From Foreign Key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode	
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
		 
	//From Foreign Key FK_CountryRegionCurrency_Currency_CurrencyCode	
		protected SalesCurrency _salesCurrency;
		public virtual SalesCurrency SalesCurrency 
		{ 
			get { return _salesCurrency; }
			set 
			{ 
				_salesCurrency = value;  
				IsDirty = true;
			}
		} 
				}
}

		