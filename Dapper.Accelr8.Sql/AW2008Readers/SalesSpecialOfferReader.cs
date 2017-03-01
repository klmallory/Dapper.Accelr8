
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

namespace Dapper.Accelr8.AW2008Readers
{
    public class SalesSpecialOfferReader : EntityReader<int, SalesSpecialOffer>
    {
        public SalesSpecialOfferReader(
            SalesSpecialOfferTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , SalesSpecialOfferProduct> _salesSpecialOfferProductReader;
		protected static IEntityReader<int , SalesSpecialOfferProduct> GetSalesSpecialOfferProductReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSpecialOfferProduct>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSpecialOfferProduct on the parent on SalesSpecialOfferProducts.
		/// From foriegn key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSpecialOfferProducts(IList<SalesSpecialOffer> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSpecialOfferProduct

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSpecialOfferProduct>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSpecialOfferProducts = typedChildren.Where(b => b.SalesSpecialOfferProduct == r.Id).ToList();
				r.SalesSpecialOfferProducts.ToList().ForEach(b => { b.Loaded = false; b.SalesSpecialOffer = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.SpecialOffer into class SalesSpecialOffer
		/// </summary>
		/// <param name="results">SalesSpecialOffer</param>
		/// <param name="row"></param>
        public override SalesSpecialOffer LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSpecialOffer();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.Description = GetRowData<string>(dataRow, "Description"); 
      		domain.DiscountPct = GetRowData<decimal>(dataRow, "DiscountPct"); 
      		domain.Type = GetRowData<string>(dataRow, "Type"); 
      		domain.Category = GetRowData<string>(dataRow, "Category"); 
      		domain.StartDate = GetRowData<DateTime>(dataRow, "StartDate"); 
      		domain.EndDate = GetRowData<DateTime>(dataRow, "EndDate"); 
      		domain.MinQty = GetRowData<int>(dataRow, "MinQty"); 
      		domain.MaxQty = GetRowData<int?>(dataRow, "MaxQty"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSpecialOffer></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSpecialOffer> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesSpecialOfferProductReader(), id, IdColumn, SetChildrenSalesSpecialOfferProducts);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesSpecialOffer entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesSpecialOfferProductReader(), entity.Id
				, SalesSpecialOfferProductColumnNames.SpecialOfferID.ToString()
				, SetChildrenSalesSpecialOfferProducts);

			QueryResultForChildrenOnly(new List<SalesSpecialOffer>() { entity });
			entity.Loaded = false;
			GetSalesSpecialOfferProductReader().SetAllChildrenForExisting(entity.SalesSpecialOfferProducts);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSpecialOffer> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesSpecialOfferProductReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSpecialOfferProductColumnNames.SpecialOfferID.ToString()
				, SetChildrenSalesSpecialOfferProducts);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSpecialOfferProductReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSpecialOfferProducts).ToList());
					
		}
    }
}
		