
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
	public enum SubmissionColumnNames
	{	
		SubmissionId, 	
		TransactionId, 	
		EndpointId, 	
		AgencyId, 	
		Status, 	
	}

	public enum SubmissionCascadeNames
	{	
		submissionstatushistory, 	
		response, 	
		matchrequest, 	
		
		agency, 	
		transaction, 	
		endpoint, 	
	}

	public class SubmissionTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SubmissionTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = SubmissionColumnNames.SubmissionId.ToString();
			TableName = "Submissions";
			TableAlias = "submission";
			ColumnNames = Enum.GetNames(typeof(SubmissionColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Submission_Agency
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Agency))),
			TableName = "Agencies",
			Alias = TableAlias + "_" + "agency",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Agency));
					var st = (entity as Submission);

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
					ParentField = SubmissionColumnNames.SubmissionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Submissions_Transactions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Transaction))),
			TableName = "Transactions",
			Alias = TableAlias + "_" + "transaction",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Transaction));
					var st = (entity as Submission);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Transaction = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = TransactionColumnNames.TransactionId.ToString(),
					Operator = Operator.Equals,
					ParentField = SubmissionColumnNames.SubmissionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_Submissions_Endpoints
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Endpoint))),
			TableName = "Endpoints",
			Alias = TableAlias + "_" + "endpoint",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Endpoint));
					var st = (entity as Submission);

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
					ParentField = SubmissionColumnNames.SubmissionId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		