
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
    public class SalesCreditCardWriter : EntityWriter<int, SalesCreditCard>
    {
        public SalesCreditCardWriter
			(SalesCreditCardTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderHeader>>(); }
		static IEntityWriter<int, SalesPersonCreditCard> GetSalesPersonCreditCardWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesPersonCreditCard>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesCreditCard entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesCreditCardColumnNames)f.Key)
                {
                    
					case SalesCreditCardColumnNames.CardType:
						parms.Add(GetParamName("CardType", actionType, taskIndex, ref count), entity.CardType);
						break;
					case SalesCreditCardColumnNames.CardNumber:
						parms.Add(GetParamName("CardNumber", actionType, taskIndex, ref count), entity.CardNumber);
						break;
					case SalesCreditCardColumnNames.ExpMonth:
						parms.Add(GetParamName("ExpMonth", actionType, taskIndex, ref count), entity.ExpMonth);
						break;
					case SalesCreditCardColumnNames.ExpYear:
						parms.Add(GetParamName("ExpYear", actionType, taskIndex, ref count), entity.ExpYear);
						break;
					case SalesCreditCardColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesCreditCard entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID
			var salesSalesOrderHeader64 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesCreditCardCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					Cascade(salesSalesOrderHeader64, item, context);

			if (salesSalesOrderHeader64.Count > 0)
				WithChild(salesSalesOrderHeader64, entity);

			//From Foreign Key FK_PersonCreditCard_CreditCard_CreditCardID
			var salesPersonCreditCard65 = GetSalesPersonCreditCardWriter();
			if (_cascades.Contains(SalesCreditCardCascadeNames.sales.personcreditcard.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesPersonCreditCards)
					Cascade(salesPersonCreditCard65, item, context);

			if (salesPersonCreditCard65.Count > 0)
				WithChild(salesPersonCreditCard65, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesCreditCard entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID
			if (entity.SalesSalesOrderHeaders != null && entity.SalesSalesOrderHeaders.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaders)
					rel.SalesSalesOrderHeader = entity.Id;

			//From Foreign Key FK_PersonCreditCard_CreditCard_CreditCardID
			if (entity.SalesPersonCreditCards != null && entity.SalesPersonCreditCards.Count > 0)
				foreach (var rel in entity.SalesPersonCreditCards)
					rel.SalesPersonCreditCard = entity.Id;

				
		}

		protected override void RemoveRelations(SalesCreditCard entity, ScriptContext context)
        {
					//From Foreign Key FK_SalesOrderHeader_CreditCard_CreditCardID
			var salesSalesOrderHeader68 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesCreditCardCascadeNames.sales.salesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					CascadeDelete(salesSalesOrderHeader68, item, context);

			if (salesSalesOrderHeader68.Count > 0)
				WithChild(salesSalesOrderHeader68, entity);

					//From Foreign Key FK_PersonCreditCard_CreditCard_CreditCardID
			var salesPersonCreditCard69 = GetSalesPersonCreditCardWriter();
			if (_cascades.Contains(SalesCreditCardCascadeNames.sales.personcreditcard.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesPersonCreditCards)
					CascadeDelete(salesPersonCreditCard69, item, context);

			if (salesPersonCreditCard69.Count > 0)
				WithChild(salesPersonCreditCard69, entity);

				}
	}
}
		