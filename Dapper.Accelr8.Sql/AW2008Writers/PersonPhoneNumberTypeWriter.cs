
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
    public class PersonPhoneNumberTypeWriter : EntityWriter<int, PersonPhoneNumberType>
    {
        public PersonPhoneNumberTypeWriter
			(PersonPhoneNumberTypeTableInfo tableInfo
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

		static IEntityWriter<int, PersonPersonPhone> GetPersonPersonPhoneWriter()
		{ return s_loc8r.GetWriter<int, PersonPersonPhone>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonPhoneNumberType entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonPhoneNumberTypeFieldNames)f.Key)
                {
                    
					case PersonPhoneNumberTypeFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case PersonPhoneNumberTypeFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonPhoneNumberType entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID
			var personPersonPhone177 = GetPersonPersonPhoneWriter();
			if (_cascades.Contains(PersonPhoneNumberTypeCascadeNames.personpersonphones.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonPersonPhones)
					Cascade(personPersonPhone177, item, context);

			if (personPersonPhone177.Count > 0)
				WithChild(personPersonPhone177, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonPhoneNumberType entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID
			if (entity.PersonPersonPhones != null && entity.PersonPersonPhones.Count > 0)
				foreach (var rel in entity.PersonPersonPhones)
					rel.PhoneNumberTypeID = entity.Id;

				
		}

		protected override void RemoveRelations(PersonPhoneNumberType entity, ScriptContext context)
        {
					//From Foreign Key FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID
			var personPersonPhone179 = GetPersonPersonPhoneWriter();
			if (_cascades.Contains(PersonPhoneNumberTypeCascadeNames.personpersonphone.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonPersonPhones)
					CascadeDelete(personPersonPhone179, item, context);

			if (personPersonPhone179.Count > 0)
				WithChild(personPersonPhone179, entity);

				}
	}
}
		