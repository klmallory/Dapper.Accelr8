
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
    public class PersonPhoneNumberTypeReader : EntityReader<int, PersonPhoneNumberType>
    {
        public PersonPhoneNumberTypeReader(
            PersonPhoneNumberTypeTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , PersonPersonPhone> _personPersonPhoneReader;
		protected static IEntityReader<int , PersonPersonPhone> GetPersonPersonPhoneReader()
		{
			return _locator.Resolve<IEntityReader<int , PersonPersonPhone>>();
		}

		
		/// <summary>
		/// Sets the children of type PersonPersonPhone on the parent on PersonPersonPhones.
		/// From foriegn key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonPersonPhones(IList<PersonPhoneNumberType> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonPersonPhone

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonPersonPhone>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PersonPersonPhones = typedChildren.Where(b => b.PersonPersonPhone == r.Id).ToList();
				r.PersonPersonPhones.ToList().ForEach(b => { b.Loaded = false; b.PersonPhoneNumberType = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Person.PhoneNumberType into class PersonPhoneNumberType
		/// </summary>
		/// <param name="results">PersonPhoneNumberType</param>
		/// <param name="row"></param>
        public override PersonPhoneNumberType LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonPhoneNumberType();
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
		/// <param name="results">IEntityReader<int, PersonPhoneNumberType></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonPhoneNumberType> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPersonPersonPhoneReader(), id, IdColumn, SetChildrenPersonPersonPhones);
			
            return this;
        }

        public override void SetAllChildrenForExisting(PersonPhoneNumberType entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPersonPersonPhoneReader(), entity.Id
				, PersonPersonPhoneColumnNames.PhoneNumberTypeID.ToString()
				, SetChildrenPersonPersonPhones);

			QueryResultForChildrenOnly(new List<PersonPhoneNumberType>() { entity });
			entity.Loaded = false;
			GetPersonPersonPhoneReader().SetAllChildrenForExisting(entity.PersonPersonPhones);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonPhoneNumberType> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPersonPersonPhoneReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PersonPersonPhoneColumnNames.PhoneNumberTypeID.ToString()
				, SetChildrenPersonPersonPhones);

					
			QueryResultForChildrenOnly(entities);

			GetPersonPersonPhoneReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonPersonPhones).ToList());
					
		}
    }
}
		