
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
	public enum SalesSalesPersonQuotaHistoryFieldNames
	{	
		BusinessEntityID, 	
		QuotaDate, 	
		SalesQuota, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSalesPersonQuotaHistoryCascadeNames
	{	
		
		salessalesperson_p, 	}

	public class SalesSalesPersonQuotaHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSalesPersonQuotaHistoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesPersonQuotaHistoryFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesSalesPersonQuotaHistoryFieldNames.QuotaDate, "QuotaDate" }, 
						{ (int)SalesSalesPersonQuotaHistoryFieldNames.SalesQuota, "SalesQuota" }, 
						{ (int)SalesSalesPersonQuotaHistoryFieldNames.rowguid, "rowguid" }, 
						{ (int)SalesSalesPersonQuotaHistoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSalesPersonQuotaHistoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesPersonQuotaHistoryFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)SalesSalesPersonQuotaHistoryFieldNames.QuotaDate, "QuotaDate" }, 
				};

		public SalesSalesPersonQuotaHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SalesPersonQuotaHistory";
			TableAlias = "salessalespersonquotahistory";
			Columns = SalesSalesPersonQuotaHistoryColumnNames;
			IdColumns = SalesSalesPersonQuotaHistoryIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesPerson>("SalesSalesPerson")),
			TableName = "Sales.SalesPerson",
			Alias = TableAlias + "_" + "SalesSalesPerson",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesPerson>("SalesSalesPerson");
					var st = (entity as SalesSalesPersonQuotaHistory);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.SalesSalesPerson = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesPersonColumnNames.   .ToString()
					//SalesSalesPersonQuotaHistoryColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		