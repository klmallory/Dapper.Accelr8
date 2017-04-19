
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
	public enum ProductionProductDocumentFieldNames
	{	
		ProductID, 	
		DocumentNode, 	
		ModifiedDate, 	
	}

	public enum ProductionProductDocumentCascadeNames
	{	
		
		productionproduct_p, 	}

	public class ProductionProductDocumentTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionProductDocumentColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductDocumentFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionProductDocumentFieldNames.DocumentNode, "DocumentNode" }, 
						{ (int)ProductionProductDocumentFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionProductDocumentIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionProductDocumentFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionProductDocumentFieldNames.DocumentNode, "DocumentNode" }, 
				};

		public ProductionProductDocumentTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.ProductDocument";
			TableAlias = "productionproductdocument";
			Columns = ProductionProductDocumentColumnNames;
			IdColumns = ProductionProductDocumentIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_ProductDocument_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionProductDocument);

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
					//ProductionProductDocumentColumnNames.      .ToString()
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

		