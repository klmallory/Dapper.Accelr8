
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
	public enum MatchRequestColumnNames
	{	
		MatchRequestId, 	
		SubmissionId, 	
		AbisRequestId, 	
		AbisOperation, 	
		Status, 	
		PersonId, 	
	}

	public enum MatchRequestCascadeNames
	{	
		
		submission, 	
	}

	public class MatchRequestTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public MatchRequestTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = MatchRequestColumnNames.MatchRequestId.ToString();
			TableName = "MatchRequests";
			TableAlias = "matchrequest";
			ColumnNames = Enum.GetNames(typeof(MatchRequestColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_MatchRequest_Submission_SubmissionId
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Submission))),
			TableName = "Submissions",
			Alias = TableAlias + "_" + "submission",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Submission));
					var st = (entity as MatchRequest);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Submission = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = SubmissionColumnNames.SubmissionId.ToString(),
					Operator = Operator.Equals,
					ParentField = MatchRequestColumnNames.MatchRequestId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		