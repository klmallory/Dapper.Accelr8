
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
	public enum HumanResourcesEmployeeFieldNames
	{	
		Id, 	
		NationalIDNumber, 	
		LoginID, 	
		OrganizationNode, 	
		OrganizationLevel, 	
		JobTitle, 	
		BirthDate, 	
		MaritalStatus, 	
		Gender, 	
		HireDate, 	
		SalariedFlag, 	
		VacationHours, 	
		SickLeaveHours, 	
		CurrentFlag, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesEmployeeCascadeNames
	{	
		purchasingpurchaseorderheaders, 	
		productiondocuments, 	
		humanresourcesemployeedepartmenthistories, 	
		humanresourcesemployeepayhistories, 	
		salessalespeople, 	
		humanresourcesjobcandidates, 	
		
		personperson_p, 	}

	public class HumanResourcesEmployeeTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> HumanResourcesEmployeeColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesEmployeeFieldNames.Id, "BusinessEntityID" }, 
						{ (int)HumanResourcesEmployeeFieldNames.NationalIDNumber, "NationalIDNumber" }, 
						{ (int)HumanResourcesEmployeeFieldNames.LoginID, "LoginID" }, 
						{ (int)HumanResourcesEmployeeFieldNames.OrganizationNode, "OrganizationNode" }, 
						{ (int)HumanResourcesEmployeeFieldNames.OrganizationLevel, "OrganizationLevel" }, 
						{ (int)HumanResourcesEmployeeFieldNames.JobTitle, "JobTitle" }, 
						{ (int)HumanResourcesEmployeeFieldNames.BirthDate, "BirthDate" }, 
						{ (int)HumanResourcesEmployeeFieldNames.MaritalStatus, "MaritalStatus" }, 
						{ (int)HumanResourcesEmployeeFieldNames.Gender, "Gender" }, 
						{ (int)HumanResourcesEmployeeFieldNames.HireDate, "HireDate" }, 
						{ (int)HumanResourcesEmployeeFieldNames.SalariedFlag, "SalariedFlag" }, 
						{ (int)HumanResourcesEmployeeFieldNames.VacationHours, "VacationHours" }, 
						{ (int)HumanResourcesEmployeeFieldNames.SickLeaveHours, "SickLeaveHours" }, 
						{ (int)HumanResourcesEmployeeFieldNames.CurrentFlag, "CurrentFlag" }, 
						{ (int)HumanResourcesEmployeeFieldNames.rowguid, "rowguid" }, 
						{ (int)HumanResourcesEmployeeFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesEmployeeIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesEmployeeFieldNames.Id, "BusinessEntityID" }, 
				};

		public HumanResourcesEmployeeTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "HumanResources";
			TableName = "HumanResources.Employee";
			TableAlias = "humanresourcesemployee";
			Columns = HumanResourcesEmployeeColumnNames;
			IdColumns = HumanResourcesEmployeeIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_Employee_Person_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonPerson>("PersonPerson")),
			TableName = "Person.Person",
			Alias = TableAlias + "_" + "PersonPerson",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonPerson>("PersonPerson");
					var st = (entity as HumanResourcesEmployee);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.PersonPerson = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonPersonColumnNames.   .ToString()
					//HumanResourcesEmployeeColumnNames.      .ToString()
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

		