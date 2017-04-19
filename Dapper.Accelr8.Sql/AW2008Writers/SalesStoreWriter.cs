
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
    public class SalesStoreWriter : EntityWriter<int, SalesStore>
    {
        public SalesStoreWriter
			(SalesStoreTableInfo tableInfo
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

		static IEntityWriter<int, SalesCustomer> GetSalesCustomerWriter()
		{ return s_loc8r.GetWriter<int, SalesCustomer>(); }
		
		static IEntityWriter<int, PersonBusinessEntity> GetPersonBusinessEntityWriter()
		{ return s_loc8r.GetWriter<int, PersonBusinessEntity>(); }
		static IEntityWriter<int, SalesSalesPerson> GetSalesSalesPersonWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesPerson>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesStore entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesStoreFieldNames)f.Key)
                {
                    
					case SalesStoreFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case SalesStoreFieldNames.SalesPersonID:
						parms.Add(GetParamName("SalesPersonID", actionType, taskIndex, ref count), entity.SalesPersonID);
						break;
					case SalesStoreFieldNames.Demographics:
						parms.Add(GetParamName("Demographics", actionType, taskIndex, ref count), entity.Demographics);
						break;
					case SalesStoreFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesStoreFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesStore entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Customer_Store_StoreID
			var salesCustomer405 = GetSalesCustomerWriter();
			if (_cascades.Contains(SalesStoreCascadeNames.salescustomers.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCustomers)
					Cascade(salesCustomer405, item, context);

			if (salesCustomer405.Count > 0)
				WithChild(salesCustomer405, entity);

		
		
			//From Foreign Key FK_Store_BusinessEntity_BusinessEntityID
			var personBusinessEntity406 = GetPersonBusinessEntityWriter();
		if ((_cascades.Contains(SalesStoreCascadeNames.personbusinessentity_p.ToString()) || _cascades.Contains("all")) && entity.PersonBusinessEntity != null)
			if (Cascade(personBusinessEntity406, entity.PersonBusinessEntity, context))
				WithParent(personBusinessEntity406, entity);

			//From Foreign Key FK_Store_SalesPerson_SalesPersonID
			var salesSalesPerson407 = GetSalesSalesPersonWriter();
		if ((_cascades.Contains(SalesStoreCascadeNames.salessalesperson_p.ToString()) || _cascades.Contains("all")) && entity.SalesSalesPerson != null)
			if (Cascade(salesSalesPerson407, entity.SalesSalesPerson, context))
				WithParent(salesSalesPerson407, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesStore entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_Customer_Store_StoreID
			if (entity.SalesCustomers != null && entity.SalesCustomers.Count > 0)
				foreach (var rel in entity.SalesCustomers)
					rel.StoreID = entity.Id;

				
			//From Foreign Key FK_Store_BusinessEntity_BusinessEntityID
			if (entity.PersonBusinessEntity != null)
				entity.BusinessEntityID = entity.PersonBusinessEntity.Id;

			//From Foreign Key FK_Store_SalesPerson_SalesPersonID
			if (entity.SalesSalesPerson != null)
				entity.SalesPersonID = entity.SalesSalesPerson.Id;

		}

		protected override void RemoveRelations(SalesStore entity, ScriptContext context)
        {
					//From Foreign Key FK_Customer_Store_StoreID
			var salesCustomer411 = GetSalesCustomerWriter();
			if (_cascades.Contains(SalesStoreCascadeNames.salescustomer.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCustomers)
					CascadeDelete(salesCustomer411, item, context);

			if (salesCustomer411.Count > 0)
				WithChild(salesCustomer411, entity);

				}
	}
}
		