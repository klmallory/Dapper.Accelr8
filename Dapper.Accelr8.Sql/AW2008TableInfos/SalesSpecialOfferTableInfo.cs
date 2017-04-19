
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
	public enum SalesSpecialOfferFieldNames
	{	
		Id, 	
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
		salesspecialofferproducts, 	
		}

	public class SalesSpecialOfferTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSpecialOfferColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSpecialOfferFieldNames.Id, "SpecialOfferID" }, 
						{ (int)SalesSpecialOfferFieldNames.Description, "Description" }, 
						{ (int)SalesSpecialOfferFieldNames.DiscountPct, "DiscountPct" }, 
						{ (int)SalesSpecialOfferFieldNames.Type, "Type" }, 
						{ (int)SalesSpecialOfferFieldNames.Category, "Category" }, 
						{ (int)SalesSpecialOfferFieldNames.StartDate, "StartDate" }, 
						{ (int)SalesSpecialOfferFieldNames.EndDate, "EndDate" }, 
						{ (int)SalesSpecialOfferFieldNames.MinQty, "MinQty" }, 
						{ (int)SalesSpecialOfferFieldNames.MaxQty, "MaxQty" }, 
						{ (int)SalesSpecialOfferFieldNames.rowguid, "rowguid" }, 
						{ (int)SalesSpecialOfferFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSpecialOfferIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSpecialOfferFieldNames.Id, "SpecialOfferID" }, 
				};

		public SalesSpecialOfferTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SpecialOffer";
			TableAlias = "salesspecialoffer";
			Columns = SalesSpecialOfferColumnNames;
			IdColumns = SalesSpecialOfferIdColumnNames;

			Joins = new JoinInfo[] {
						};
		}
	}
}

		