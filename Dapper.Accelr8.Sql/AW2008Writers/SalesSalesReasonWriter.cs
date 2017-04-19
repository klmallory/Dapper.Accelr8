
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
    public class SalesSalesReasonWriter : EntityWriter<int, SalesSalesReason>
    {
        public SalesSalesReasonWriter
			(SalesSalesReasonTableInfo tableInfo
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

		static IEntityWriter<int, SalesSalesOrderHeaderSalesReason> GetSalesSalesOrderHeaderSalesReasonWriter()
		{ return s_loc8r.GetWriter<int, SalesSalesOrderHeaderSalesReason>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesReason entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesReasonFieldNames)f.Key)
                {
                    
					case SalesSalesReasonFieldNames.Name:
						parms.Add(GetParamName("Name", actionType, taskIndex, ref count), entity.Name);
						break;
					case SalesSalesReasonFieldNames.ReasonType:
						parms.Add(GetParamName("ReasonType", actionType, taskIndex, ref count), entity.ReasonType);
						break;
					case SalesSalesReasonFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesReason entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID
			var salesSalesOrderHeaderSalesReason342 = GetSalesSalesOrderHeaderSalesReasonWriter();
			if (_cascades.Contains(SalesSalesReasonCascadeNames.salessalesorderheadersalesreasons.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaderSalesReasons)
					Cascade(salesSalesOrderHeaderSalesReason342, item, context);

			if (salesSalesOrderHeaderSalesReason342.Count > 0)
				WithChild(salesSalesOrderHeaderSalesReason342, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesReason entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID
			if (entity.SalesSalesOrderHeaderSalesReasons != null && entity.SalesSalesOrderHeaderSalesReasons.Count > 0)
				foreach (var rel in entity.SalesSalesOrderHeaderSalesReasons)
					rel.SalesReasonID = entity.Id;

				
		}

		protected override void RemoveRelations(SalesSalesReason entity, ScriptContext context)
        {
					//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID
			var salesSalesOrderHeaderSalesReason344 = GetSalesSalesOrderHeaderSalesReasonWriter();
			if (_cascades.Contains(SalesSalesReasonCascadeNames.salessalesorderheadersalesreason.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSalesOrderHeaderSalesReasons)
					CascadeDelete(salesSalesOrderHeaderSalesReason344, item, context);

			if (salesSalesOrderHeaderSalesReason344.Count > 0)
				WithChild(salesSalesOrderHeaderSalesReason344, entity);

				}
	}
}
		