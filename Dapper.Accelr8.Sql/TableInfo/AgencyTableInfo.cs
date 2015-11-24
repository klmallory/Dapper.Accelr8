
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
	public enum AgencyColumnNames
	{	
		AgencyId, 	
		Name, 	
		ORI, 	
		CMABIS, 	
		AgencySpecId, 	
	}

	public enum AgencyCascadeNames
	{	
		workspace, 	
		submission, 	
		agencyendpoint, 	
		
		agencyspec, 	
	}

	public class AgencyTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public AgencyTableInfo(IServiceLocatorMarker locator) : base(locator)
		{
			UniqueId = true;
			IdColumn = AgencyColumnNames.AgencyId.ToString();
			TableName = "Agencies";
			TableAlias = "agency";
			ColumnNames = Enum.GetNames(typeof(AgencyColumnNames));

			Joins = new JoinInfo[] {
						//For Key FK_Agencies_AgencySpecs_AgencySpecId
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => GetReader(typeof(int), typeof(AgencySpec))),
			TableName = "AgencySpecs",
			Alias = TableAlias + "_" + "agencyspec",
			Load = (entity, row) =>
				{ 
					var reader = GetReader(typeof(int), typeof(AgencySpec));
					var st = (entity as Agency);

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
					ParentField = AgencyColumnNames.AgencyId.ToString(),
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}
		