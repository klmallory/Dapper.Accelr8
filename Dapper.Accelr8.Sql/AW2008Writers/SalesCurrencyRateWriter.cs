
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
    public class SalesCurrencyRateWriter : EntityWriter<int, SalesCurrencyRate>
    {
        public SalesCurrencyRateWriter
			(SalesCurrencyRateTableInfo tableInfo
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

		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesOrderHeader>(); }
		
		static IEntityWriter<string, SalesCurrency> GetSalesCurrencyWriter()
		{ return s_loc8r.GetWriter<string, SalesCurrency>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesCurrencyRate entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesCurrencyRateFieldNames)f.Key)
                {
                    
					case SalesCurrencyRateFieldNames.CurrencyRateDate:
						parms.Add(GetParamName("CurrencyRateDate", actionType, taskIndex, ref count), entity.CurrencyRateDate);
						break;
					case SalesCurrencyRateFieldNames.FromCurrencyCode:
						parms.Add(GetParamName("FromCurrencyCode", actionType, taskIndex, ref count), entity.FromCurrencyCode);
						break;
					case SalesCurrencyRateFieldNames.ToCurrencyCode:
						parms.Add(GetParamName("ToCurrencyCode", actionType, taskIndex, ref count), entity.ToCurrencyCode);
						break;
					case SalesCurrencyRateFieldNames.AverageRate:
						parms.Add(GetParamName("AverageRate", actionType, taskIndex, ref count), entity.AverageRate);
						break;
					case SalesCurrencyRateFieldNames.EndOfDayRate:
						parms.Add(GetParamName("EndOfDayRate", actionType, taskIndex, ref count), entity.EndOfDayRate);
						break;
					case SalesCurrencyRateFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesCurrencyRate entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
			var salesSalesOrderHeader82 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesCurrencyRateCascadeNames.salessalesorderheaders.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					Cascade(salesSalesOrderHeader82, item, context);

			if (salesSalesOrderHeader82.Count > 0)
				WithChild(salesSalesOrderHeader82, entity);

		
		
			//From Foreign Key FK_CurrencyRate_Currency_FromCurrencyCode
			var salesCurrency83 = GetSalesCurrencyWriter();
		if ((_cascades.Contains(SalesCurrencyRateCascadeNames.salescurrency1_p.ToString()) || _cascades.Contains("all")) && entity.SalesCurrency1 != null)
			if (Cascade(salesCurrency83, entity.SalesCurrency1, context))
				WithParent(salesCurrency83, entity);

			//From Foreign Key FK_CurrencyRate_Currency_ToCurrencyCode
			var salesCurrency84 = GetSalesCurrencyWriter();
		if ((_cascades.Contains(SalesCurrencyRateCascadeNames.salescurrency2_p.ToString()) || _cascades.Contains("all")) && entity.SalesCurrency2 != null)
			if (Cascade(salesCurrency84, entity.SalesCurrency2, context))
				WithParent(salesCurrency84, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesCurrencyRate entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
			if (entity.SalesSalesOrderHeaders != null && entity.SalesSalesOrderHeaders.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaders)
					rel.CurrencyRateID = entity.Id;

				
			//From Foreign Key FK_CurrencyRate_Currency_FromCurrencyCode
			if (entity.SalesCurrency1 != null)
				entity.FromCurrencyCode = entity.SalesCurrency1.Id;

			//From Foreign Key FK_CurrencyRate_Currency_ToCurrencyCode
			if (entity.SalesCurrency2 != null)
				entity.ToCurrencyCode = entity.SalesCurrency2.Id;

		}

		protected override void RemoveRelations(SalesCurrencyRate entity, ScriptContext context)
        {
					//From Foreign Key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
			var salesSalesOrderHeader88 = GetSalesSalesOrderHeaderWriter();
			if (_cascades.Contains(SalesCurrencyRateCascadeNames.salessalesorderheader.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaders)
					CascadeDelete(salesSalesOrderHeader88, item, context);

			if (salesSalesOrderHeader88.Count > 0)
				WithChild(salesSalesOrderHeader88, entity);

				}
	}
}
		