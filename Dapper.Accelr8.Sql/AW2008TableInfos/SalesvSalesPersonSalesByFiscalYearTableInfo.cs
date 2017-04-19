
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
	public enum SalesvSalesPersonSalesByFiscalYearFieldNames
	{	
		SalesPersonID, 	
		FullName, 	
		JobTitle, 	
		SalesTerritory, 	
		_N_2002, 	
		_N_2003, 	
		_N_2004, 	
	}

	public enum SalesvSalesPersonSalesByFiscalYearCascadeNames
	{	
		}

	public class SalesvSalesPersonSalesByFiscalYearTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesvSalesPersonSalesByFiscalYearColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesvSalesPersonSalesByFiscalYearFieldNames.SalesPersonID, "SalesPersonID" }, 
						{ (int)SalesvSalesPersonSalesByFiscalYearFieldNames.FullName, "FullName" }, 
						{ (int)SalesvSalesPersonSalesByFiscalYearFieldNames.JobTitle, "JobTitle" }, 
						{ (int)SalesvSalesPersonSalesByFiscalYearFieldNames.SalesTerritory, "SalesTerritory" }, 
						{ (int)SalesvSalesPersonSalesByFiscalYearFieldNames._N_2002, "2002" }, 
						{ (int)SalesvSalesPersonSalesByFiscalYearFieldNames._N_2003, "2003" }, 
						{ (int)SalesvSalesPersonSalesByFiscalYearFieldNames._N_2004, "2004" }, 
				};	

		public static readonly IDictionary<int, string> SalesvSalesPersonSalesByFiscalYearIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)SalesvSalesPersonSalesByFiscalYearFieldNames.SalesPersonID, "SalesPersonID" }, 
				};

		public SalesvSalesPersonSalesByFiscalYearTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "Sales";
			TableName = "Sales.vSalesPersonSalesByFiscalYears";
			TableAlias = "salesvsalespersonsalesbyfiscalyear";
			Columns = SalesvSalesPersonSalesByFiscalYearColumnNames;
			IdColumns = SalesvSalesPersonSalesByFiscalYearIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		