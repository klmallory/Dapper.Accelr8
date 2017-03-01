
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008TableInfos
{
	public enum PersonAddressColumnNames
	{	
		AddressID, 	
		AddressLine1, 	
		AddressLine2, 	
		City, 	
		StateProvinceID, 	
		PostalCode, 	
		SpatialLocation, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonAddressCascadeNames
	{	
		personbusinessentityaddress, 	
		salessalesorderheader, 	
		
		personstateprovince_p, 	}

	public class PersonAddressTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonAddressColumnNames.AddressID.ToString();
			//Schema = "Person.Address";
			TableName = "Person.Address";
			TableAlias = "personaddress";
			ColumnNames = typeof(PersonAddressColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_Address_StateProvince_StateProvinceID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonStateProvince>("PersonStateProvince")),
			TableName = "Person.StateProvince",
			Alias = TableAlias + "_" + "PersonStateProvince",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonStateProvince>("PersonStateProvince");
					var st = (entity as PersonAddress);

					if (st == null || row == null)
						return st;

					if (row.StateProvinceID == null || row.StateProvinceID == default(int))
						return st;

					st.PersonStateProvince = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonStateProvinceColumnNames.   .ToString()
					//PersonAddressColumnNames.      .ToString()
					JoinField = "StateProvinceID",
					Operator = Operator.Equals,
					ParentField = "StateProvinceID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		