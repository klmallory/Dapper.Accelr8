
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
	public enum ErrorLogFieldNames
	{	
		Id, 	
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
	
		public static readonly IDictionary<int, string> ErrorLogColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ErrorLogFieldNames.Id, "ErrorLogID" }, 
						{ (int)ErrorLogFieldNames.ErrorTime, "ErrorTime" }, 
						{ (int)ErrorLogFieldNames.UserName, "UserName" }, 
						{ (int)ErrorLogFieldNames.ErrorNumber, "ErrorNumber" }, 
						{ (int)ErrorLogFieldNames.ErrorSeverity, "ErrorSeverity" }, 
						{ (int)ErrorLogFieldNames.ErrorState, "ErrorState" }, 
						{ (int)ErrorLogFieldNames.ErrorProcedure, "ErrorProcedure" }, 
						{ (int)ErrorLogFieldNames.ErrorLine, "ErrorLine" }, 
						{ (int)ErrorLogFieldNames.ErrorMessage, "ErrorMessage" }, 
				};	

		public static readonly IDictionary<int, string> ErrorLogIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ErrorLogFieldNames.Id, "ErrorLogID" }, 
				};

		public ErrorLogTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "dbo";
			TableName = "ErrorLog";
			TableAlias = "errorlog";
			Columns = ErrorLogColumnNames;
			IdColumns = ErrorLogIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		