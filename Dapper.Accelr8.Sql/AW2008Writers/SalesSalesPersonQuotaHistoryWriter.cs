
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
    public class SalesSalesPersonQuotaHistoryWriter : EntityWriter<int, SalesSalesPersonQuotaHistory>
    {
        public SalesSalesPersonQuotaHistoryWriter
			(SalesSalesPersonQuotaHistoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, SalesSalesPerson> GetSalesSalesPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesPerson>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesPersonQuotaHistory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesPersonQuotaHistoryColumnNames)f.Key)
                {
                    
					case SalesSalesPersonQuotaHistoryColumnNames.SalesQuota:
						parms.Add(GetParamName("SalesQuota", actionType, taskIndex, ref count), entity.SalesQuota);
						break;
					case SalesSalesPersonQuotaHistoryColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSalesPersonQuotaHistoryColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesPersonQuotaHistory entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID
			var salesSalesPerson340 = GetSalesSalesPersonWriter();
		if ((_cascades.Contains(SalesSalesPersonQuotaHistoryCascadeNames.salessalesperson.ToString()) || _cascades.Contains("all")) && entity.SalesSalesPerson != null)
			if (Cascade(salesSalesPerson340, entity.SalesSalesPerson, context))
				WithParent(salesSalesPerson340, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesPersonQuotaHistory entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID
			if (entity.SalesSalesPerson != null)
				entity.SalesSalesPersonQuotaHistory = entity.SalesSalesPerson.Id;

		}

		protected override void RemoveRelations(SalesSalesPersonQuotaHistory entity, ScriptContext context)
        {
				}
	}
}
		