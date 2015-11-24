
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
	public enum RoutedResponseColumnNames
	{	
		RoutedResponseId, 	
		ResponseId, 	
		EndpointId, 	
		Status, 	
	}

	public enum RoutedResponseCascadeNames
	{	
		routedresponsestatushistory, 	
		
		response, 	
		endpoint, 	
	}

	public class RoutedResponseTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public RoutedResponseTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = RoutedResponseColumnNames.RoutedResponseId.ToString();
			TableName = "RoutedResponses";
			TableAlias = "routedresponse";
			ColumnNames = Enum.GetNames(typeof(RoutedResponseColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_RoutedResponses_Responses
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Response))),
			TableName = "Responses",
			Alias = TableAlias + "_" + "response",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Response));
					var st = (entity as RoutedResponse);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Response = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = ResponseColumnNames.ResponseId.ToString(),
					Operator = Operator.Equals,
					ParentField = RoutedResponseColumnNames.RoutedResponseId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK__RoutedRes__Endpo__6477ECF3
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Endpoint))),
			TableName = "Endpoints",
			Alias = TableAlias + "_" + "endpoint",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Endpoint));
					var st = (entity as RoutedResponse);

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
					ParentField = RoutedResponseColumnNames.RoutedResponseId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		