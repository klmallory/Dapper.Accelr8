
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
	public enum SalesvSalesPersonSalesByFiscalYearColumnNames
	{	
		SalesPersonID, 	
		FullName, 	
		JobTitle, 	
		SalesTerritory, 	
		_n_2002, 	
		_n_2003, 	
		_n_2004, 	
	}

	public enum SalesvSalesPersonSalesByFiscalYearCascadeNames
	{	
		}

	public class SalesvSalesPersonSalesByFiscalYearTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesvSalesPersonSalesByFiscalYearTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = SalesvSalesPersonSalesByFiscalYearColumnNames.SalesPersonID.ToString();
			//Schema = "Sales.vSalesPersonSalesByFiscalYears";
			TableName = "Sales.vSalesPersonSalesByFiscalYears";
			TableAlias = "salesvsalespersonsalesbyfiscalyear";
			ColumnNames = typeof(SalesvSalesPersonSalesByFiscalYearColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		