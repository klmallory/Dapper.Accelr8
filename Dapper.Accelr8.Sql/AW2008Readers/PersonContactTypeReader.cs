
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
    public class PersonContactTypeReader : EntityReader<int, PersonContactType>
    {
        public PersonContactTypeReader(
            PersonContactTypeTableInfo tableInfo
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

		//Child Count 1
		//Parent Count 0
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , PersonBusinessEntityContact> GetPersonBusinessEntityContactReader()
		{
			return s_loc8r.GetReader<CompoundKey , PersonBusinessEntityContact>();
		}

		
		/// <summary>
		/// Sets the children of type PersonBusinessEntityContact on the parent on PersonBusinessEntityContacts.
		/// From foriegn key FK_BusinessEntityContact_ContactType_ContactTypeID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityContacts(IList<PersonContactType> results, IList<object> children)
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
				

				r.PersonBusinessEntityContacts = typedChildren.Where(b =>  b.ContactTypeID == r.Id ).ToList();
				r.PersonBusinessEntityContacts.ToList().ForEach(b => { b.Loaded = false; b.PersonContactType = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Person.ContactType into class PersonContactType
		/// </summary>
		/// <param name="results">PersonContactType</param>
		/// <param name="row"></param>
        public override PersonContactType LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonContactType();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "ContactTypeID"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PersonContactType></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonContactType> WithAllChildrenForExisting(PersonContactType existing)
        {
						WithChildForParentValues(GetPersonBusinessEntityContactReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "ContactTypeID",  }
				, SetChildrenPersonBusinessEntityContacts);
			
            return this;
        }


        public override void SetAllChildrenForExisting(PersonContactType entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetPersonBusinessEntityContactReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "ContactTypeID",  }
				, SetChildrenPersonBusinessEntityContacts);

			
QueryResultForChildrenOnly(new List<PersonContactType>() { entity });
			entity.Loaded = false;
			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entity.PersonBusinessEntityContacts);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonContactType> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetPersonBusinessEntityContactReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "ContactTypeID",  }
				, SetChildrenPersonBusinessEntityContacts);

					
			QueryResultForChildrenOnly(entities);

			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityContacts).ToList());
					
		}
    }
}
		