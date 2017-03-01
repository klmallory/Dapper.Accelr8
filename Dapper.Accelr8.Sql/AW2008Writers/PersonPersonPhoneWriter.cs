
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
    public class PersonPersonPhoneWriter : EntityWriter<int, PersonPersonPhone>
    {
        public PersonPersonPhoneWriter
			(PersonPersonPhoneTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, PersonPerson> GetPersonPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonPerson>>(); }
		static IEntityWriter<int, PersonPhoneNumberType> GetPersonPhoneNumberTypeWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonPhoneNumberType>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonPersonPhone entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonPersonPhoneColumnNames)f.Key)
                {
                    
					case PersonPersonPhoneColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonPersonPhone entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_PersonPhone_Person_BusinessEntityID
			var personPerson173 = GetPersonPersonWriter();
		if ((_cascades.Contains(PersonPersonPhoneCascadeNames.personperson.ToString()) || _cascades.Contains("all")) && entity.PersonPerson != null)
			if (Cascade(personPerson173, entity.PersonPerson, context))
				WithParent(personPerson173, entity);

			//From Foreign Key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID
			var personPhoneNumberType174 = GetPersonPhoneNumberTypeWriter();
		if ((_cascades.Contains(PersonPersonPhoneCascadeNames.personphonenumbertype.ToString()) || _cascades.Contains("all")) && entity.PersonPhoneNumberType != null)
			if (Cascade(personPhoneNumberType174, entity.PersonPhoneNumberType, context))
				WithParent(personPhoneNumberType174, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonPersonPhone entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_PersonPhone_Person_BusinessEntityID
			if (entity.PersonPerson != null)
				entity.PersonPersonPhone = entity.PersonPerson.Id;

			//From Foreign Key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID
			if (entity.PersonPhoneNumberType != null)
				entity.PersonPersonPhone = entity.PersonPhoneNumberType.Id;

		}

		protected override void RemoveRelations(PersonPersonPhone entity, ScriptContext context)
        {
				}
	}
}
		