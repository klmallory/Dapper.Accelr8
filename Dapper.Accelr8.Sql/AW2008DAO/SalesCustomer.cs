
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
	public class SalesCustomer : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesCustomer()
		{
							
			IsDirty = false; 
			_salesSalesOrderHeaders = new List<SalesSalesOrderHeader>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected int? _personID;
		public int? PersonID 
		{ 
			get { return _personID; }
			set 
			{ 
				_personID = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _storeID;
		public int? StoreID 
		{ 
			get { return _storeID; }
			set 
			{ 
				_storeID = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _territoryID;
		public int? TerritoryID 
		{ 
			get { return _territoryID; }
			set 
			{ 
				_territoryID = value;  
				IsDirty = true;
			}
		} 
			
		protected string _accountNumber;
		public string AccountNumber 
		{ 
			get { return _accountNumber; }
			set 
			{ 
				_accountNumber = value;  
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
		 
	//From Foreign Key FK_Customer_Store_StoreID	
		protected SalesStore _salesStore;
		public virtual SalesStore SalesStore 
		{ 
			get { return _salesStore; }
			set 
			{ 
				_salesStore = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Customer_Person_PersonID	
		protected PersonPerson _personPerson;
		public virtual PersonPerson PersonPerson 
		{ 
			get { return _personPerson; }
			set 
			{ 
				_personPerson = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Customer_SalesTerritory_TerritoryID	
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
		 
	//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID	
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

		