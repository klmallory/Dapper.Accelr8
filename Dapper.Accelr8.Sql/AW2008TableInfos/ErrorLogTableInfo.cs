
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
	public enum ErrorLogColumnNames
	{	
		ErrorLogID, 	
		ErrorTime, 	
		UserName, 	
		ErrorNumber, 	
		ErrorSeverity, 	
		ErrorState, 	
		ErrorProcedure, 	
		ErrorLine, 	
		ErrorMessage, 	
	}

	public enum ErrorLogCascadeNames
	{	
		}

	public class ErrorLogTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ErrorLogTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ErrorLogColumnNames.ErrorLogID.ToString();
			//Schema = "ErrorLog";
			TableName = "ErrorLog";
			TableAlias = "errorlog";
			ColumnNames = typeof(ErrorLogColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		