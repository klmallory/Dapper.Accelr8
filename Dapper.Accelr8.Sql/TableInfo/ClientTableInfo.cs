
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
	public enum ClientColumnNames
	{	
		ClientId, 	
		Name, 	
		Description, 	
		IsActive, 	
		EmailAddress, 	
		Address1, 	
		Address2, 	
		City, 	
		State, 	
		Zip, 	
		Country, 	
		Phone, 	
		GroupId, 	
		OriginatingAgencyId, 	
		EndpointId, 	
		ContactName, 	
	}

	public enum ClientCascadeNames
	{	
		transaction, 	
		
		group, 	
		endpoint, 	
	}

	public class ClientTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ClientTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = ClientColumnNames.ClientId.ToString();
			TableName = "Clients";
			TableAlias = "client";
			ColumnNames = Enum.GetNames(typeof(ClientColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Clients_Groups
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Group))),
			TableName = "Groups",
			Alias = TableAlias + "_" + "group",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Group));
					var st = (entity as Client);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Group = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = GroupColumnNames.GroupId.ToString(),
					Operator = Operator.Equals,
					ParentField = ClientColumnNames.ClientId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Clients_Endpoint
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Endpoint))),
			TableName = "Endpoints",
			Alias = TableAlias + "_" + "endpoint",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Endpoint));
					var st = (entity as Client);

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
					ParentField = ClientColumnNames.ClientId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		