
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
	public enum AWBuildVersionColumnNames
	{	
		SystemInformationID, 	
		Database_spc_Version, 	
		VersionDate, 	
		ModifiedDate, 	
	}

	public enum AWBuildVersionCascadeNames
	{	
		}

	public class AWBuildVersionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AWBuildVersionTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = AWBuildVersionColumnNames.SystemInformationID.ToString();
			//Schema = "AWBuildVersion";
			TableName = "AWBuildVersion";
			TableAlias = "awbuildversion";
			ColumnNames = typeof(AWBuildVersionColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		