
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
        {
			if (s_loc8r == null)
				s_loc8r = loc8r;		 
		}

		static ILoc8 s_loc8r = null;

		//Child Count 2
		//Parent Count 0
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesPersonCreditCard> GetSalesPersonCreditCardReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesPersonCreditCard>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return s_loc8r.GetReader<int , SalesSalesOrderHeader>();
		}

		
		/// <summary>
		/// Sets the children of type SalesPersonCreditCard on the parent on SalesPersonCreditCards.
		/// From foriegn key FK_PersonCreditCard_CreditCard_CreditCardID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesPersonCreditCards(IList<SalesCreditCard> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesPersonCreditCard

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesPersonCreditCard>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesPersonCreditCards = typedChildren.Where(b =>  b.CreditCardID == r.Id ).ToList();
				r.SalesPersonCreditCards.ToList().ForEach(b => { b.Loaded = false; b.SalesCreditCard = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
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
				

				r.SalesSalesOrderHeaders = typedChildren.Where(b =>  b.CreditCardID == r.Id ).ToList();
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.SalesCreditCard = r; b.Loaded = true; });
				
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

			domain.Id = GetRowData<int>(dataRow, "CreditCardID"); 
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
        public override IEntityReader<int, SalesCreditCard> WithAllChildrenForExisting(SalesCreditCard existing)
        {
						WithChildForParentValues(GetSalesPersonCreditCardReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "CreditCardID",  }
				, SetChildrenSalesPersonCreditCards);
						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "CreditCardID",  }
				, SetChildrenSalesSalesOrderHeaders);
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesCreditCard entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetSalesPersonCreditCardReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "CreditCardID",  }
				, SetChildrenSalesPersonCreditCards);

						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "CreditCardID",  }
				, SetChildrenSalesSalesOrderHeaders);

			
QueryResultForChildrenOnly(new List<SalesCreditCard>() { entity });
			entity.Loaded = false;
			GetSalesPersonCreditCardReader().SetAllChildrenForExisting(entity.SalesPersonCreditCards);
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesCreditCard> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetSalesPersonCreditCardReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "CreditCardID",  }
				, SetChildrenSalesPersonCreditCards);

			WithChildForParentsValues(GetSalesSalesOrderHeaderReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "CreditCardID",  }
				, SetChildrenSalesSalesOrderHeaders);

					
			QueryResultForChildrenOnly(entities);

			GetSalesPersonCreditCardReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesPersonCreditCards).ToList());
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
					
		}
    }
}
		