
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
	public enum PersonBusinessEntityColumnNames
	{	
		BusinessEntityID, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonBusinessEntityCascadeNames
	{	
		salesstore, 	
		personbusinessentityaddress, 	
		personbusinessentitycontact, 	
		purchasingvendor, 	
		personperson, 	
		}

	public class PersonBusinessEntityTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public PersonBusinessEntityTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = PersonBusinessEntityColumnNames.BusinessEntityID.ToString();
			//Schema = "Person.BusinessEntity";
			TableName = "Person.BusinessEntity";
			TableAlias = "personbusinessentity";
			ColumnNames = typeof(PersonBusinessEntityColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		