

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
    public class SettingReader : EntityReader<int, Setting>
    {
        public SettingReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 0
		
			/// <summary>
		/// Loads the table Settings into class Setting
		/// </summary>
		/// <param name="results">Setting</param>
		/// <param name="row"></param>
        public override Setting LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Setting();

			
			domain.AuditAgeDay = GetRowData<int?>(dataRow, SettingColumnNames.AuditAgeDays.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Setting></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Setting> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(Setting entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<Setting> entities)
        {
					
		}
    }
}
		