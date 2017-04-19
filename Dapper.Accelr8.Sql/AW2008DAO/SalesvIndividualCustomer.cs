
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
	public class SalesvIndividualCustomer : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesvIndividualCustomer()
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
			
		protected string _title;
		public string Title 
		{ 
			get { return _title; }
			set 
			{ 
				_title = value;  
				IsDirty = true;
			}
		} 
			
		protected object _firstName;
		public object FirstName 
		{ 
			get { return _firstName; }
			set 
			{ 
				_firstName = value;  
				IsDirty = true;
			}
		} 
			
		protected object _middleName;
		public object MiddleName 
		{ 
			get { return _middleName; }
			set 
			{ 
				_middleName = value;  
				IsDirty = true;
			}
		} 
			
		protected object _lastName;
		public object LastName 
		{ 
			get { return _lastName; }
			set 
			{ 
				_lastName = value;  
				IsDirty = true;
			}
		} 
			
		protected string _suffix;
		public string Suffix 
		{ 
			get { return _suffix; }
			set 
			{ 
				_suffix = value;  
				IsDirty = true;
			}
		} 
			
		protected object _phoneNumber;
		public object PhoneNumber 
		{ 
			get { return _phoneNumber; }
			set 
			{ 
				_phoneNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected object _phoneNumberType;
		public object PhoneNumberType 
		{ 
			get { return _phoneNumberType; }
			set 
			{ 
				_phoneNumberType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _emailAddress;
		public string EmailAddress 
		{ 
			get { return _emailAddress; }
			set 
			{ 
				_emailAddress = value;  
				IsDirty = true;
			}
		} 
			
		protected int _emailPromotion;
		public int EmailPromotion 
		{ 
			get { return _emailPromotion; }
			set 
			{ 
				_emailPromotion = value;  
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
			
		protected string _demographics;
		public string Demographics 
		{ 
			get { return _demographics; }
			set 
			{ 
				_demographics = value;  
				IsDirty = true;
			}
		} 
				}
}

		