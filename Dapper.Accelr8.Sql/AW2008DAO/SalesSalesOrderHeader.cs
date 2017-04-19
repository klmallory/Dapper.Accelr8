
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
	public class SalesSalesOrderHeader : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesSalesOrderHeader()
		{
							
			IsDirty = false; 
			_salesSalesOrderDetails = new List<SalesSalesOrderDetail>();
		_salesSalesOrderHeaderSalesReasons = new List<SalesSalesOrderHeaderSalesReason>();
		_orderDate = (DateTime)SqlDateTime.MinValue;
		_dueDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected byte _revisionNumber;
		public byte RevisionNumber 
		{ 
			get { return _revisionNumber; }
			set 
			{ 
				_revisionNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _orderDate;
		public DateTime OrderDate 
		{ 
			get { return _orderDate; }
			set 
			{ 
				_orderDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _dueDate;
		public DateTime DueDate 
		{ 
			get { return _dueDate; }
			set 
			{ 
				_dueDate = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime? _shipDate;
		public DateTime? ShipDate 
		{ 
			get { return _shipDate; }
			set 
			{ 
				_shipDate = value;  
				IsDirty = true;
			}
		} 
			
		protected byte _status;
		public byte Status 
		{ 
			get { return _status; }
			set 
			{ 
				_status = value;  
				IsDirty = true;
			}
		} 
			
		protected object _onlineOrderFlag;
		public object OnlineOrderFlag 
		{ 
			get { return _onlineOrderFlag; }
			set 
			{ 
				_onlineOrderFlag = value;  
				IsDirty = true;
			}
		} 
			
		protected string _salesOrderNumber;
		public string SalesOrderNumber 
		{ 
			get { return _salesOrderNumber; }
			set 
			{ 
				_salesOrderNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected object _purchaseOrderNumber;
		public object PurchaseOrderNumber 
		{ 
			get { return _purchaseOrderNumber; }
			set 
			{ 
				_purchaseOrderNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected object _accountNumber;
		public object AccountNumber 
		{ 
			get { return _accountNumber; }
			set 
			{ 
				_accountNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected int _customerID;
		public int CustomerID 
		{ 
			get { return _customerID; }
			set 
			{ 
				_customerID = value;  
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
			
		protected int _billToAddressID;
		public int BillToAddressID 
		{ 
			get { return _billToAddressID; }
			set 
			{ 
				_billToAddressID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _shipToAddressID;
		public int ShipToAddressID 
		{ 
			get { return _shipToAddressID; }
			set 
			{ 
				_shipToAddressID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _shipMethodID;
		public int ShipMethodID 
		{ 
			get { return _shipMethodID; }
			set 
			{ 
				_shipMethodID = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _creditCardID;
		public int? CreditCardID 
		{ 
			get { return _creditCardID; }
			set 
			{ 
				_creditCardID = value;  
				IsDirty = true;
			}
		} 
			
		protected string _creditCardApprovalCode;
		public string CreditCardApprovalCode 
		{ 
			get { return _creditCardApprovalCode; }
			set 
			{ 
				_creditCardApprovalCode = value;  
				IsDirty = true;
			}
		} 
			
		protected int? _currencyRateID;
		public int? CurrencyRateID 
		{ 
			get { return _currencyRateID; }
			set 
			{ 
				_currencyRateID = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _subTotal;
		public decimal SubTotal 
		{ 
			get { return _subTotal; }
			set 
			{ 
				_subTotal = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _taxAmt;
		public decimal TaxAmt 
		{ 
			get { return _taxAmt; }
			set 
			{ 
				_taxAmt = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _freight;
		public decimal Freight 
		{ 
			get { return _freight; }
			set 
			{ 
				_freight = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _totalDue;
		public decimal TotalDue 
		{ 
			get { return _totalDue; }
			set 
			{ 
				_totalDue = value;  
				IsDirty = true;
			}
		} 
			
		protected string _comment;
		public string Comment 
		{ 
			get { return _comment; }
			set 
			{ 
				_comment = value;  
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
		 
	//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID	
		protected PersonAddress _personAddress1;
		public virtual PersonAddress PersonAddress1 
		{ 
			get { return _personAddress1; }
			set 
			{ 
				_personAddress1 = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID	
		protected PersonAddress _personAddress2;
		public virtual PersonAddress PersonAddress2 
		{ 
			get { return _personAddress2; }
			set 
			{ 
				_personAddress2 = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID	
		protected SalesCreditCard _salesCreditCard;
		public virtual SalesCreditCard SalesCreditCard 
		{ 
			get { return _salesCreditCard; }
			set 
			{ 
				_salesCreditCard = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID	
		protected SalesCurrencyRate _salesCurrencyRate;
		public virtual SalesCurrencyRate SalesCurrencyRate 
		{ 
			get { return _salesCurrencyRate; }
			set 
			{ 
				_salesCurrencyRate = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderHeader_Customer_CustomerID	
		protected SalesCustomer _salesCustomer;
		public virtual SalesCustomer SalesCustomer 
		{ 
			get { return _salesCustomer; }
			set 
			{ 
				_salesCustomer = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderHeader_SalesPerson_SalesPersonID	
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
		 
	//From Foreign Key FK_SalesOrderHeader_SalesTerritory_TerritoryID	
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
		 
	//From Foreign Key FK_SalesOrderHeader_ShipMethod_ShipMethodID	
		protected PurchasingShipMethod _purchasingShipMethod;
		public virtual PurchasingShipMethod PurchasingShipMethod 
		{ 
			get { return _purchasingShipMethod; }
			set 
			{ 
				_purchasingShipMethod = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID	
		protected IList<SalesSalesOrderDetail> _salesSalesOrderDetails;
		public virtual IList<SalesSalesOrderDetail> SalesSalesOrderDetails 
		{ 
			get { return _salesSalesOrderDetails; }
			set 
			{ 
				_salesSalesOrderDetails = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID	
		protected IList<SalesSalesOrderHeaderSalesReason> _salesSalesOrderHeaderSalesReasons;
		public virtual IList<SalesSalesOrderHeaderSalesReason> SalesSalesOrderHeaderSalesReasons 
		{ 
			get { return _salesSalesOrderHeaderSalesReasons; }
			set 
			{ 
				_salesSalesOrderHeaderSalesReasons = value;  
				IsDirty = true;
			}
		} 
					}
}

		