
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
	public enum ProductionIllustrationFieldNames
	{	
		Id, 	
		Diagram, 	
		ModifiedDate, 	
	}

	public enum ProductionIllustrationCascadeNames
	{	
		productionproductmodelillustrations, 	
		}

	public class ProductionIllustrationTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionIllustrationColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionIllustrationFieldNames.Id, "IllustrationID" }, 
						{ (int)ProductionIllustrationFieldNames.Diagram, "Diagram" }, 
						{ (int)ProductionIllustrationFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionIllustrationIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionIllustrationFieldNames.Id, "IllustrationID" }, 
				};

		public ProductionIllustrationTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.Illustration";
			TableAlias = "productionillustration";
			Columns = ProductionIllustrationColumnNames;
			IdColumns = ProductionIllustrationIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		