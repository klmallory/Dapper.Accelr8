
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
	public enum HumanResourcesvJobCandidateFieldNames
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
	
		public static readonly IDictionary<int, string> HumanResourcesvJobCandidateColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)HumanResourcesvJobCandidateFieldNames.JobCandidateID, "JobCandidateID" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.BusinessEntityID, "BusinessEntityID" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Name__Prefix, "Name.Prefix" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Name__First, "Name.First" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Name__Middle, "Name.Middle" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Name__Last, "Name.Last" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Name__Suffix, "Name.Suffix" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Skills, "Skills" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Addr__Type, "Addr.Type" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Addr__Loc__CountryRegion, "Addr.Loc.CountryRegion" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Addr__Loc__State, "Addr.Loc.State" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Addr__Loc__City, "Addr.Loc.City" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.Addr__PostalCode, "Addr.PostalCode" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.EMail, "EMail" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.WebSite, "WebSite" }, 
						{ (int)HumanResourcesvJobCandidateFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> HumanResourcesvJobCandidateIdColumnNames
		= new Dictionary<int, string>()
		{
						{ (int)HumanResourcesvJobCandidateFieldNames.JobCandidateID, "JobCandidateID" }, 
				};

		public HumanResourcesvJobCandidateTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = false;
			Schema = "HumanResources";
			TableName = "HumanResources.vJobCandidate";
			TableAlias = "humanresourcesvjobcandidate";
			Columns = HumanResourcesvJobCandidateColumnNames;
			IdColumns = HumanResourcesvJobCandidateIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		