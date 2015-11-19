

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
    public class BiographicGroupReader : EntityReader<int, BiographicGroup>
    {
        public BiographicGroupReader(
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
		/// Loads the table BiographicGroups into class BiographicGroup
		/// </summary>
		/// <param name="results">BiographicGroup</param>
		/// <param name="row"></param>
        public override BiographicGroup LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new BiographicGroup();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.Name = GetRowData<string>(dataRow, BiographicGroupColumnNames.Name.ToString()); 	
			domain.WorkspaceId = GetRowData<int?>(dataRow, BiographicGroupColumnNames.WorkspaceId.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, BiographicGroup> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(BiographicGroup entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<BiographicGroup> entities)
        {
					
		}
    }
}
		