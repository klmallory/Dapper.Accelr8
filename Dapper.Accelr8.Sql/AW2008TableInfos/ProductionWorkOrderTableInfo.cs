
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
	public enum ProductionWorkOrderColumnNames
	{	
		WorkOrderID, 	
		ProductID, 	
		OrderQty, 	
		StockedQty, 	
		ScrappedQty, 	
		StartDate, 	
		EndDate, 	
		DueDate, 	
		ScrapReasonID, 	
		ModifiedDate, 	
	}

	public enum ProductionWorkOrderCascadeNames
	{	
		productionworkorderrouting, 	
		
		productionproduct_p, 	
		productionscrapreason_p, 	}

	public class ProductionWorkOrderTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionWorkOrderTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionWorkOrderColumnNames.WorkOrderID.ToString();
			//Schema = "Production.WorkOrder";
			TableName = "Production.WorkOrder";
			TableAlias = "productionworkorder";
			ColumnNames = typeof(ProductionWorkOrderColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_WorkOrder_Product_ProductID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionWorkOrder);

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
					//ProductionWorkOrderColumnNames.      .ToString()
					JoinField = "ProductID",
					Operator = Operator.Equals,
					ParentField = "ProductID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_WorkOrder_ScrapReason_ScrapReasonID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<short, ProductionScrapReason>("ProductionScrapReason")),
			TableName = "Production.ScrapReason",
			Alias = TableAlias + "_" + "ProductionScrapReason",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<short, ProductionScrapReason>("ProductionScrapReason");
					var st = (entity as ProductionWorkOrder);

					if (st == null || row == null)
						return st;

					if (row.ScrapReasonID == null || row.ScrapReasonID == default(short))
						return st;

					st.ProductionScrapReason = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionScrapReasonColumnNames.   .ToString()
					//ProductionWorkOrderColumnNames.      .ToString()
					JoinField = "ScrapReasonID",
					Operator = Operator.Equals,
					ParentField = "ScrapReasonID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		