
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
	public enum PersonAddressTypeFieldNames
	{	
		Id, 	
		Name, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonAddressTypeCascadeNames
	{	
		personbusinessentityaddresses, 	
		}

	public class PersonAddressTypeTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonAddressTypeColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonAddressTypeFieldNames.Id, "AddressTypeID" }, 
						{ (int)PersonAddressTypeFieldNames.Name, "Name" }, 
						{ (int)PersonAddressTypeFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonAddressTypeFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonAddressTypeIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonAddressTypeFieldNames.Id, "AddressTypeID" }, 
				};

		public PersonAddressTypeTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.AddressType";
			TableAlias = "personaddresstype";
			Columns = PersonAddressTypeColumnNames;
			IdColumns = PersonAddressTypeIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		