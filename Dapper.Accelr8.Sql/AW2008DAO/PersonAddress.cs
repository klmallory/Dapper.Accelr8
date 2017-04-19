
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
	public class PersonAddress : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonAddress()
		{
							
			IsDirty = false; 
			_personBusinessEntityAddresses = new List<PersonBusinessEntityAddress>();
		_salesSalesOrderHeaders1 = new List<SalesSalesOrderHeader>();
		_salesSalesOrderHeaders2 = new List<SalesSalesOrderHeader>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
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
			
		protected object _spatialLocation;
		public object SpatialLocation 
		{ 
			get { return _spatialLocation; }
			set 
			{ 
				_spatialLocation = value;  
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
		 
	//From Foreign Key FK_Address_StateProvince_StateProvinceID	
		protected PersonStateProvince _personStateProvince;
		public virtual PersonStateProvince PersonStateProvince 
		{ 
			get { return _personStateProvince; }
			set 
			{ 
				_personStateProvince = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_BusinessEntityAddress_Address_AddressID	
		protected IList<PersonBusinessEntityAddress> _personBusinessEntityAddresses;
		public virtual IList<PersonBusinessEntityAddress> PersonBusinessEntityAddresses 
		{ 
			get { return _personBusinessEntityAddresses; }
			set 
			{ 
				_personBusinessEntityAddresses = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID	
		protected IList<SalesSalesOrderHeader> _salesSalesOrderHeaders1;
		public virtual IList<SalesSalesOrderHeader> SalesSalesOrderHeaders1 
		{ 
			get { return _salesSalesOrderHeaders1; }
			set 
			{ 
				_salesSalesOrderHeaders1 = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID	
		protected IList<SalesSalesOrderHeader> _salesSalesOrderHeaders2;
		public virtual IList<SalesSalesOrderHeader> SalesSalesOrderHeaders2 
		{ 
			get { return _salesSalesOrderHeaders2; }
			set 
			{ 
				_salesSalesOrderHeaders2 = value;  
				IsDirty = true;
			}
		} 
					}
}

		