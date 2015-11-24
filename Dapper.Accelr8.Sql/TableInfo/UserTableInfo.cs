
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
	public enum UserColumnNames
	{	
		UserId, 	
		Username, 	
		ApplicationId, 	
		DisplayLanguage, 	
		IsDisabled, 	
	}

	public enum UserCascadeNames
	{	
		license, 	
		usersgroup, 	
		transaction, 	
		
		application, 	
	}

	public class UserTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public UserTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = UserColumnNames.UserId.ToString();
			TableName = "Users";
			TableAlias = "user";
			ColumnNames = Enum.GetNames(typeof(UserColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Users_Applications
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(Application))),
			TableName = "Applications",
			Alias = TableAlias + "_" + "application",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(Application));
					var st = (entity as User);

					if (st == null || row == null)
						return st;

					if (row.Id == default(int))
						return st;

					st.Application = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					JoinField = ApplicationColumnNames.ApplicationId.ToString(),
					Operator = Operator.Equals,
					ParentField = UserColumnNames.UserId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		