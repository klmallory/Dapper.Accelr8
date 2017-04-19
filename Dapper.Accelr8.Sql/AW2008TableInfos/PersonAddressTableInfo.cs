
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
	public enum PersonAddressFieldNames
	{	
		Id, 	
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
		personbusinessentityaddresses, 	
		salessalesorderheaders1, 	
		
		personstateprovince_p, 	}

	public class PersonAddressTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonAddressColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonAddressFieldNames.Id, "AddressID" }, 
						{ (int)PersonAddressFieldNames.AddressLine1, "AddressLine1" }, 
						{ (int)PersonAddressFieldNames.AddressLine2, "AddressLine2" }, 
						{ (int)PersonAddressFieldNames.City, "City" }, 
						{ (int)PersonAddressFieldNames.StateProvinceID, "StateProvinceID" }, 
						{ (int)PersonAddressFieldNames.PostalCode, "PostalCode" }, 
						{ (int)PersonAddressFieldNames.SpatialLocation, "SpatialLocation" }, 
						{ (int)PersonAddressFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonAddressFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonAddressIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonAddressFieldNames.Id, "AddressID" }, 
				};

		public PersonAddressTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.Address";
			TableAlias = "personaddress";
			Columns = PersonAddressColumnNames;
			IdColumns = PersonAddressIdColumnNames;

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

		