
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008Readers
{
    public class PersonPersonReader : EntityReader<int, PersonPerson>
    {
        public PersonPersonReader(
            PersonPersonTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 7
		//Parent Count 1
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PersonBusinessEntityContact> GetPersonBusinessEntityContactReader()
		{
			return s_loc8r.GetReader<CompoundKey , PersonBusinessEntityContact>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesCustomer> GetSalesCustomerReader()
		{
			return s_loc8r.GetReader<int , SalesCustomer>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PersonEmailAddress> GetPersonEmailAddressReader()
		{
			return s_loc8r.GetReader<CompoundKey , PersonEmailAddress>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , HumanResourcesEmployee> GetHumanResourcesEmployeeReader()
		{
			return s_loc8r.GetReader<int , HumanResourcesEmployee>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , PersonPassword> GetPersonPasswordReader()
		{
			return s_loc8r.GetReader<int , PersonPassword>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesPersonCreditCard> GetSalesPersonCreditCardReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesPersonCreditCard>();
		}

				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PersonPersonPhone> GetPersonPersonPhoneReader()
		{
			return s_loc8r.GetReader<CompoundKey , PersonPersonPhone>();
		}

		
		/// <summary>
		/// Sets the children of type PersonBusinessEntityContact on the parent on PersonBusinessEntityContacts.
		/// From foriegn key FK_BusinessEntityContact_Person_PersonID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityContacts(IList<PersonPerson> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: PersonBusinessEntityContact

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonBusinessEntityContact>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PersonBusinessEntityContacts = typedChildren.Where(b =>  b.PersonID == r.Id ).ToList();
				r.PersonBusinessEntityContacts.ToList().ForEach(b => { b.Loaded = false; b.PersonPerson = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesCustomer on the parent on SalesCustomers.
		/// From foriegn key FK_Customer_Person_PersonID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCustomers(IList<PersonPerson> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesCustomer

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCustomer>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesCustomers = typedChildren.Where(b =>  b.PersonID == r.Id ).ToList();
				r.SalesCustomers.ToList().ForEach(b => { b.Loaded = false; b.PersonPerson = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PersonEmailAddress on the parent on PersonEmailAddresses.
		/// From foriegn key FK_EmailAddress_Person_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonEmailAddresses(IList<PersonPerson> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: PersonEmailAddress

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonEmailAddress>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PersonEmailAddresses = typedChildren.Where(b =>  b.BusinessEntityID == r.Id ).ToList();
				r.PersonEmailAddresses.ToList().ForEach(b => { b.Loaded = false; b.PersonPerson = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type HumanResourcesEmployee on the parent on HumanResourcesEmployees.
		/// From foriegn key FK_Employee_Person_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenHumanResourcesEmployees(IList<PersonPerson> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: HumanResourcesEmployee

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<HumanResourcesEmployee>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.HumanResourcesEmployees = typedChildren.Where(b =>  b.Id == r.Id ).ToList();
				r.HumanResourcesEmployees.ToList().ForEach(b => { b.Loaded = false; b.PersonPerson = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PersonPassword on the parent on PersonPasswords.
		/// From foriegn key FK_Password_Person_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonPasswords(IList<PersonPerson> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonPassword

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonPassword>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PersonPasswords = typedChildren.Where(b =>  b.Id == r.Id ).ToList();
				r.PersonPasswords.ToList().ForEach(b => { b.Loaded = false; b.PersonPerson = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesPersonCreditCard on the parent on SalesPersonCreditCards.
		/// From foriegn key FK_PersonCreditCard_Person_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesPersonCreditCards(IList<PersonPerson> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesPersonCreditCard

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesPersonCreditCard>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesPersonCreditCards = typedChildren.Where(b =>  b.BusinessEntityID == r.Id ).ToList();
				r.SalesPersonCreditCards.ToList().ForEach(b => { b.Loaded = false; b.PersonPerson = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PersonPersonPhone on the parent on PersonPersonPhones.
		/// From foriegn key FK_PersonPhone_Person_BusinessEntityID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonPersonPhones(IList<PersonPerson> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: PersonPersonPhone

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonPersonPhone>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PersonPersonPhones = typedChildren.Where(b =>  b.BusinessEntityID == r.Id ).ToList();
				r.PersonPersonPhones.ToList().ForEach(b => { b.Loaded = false; b.PersonPerson = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Person.Person into class PersonPerson
		/// </summary>
		/// <param name="results">PersonPerson</param>
		/// <param name="row"></param>
        public override PersonPerson LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonPerson();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "BusinessEntityID"); 
      		domain.PersonType = GetRowData<string>(dataRow, "PersonType"); 
      		domain.NameStyle = GetRowData<object>(dataRow, "NameStyle"); 
      		domain.Title = GetRowData<string>(dataRow, "Title"); 
      		domain.FirstName = GetRowData<object>(dataRow, "FirstName"); 
      		domain.MiddleName = GetRowData<object>(dataRow, "MiddleName"); 
      		domain.LastName = GetRowData<object>(dataRow, "LastName"); 
      		domain.Suffix = GetRowData<string>(dataRow, "Suffix"); 
      		domain.EmailPromotion = GetRowData<int>(dataRow, "EmailPromotion"); 
      		domain.AdditionalContactInfo = GetRowData<string>(dataRow, "AdditionalContactInfo"); 
      		domain.Demographics = GetRowData<string>(dataRow, "Demographics"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PersonPerson></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonPerson> WithAllChildrenForExisting(PersonPerson existing)
        {
						WithChildForParentValues(GetPersonBusinessEntityContactReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "PersonID",  }
				, SetChildrenPersonBusinessEntityContacts);
						WithChildForParentValues(GetSalesCustomerReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "PersonID",  }
				, SetChildrenSalesCustomers);
						WithChildForParentValues(GetPersonEmailAddressReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonEmailAddresses);
						WithChildForParentValues(GetHumanResourcesEmployeeReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenHumanResourcesEmployees);
						WithChildForParentValues(GetPersonPasswordReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenPersonPasswords);
						WithChildForParentValues(GetSalesPersonCreditCardReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenSalesPersonCreditCards);
						WithChildForParentValues(GetPersonPersonPhoneReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonPersonPhones);
			
            return this;
        }


        public override void SetAllChildrenForExisting(PersonPerson entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetPersonBusinessEntityContactReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "PersonID",  }
				, SetChildrenPersonBusinessEntityContacts);

						WithChildForParentValues(GetSalesCustomerReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "PersonID",  }
				, SetChildrenSalesCustomers);

						WithChildForParentValues(GetPersonEmailAddressReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonEmailAddresses);

						WithChildForParentValues(GetHumanResourcesEmployeeReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenHumanResourcesEmployees);

						WithChildForParentValues(GetPersonPasswordReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "Id",  }
				, SetChildrenPersonPasswords);

						WithChildForParentValues(GetSalesPersonCreditCardReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenSalesPersonCreditCards);

						WithChildForParentValues(GetPersonPersonPhoneReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonPersonPhones);

			
QueryResultForChildrenOnly(new List<PersonPerson>() { entity });
			entity.Loaded = false;
			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entity.PersonBusinessEntityContacts);
			GetSalesCustomerReader().SetAllChildrenForExisting(entity.SalesCustomers);
			GetPersonEmailAddressReader().SetAllChildrenForExisting(entity.PersonEmailAddresses);
			GetHumanResourcesEmployeeReader().SetAllChildrenForExisting(entity.HumanResourcesEmployees);
			GetPersonPasswordReader().SetAllChildrenForExisting(entity.PersonPasswords);
			GetSalesPersonCreditCardReader().SetAllChildrenForExisting(entity.SalesPersonCreditCards);
			GetPersonPersonPhoneReader().SetAllChildrenForExisting(entity.PersonPersonPhones);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonPerson> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetPersonBusinessEntityContactReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "PersonID",  }
				, SetChildrenPersonBusinessEntityContacts);

			WithChildForParentsValues(GetSalesCustomerReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "PersonID",  }
				, SetChildrenSalesCustomers);

			WithChildForParentsValues(GetPersonEmailAddressReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonEmailAddresses);

			WithChildForParentsValues(GetHumanResourcesEmployeeReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "Id",  }
				, SetChildrenHumanResourcesEmployees);

			WithChildForParentsValues(GetPersonPasswordReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "Id",  }
				, SetChildrenPersonPasswords);

			WithChildForParentsValues(GetSalesPersonCreditCardReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenSalesPersonCreditCards);

			WithChildForParentsValues(GetPersonPersonPhoneReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "BusinessEntityID",  }
				, SetChildrenPersonPersonPhones);

					
			QueryResultForChildrenOnly(entities);

			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityContacts).ToList());
			GetSalesCustomerReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCustomers).ToList());
			GetPersonEmailAddressReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonEmailAddresses).ToList());
			GetHumanResourcesEmployeeReader().SetAllChildrenForExisting(entities.SelectMany(e => e.HumanResourcesEmployees).ToList());
			GetPersonPasswordReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonPasswords).ToList());
			GetSalesPersonCreditCardReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesPersonCreditCards).ToList());
			GetPersonPersonPhoneReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonPersonPhones).ToList());
					
		}
    }
}
		