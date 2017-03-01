
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
	public partial class PersonPerson : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public PersonPerson()
		{			
			IsDirty = false; 
			_personBusinessEntityContacts = new List<PersonBusinessEntityContact>();
		_salesCustomers = new List<SalesCustomer>();
		_personEmailAddresses = new List<PersonEmailAddress>();
		_humanResourcesEmployees = new List<HumanResourcesEmployee>();
		_personPasswords = new List<PersonPassword>();
		_salesPersonCreditCards = new List<SalesPersonCreditCard>();
		_personPersonPhones = new List<PersonPersonPhone>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


		
		protected string _personType;
		public string PersonType 
		{ 
			get { return _personType; }
			set 
			{ 
				_personType = value;  
				IsDirty = true;
			}
		} 
			
		protected object _nameStyle;
		public object NameStyle 
		{ 
			get { return _nameStyle; }
			set 
			{ 
				_nameStyle = value;  
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
			
		protected string _additionalContactInfo;
		public string AdditionalContactInfo 
		{ 
			get { return _additionalContactInfo; }
			set 
			{ 
				_additionalContactInfo = value;  
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
		 
	//From Foreign Key FK_Person_BusinessEntity_BusinessEntityID	
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
		 
	//From Foreign Key FK_BusinessEntityContact_Person_PersonID	
		protected IList<PersonBusinessEntityContact> _personBusinessEntityContacts;
		public virtual IList<PersonBusinessEntityContact> PersonBusinessEntityContacts 
		{ 
			get { return _personBusinessEntityContacts; }
			set 
			{ 
				_personBusinessEntityContacts = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Customer_Person_PersonID	
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
			 
	//From Foreign Key FK_EmailAddress_Person_BusinessEntityID	
		protected IList<PersonEmailAddress> _personEmailAddresses;
		public virtual IList<PersonEmailAddress> PersonEmailAddresses 
		{ 
			get { return _personEmailAddresses; }
			set 
			{ 
				_personEmailAddresses = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Employee_Person_BusinessEntityID	
		protected IList<HumanResourcesEmployee> _humanResourcesEmployees;
		public virtual IList<HumanResourcesEmployee> HumanResourcesEmployees 
		{ 
			get { return _humanResourcesEmployees; }
			set 
			{ 
				_humanResourcesEmployees = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_Password_Person_BusinessEntityID	
		protected IList<PersonPassword> _personPasswords;
		public virtual IList<PersonPassword> PersonPasswords 
		{ 
			get { return _personPasswords; }
			set 
			{ 
				_personPasswords = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_PersonCreditCard_Person_BusinessEntityID	
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
			 
	//From Foreign Key FK_PersonPhone_Person_BusinessEntityID	
		protected IList<PersonPersonPhone> _personPersonPhones;
		public virtual IList<PersonPersonPhone> PersonPersonPhones 
		{ 
			get { return _personPersonPhones; }
			set 
			{ 
				_personPersonPhones = value;  
				IsDirty = true;
			}
		} 
					}
}

		