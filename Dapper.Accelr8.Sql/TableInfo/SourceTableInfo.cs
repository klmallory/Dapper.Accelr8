
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
	public enum SourceColumnNames
	{	
		SourceId, 	
		Name, 	
		SourceKey, 	
		Description, 	
	}

	public enum SourceCascadeNames
	{	
		transaction, 	
		
	}

	public class SourceTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SourceTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = SourceColumnNames.SourceId.ToString();
			TableName = "Source";
			TableAlias = "source";
			ColumnNames = Enum.GetNames(typeof(SourceColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		