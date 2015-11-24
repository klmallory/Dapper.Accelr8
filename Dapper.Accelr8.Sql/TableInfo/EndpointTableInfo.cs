
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
	public enum EndpointColumnNames
	{	
		EndpointId, 	
		ServerId, 	
		Name, 	
		Configuration, 	
	}

	public enum EndpointCascadeNames
	{	
		submission, 	
		client, 	
		routedresponse, 	
		agencyendpoint, 	
		
		server, 	
	}

	public class EndpointTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public EndpointTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = EndpointColumnNames.EndpointId.ToString();
			TableName = "Endpoints";
			TableAlias = "endpoint";
			ColumnNames = Enum.GetNames(typeof(EndpointColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Endpoints_Servers
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Server))),
			TableName = "Servers",
			Alias = TableAlias + "_" + "server",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Server));
					var st = (entity as Endpoint);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Server = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = ServerColumnNames.ServerId.ToString(),
					Operator = Operator.Equals,
					ParentField = EndpointColumnNames.EndpointId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		