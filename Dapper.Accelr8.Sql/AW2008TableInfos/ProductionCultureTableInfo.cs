
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
	public enum ProductionCultureFieldNames
	{	
		Id, 	
		Name, 	
		ModifiedDate, 	
	}

	public enum ProductionCultureCascadeNames
	{	
		productionproductmodelproductdescriptioncultures, 	
		}

	public class ProductionCultureTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionCultureColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionCultureFieldNames.Id, "CultureID" }, 
						{ (int)ProductionCultureFieldNames.Name, "Name" }, 
						{ (int)ProductionCultureFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionCultureIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionCultureFieldNames.Id, "CultureID" }, 
				};

		public ProductionCultureTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.Culture";
			TableAlias = "productionculture";
			Columns = ProductionCultureColumnNames;
			IdColumns = ProductionCultureIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		