
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

namespace Dapper.Accelr8.AW2008Writers
{
    public class PersonBusinessEntityContactWriter : EntityWriter<int, PersonBusinessEntityContact>
    {
        public PersonBusinessEntityContactWriter
			(PersonBusinessEntityContactTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, PersonBusinessEntity> GetPersonBusinessEntityWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonBusinessEntity>>(); }
		static IEntityWriter<int, PersonContactType> GetPersonContactTypeWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonContactType>>(); }
		static IEntityWriter<int, PersonPerson> GetPersonPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonPerson>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonBusinessEntityContact entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonBusinessEntityContactColumnNames)f.Key)
                {
                    
					case PersonBusinessEntityContactColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonBusinessEntityContactColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonBusinessEntityContact entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID
			var personBusinessEntity42 = GetPersonBusinessEntityWriter();
		if ((_cascades.Contains(PersonBusinessEntityContactCascadeNames.personbusinessentity.ToString()) || _cascades.Contains("all")) && entity.PersonBusinessEntity != null)
			if (Cascade(personBusinessEntity42, entity.PersonBusinessEntity, context))
				WithParent(personBusinessEntity42, entity);

			//From Foreign Key FK_BusinessEntityContact_ContactType_ContactTypeID
			var personContactType43 = GetPersonContactTypeWriter();
		if ((_cascades.Contains(PersonBusinessEntityContactCascadeNames.personcontacttype.ToString()) || _cascades.Contains("all")) && entity.PersonContactType != null)
			if (Cascade(personContactType43, entity.PersonContactType, context))
				WithParent(personContactType43, entity);

			//From Foreign Key FK_BusinessEntityContact_Person_PersonID
			var personPerson44 = GetPersonPersonWriter();
		if ((_cascades.Contains(PersonBusinessEntityContactCascadeNames.personperson.ToString()) || _cascades.Contains("all")) && entity.PersonPerson != null)
			if (Cascade(personPerson44, entity.PersonPerson, context))
				WithParent(personPerson44, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonBusinessEntityContact entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_BusinessEntityContact_BusinessEntity_BusinessEntityID
			if (entity.PersonBusinessEntity != null)
				entity.PersonBusinessEntityContact = entity.PersonBusinessEntity.Id;

			//From Foreign Key FK_BusinessEntityContact_ContactType_ContactTypeID
			if (entity.PersonContactType != null)
				entity.PersonBusinessEntityContact = entity.PersonContactType.Id;

			//From Foreign Key FK_BusinessEntityContact_Person_PersonID
			if (entity.PersonPerson != null)
				entity.PersonBusinessEntityContact = entity.PersonPerson.Id;

		}

		protected override void RemoveRelations(PersonBusinessEntityContact entity, ScriptContext context)
        {
				}
	}
}
		