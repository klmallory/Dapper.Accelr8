
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
	public enum ResponseColumnNames
	{	
		ResponseId, 	
		SubmissionId, 	
		DateReceived, 	
		FilePath, 	
		ResponseType, 	
		TCR, 	
		TCN, 	
		AgencyId, 	
	}

	public enum ResponseCascadeNames
	{	
		routedresponse, 	
		
		submission, 	
	}

	public class ResponseTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ResponseTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = ResponseColumnNames.ResponseId.ToString();
			TableName = "Responses";
			TableAlias = "response";
			ColumnNames = Enum.GetNames(typeof(ResponseColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Responses_Submissions
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Submission))),
			TableName = "Submissions",
			Alias = TableAlias + "_" + "submission",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Submission));
					var st = (entity as Response);

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
					ParentField = ResponseColumnNames.ResponseId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		