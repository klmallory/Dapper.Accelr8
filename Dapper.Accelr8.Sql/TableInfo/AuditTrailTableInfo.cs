
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
	public enum AuditTrailColumnNames
	{	
		AuditTrailId, 	
		UserName, 	
		AuditDate, 	
		Action, 	
		Area, 	
		Details, 	
	}

	public enum AuditTrailCascadeNames
	{	
		
	}

	public class AuditTrailTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AuditTrailTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AuditTrailColumnNames.AuditTrailId.ToString();
			TableName = "AuditTrail";
			TableAlias = "audittrail";
			ColumnNames = Enum.GetNames(typeof(AuditTrailColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		