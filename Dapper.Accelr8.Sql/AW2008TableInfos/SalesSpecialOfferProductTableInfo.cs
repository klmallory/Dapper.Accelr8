
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
	public enum SalesSpecialOfferProductFieldNames
	{	
		SpecialOfferID, 	
		ProductID, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSpecialOfferProductCascadeNames
	{	
		salessalesorderdetails1, 	
		
		salesspecialoffer_p, 	
		productionproduct_p, 	}

	public class SalesSpecialOfferProductTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSpecialOfferProductColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSpecialOfferProductFieldNames.SpecialOfferID, "SpecialOfferID" }, 
						{ (int)SalesSpecialOfferProductFieldNames.ProductID, "ProductID" }, 
						{ (int)SalesSpecialOfferProductFieldNames.rowguid, "rowguid" }, 
						{ (int)SalesSpecialOfferProductFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSpecialOfferProductIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSpecialOfferProductFieldNames.SpecialOfferID, "SpecialOfferID" }, 
						{ (int)SalesSpecialOfferProductFieldNames.ProductID, "ProductID" }, 
				};

		public SalesSpecialOfferProductTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SpecialOfferProduct";
			TableAlias = "salesspecialofferproduct";
			Columns = SalesSpecialOfferProductColumnNames;
			IdColumns = SalesSpecialOfferProductIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSpecialOffer>("SalesSpecialOffer")),
			TableName = "Sales.SpecialOffer",
			Alias = TableAlias + "_" + "SalesSpecialOffer",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSpecialOffer>("SalesSpecialOffer");
					var st = (entity as SalesSpecialOfferProduct);

					if (st == null || row == null)
						return st;

					if (row.SpecialOfferID == null || row.SpecialOfferID == default(int))
						return st;

					st.SalesSpecialOffer = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSpecialOfferColumnNames.   .ToString()
					//SalesSpecialOfferProductColumnNames.      .ToString()
					JoinField = "SpecialOfferID",
					Operator = Operator.Equals,
					ParentField = "SpecialOfferID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SpecialOfferProduct_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as SalesSpecialOfferProduct);

					if (st == null || row == null)
						return st;

					if (row.ProductID == null || row.ProductID == default(int))
						return st;

					st.ProductionProduct = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductColumnNames.   .ToString()
					//SalesSpecialOfferProductColumnNames.      .ToString()
					JoinField = "ProductID",
					Operator = Operator.Equals,
					ParentField = "ProductID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		