
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
	public partial class PurchasingvVendorWithAddress : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PurchasingvVendorWithAddress()
		{			
			IsDirty = false; 
			}


		
		protected int _businessEntityID;
		public int BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;  
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
			
		protected object _addressType;
		public object AddressType 
		{ 
			get { return _addressType; }
			set 
			{ 
				_addressType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _addressLine1;
		public string AddressLine1 
		{ 
			get { return _addressLine1; }
			set 
			{ 
				_addressLine1 = value;  
				IsDirty = true;
			}
		} 
			
		protected string _addressLine2;
		public string AddressLine2 
		{ 
			get { return _addressLine2; }
			set 
			{ 
				_addressLine2 = value;  
				IsDirty = true;
			}
		} 
			
		protected string _city;
		public string City 
		{ 
			get { return _city; }
			set 
			{ 
				_city = value;  
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
			
		protected string _postalCode;
		public string PostalCode 
		{ 
			get { return _postalCode; }
			set 
			{ 
				_postalCode = value;  
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

		