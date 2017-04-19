
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
    public class SalesSpecialOfferProductReader : EntityReader<CompoundKey, SalesSpecialOfferProduct>
    {
        public SalesSpecialOfferProductReader(
            SalesSpecialOfferProductTableInfo tableInfo
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

		//Child Count 1
		//Parent Count 2
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesSalesOrderDetail> GetSalesSalesOrderDetailReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesSalesOrderDetail>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSalesOrderDetail on the parent on SalesSalesOrderDetails.
		/// From foriegn key FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderDetails(IList<SalesSpecialOfferProduct> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesSalesOrderDetail

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderDetail>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesOrderDetails = typedChildren.Where(b =>  b.ProductID == r.ProductID  &&  b.SpecialOfferID == r.SpecialOfferID ).ToList();
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

			domain.SpecialOfferID = GetRowData<int>(dataRow, "SpecialOfferID"); 
      		domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.rowguid = GetRowData<Guid>(dataRow, "rowguid"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      				domain.Id = SalesSpecialOfferProduct.GetCompoundKeyFor(domain); 
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified CompoundKey Id.
		/// </summary>
		/// <param name="results">IEntityReader<CompoundKey, SalesSpecialOfferProduct></param>
		/// <param name="id">CompoundKey</param>
        public override IEntityReader<CompoundKey, SalesSpecialOfferProduct> WithAllChildrenForExisting(SalesSpecialOfferProduct existing)
        {
						WithChildForParentValues(GetSalesSalesOrderDetailReader()
				, new object[] {  existing.ProductID,  existing.SpecialOfferID,  } 
				, new string[] {  "ProductID",  "SpecialOfferID",  }
				, SetChildrenSalesSalesOrderDetails);
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesSpecialOfferProduct entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetSalesSalesOrderDetailReader()
				, new object[] {  entity.ProductID,  entity.SpecialOfferID,  } 
				, new string[] {  "ProductID",  "SpecialOfferID",  }
				, SetChildrenSalesSalesOrderDetails);

			
QueryResultForChildrenOnly(new List<SalesSpecialOfferProduct>() { entity });
			entity.Loaded = false;
			GetSalesSalesOrderDetailReader().SetAllChildrenForExisting(entity.SalesSalesOrderDetails);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSpecialOfferProduct> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetSalesSalesOrderDetailReader()
				, entities.Select(s => new object[] {  s.ProductID,  s.SpecialOfferID,  }).ToList() 
				, new string[] {  "ProductID",  "SpecialOfferID",  }
				, SetChildrenSalesSalesOrderDetails);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSalesOrderDetailReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderDetails).ToList());
					
		}
    }
}
		