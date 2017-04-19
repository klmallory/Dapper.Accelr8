
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
	public enum PersonBusinessEntityFieldNames
	{	
		Id, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonBusinessEntityCascadeNames
	{	
		salesstores, 	
		personbusinessentityaddresses, 	
		personbusinessentitycontacts, 	
		purchasingvendors, 	
		personpeople, 	
		}

	public class PersonBusinessEntityTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonBusinessEntityColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonBusinessEntityFieldNames.Id, "BusinessEntityID" }, 
						{ (int)PersonBusinessEntityFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonBusinessEntityFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonBusinessEntityIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonBusinessEntityFieldNames.Id, "BusinessEntityID" }, 
				};

		public PersonBusinessEntityTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.BusinessEntity";
			TableAlias = "personbusinessentity";
			Columns = PersonBusinessEntityColumnNames;
			IdColumns = PersonBusinessEntityIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		