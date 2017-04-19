
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
	public enum HumanResourcesJobCandidateFieldNames
	{	
		Id, 	
		BusinessEntityID, 	
		Resume, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesJobCandidateCascadeNames
	{	
		
		humanresourcesemployee_p, 	}

	public class HumanResourcesJobCandidateTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> HumanResourcesJobCandidateColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesJobCandidateFieldNames.Id, "JobCandidateID" }, 
						{ (int)HumanResourcesJobCandidateFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesJobCandidateFieldNames.Resume, "Resume" }, 
						{ (int)HumanResourcesJobCandidateFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesJobCandidateIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesJobCandidateFieldNames.Id, "JobCandidateID" }, 
				};

		public HumanResourcesJobCandidateTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "HumanResources";
			TableName = "HumanResources.JobCandidate";
			TableAlias = "humanresourcesjobcandidate";
			Columns = HumanResourcesJobCandidateColumnNames;
			IdColumns = HumanResourcesJobCandidateIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_JobCandidate_Employee_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee")),
			TableName = "HumanResources.Employee",
			Alias = TableAlias + "_" + "HumanResourcesEmployee",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee");
					var st = (entity as HumanResourcesJobCandidate);

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
					//HumanResourcesJobCandidateColumnNames.      .ToString()
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

		