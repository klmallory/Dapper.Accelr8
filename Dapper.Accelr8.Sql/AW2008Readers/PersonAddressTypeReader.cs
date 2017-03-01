
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
    public class PersonAddressTypeReader : EntityReader<int, PersonAddressType>
    {
        public PersonAddressTypeReader(
            PersonAddressTypeTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , PersonBusinessEntityAddress> _personBusinessEntityAddressReader;
		protected static IEntityReader<int , PersonBusinessEntityAddress> GetPersonBusinessEntityAddressReader()
		{
			return _locator.Resolve<IEntityReader<int , PersonBusinessEntityAddress>>();
		}

		
		/// <summary>
		/// Sets the children of type PersonBusinessEntityAddress on the parent on PersonBusinessEntityAddresses.
		/// From foriegn key FK_BusinessEntityAddress_AddressType_AddressTypeID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonBusinessEntityAddresses(IList<PersonAddressType> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonBusinessEntityAddress

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonBusinessEntityAddress>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.PersonBusinessEntityAddresses = typedChildren.Where(b => b.PersonBusinessEntityAddress == r.Id).ToList();
				r.PersonBusinessEntityAddresses.ToList().ForEach(b => { b.Loaded = false; b.PersonAddressType = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Person.AddressType into class PersonAddressType
		/// </summary>
		/// <param name="results">PersonAddressType</param>
		/// <param name="row"></param>
        public override PersonAddressType LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonAddressType();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, PersonAddressType></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, PersonAddressType> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPersonBusinessEntityAddressReader(), id, IdColumn, SetChildrenPersonBusinessEntityAddresses);
			
            return this;
        }

        public override void SetAllChildrenForExisting(PersonAddressType entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPersonBusinessEntityAddressReader(), entity.Id
				, PersonBusinessEntityAddressColumnNames.AddressTypeID.ToString()
				, SetChildrenPersonBusinessEntityAddresses);

			QueryResultForChildrenOnly(new List<PersonAddressType>() { entity });
			entity.Loaded = false;
			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entity.PersonBusinessEntityAddresses);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonAddressType> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPersonBusinessEntityAddressReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), PersonBusinessEntityAddressColumnNames.AddressTypeID.ToString()
				, SetChildrenPersonBusinessEntityAddresses);

					
			QueryResultForChildrenOnly(entities);

			GetPersonBusinessEntityAddressReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonBusinessEntityAddresses).ToList());
					
		}
    }
}
		