
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
    public class PersonEmailAddressWriter : EntityWriter<int, PersonEmailAddress>
    {
        public PersonEmailAddressWriter
			(PersonEmailAddressTableInfo tableInfo
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
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonEmailAddress entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonEmailAddressColumnNames)f.Key)
                {
                    
					case PersonEmailAddressColumnNames.EmailAddress:
						parms.Add(GetParamName("EmailAddress", actionType, taskIndex, ref count), entity.EmailAddress);
						break;
					case PersonEmailAddressColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonEmailAddressColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonEmailAddress entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_EmailAddress_Person_BusinessEntityID
			var personPerson103 = GetPersonPersonWriter();
		if ((_cascades.Contains(PersonEmailAddressCascadeNames.personperson.ToString()) || _cascades.Contains("all")) && entity.PersonPerson != null)
			if (Cascade(personPerson103, entity.PersonPerson, context))
				WithParent(personPerson103, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonEmailAddress entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_EmailAddress_Person_BusinessEntityID
			if (entity.PersonPerson != null)
				entity.PersonEmailAddress = entity.PersonPerson.Id;

		}

		protected override void RemoveRelations(PersonEmailAddress entity, ScriptContext context)
        {
				}
	}
}
		