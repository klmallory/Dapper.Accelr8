
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
	public enum SalesSpecialOfferColumnNames
	{	
		SpecialOfferID, 	
		Description, 	
		DiscountPct, 	
		Type, 	
		Category, 	
		StartDate, 	
		EndDate, 	
		MinQty, 	
		MaxQty, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSpecialOfferCascadeNames
	{	
		salesspecialofferproduct, 	
		}

	public class SalesSpecialOfferTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesSpecialOfferTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesSpecialOfferColumnNames.SpecialOfferID.ToString();
			//Schema = "Sales.SpecialOffer";
			TableName = "Sales.SpecialOffer";
			TableAlias = "salesspecialoffer";
			ColumnNames = typeof(SalesSpecialOfferColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						};
		}
	}
}

		