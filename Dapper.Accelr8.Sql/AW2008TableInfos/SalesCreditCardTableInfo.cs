
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
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008TableInfos
{
	public enum SalesCreditCardFieldNames
	{	
		Id, 	
		CardType, 	
		CardNumber, 	
		ExpMonth, 	
		ExpYear, 	
		ModifiedDate, 	
	}

	public enum SalesCreditCardCascadeNames
	{	
		salessalesorderheaders, 	
		salespersoncreditcards, 	
		}

	public class SalesCreditCardTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesCreditCardColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesCreditCardFieldNames.Id, "CreditCardID" }, 
						{ (int)SalesCreditCardFieldNames.CardType, "CardType" }, 
						{ (int)SalesCreditCardFieldNames.CardNumber, "CardNumber" }, 
						{ (int)SalesCreditCardFieldNames.ExpMonth, "ExpMonth" }, 
						{ (int)SalesCreditCardFieldNames.ExpYear, "ExpYear" }, 
						{ (int)SalesCreditCardFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesCreditCardIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesCreditCardFieldNames.Id, "CreditCardID" }, 
				};

		public SalesCreditCardTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.CreditCard";
			TableAlias = "salescreditcard";
			Columns = SalesCreditCardColumnNames;
			IdColumns = SalesCreditCardIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		