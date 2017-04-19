
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
	public enum ProductionWorkOrderRoutingFieldNames
	{	
		WorkOrderID, 	
		ProductID, 	
		OperationSequence, 	
		LocationID, 	
		ScheduledStartDate, 	
		ScheduledEndDate, 	
		ActualStartDate, 	
		ActualEndDate, 	
		ActualResourceHrs, 	
		PlannedCost, 	
		ActualCost, 	
		ModifiedDate, 	
	}

	public enum ProductionWorkOrderRoutingCascadeNames
	{	
		
		productionworkorder_p, 	
		productionlocation_p, 	}

	public class ProductionWorkOrderRoutingTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> ProductionWorkOrderRoutingColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)ProductionWorkOrderRoutingFieldNames.WorkOrderID, "WorkOrderID" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.OperationSequence, "OperationSequence" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.LocationID, "LocationID" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ScheduledStartDate, "ScheduledStartDate" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ScheduledEndDate, "ScheduledEndDate" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ActualStartDate, "ActualStartDate" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ActualEndDate, "ActualEndDate" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ActualResourceHrs, "ActualResourceHrs" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.PlannedCost, "PlannedCost" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ActualCost, "ActualCost" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> ProductionWorkOrderRoutingIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)ProductionWorkOrderRoutingFieldNames.WorkOrderID, "WorkOrderID" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.ProductID, "ProductID" }, 
						{ (int)ProductionWorkOrderRoutingFieldNames.OperationSequence, "OperationSequence" }, 
				};

		public ProductionWorkOrderRoutingTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Production";
			TableName = "Production.WorkOrderRouting";
			TableAlias = "productionworkorderrouting";
			Columns = ProductionWorkOrderRoutingColumnNames;
			IdColumns = ProductionWorkOrderRoutingIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_WorkOrderRouting_WorkOrder_WorkOrderID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionWorkOrder>("ProductionWorkOrder")),
			TableName = "Production.WorkOrder",
			Alias = TableAlias + "_" + "ProductionWorkOrder",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionWorkOrder>("ProductionWorkOrder");
					var st = (entity as ProductionWorkOrderRouting);

					if (st == null || row == null)
						return st;

					if (row.WorkOrderID == null || row.WorkOrderID == default(int))
						return st;

					st.ProductionWorkOrder = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionWorkOrderColumnNames.   .ToString()
					//ProductionWorkOrderRoutingColumnNames.      .ToString()
					JoinField = "WorkOrderID",
					Operator = Operator.Equals,
					ParentField = "WorkOrderID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_WorkOrderRouting_Location_LocationID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<short, ProductionLocation>("ProductionLocation")),
			TableName = "Production.Location",
			Alias = TableAlias + "_" + "ProductionLocation",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<short, ProductionLocation>("ProductionLocation");
					var st = (entity as ProductionWorkOrderRouting);

					if (st == null || row == null)
						return st;

					if (row.LocationID == null || row.LocationID == default(short))
						return st;

					st.ProductionLocation = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionLocationColumnNames.   .ToString()
					//ProductionWorkOrderRoutingColumnNames.      .ToString()
					JoinField = "LocationID",
					Operator = Operator.Equals,
					ParentField = "LocationID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		