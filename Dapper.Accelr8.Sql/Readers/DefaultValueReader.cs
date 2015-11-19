

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
    public class DefaultValueReader : EntityReader<int, DefaultValue>
    {
        public DefaultValueReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 0
		//Parent Count 1

			/// <summary>
		/// Loads the table DefaultValues into class DefaultValue
		/// </summary>
		/// <param name="results">DefaultValue</param>
		/// <param name="row"></param>
        public override DefaultValue LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new DefaultValue();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.WorkspaceId = GetRowData<int?>(dataRow, DefaultValueColumnNames.WorkspaceId.ToString()); 	
			domain.Value = GetRowData<string>(dataRow, DefaultValueColumnNames.Value.ToString()); 	
			domain.Mnemonic = GetRowData<string>(dataRow, DefaultValueColumnNames.Mnemonic.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, DefaultValue> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(DefaultValue entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<DefaultValue> entities)
        {
					
		}
    }
}
		