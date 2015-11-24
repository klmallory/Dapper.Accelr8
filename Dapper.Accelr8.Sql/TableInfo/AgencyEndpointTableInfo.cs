
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
	public enum AgencyEndpointColumnNames
	{	
		AgencyEndpointId, 	
		AgencyId, 	
		EndpointId, 	
	}

	public enum AgencyEndpointCascadeNames
	{	
		
		agency, 	
		endpoint, 	
	}

	public class AgencyEndpointTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AgencyEndpointTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AgencyEndpointColumnNames.AgencyEndpointId.ToString();
			TableName = "AgencyEndpoints";
			TableAlias = "agencyendpoint";
			ColumnNames = Enum.GetNames(typeof(AgencyEndpointColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_AgencyEndpoints_Agencies
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Agency))),
			TableName = "Agencies",
			Alias = TableAlias + "_" + "agency",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Agency));
					var st = (entity as AgencyEndpoint);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Agency = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = AgencyColumnNames.AgencyId.ToString(),
					Operator = Operator.Equals,
					ParentField = AgencyEndpointColumnNames.AgencyEndpointId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_AgencyEndpoints_Endpoints
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Endpoint))),
			TableName = "Endpoints",
			Alias = TableAlias + "_" + "endpoint",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Endpoint));
					var st = (entity as AgencyEndpoint);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Endpoint = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = EndpointColumnNames.EndpointId.ToString(),
					Operator = Operator.Equals,
					ParentField = AgencyEndpointColumnNames.AgencyEndpointId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		