
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
	public enum SalesSalesReasonFieldNames
	{	
		Id, 	
		Name, 	
		ReasonType, 	
		ModifiedDate, 	
	}

	public enum SalesSalesReasonCascadeNames
	{	
		salessalesorderheadersalesreasons, 	
		}

	public class SalesSalesReasonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSalesReasonColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesReasonFieldNames.Id, "SalesReasonID" }, 
						{ (int)SalesSalesReasonFieldNames.Name, "Name" }, 
						{ (int)SalesSalesReasonFieldNames.ReasonType, "ReasonType" }, 
						{ (int)SalesSalesReasonFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSalesReasonIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesReasonFieldNames.Id, "SalesReasonID" }, 
				};

		public SalesSalesReasonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SalesReason";
			TableAlias = "salessalesreason";
			Columns = SalesSalesReasonColumnNames;
			IdColumns = SalesSalesReasonIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		