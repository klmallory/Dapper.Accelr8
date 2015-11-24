
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
	public enum ApplicationColumnNames
	{	
		ApplicationId, 	
		Name, 	
		ApplicationKey, 	
		Description, 	
	}

	public enum ApplicationCascadeNames
	{	
		user, 	
		
	}

	public class ApplicationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ApplicationTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = ApplicationColumnNames.ApplicationId.ToString();
			TableName = "Applications";
			TableAlias = "application";
			ColumnNames = Enum.GetNames(typeof(ApplicationColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		