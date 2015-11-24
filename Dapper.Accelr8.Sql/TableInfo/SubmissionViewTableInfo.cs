
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
	public enum SubmissionViewColumnNames
	{	
		SubmissionId, 	
		TransactionId, 	
		EndpointId, 	
		AgencyId, 	
		Status, 	
		ResponseCount, 	
		TCN, 	
		StatusDate, 	
		Destination, 	
	}

	public enum SubmissionViewCascadeNames
	{	
		
	}

	public class SubmissionViewTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SubmissionViewTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = false;
			IdColumn = SubmissionViewColumnNames.SubmissionId.ToString();
			TableName = "Submissions_VW";
			TableAlias = "submissions_vw";
			ColumnNames = Enum.GetNames(typeof(SubmissionViewColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		