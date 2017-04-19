
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
	public class SalesPersonCreditCard : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public SalesPersonCreditCard()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(SalesPersonCreditCard dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.BusinessEntityID,
							dao.CreditCardID,
						
				}
			};
		}

			
			protected int _businessEntityID;
		public int BusinessEntityID 
		{ 
			get { return _businessEntityID; }
			set 
			{ 
				_businessEntityID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected int _creditCardID;
		public int CreditCardID 
		{ 
			get { return _creditCardID; }
			set 
			{ 
				_creditCardID = value;
				this.Id = GetCompoundKeyFor(this);

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

		