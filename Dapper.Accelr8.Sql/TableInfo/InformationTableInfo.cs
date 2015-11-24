
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
	public enum InformationColumnNames
	{	
		InformationID, 	
		DBVersion, 	
	}

	public enum InformationCascadeNames
	{	
		
	}

	public class InformationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public InformationTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = InformationColumnNames.InformationID.ToString();
			TableName = "Information";
			TableAlias = "information";
			ColumnNames = Enum.GetNames(typeof(InformationColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		