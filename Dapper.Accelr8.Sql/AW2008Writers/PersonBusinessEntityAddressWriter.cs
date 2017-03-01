
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
    public class PersonBusinessEntityAddressWriter : EntityWriter<int, PersonBusinessEntityAddress>
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

		}

		
		static IEntityWriter<int, PersonAddress> GetPersonAddressWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonAddress>>(); }
		static IEntityWriter<int, PersonAddressType> GetPersonAddressTypeWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonAddressType>>(); }
		static IEntityWriter<int, PersonBusinessEntity> GetPersonBusinessEntityWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonBusinessEntity>>(); }
		
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
                switch ((PersonBusinessEntityAddressColumnNames)f.Key)
                {
                    
					case PersonBusinessEntityAddressColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonBusinessEntityAddressColumnNames.ModifiedDate:
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
		if ((_cascades.Contains(PersonBusinessEntityAddressCascadeNames.personaddress.ToString()) || _cascades.Contains("all")) && entity.PersonAddress != null)
			if (Cascade(personAddress36, entity.PersonAddress, context))
				WithParent(personAddress36, entity);

			//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID
			var personAddressType37 = GetPersonAddressTypeWriter();
		if ((_cascades.Contains(PersonBusinessEntityAddressCascadeNames.personaddresstype.ToString()) || _cascades.Contains("all")) && entity.PersonAddressType != null)
			if (Cascade(personAddressType37, entity.PersonAddressType, context))
				WithParent(personAddressType37, entity);

			//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
			var personBusinessEntity38 = GetPersonBusinessEntityWriter();
		if ((_cascades.Contains(PersonBusinessEntityAddressCascadeNames.personbusinessentity.ToString()) || _cascades.Contains("all")) && entity.PersonBusinessEntity != null)
			if (Cascade(personBusinessEntity38, entity.PersonBusinessEntity, context))
				WithParent(personBusinessEntity38, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonBusinessEntityAddress entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_BusinessEntityAddress_Address_AddressID
			if (entity.PersonAddress != null)
				entity.PersonBusinessEntityAddress = entity.PersonAddress.Id;

			//From Foreign Key FK_BusinessEntityAddress_AddressType_AddressTypeID
			if (entity.PersonAddressType != null)
				entity.PersonBusinessEntityAddress = entity.PersonAddressType.Id;

			//From Foreign Key FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID
			if (entity.PersonBusinessEntity != null)
				entity.PersonBusinessEntityAddress = entity.PersonBusinessEntity.Id;

		}

		protected override void RemoveRelations(PersonBusinessEntityAddress entity, ScriptContext context)
        {
				}
	}
}
		