
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
    public class SalesSpecialOfferWriter : EntityWriter<int, SalesSpecialOffer>
    {
        public SalesSpecialOfferWriter
			(SalesSpecialOfferTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		static IEntityWriter<int, SalesSpecialOfferProduct> GetSalesSpecialOfferProductWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSpecialOfferProduct>>(); }
		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSpecialOffer entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSpecialOfferColumnNames)f.Key)
                {
                    
					case SalesSpecialOfferColumnNames.Description:
						parms.Add(GetParamName("Description", actionType, taskIndex, ref count), entity.Description);
						break;
					case SalesSpecialOfferColumnNames.DiscountPct:
						parms.Add(GetParamName("DiscountPct", actionType, taskIndex, ref count), entity.DiscountPct);
						break;
					case SalesSpecialOfferColumnNames.Type:
						parms.Add(GetParamName("Type", actionType, taskIndex, ref count), entity.Type);
						break;
					case SalesSpecialOfferColumnNames.Category:
						parms.Add(GetParamName("Category", actionType, taskIndex, ref count), entity.Category);
						break;
					case SalesSpecialOfferColumnNames.StartDate:
						parms.Add(GetParamName("StartDate", actionType, taskIndex, ref count), entity.StartDate);
						break;
					case SalesSpecialOfferColumnNames.EndDate:
						parms.Add(GetParamName("EndDate", actionType, taskIndex, ref count), entity.EndDate);
						break;
					case SalesSpecialOfferColumnNames.MinQty:
						parms.Add(GetParamName("MinQty", actionType, taskIndex, ref count), entity.MinQty);
						break;
					case SalesSpecialOfferColumnNames.MaxQty:
						parms.Add(GetParamName("MaxQty", actionType, taskIndex, ref count), entity.MaxQty);
						break;
					case SalesSpecialOfferColumnNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case SalesSpecialOfferColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSpecialOffer entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID
			var salesSpecialOfferProduct382 = GetSalesSpecialOfferProductWriter();
			if (_cascades.Contains(SalesSpecialOfferCascadeNames.sales.specialofferproduct.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSpecialOfferProducts)
					Cascade(salesSpecialOfferProduct382, item, context);

			if (salesSpecialOfferProduct382.Count > 0)
				WithChild(salesSpecialOfferProduct382, entity);

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSpecialOffer entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID
			if (entity.SalesSpecialOfferProducts != null && entity.SalesSpecialOfferProducts.Count > 0)
				foreach (var rel in entity.SalesSpecialOfferProducts)
					rel.SalesSpecialOfferProduct = entity.Id;

				
		}

		protected override void RemoveRelations(SalesSpecialOffer entity, ScriptContext context)
        {
					//From Foreign Key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID
			var salesSpecialOfferProduct384 = GetSalesSpecialOfferProductWriter();
			if (_cascades.Contains(SalesSpecialOfferCascadeNames.sales.specialofferproduct.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesSpecialOfferProducts)
					CascadeDelete(salesSpecialOfferProduct384, item, context);

			if (salesSpecialOfferProduct384.Count > 0)
				WithChild(salesSpecialOfferProduct384, entity);

				}
	}
}
		