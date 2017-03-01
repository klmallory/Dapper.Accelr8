
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
	public enum SalesCreditCardColumnNames
	{	
		CreditCardID, 	
		CardType, 	
		CardNumber, 	
		ExpMonth, 	
		ExpYear, 	
		ModifiedDate, 	
	}

	public enum SalesCreditCardCascadeNames
	{	
		salessalesorderheader, 	
		salespersoncreditcard, 	
		}

	public class SalesCreditCardTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesCreditCardTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesCreditCardColumnNames.CreditCardID.ToString();
			//Schema = "Sales.CreditCard";
			TableName = "Sales.CreditCard";
			TableAlias = "salescreditcard";
			ColumnNames = typeof(SalesCreditCardColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		