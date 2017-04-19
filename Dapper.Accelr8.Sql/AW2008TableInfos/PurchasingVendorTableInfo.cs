
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
	public enum PurchasingVendorFieldNames
	{	
		Id, 	
		AccountNumber, 	
		Name, 	
		CreditRating, 	
		PreferredVendorStatus, 	
		ActiveFlag, 	
		PurchasingWebServiceURL, 	
		ModifiedDate, 	
	}

	public enum PurchasingVendorCascadeNames
	{	
		purchasingproductvendors, 	
		purchasingpurchaseorderheaders, 	
		
		personbusinessentity_p, 	}

	public class PurchasingVendorTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PurchasingVendorColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PurchasingVendorFieldNames.Id, "BusinessEntityID" }, 
						{ (int)PurchasingVendorFieldNames.AccountNumber, "AccountNumber" }, 
						{ (int)PurchasingVendorFieldNames.Name, "Name" }, 
						{ (int)PurchasingVendorFieldNames.CreditRating, "CreditRating" }, 
						{ (int)PurchasingVendorFieldNames.PreferredVendorStatus, "PreferredVendorStatus" }, 
						{ (int)PurchasingVendorFieldNames.ActiveFlag, "ActiveFlag" }, 
						{ (int)PurchasingVendorFieldNames.PurchasingWebServiceURL, "PurchasingWebServiceURL" }, 
						{ (int)PurchasingVendorFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PurchasingVendorIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PurchasingVendorFieldNames.Id, "BusinessEntityID" }, 
				};

		public PurchasingVendorTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Purchasing";
			TableName = "Purchasing.Vendor";
			TableAlias = "purchasingvendor";
			Columns = PurchasingVendorColumnNames;
			IdColumns = PurchasingVendorIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_Vendor_BusinessEntity_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity")),
			TableName = "Person.BusinessEntity",
			Alias = TableAlias + "_" + "PersonBusinessEntity",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonBusinessEntity>("PersonBusinessEntity");
					var st = (entity as PurchasingVendor);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.PersonBusinessEntity = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonBusinessEntityColumnNames.   .ToString()
					//PurchasingVendorColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		