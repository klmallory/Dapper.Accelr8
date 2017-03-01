
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
    public class SalesSalesReasonReader : EntityReader<int, SalesSalesReason>
    {
        public SalesSalesReasonReader(
            SalesSalesReasonTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , SalesSalesOrderHeaderSalesReason> _salesSalesOrderHeaderSalesReasonReader;
		protected static IEntityReader<int , SalesSalesOrderHeaderSalesReason> GetSalesSalesOrderHeaderSalesReasonReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesOrderHeaderSalesReason>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSalesOrderHeaderSalesReason on the parent on SalesSalesOrderHeaderSalesReasons.
		/// From foriegn key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaderSalesReasons(IList<SalesSalesReason> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesOrderHeaderSalesReason

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderHeaderSalesReason>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSalesOrderHeaderSalesReasons = typedChildren.Where(b => b.SalesSalesOrderHeaderSalesReason == r.Id).ToList();
				r.SalesSalesOrderHeaderSalesReasons.ToList().ForEach(b => { b.Loaded = false; b.SalesSalesReason = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.SalesReason into class SalesSalesReason
		/// </summary>
		/// <param name="results">SalesSalesReason</param>
		/// <param name="row"></param>
        public override SalesSalesReason LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesSalesReason();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ReasonType = GetRowData<object>(dataRow, "ReasonType"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesSalesReason></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesSalesReason> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesSalesOrderHeaderSalesReasonReader(), id, IdColumn, SetChildrenSalesSalesOrderHeaderSalesReasons);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesSalesReason entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesSalesOrderHeaderSalesReasonReader(), entity.Id
				, SalesSalesOrderHeaderSalesReasonColumnNames.SalesReasonID.ToString()
				, SetChildrenSalesSalesOrderHeaderSalesReasons);

			QueryResultForChildrenOnly(new List<SalesSalesReason>() { entity });
			entity.Loaded = false;
			GetSalesSalesOrderHeaderSalesReasonReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaderSalesReasons);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesSalesReason> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesSalesOrderHeaderSalesReasonReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderHeaderSalesReasonColumnNames.SalesReasonID.ToString()
				, SetChildrenSalesSalesOrderHeaderSalesReasons);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSalesOrderHeaderSalesReasonReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaderSalesReasons).ToList());
					
		}
    }
}
		