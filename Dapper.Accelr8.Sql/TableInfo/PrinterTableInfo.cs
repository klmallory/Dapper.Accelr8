
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
	public enum PrinterColumnNames
	{	
		PrinterId, 	
		Name, 	
	}

	public enum PrinterCascadeNames
	{	
		printergroup, 	
		
	}

	public class PrinterTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PrinterTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = PrinterColumnNames.PrinterId.ToString();
			TableName = "Printers";
			TableAlias = "printer";
			ColumnNames = Enum.GetNames(typeof(PrinterColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		