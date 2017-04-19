
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
    public class PersonBusinessEntityAddressWriter : EntityWriter<CompoundKey, PersonBusinessEntityAddress>
    {
        public PersonBusinessEntityAddressWriter
			(PersonBusinessEntityAddressTableInfo tableInfo
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

		
		static IEntityWriter<int, PersonAddress> GetPersonAddressWriter()
		{ return s_loc8r.GetWriter<int, PersonAddress>(); }
		static IEntityWriter<int, PersonAddressType> GetPersonAddressTypeWriter()
		{ return s_loc8r.GetWriter<int, PersonAddressType>(); }
		static IEntityWriter<int, PersonBusinessEntity> GetPersonBusinessEntityWriter()
		{ return s_loc8r.GetWriter<int, PersonBusinessEntity>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonBusinessEntityAddress entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonBusinessEntityAddressFieldNames)f.Key)
                {
                    
					case PersonBusinessEntityAddressFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonBusinessEntityAddressFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonBusinessEntityAddress entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_BusinessEntityAddress_Address_AddressID
			var personAddress36 = GetPersonAddressWriter();
		if ((_cascades.Contains(PersonBusinessEntityAddressCascadeNames.personaddress_p.ToString()) || _cascades.Contains("all")) && entity.PersonAddress != null)
			if (Cascade(personAddress36, entity.PersonAddress, context))
				WithParent(personAddress36, entity);

			//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID
			var personAddressType37 = GetPersonAddressTypeWriter();
		if ((_cascades.Contains(PersonBusinessEntityAddressCascadeNames.personaddresstype_p.ToString()) || _cascades.Contains("all")) && entity.PersonAddressType != null)
			if (Cascade(personAddressType37, entity.PersonAddressType, context))
				WithParent(personAddressType37, entity);

			//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
			var personBusinessEntity38 = GetPersonBusinessEntityWriter();
		if ((_cascades.Contains(PersonBusinessEntityAddressCascadeNames.personbusinessentity_p.ToString()) || _cascades.Contains("all")) && entity.PersonBusinessEntity != null)
			if (Cascade(personBusinessEntity38, entity.PersonBusinessEntity, context))
				WithParent(personBusinessEntity38, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonBusinessEntityAddress entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_BusinessEntityAddress_Address_AddressID
			if (entity.PersonAddress != null)
				entity.AddressID = entity.PersonAddress.Id;

			//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID
			if (entity.PersonAddressType != null)
				entity.AddressTypeID = entity.PersonAddressType.Id;

			//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
			if (entity.PersonBusinessEntity != null)
				entity.BusinessEntityID = entity.PersonBusinessEntity.Id;

		}

		protected override void RemoveRelations(PersonBusinessEntityAddress entity, ScriptContext context)
        {
				}
	}
}
		