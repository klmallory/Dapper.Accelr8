
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
	public class PersonvAdditionalContactInfo : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonvAdditionalContactInfo()
		{
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
			
		protected string _telephoneNumber;
		public string TelephoneNumber 
		{ 
			get { return _telephoneNumber; }
			set 
			{ 
				_telephoneNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected string _telephoneSpecialInstructions;
		public string TelephoneSpecialInstructions 
		{ 
			get { return _telephoneSpecialInstructions; }
			set 
			{ 
				_telephoneSpecialInstructions = value;  
				IsDirty = true;
			}
		} 
			
		protected string _street;
		public string Street 
		{ 
			get { return _street; }
			set 
			{ 
				_street = value;  
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
			
		protected string _stateProvince;
		public string StateProvince 
		{ 
			get { return _stateProvince; }
			set 
			{ 
				_stateProvince = value;  
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
			
		protected string _countryRegion;
		public string CountryRegion 
		{ 
			get { return _countryRegion; }
			set 
			{ 
				_countryRegion = value;  
				IsDirty = true;
			}
		} 
			
		protected string _homeAddressSpecialInstructions;
		public string HomeAddressSpecialInstructions 
		{ 
			get { return _homeAddressSpecialInstructions; }
			set 
			{ 
				_homeAddressSpecialInstructions = value;  
				IsDirty = true;
			}
		} 
			
		protected string _eMailAddress;
		public string EMailAddress 
		{ 
			get { return _eMailAddress; }
			set 
			{ 
				_eMailAddress = value;  
				IsDirty = true;
			}
		} 
			
		protected string _eMailSpecialInstructions;
		public string EMailSpecialInstructions 
		{ 
			get { return _eMailSpecialInstructions; }
			set 
			{ 
				_eMailSpecialInstructions = value;  
				IsDirty = true;
			}
		} 
			
		protected string _eMailTelephoneNumber;
		public string EMailTelephoneNumber 
		{ 
			get { return _eMailTelephoneNumber; }
			set 
			{ 
				_eMailTelephoneNumber = value;  
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
				}
}

		