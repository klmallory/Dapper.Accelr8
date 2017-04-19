
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
	public enum DatabaseLogFieldNames
	{	
		Id, 	
		PostTime, 	
		DatabaseUser, 	
		Event, 	
		Schema, 	
		Object, 	
		TSQL, 	
		XmlEvent, 	
	}

	public enum DatabaseLogCascadeNames
	{	
		}

	public class DatabaseLogTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> DatabaseLogColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)DatabaseLogFieldNames.Id, "DatabaseLogID" }, 
						{ (int)DatabaseLogFieldNames.PostTime, "PostTime" }, 
						{ (int)DatabaseLogFieldNames.DatabaseUser, "DatabaseUser" }, 
						{ (int)DatabaseLogFieldNames.Event, "Event" }, 
						{ (int)DatabaseLogFieldNames.Schema, "Schema" }, 
						{ (int)DatabaseLogFieldNames.Object, "Object" }, 
						{ (int)DatabaseLogFieldNames.TSQL, "TSQL" }, 
						{ (int)DatabaseLogFieldNames.XmlEvent, "XmlEvent" }, 
				};	

		public static readonly IDictionary<int, string> DatabaseLogIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)DatabaseLogFieldNames.Id, "DatabaseLogID" }, 
				};

		public DatabaseLogTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "dbo";
			TableName = "DatabaseLog";
			TableAlias = "databaselog";
			Columns = DatabaseLogColumnNames;
			IdColumns = DatabaseLogIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		