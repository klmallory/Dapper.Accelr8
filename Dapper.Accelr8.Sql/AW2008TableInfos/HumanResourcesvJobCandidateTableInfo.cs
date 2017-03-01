
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
	public enum HumanResourcesvJobCandidateColumnNames
	{	
		JobCandidateID, 	
		BusinessEntityID, 	
		Name__Prefix, 	
		Name__First, 	
		Name__Middle, 	
		Name__Last, 	
		Name__Suffix, 	
		Skills, 	
		Addr__Type, 	
		Addr__Loc__CountryRegion, 	
		Addr__Loc__State, 	
		Addr__Loc__City, 	
		Addr__PostalCode, 	
		EMail, 	
		WebSite, 	
		ModifiedDate, 	
	}

	public enum HumanResourcesvJobCandidateCascadeNames
	{	
		}

	public class HumanResourcesvJobCandidateTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public HumanResourcesvJobCandidateTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = false;
			IdColumn = HumanResourcesvJobCandidateColumnNames.JobCandidateID.ToString();
			//Schema = "HumanResources.vJobCandidate";
			TableName = "HumanResources.vJobCandidate";
			TableAlias = "humanresourcesvjobcandidate";
			ColumnNames = typeof(HumanResourcesvJobCandidateColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		