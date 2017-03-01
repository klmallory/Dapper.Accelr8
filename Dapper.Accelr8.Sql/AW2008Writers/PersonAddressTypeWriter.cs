
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
    public class PersonAddressTypeWriter : EntityWriter<int, PersonAddressType>
    {
        public PersonAddressTypeWriter
			(PersonAddressTypeTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, PersonBusinessEntityAddress> GetPersonBusinessEntityAddressWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonBusinessEntityAddress>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonAddressType entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonAddressTypeColumnNames)f.Key)
                {
                    
					case PersonAddressTypeColumnNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case PersonAddressTypeColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonAddressTypeColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonAddressType entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID
			var personBusinessEntityAddress12 = GetPersonBusinessEntityAddressWriter();
			if (_cascades.Contains(PersonAddressTypeCascadeNames.person.businessentityaddress.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityAddresses)
					Cascade(personBusinessEntityAddress12, item, context);

			if (personBusinessEntityAddress12.Count > 0)
				WithChild(personBusinessEntityAddress12, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonAddressType entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID
			if (entity.PersonBusinessEntityAddresses != null && entity.PersonBusinessEntityAddresses.Count > 0)
				foreach (var rel in entity.PersonBusinessEntityAddresses)
					rel.PersonBusinessEntityAddress = entity.Id;

				
		}

		protected override void RemoveRelations(PersonAddressType entity, ScriptContext context)
        {
					//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID
			var personBusinessEntityAddress14 = GetPersonBusinessEntityAddressWriter();
			if (_cascades.Contains(PersonAddressTypeCascadeNames.person.businessentityaddress.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityAddresses)
					CascadeDelete(personBusinessEntityAddress14, item, context);

			if (personBusinessEntityAddress14.Count > 0)
				WithChild(personBusinessEntityAddress14, entity);

				}
	}
}
		