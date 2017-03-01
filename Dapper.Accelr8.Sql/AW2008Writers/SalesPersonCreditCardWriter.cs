
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
    public class SalesPersonCreditCardWriter : EntityWriter<int, SalesPersonCreditCard>
    {
        public SalesPersonCreditCardWriter
			(SalesPersonCreditCardTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, SalesCreditCard> GetSalesCreditCardWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesCreditCard>>(); }
		static IEntityWriter<int, PersonPerson> GetPersonPersonWriter()
		{ return _locator.Resolve<IEntityWriter<int, PersonPerson>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesPersonCreditCard entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesPersonCreditCardColumnNames)f.Key)
                {
                    
					case SalesPersonCreditCardColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesPersonCreditCard entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_PersonCreditCard_CreditCard_CreditCardID
			var salesCreditCard169 = GetSalesCreditCardWriter();
		if ((_cascades.Contains(SalesPersonCreditCardCascadeNames.salescreditcard.ToString()) || _cascades.Contains("all")) && entity.SalesCreditCard != null)
			if (Cascade(salesCreditCard169, entity.SalesCreditCard, context))
				WithParent(salesCreditCard169, entity);

			//From Foreign Key FK_PersonCreditCard_Person_BusinessEntityID
			var personPerson170 = GetPersonPersonWriter();
		if ((_cascades.Contains(SalesPersonCreditCardCascadeNames.personperson.ToString()) || _cascades.Contains("all")) && entity.PersonPerson != null)
			if (Cascade(personPerson170, entity.PersonPerson, context))
				WithParent(personPerson170, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesPersonCreditCard entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_PersonCreditCard_CreditCard_CreditCardID
			if (entity.SalesCreditCard != null)
				entity.SalesPersonCreditCard = entity.SalesCreditCard.Id;

			//From Foreign Key FK_PersonCreditCard_Person_BusinessEntityID
			if (entity.PersonPerson != null)
				entity.SalesPersonCreditCard = entity.PersonPerson.Id;

		}

		protected override void RemoveRelations(SalesPersonCreditCard entity, ScriptContext context)
        {
				}
	}
}
		