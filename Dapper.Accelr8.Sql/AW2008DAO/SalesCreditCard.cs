
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
	public class SalesCreditCard : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesCreditCard()
		{
							
			IsDirty = false; 
			_salesPersonCreditCards = new List<SalesPersonCreditCard>();
		_salesSalesOrderHeaders = new List<SalesSalesOrderHeader>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected string _cardType;
		public string CardType 
		{ 
			get { return _cardType; }
			set 
			{ 
				_cardType = value;  
				IsDirty = true;
			}
		} 
			
		protected string _cardNumber;
		public string CardNumber 
		{ 
			get { return _cardNumber; }
			set 
			{ 
				_cardNumber = value;  
				IsDirty = true;
			}
		} 
			
		protected byte _expMonth;
		public byte ExpMonth 
		{ 
			get { return _expMonth; }
			set 
			{ 
				_expMonth = value;  
				IsDirty = true;
			}
		} 
			
		protected short _expYear;
		public short ExpYear 
		{ 
			get { return _expYear; }
			set 
			{ 
				_expYear = value;  
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
		 
	//From Foreign Key FK_PersonCreditCard_CreditCard_CreditCardID	
		protected IList<SalesPersonCreditCard> _salesPersonCreditCards;
		public virtual IList<SalesPersonCreditCard> SalesPersonCreditCards 
		{ 
			get { return _salesPersonCreditCards; }
			set 
			{ 
				_salesPersonCreditCards = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID	
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

		