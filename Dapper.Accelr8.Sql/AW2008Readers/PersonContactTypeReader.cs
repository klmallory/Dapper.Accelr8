
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
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , PersonBusinessEntityContact> _personBusinessEntityContactReader;
		protected static IEntityReader<int , PersonBusinessEntityContact> GetPersonBusinessEntityContactReader()
		{
			return _locator.Resolve<IEntityReader<int , PersonBusinessEntityContact>>();
		}

		
		/// <summary>
		/// Sets the children of type PersonBusinessEntityContact on the parent on PersonBusinessEntityContacts.
		/// From foriegn key FK_BusinessEntityContact_ContactType_ContactTypeID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityContacts(IList<PersonContactType> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonBusinessEntityContact

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonBusinessEntityContact>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PersonBusinessEntityContacts = typedChildren.Where(b => b.PersonBusinessEntityContact == r.Id).ToList();
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

			domain.Id = GetRowData<int>(dataRow, IdColumn);
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
        public override IEntityReader<int, PersonContactType> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPersonBusinessEntityContactReader(), id, IdColumn, SetChildrenPersonBusinessEntityContacts);
			
            return this;
        }

        public override void SetAllChildrenForExisting(PersonContactType entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPersonBusinessEntityContactReader(), entity.Id
				, PersonBusinessEntityContactColumnNames.ContactTypeID.ToString()
				, SetChildrenPersonBusinessEntityContacts);

			QueryResultForChildrenOnly(new List<PersonContactType>() { entity });
			entity.Loaded = false;
			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entity.PersonBusinessEntityContacts);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonContactType> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPersonBusinessEntityContactReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PersonBusinessEntityContactColumnNames.ContactTypeID.ToString()
				, SetChildrenPersonBusinessEntityContacts);

					
			QueryResultForChildrenOnly(entities);

			GetPersonBusinessEntityContactReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityContacts).ToList());
					
		}
    }
}
		