
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
	public enum AWBuildVersionFieldNames
	{	
		Id, 	
		Database_Spc_Version, 	
		VersionDate, 	
		ModifiedDate, 	
	}

	public enum AWBuildVersionCascadeNames
	{	
		}

	public class AWBuildVersionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> AWBuildVersionColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)AWBuildVersionFieldNames.Id, "SystemInformationID" }, 
						{ (int)AWBuildVersionFieldNames.Database_Spc_Version, "Database Version" }, 
						{ (int)AWBuildVersionFieldNames.VersionDate, "VersionDate" }, 
						{ (int)AWBuildVersionFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> AWBuildVersionIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)AWBuildVersionFieldNames.Id, "SystemInformationID" }, 
				};

		public AWBuildVersionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "dbo";
			TableName = "AWBuildVersion";
			TableAlias = "awbuildversion";
			Columns = AWBuildVersionColumnNames;
			IdColumns = AWBuildVersionIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		