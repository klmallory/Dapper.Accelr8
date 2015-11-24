
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
	public enum RoutedResponseStatusHistoryColumnNames
	{	
		RoutedResponseStatusId, 	
		RoutedResponseId, 	
		RoutedResponseStatus, 	
		StatusDate, 	
	}

	public enum RoutedResponseStatusHistoryCascadeNames
	{	
		
		routedresponse, 	
	}

	public class RoutedResponseStatusHistoryTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public RoutedResponseStatusHistoryTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = RoutedResponseStatusHistoryColumnNames.RoutedResponseStatusId.ToString();
			TableName = "RoutedResponseStatusHistory";
			TableAlias = "routedresponsestatushistory";
			ColumnNames = Enum.GetNames(typeof(RoutedResponseStatusHistoryColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_RoutedResponseStatusHistory_RoutedResponse_RoutedResponseId
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(RoutedResponse))),
			TableName = "RoutedResponses",
			Alias = TableAlias + "_" + "routedresponse",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(RoutedResponse));
					var st = (entity as RoutedResponseStatusHistory);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.RoutedResponse = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = RoutedResponseColumnNames.RoutedResponseId.ToString(),
					Operator = Operator.Equals,
					ParentField = RoutedResponseStatusHistoryColumnNames.RoutedResponseStatusId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		