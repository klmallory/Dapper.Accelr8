
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
    public class PersonAddressWriter : EntityWriter<int, PersonAddress>
    {
        public PersonAddressWriter
			(PersonAddressTableInfo tableInfo
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
		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderHeader>>(); }
		
		static IEntityWriter<int, PersonStateProvince> GetPersonStateProvinceWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonStateProvince>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonAddress entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonAddressColumnNames)f.Key)
                {
                    
					case PersonAddressColumnNames.AddressLine1:
						parms.Add(GetParamName("AddressLine1", actionType, taskIndex, ref count), entity.AddressLine1);
						break;
					case PersonAddressColumnNames.AddressLine2:
						parms.Add(GetParamName("AddressLine2", actionType, taskIndex, ref count), entity.AddressLine2);
						break;
					case PersonAddressColumnNames.City:
						parms.Add(GetParamName("City", actionType, taskIndex, ref count), entity.City);
						break;
					case PersonAddressColumnNames.StateProvinceID:
						parms.Add(GetParamName("StateProvinceID", actionType, taskIndex, ref count), entity.StateProvinceID);
						break;
					case PersonAddressColumnNames.PostalCode:
						parms.Add(GetParamName("PostalCode", actionType, taskIndex, ref count), entity.PostalCode);
						break;
					case PersonAddressColumnNames.SpatialLocation:
						parms.Add(GetParamName("SpatialLocation", actionType, taskIndex, ref count), entity.SpatialLocation);
						break;
					case PersonAddressColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonAddressColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonAddress entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_BusinessEntityAddress_Address_AddressID
			var personBusinessEntityAddress1 = GetPersonBusinessEntityAddressWriter();
			if (_cascades.Contains(PersonAddressCascadeNames.person.businessentityaddress.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityAddresses)
					Cascade(personBusinessEntityAddress1, item, context);

			if (personBusinessEntityAddress1.Count > 0)
				WithChild(personBusinessEntityAddress1, entity);

			//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID
			var salesSalesOrderHeader2 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(PersonAddressCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					Cascade(salesSalesOrderHeader2, item, context);

			if (salesSalesOrderHeader2.Count > 0)
				WithChild(salesSalesOrderHeader2, entity);

			//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID
			var salesSalesOrderHeader3 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(PersonAddressCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					Cascade(salesSalesOrderHeader3, item, context);

			if (salesSalesOrderHeader3.Count > 0)
				WithChild(salesSalesOrderHeader3, entity);

		
		
			//From Foreign Key FK_Address_StateProvince_StateProvinceID
			var personStateProvince4 = GetPersonStateProvinceWriter();
		if ((_cascades.Contains(PersonAddressCascadeNames.personstateprovince.ToString()) || _cascades.Contains("all")) && entity.PersonStateProvince != null)
			if (Cascade(personStateProvince4, entity.PersonStateProvince, context))
				WithParent(personStateProvince4, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonAddress entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_BusinessEntityAddress_Address_AddressID
			if (entity.PersonBusinessEntityAddresses != null && entity.PersonBusinessEntityAddresses.Count > 0)
				foreach (var rel in entity.PersonBusinessEntityAddresses)
					rel.PersonBusinessEntityAddress = entity.Id;

			//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID
			if (entity.SalesSalesOrderHeaders != null && entity.SalesSalesOrderHeaders.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaders)
					rel.SalesSalesOrderHeader = entity.Id;

			//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID
			if (entity.SalesSalesOrderHeaders != null && entity.SalesSalesOrderHeaders.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaders)
					rel.SalesSalesOrderHeader = entity.Id;

				
			//From Foreign Key FK_Address_StateProvince_StateProvinceID
			if (entity.PersonStateProvince != null)
				entity.PersonAddress = entity.PersonStateProvince.Id;

		}

		protected override void RemoveRelations(PersonAddress entity, ScriptContext context)
        {
					//From Foreign Key FK_BusinessEntityAddress_Address_AddressID
			var personBusinessEntityAddress9 = GetPersonBusinessEntityAddressWriter();
			if (_cascades.Contains(PersonAddressCascadeNames.person.businessentityaddress.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityAddresses)
					CascadeDelete(personBusinessEntityAddress9, item, context);

			if (personBusinessEntityAddress9.Count > 0)
				WithChild(personBusinessEntityAddress9, entity);

					//From Foreign Key FK_SalesOrderHeader_Address_BillToAddressID
			var salesSalesOrderHeader10 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(PersonAddressCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					CascadeDelete(salesSalesOrderHeader10, item, context);

			if (salesSalesOrderHeader10.Count > 0)
				WithChild(salesSalesOrderHeader10, entity);

					//From Foreign Key FK_SalesOrderHeader_Address_ShipToAddressID
			var salesSalesOrderHeader11 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(PersonAddressCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					CascadeDelete(salesSalesOrderHeader11, item, context);

			if (salesSalesOrderHeader11.Count > 0)
				WithChild(salesSalesOrderHeader11, entity);

				}
	}
}
		