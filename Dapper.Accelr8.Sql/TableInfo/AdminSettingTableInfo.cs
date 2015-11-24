
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
	public enum AdminSettingColumnNames
	{	
		AdminSettingsId, 	
		Name, 	
		Type, 	
		Description, 	
		Value, 	
	}

	public enum AdminSettingCascadeNames
	{	
		
	}

	public class AdminSettingTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AdminSettingTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AdminSettingColumnNames.AdminSettingsId.ToString();
			TableName = "AdminSettings";
			TableAlias = "adminsetting";
			ColumnNames = Enum.GetNames(typeof(AdminSettingColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		