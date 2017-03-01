
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
	public partial class SalesPersonCreditCard : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesPersonCreditCard()
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
		 
	//From Foreign Key FK_PersonCreditCard_CreditCard_CreditCardID	
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
		 
	//From Foreign Key FK_PersonCreditCard_Person_BusinessEntityID	
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
				}
}

		