
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
    public class PersonPasswordWriter : EntityWriter<int, PersonPassword>
    {
        public PersonPasswordWriter
			(PersonPasswordTableInfo tableInfo
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

		
		static IEntityWriter<int, PersonPerson> GetPersonPersonWriter()
		{ return s_loc8r.GetWriter<int, PersonPerson>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonPassword entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonPasswordFieldNames)f.Key)
                {
                    
					case PersonPasswordFieldNames.PasswordHash:
						parms.Add(GetParamName("PasswordHash", actionType, taskIndex, ref count), entity.PasswordHash);
						break;
					case PersonPasswordFieldNames.PasswordSalt:
						parms.Add(GetParamName("PasswordSalt", actionType, taskIndex, ref count), entity.PasswordSalt);
						break;
					case PersonPasswordFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonPasswordFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonPassword entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_Password_Person_BusinessEntityID
			var personPerson144 = GetPersonPersonWriter();
		if ((_cascades.Contains(PersonPasswordCascadeNames.personperson_p.ToString()) || _cascades.Contains("all")) && entity.PersonPerson != null)
			if (Cascade(personPerson144, entity.PersonPerson, context))
				WithParent(personPerson144, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonPassword entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_Password_Person_BusinessEntityID
			if (entity.PersonPerson != null)
				entity.BusinessEntityID = entity.PersonPerson.Id;

		}

		protected override void RemoveRelations(PersonPassword entity, ScriptContext context)
        {
				}
	}
}
		