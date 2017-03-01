
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
	public enum HumanResourcesEmployeeColumnNames
	{	
		BusinessEntityID, 	
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
		purchasingpurchaseorderheader, 	
		productiondocument, 	
		humanresourcesemployeedepartmenthistory, 	
		humanresourcesemployeepayhistory, 	
		salessalesperson, 	
		humanresourcesjobcandidate, 	
		
		personperson_p, 	}

	public class HumanResourcesEmployeeTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public HumanResourcesEmployeeTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = HumanResourcesEmployeeColumnNames.BusinessEntityID.ToString();
			//Schema = "HumanResources.Employee";
			TableName = "HumanResources.Employee";
			TableAlias = "humanresourcesemployee";
			ColumnNames = typeof(HumanResourcesEmployeeColumnNames).ToDataList<Type, int>();

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

		