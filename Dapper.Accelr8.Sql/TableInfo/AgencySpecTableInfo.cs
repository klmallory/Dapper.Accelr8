
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
	public enum AgencySpecColumnNames
	{	
		AgencySpecId, 	
		SpecKey, 	
		Name, 	
		FileDefinitionPath, 	
	}

	public enum AgencySpecCascadeNames
	{	
		agency, 	
		transaction, 	
		
	}

	public class AgencySpecTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AgencySpecTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AgencySpecColumnNames.AgencySpecId.ToString();
			TableName = "AgencySpecs";
			TableAlias = "agencyspec";
			ColumnNames = Enum.GetNames(typeof(AgencySpecColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		