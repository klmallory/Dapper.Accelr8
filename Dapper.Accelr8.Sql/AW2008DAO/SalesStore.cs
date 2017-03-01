
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
	public partial class SalesStore : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesStore()
		{			
			IsDirty = false; 
			_salesCustomers = new List<SalesCustomer>();
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
			
		protected int? _salesPersonID;
		public int? SalesPersonID 
		{ 
			get { return _salesPersonID; }
			set 
			{ 
				_salesPersonID = value;  
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
		 
	//From Foreign Key FK_Store_BusinessEntity_BusinessEntityID	
		protected PersonBusinessEntity _personBusinessEntity;
		public virtual PersonBusinessEntity PersonBusinessEntity 
		{ 
			get { return _personBusinessEntity; }
			set 
			{ 
				_personBusinessEntity = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Store_SalesPerson_SalesPersonID	
		protected SalesSalesPerson _salesSalesPerson;
		public virtual SalesSalesPerson SalesSalesPerson 
		{ 
			get { return _salesSalesPerson; }
			set 
			{ 
				_salesSalesPerson = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Customer_Store_StoreID	
		protected IList<SalesCustomer> _salesCustomers;
		public virtual IList<SalesCustomer> SalesCustomers 
		{ 
			get { return _salesCustomers; }
			set 
			{ 
				_salesCustomers = value;  
				IsDirty = true;
			}
		} 
					}
}

		