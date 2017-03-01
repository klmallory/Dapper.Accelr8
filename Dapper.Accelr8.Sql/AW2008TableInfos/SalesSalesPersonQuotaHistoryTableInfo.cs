
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
	public enum SalesSalesPersonQuotaHistoryColumnNames
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
		public SalesSalesPersonQuotaHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesSalesPersonQuotaHistoryColumnNames.BusinessEntityID.ToString();
			//Schema = "Sales.SalesPersonQuotaHistory";
			TableName = "Sales.SalesPersonQuotaHistory";
			TableAlias = "salessalespersonquotahistory";
			ColumnNames = typeof(SalesSalesPersonQuotaHistoryColumnNames).ToDataList<Type, int>();

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

		