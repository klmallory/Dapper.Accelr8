
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
	public enum HumanResourcesEmployeePayHistoryFieldNames
	{	
		BusinessEntityID, 	
		RateChangeDate, 	
		Rate, 	
		PayFrequency, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesEmployeePayHistoryCascadeNames
	{	
		
		humanresourcesemployee_p, 	}

	public class HumanResourcesEmployeePayHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> HumanResourcesEmployeePayHistoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesEmployeePayHistoryFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesEmployeePayHistoryFieldNames.RateChangeDate, "RateChangeDate" }, 
						{ (int)HumanResourcesEmployeePayHistoryFieldNames.Rate, "Rate" }, 
						{ (int)HumanResourcesEmployeePayHistoryFieldNames.PayFrequency, "PayFrequency" }, 
						{ (int)HumanResourcesEmployeePayHistoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesEmployeePayHistoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesEmployeePayHistoryFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesEmployeePayHistoryFieldNames.RateChangeDate, "RateChangeDate" }, 
				};

		public HumanResourcesEmployeePayHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "HumanResources";
			TableName = "HumanResources.EmployeePayHistory";
			TableAlias = "humanresourcesemployeepayhistory";
			Columns = HumanResourcesEmployeePayHistoryColumnNames;
			IdColumns = HumanResourcesEmployeePayHistoryIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_EmployeePayHistory_Employee_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee")),
			TableName = "HumanResources.Employee",
			Alias = TableAlias + "_" + "HumanResourcesEmployee",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee");
					var st = (entity as HumanResourcesEmployeePayHistory);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.HumanResourcesEmployee = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//HumanResourcesEmployeeColumnNames.   .ToString()
					//HumanResourcesEmployeePayHistoryColumnNames.      .ToString()
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

		