
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
	public enum SalesSalesReasonColumnNames
	{	
		SalesReasonID, 	
		Name, 	
		ReasonType, 	
		ModifiedDate, 	
	}

	public enum SalesSalesReasonCascadeNames
	{	
		salessalesorderheadersalesreason, 	
		}

	public class SalesSalesReasonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesSalesReasonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesSalesReasonColumnNames.SalesReasonID.ToString();
			//Schema = "Sales.SalesReason";
			TableName = "Sales.SalesReason";
			TableAlias = "salessalesreason";
			ColumnNames = typeof(SalesSalesReasonColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		