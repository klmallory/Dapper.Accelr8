
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
	public class SalesvStoreWithContact : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public SalesvStoreWithContact()
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
			
		protected object _contactType;
		public object ContactType 
		{ 
			get { return _contactType; }
			set 
			{ 
				_contactType = value;  
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
				}
}

		