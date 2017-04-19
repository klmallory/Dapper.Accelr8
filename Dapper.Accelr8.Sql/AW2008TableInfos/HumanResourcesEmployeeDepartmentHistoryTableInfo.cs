
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
	public enum HumanResourcesEmployeeDepartmentHistoryFieldNames
	{	
		BusinessEntityID, 	
		DepartmentID, 	
		ShiftID, 	
		StartDate, 	
		EndDate, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesEmployeeDepartmentHistoryCascadeNames
	{	
		
		humanresourcesdepartment_p, 	
		humanresourcesemployee_p, 	
		humanresourcesshift_p, 	}

	public class HumanResourcesEmployeeDepartmentHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> HumanResourcesEmployeeDepartmentHistoryColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.DepartmentID, "DepartmentID" }, 
						{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.ShiftID, "ShiftID" }, 
						{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.StartDate, "StartDate" }, 
						{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.EndDate, "EndDate" }, 
						{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesEmployeeDepartmentHistoryIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.DepartmentID, "DepartmentID" }, 
						{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.ShiftID, "ShiftID" }, 
						{ (int)HumanResourcesEmployeeDepartmentHistoryFieldNames.StartDate, "StartDate" }, 
				};

		public HumanResourcesEmployeeDepartmentHistoryTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "HumanResources";
			TableName = "HumanResources.EmployeeDepartmentHistory";
			TableAlias = "humanresourcesemployeedepartmenthistory";
			Columns = HumanResourcesEmployeeDepartmentHistoryColumnNames;
			IdColumns = HumanResourcesEmployeeDepartmentHistoryIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_EmployeeDepartmentHistory_Department_DepartmentID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<short, HumanResourcesDepartment>("HumanResourcesDepartment")),
			TableName = "HumanResources.Department",
			Alias = TableAlias + "_" + "HumanResourcesDepartment",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<short, HumanResourcesDepartment>("HumanResourcesDepartment");
					var st = (entity as HumanResourcesEmployeeDepartmentHistory);

					if (st == null || row == null)
						return st;

					if (row.DepartmentID == null || row.DepartmentID == default(short))
						return st;

					st.HumanResourcesDepartment = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//HumanResourcesDepartmentColumnNames.   .ToString()
					//HumanResourcesEmployeeDepartmentHistoryColumnNames.      .ToString()
					JoinField = "DepartmentID",
					Operator = Operator.Equals,
					ParentField = "DepartmentID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_EmployeeDepartmentHistory_Employee_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee")),
			TableName = "HumanResources.Employee",
			Alias = TableAlias + "_" + "HumanResourcesEmployee",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee");
					var st = (entity as HumanResourcesEmployeeDepartmentHistory);

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
					//HumanResourcesEmployeeDepartmentHistoryColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_EmployeeDepartmentHistory_Shift_ShiftID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<byte, HumanResourcesShift>("HumanResourcesShift")),
			TableName = "HumanResources.Shift",
			Alias = TableAlias + "_" + "HumanResourcesShift",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<byte, HumanResourcesShift>("HumanResourcesShift");
					var st = (entity as HumanResourcesEmployeeDepartmentHistory);

					if (st == null || row == null)
						return st;

					if (row.ShiftID == null || row.ShiftID == default(byte))
						return st;

					st.HumanResourcesShift = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//HumanResourcesShiftColumnNames.   .ToString()
					//HumanResourcesEmployeeDepartmentHistoryColumnNames.      .ToString()
					JoinField = "ShiftID",
					Operator = Operator.Equals,
					ParentField = "ShiftID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		