
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
	public enum PrinterGroupColumnNames
	{	
		PrinterGroupsId, 	
		PrinterId, 	
		GroupId, 	
	}

	public enum PrinterGroupCascadeNames
	{	
		
		group, 	
		printer, 	
	}

	public class PrinterGroupTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PrinterGroupTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = PrinterGroupColumnNames.PrinterGroupsId.ToString();
			TableName = "PrinterGroups";
			TableAlias = "printergroup";
			ColumnNames = Enum.GetNames(typeof(PrinterGroupColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_PrinterGroups_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as PrinterGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = PrinterGroupColumnNames.PrinterGroupsId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_PrinterGroups_Printers
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Printer))),
			TableName = "Printers",
			Alias = TableAlias + "_" + "printer",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Printer));
					var st = (entity as PrinterGroup);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Printer = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = PrinterColumnNames.PrinterId.ToString(),
					Operator = Operator.Equals,
					ParentField = PrinterGroupColumnNames.PrinterGroupsId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		