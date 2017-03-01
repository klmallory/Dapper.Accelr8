
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
	public enum PersonAddressTypeColumnNames
	{	
		AddressTypeID, 	
		Name, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonAddressTypeCascadeNames
	{	
		personbusinessentityaddress, 	
		}

	public class PersonAddressTypeTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonAddressTypeTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonAddressTypeColumnNames.AddressTypeID.ToString();
			//Schema = "Person.AddressType";
			TableName = "Person.AddressType";
			TableAlias = "personaddresstype";
			ColumnNames = typeof(PersonAddressTypeColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		