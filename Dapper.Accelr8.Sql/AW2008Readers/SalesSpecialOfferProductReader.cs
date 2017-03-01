
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
    public class SalesSpecialOfferProductReader : EntityReader<int, SalesSpecialOfferProduct>
    {
        public SalesSpecialOfferProductReader(
            SalesSpecialOfferProductTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 2
		//Parent Count 2
		static IEntityReader<int , SalesSalesOrderDetail> _salesSalesOrderDetailReader;
		protected static IEntityReader<int , SalesSalesOrderDetail> GetSalesSalesOrderDetailReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesOrderDetail>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSalesOrderDetail on the parent on SalesSalesOrderDetails.
		/// From foriegn key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderDetails(IList<SalesSpecialOfferProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesOrderDetail

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderDetail>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSalesOrderDetails = typedChildren.Where(b => b.SalesSalesOrderDetail == r.Id).ToList();
				r.SalesSalesOrderDetails.ToList().ForEach(b => { b.Loaded = false; b.SalesSpecialOfferProduct = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesOrderDetail on the parent on SalesSalesOrderDetails.
		/// From foriegn key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderDetails(IList<SalesSpecialOfferProduct> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesOrderDetail

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderDetail>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSalesOrderDetails = typedChildren.Where(b => b.SalesSalesOrderDetail == r.Id).ToList();
				r.SalesSalesOrderDetails.ToList().ForEach(b => { b.Loaded = false; b.SalesSpecialOfferProduct = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.SpecialOfferProduct into class SalesSpecialOfferProduct
		/// </summary>
		/// <param name="results">SalesSpecialOfferProduct</param>
		/// <param name="row"></param>
        public override SalesSpecialOfferProduct LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSpecialOfferProduct();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSpecialOfferProduct></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSpecialOfferProduct> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesSalesOrderDetailReader(), id, IdColumn, SetChildrenSalesSalesOrderDetails);
			
			WithChildForParentId(GetSalesSalesOrderDetailReader(), id, IdColumn, SetChildrenSalesSalesOrderDetails);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesSpecialOfferProduct entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesSalesOrderDetailReader(), entity.Id
				, SalesSalesOrderDetailColumnNames.SpecialOfferID.ToString()
				, SetChildrenSalesSalesOrderDetails);

			WithChildForParentId(GetSalesSalesOrderDetailReader(), entity.Id
				, SalesSalesOrderDetailColumnNames.ProductID.ToString()
				, SetChildrenSalesSalesOrderDetails);

			QueryResultForChildrenOnly(new List<SalesSpecialOfferProduct>() { entity });
			entity.Loaded = false;
			GetSalesSalesOrderDetailReader().SetAllChildrenForExisting(entity.SalesSalesOrderDetails);
			GetSalesSalesOrderDetailReader().SetAllChildrenForExisting(entity.SalesSalesOrderDetails);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSpecialOfferProduct> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesSalesOrderDetailReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderDetailColumnNames.SpecialOfferID.ToString()
				, SetChildrenSalesSalesOrderDetails);

			WithChildForParentIds(GetSalesSalesOrderDetailReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderDetailColumnNames.ProductID.ToString()
				, SetChildrenSalesSalesOrderDetails);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSalesOrderDetailReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderDetails).ToList());
			GetSalesSalesOrderDetailReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderDetails).ToList());
					
		}
    }
}
		