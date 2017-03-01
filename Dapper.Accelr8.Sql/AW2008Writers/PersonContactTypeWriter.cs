
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
    public class PersonContactTypeWriter : EntityWriter<int, PersonContactType>
    {
        public PersonContactTypeWriter
			(PersonContactTypeTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, PersonBusinessEntityContact> GetPersonBusinessEntityContactWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonBusinessEntityContact>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonContactType entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonContactTypeColumnNames)f.Key)
                {
                    
					case PersonContactTypeColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case PersonContactTypeColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonContactType entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_BusinessEntityContact_ContactType_ContactTypeID
			var personBusinessEntityContact48 = GetPersonBusinessEntityContactWriter();
			if (_cascades.Contains(PersonContactTypeCascadeNames.person.businessentitycontact.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityContacts)
					Cascade(personBusinessEntityContact48, item, context);

			if (personBusinessEntityContact48.Count > 0)
				WithChild(personBusinessEntityContact48, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonContactType entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_BusinessEntityContact_ContactType_ContactTypeID
			if (entity.PersonBusinessEntityContacts != null && entity.PersonBusinessEntityContacts.Count > 0)
				foreach (var rel in entity.PersonBusinessEntityContacts)
					rel.PersonBusinessEntityContact = entity.Id;

				
		}

		protected override void RemoveRelations(PersonContactType entity, ScriptContext context)
        {
					//From Foreign Key FK_BusinessEntityContact_ContactType_ContactTypeID
			var personBusinessEntityContact50 = GetPersonBusinessEntityContactWriter();
			if (_cascades.Contains(PersonContactTypeCascadeNames.person.businessentitycontact.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityContacts)
					CascadeDelete(personBusinessEntityContact50, item, context);

			if (personBusinessEntityContact50.Count > 0)
				WithChild(personBusinessEntityContact50, entity);

				}
	}
}
		