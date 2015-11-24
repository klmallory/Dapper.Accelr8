
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.TableInfos
{
	public enum ServerColumnNames
	{	
		ServerId, 	
		Name, 	
		Direction, 	
		Description, 	
		Protocol, 	
		Configuration, 	
	}

	public enum ServerCascadeNames
	{	
		endpoint, 	
		
	}

	public class ServerTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ServerTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = ServerColumnNames.ServerId.ToString();
			TableName = "Servers";
			TableAlias = "server";
			ColumnNames = Enum.GetNames(typeof(ServerColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		