
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
	public enum LicenseColumnNames
	{	
		LicenseId, 	
		LicenseType, 	
		ComputerName, 	
		MACAddress, 	
		DeviceSerialNum, 	
		UserId, 	
		WorkstationId, 	
	}

	public enum LicenseCascadeNames
	{	
		
		user, 	
	}

	public class LicenseTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public LicenseTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = LicenseColumnNames.LicenseId.ToString();
			TableName = "Licenses";
			TableAlias = "license";
			ColumnNames = Enum.GetNames(typeof(LicenseColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Licenses_Users
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(User))),
			TableName = "Users",
			Alias = TableAlias + "_" + "user",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(User));
					var st = (entity as License);

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
					ParentField = LicenseColumnNames.LicenseId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		