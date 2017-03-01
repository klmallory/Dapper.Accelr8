
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
	public enum SalesCurrencyColumnNames
	{	
		CurrencyCode, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum SalesCurrencyCascadeNames
	{	
		salescountryregioncurrency, 	
		salescurrencyrate, 	
		}

	public class SalesCurrencyTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesCurrencyTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesCurrencyColumnNames.CurrencyCode.ToString();
			//Schema = "Sales.Currency";
			TableName = "Sales.Currency";
			TableAlias = "salescurrency";
			ColumnNames = typeof(SalesCurrencyColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		