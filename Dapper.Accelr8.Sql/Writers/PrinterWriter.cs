
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
using Dapper.Accelr8.Repo.Contracts.Writers;

namespace Dapper.Accelr8.Writers
{
    public class PrinterWriter : EntityWriter<int, Printer>
    {
        public PrinterWriter
			(TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, IServiceLocatorMarker locator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, locator)
		{

		}

		static IEntityWriter<int , PrinterGroup> GetPrinterGroupWriter()
		{ return _locator.Resolve<IEntityWriter<int , PrinterGroup>>(); }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, Printer entity, int taskIndex, int count)
        {
            var parms = new Dictionary<string, object>();

			parms.Add(GetParamName(PrinterColumnNames.PrinterId.ToString(), actionType, taskIndex, count), entity.Id);
			parms.Add(GetParamName(PrinterColumnNames.Name.ToString(), actionType, taskIndex, count), entity.Name);
					
			return parms;
        }


		protected override void CascadeRelations(Printer entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_PrinterGroups_Printers
			var printerGroup = GetPrinterGroupWriter();
			if (_cascades.Contains(PrinterCascadeNames.printergroup.ToString()))
				foreach (var item in entity.PrinterGroups)
					Cascade(printerGroup, item, context);

			if (printerGroup.Count > 0)
				WithChild(printerGroup, entity);

		
        }


	}
}
		