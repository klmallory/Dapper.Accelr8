
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
	public class PersonvStateProvinceCountryRegion : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonvStateProvinceCountryRegion()
		{
							
			IsDirty = false; 
			}


	
		
		protected int _stateProvinceID;
		public int StateProvinceID 
		{ 
			get { return _stateProvinceID; }
			set 
			{ 
				_stateProvinceID = value;  
				IsDirty = true;
			}
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
			
		protected object _stateProvinceName;
		public object StateProvinceName 
		{ 
			get { return _stateProvinceName; }
			set 
			{ 
				_stateProvinceName = value;  
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
			
		protected object _countryRegionName;
		public object CountryRegionName 
		{ 
			get { return _countryRegionName; }
			set 
			{ 
				_countryRegionName = value;  
				IsDirty = true;
			}
		} 
				}
}

		