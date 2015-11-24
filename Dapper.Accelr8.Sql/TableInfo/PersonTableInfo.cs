
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
	public enum PersonColumnNames
	{	
		PersonId, 	
		LastName, 	
		FirstName, 	
		MatcherPersonId, 	
	}

	public enum PersonCascadeNames
	{	
		transaction, 	
		
	}

	public class PersonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = PersonColumnNames.PersonId.ToString();
			TableName = "People";
			TableAlias = "person";
			ColumnNames = Enum.GetNames(typeof(PersonColumnNames));

			Joins = new JoinInfo[] {
						};
		}
	}
}
		