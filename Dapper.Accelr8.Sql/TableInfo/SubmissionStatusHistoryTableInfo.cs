
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
	public enum SubmissionStatusHistoryColumnNames
	{	
		SubmissionStatusHistoryId, 	
		SubmissionId, 	
		TransmissionStatus, 	
		StatusDate, 	
	}

	public enum SubmissionStatusHistoryCascadeNames
	{	
		
		submission, 	
	}

	public class SubmissionStatusHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SubmissionStatusHistoryTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = SubmissionStatusHistoryColumnNames.SubmissionStatusHistoryId.ToString();
			TableName = "SubmissionStatusHistory";
			TableAlias = "submissionstatushistory";
			ColumnNames = Enum.GetNames(typeof(SubmissionStatusHistoryColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_SubmissionStatusHistory_Submissions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Submission))),
			TableName = "Submissions",
			Alias = TableAlias + "_" + "submission",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Submission));
					var st = (entity as SubmissionStatusHistory);

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
					ParentField = SubmissionStatusHistoryColumnNames.SubmissionStatusHistoryId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		