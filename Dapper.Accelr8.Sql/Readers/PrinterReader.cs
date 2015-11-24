

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

namespace Dapper.Accelr8.Readers
{
    public class PrinterReader : EntityReader<int, Printer>
    {
        public PrinterReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 1
		//Parent Count 0
		static IEntityReader<int , PrinterGroup> _printerGroupReader;
		static IEntityReader<int , PrinterGroup> GetPrinterGroupReader()
		{
			if (_printerGroupReader == null)
				_printerGroupReader = _locator.Resolve<IEntityReader<int , PrinterGroup>>();

			return _printerGroupReader;
		}

		
		/// <summary>
		/// Sets the children of type PrinterGroup on the parent on PrinterGroups.
		/// From foriegn key FK_PrinterGroups_Printers
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenPrinterGroups(IList<Printer> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PrinterGroup

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PrinterGroup>();

			foreach (var r in results)
			{
				r.PrinterGroups = typedChildren.Where(b => b.PrinterId == r.Id).ToList();
				r.PrinterGroups.ToList().ForEach(b => b.Printer = r);
			}
		}

			/// <summary>
		/// Loads the table Printers into class Printer
		/// </summary>
		/// <param name="results">Printer</param>
		/// <param name="row"></param>
        public override Printer LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Printer();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.Name = GetRowData<string>(dataRow, PrinterColumnNames.Name.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Printer></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Printer> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetPrinterGroupReader(), id, IdColumn, SetChildrenPrinterGroups);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Printer entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetPrinterGroupReader(), entity.Id
				, PrinterGroupColumnNames.PrinterId.ToString()
				, SetChildrenPrinterGroups);

			QueryResultForChildrenOnly(new List<Printer>() { entity });

			GetPrinterGroupReader().SetAllChildrenForExisting(entity.PrinterGroups);
				
		}

		public override void SetAllChildrenForExisting(IList<Printer> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetPrinterGroupReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), PrinterGroupColumnNames.PrinterId.ToString()
				, SetChildrenPrinterGroups);

					
			QueryResultForChildrenOnly(entities);

			GetPrinterGroupReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PrinterGroups).ToList());
					
		}
    }
}
		