
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
	public enum SalesCurrencyFieldNames
	{	
		Id, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum SalesCurrencyCascadeNames
	{	
		salescountryregioncurrencies, 	
		salescurrencyrates1, 	
		}

	public class SalesCurrencyTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesCurrencyColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesCurrencyFieldNames.Id, "CurrencyCode" }, 
						{ (int)SalesCurrencyFieldNames.Name, "Name" }, 
						{ (int)SalesCurrencyFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesCurrencyIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesCurrencyFieldNames.Id, "CurrencyCode" }, 
				};

		public SalesCurrencyTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.Currency";
			TableAlias = "salescurrency";
			Columns = SalesCurrencyColumnNames;
			IdColumns = SalesCurrencyIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		