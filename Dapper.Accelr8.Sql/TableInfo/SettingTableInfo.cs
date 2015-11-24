
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
	public enum SettingColumnNames
	{	
		AuditAgeDays, 	
	}

	public enum SettingCascadeNames
	{	
		
	}

	public class SettingTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SettingTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = SettingColumnNames.AuditAgeDays.ToString();
			TableName = "Settings";
			TableAlias = "setting";
			ColumnNames = Enum.GetNames(typeof(SettingColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		