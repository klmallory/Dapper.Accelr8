
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
	public enum GroupColumnNames
	{	
		GroupId, 	
		Name, 	
		Description, 	
		IsDefault, 	
	}

	public enum GroupCascadeNames
	{	
		usersgroup, 	
		workspacegroup, 	
		printergroup, 	
		client, 	
		transactiongroup, 	
		
	}

	public class GroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public GroupTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = GroupColumnNames.GroupId.ToString();
			TableName = "Groups";
			TableAlias = "group";
			ColumnNames = Enum.GetNames(typeof(GroupColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		