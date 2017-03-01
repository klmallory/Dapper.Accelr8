
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
    public class SalesCreditCardReader : EntityReader<int, SalesCreditCard>
    {
        public SalesCreditCardReader(
            SalesCreditCardTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 2
		//Parent Count 0
		static IEntityReader<int , SalesSalesOrderHeader> _salesSalesOrderHeaderReader;
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesSalesOrderHeader>>();
		}

		static IEntityReader<int , SalesPersonCreditCard> _salesPersonCreditCardReader;
		protected static IEntityReader<int , SalesPersonCreditCard> GetSalesPersonCreditCardReader()
		{
			return _locator.Resolve<IEntityReader<int , SalesPersonCreditCard>>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_CreditCard_CreditCardID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders(IList<SalesCreditCard> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesOrderHeader

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderHeader>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesSalesOrderHeaders = typedChildren.Where(b => b.SalesSalesOrderHeader == r.Id).ToList();
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.SalesCreditCard = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesPersonCreditCard on the parent on SalesPersonCreditCards.
		/// From foriegn key FK_PersonCreditCard_CreditCard_CreditCardID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesPersonCreditCards(IList<SalesCreditCard> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesPersonCreditCard

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesPersonCreditCard>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.SalesPersonCreditCards = typedChildren.Where(b => b.SalesPersonCreditCard == r.Id).ToList();
				r.SalesPersonCreditCards.ToList().ForEach(b => { b.Loaded = false; b.SalesCreditCard = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.CreditCard into class SalesCreditCard
		/// </summary>
		/// <param name="results">SalesCreditCard</param>
		/// <param name="row"></param>
        public override SalesCreditCard LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesCreditCard();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.CardType = GetRowData<string>(dataRow, "CardType"); 
      		domain.CardNumber = GetRowData<string>(dataRow, "CardNumber"); 
      		domain.ExpMonth = GetRowData<byte>(dataRow, "ExpMonth"); 
      		domain.ExpYear = GetRowData<short>(dataRow, "ExpYear"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesCreditCard></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesCreditCard> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetSalesSalesOrderHeaderReader(), id, IdColumn, SetChildrenSalesSalesOrderHeaders);
			
			WithChildForParentId(GetSalesPersonCreditCardReader(), id, IdColumn, SetChildrenSalesPersonCreditCards);
			
            return this;
        }

        public override void SetAllChildrenForExisting(SalesCreditCard entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetSalesSalesOrderHeaderReader(), entity.Id
				, SalesSalesOrderHeaderColumnNames.CreditCardID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentId(GetSalesPersonCreditCardReader(), entity.Id
				, SalesPersonCreditCardColumnNames.CreditCardID.ToString()
				, SetChildrenSalesPersonCreditCards);

			QueryResultForChildrenOnly(new List<SalesCreditCard>() { entity });
			entity.Loaded = false;
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
			GetSalesPersonCreditCardReader().SetAllChildrenForExisting(entity.SalesPersonCreditCards);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesCreditCard> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetSalesSalesOrderHeaderReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesSalesOrderHeaderColumnNames.CreditCardID.ToString()
				, SetChildrenSalesSalesOrderHeaders);

			WithChildForParentIds(GetSalesPersonCreditCardReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), SalesPersonCreditCardColumnNames.CreditCardID.ToString()
				, SetChildrenSalesPersonCreditCards);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
			GetSalesPersonCreditCardReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesPersonCreditCards).ToList());
					
		}
    }
}
		