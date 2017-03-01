
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
	public enum SalesSpecialOfferProductColumnNames
	{	
		SpecialOfferID, 	
		ProductID, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSpecialOfferProductCascadeNames
	{	
		salessalesorderdetail, 	
		
		salesspecialoffer_p, 	
		productionproduct_p, 	}

	public class SalesSpecialOfferProductTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesSpecialOfferProductTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesSpecialOfferProductColumnNames.SpecialOfferID.ToString();
			//Schema = "Sales.SpecialOfferProduct";
			TableName = "Sales.SpecialOfferProduct";
			TableAlias = "salesspecialofferproduct";
			ColumnNames = typeof(SalesSpecialOfferProductColumnNames).ToDataList<Type, int>();

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

		