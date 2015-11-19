

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
    public class AgencyEndpointReader : EntityReader<int, AgencyEndpoint>
    {
        public AgencyEndpointReader(
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
		/// Loads the table AgencyEndpoints into class AgencyEndpoint
		/// </summary>
		/// <param name="results">AgencyEndpoint</param>
		/// <param name="row"></param>
        public override AgencyEndpoint LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new AgencyEndpoint();

			domain.Id = GetRowData<int>(dataRow, IdField);
			
			domain.AgencyId = GetRowData<int>(dataRow, AgencyEndpointColumnNames.AgencyId.ToString()); 	
			domain.EndpointId = GetRowData<int>(dataRow, AgencyEndpointColumnNames.EndpointId.ToString());             
			
			return domain;
        }

        public override IEntityReader<int, AgencyEndpoint> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
            return this;
        }

        public override void SetAllChildrenForExisting(AgencyEndpoint entity)
        {
				
		}

		public override void SetAllChildrenForExisting(IList<AgencyEndpoint> entities)
        {
					
		}
    }
}
		