
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
	public enum TransactionColumnNames
	{	
		TransactionId, 	
		PersonId, 	
		WorkspaceId, 	
		ClientId, 	
		TCN, 	
		OriginatingAgencyId, 	
		DestinationAgencyId, 	
		Filepath, 	
		CreatedDate, 	
		TransactionType, 	
		Name, 	
		AgencySpecId, 	
		UserId, 	
		TransactionStatus, 	
		SourceId, 	
		CaptureWorkflowName, 	
		PhotoCaptureWorkflowName, 	
		DocumentCaptureWorkflowName, 	
		WorkstationId, 	
	}

	public enum TransactionCascadeNames
	{	
		transactionfieldvalue, 	
		document, 	
		enrollmentmnemonicvalue, 	
		submission, 	
		transactionfilepath, 	
		biometric, 	
		transactionstatushistory, 	
		transactiongroup, 	
		
		person, 	
		user, 	
		client, 	
		workspace, 	
		agencyspec, 	
		source, 	
	}

	public class TransactionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public TransactionTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = TransactionColumnNames.TransactionId.ToString();
			TableName = "Transactions";
			TableAlias = "transaction";
			ColumnNames = Enum.GetNames(typeof(TransactionColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Transactions_People
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Person))),
			TableName = "People",
			Alias = TableAlias + "_" + "person",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Person));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Person = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = PersonColumnNames.PersonId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_Users
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(User))),
			TableName = "Users",
			Alias = TableAlias + "_" + "user",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(User));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.User = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = UserColumnNames.UserId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_Clients
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Client))),
			TableName = "Clients",
			Alias = TableAlias + "_" + "client",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Client));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Client = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = ClientColumnNames.ClientId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_Workspaces
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Workspace))),
			TableName = "Workspaces",
			Alias = TableAlias + "_" + "workspace",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Workspace));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Workspace = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = WorkspaceColumnNames.WorkspaceId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_AgencySpecs
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(AgencySpec))),
			TableName = "AgencySpecs",
			Alias = TableAlias + "_" + "agencyspec",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(AgencySpec));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.AgencySpec = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = AgencySpecColumnNames.AgencySpecId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Transactions_Source
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Source))),
			TableName = "Source",
			Alias = TableAlias + "_" + "source",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Source));
					var st = (entity as Transaction);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Source = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = SourceColumnNames.SourceId.ToString(),
					Operator = Operator.Equals,
					ParentField = TransactionColumnNames.TransactionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		