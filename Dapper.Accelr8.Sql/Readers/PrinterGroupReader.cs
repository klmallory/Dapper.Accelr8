

using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfo;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.Readers
{
    public class PrinterGroupReader : EntityReader<int, PrinterGroup>
    {
        public PrinterGroupReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 2

			/// <summary>
		/// Loads the table PrinterGroups into class PrinterGroup
		/// </summary>
		/// <param name="results">PrinterGroup</param>
		/// <param name="row"></param>
        public override PrinterGroup LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PrinterGroup();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.PrinterId = GetRowData<int>(dataRow, PrinterGroupColumnNames.PrinterId.ToString()); 	
			domain.GroupId = GetRowData<int>(dataRow, PrinterGroupColumnNames.GroupId.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, PrinterGroup> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(PrinterGroup entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<PrinterGroup> entities)
        {
					
		}
    }
}
		