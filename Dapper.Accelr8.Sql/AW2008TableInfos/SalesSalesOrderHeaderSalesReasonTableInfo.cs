
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
	public enum SalesSalesOrderHeaderSalesReasonFieldNames
	{	
		SalesOrderID, 	
		SalesReasonID, 	
		ModifiedDate, 	
	}

	public enum SalesSalesOrderHeaderSalesReasonCascadeNames
	{	
		
		salessalesorderheader_p, 	
		salessalesreason_p, 	}

	public class SalesSalesOrderHeaderSalesReasonTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSalesOrderHeaderSalesReasonColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesOrderHeaderSalesReasonFieldNames.SalesOrderID, "SalesOrderID" }, 
						{ (int)SalesSalesOrderHeaderSalesReasonFieldNames.SalesReasonID, "SalesReasonID" }, 
						{ (int)SalesSalesOrderHeaderSalesReasonFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSalesOrderHeaderSalesReasonIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesOrderHeaderSalesReasonFieldNames.SalesOrderID, "SalesOrderID" }, 
						{ (int)SalesSalesOrderHeaderSalesReasonFieldNames.SalesReasonID, "SalesReasonID" }, 
				};

		public SalesSalesOrderHeaderSalesReasonTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SalesOrderHeaderSalesReason";
			TableAlias = "salessalesorderheadersalesreason";
			Columns = SalesSalesOrderHeaderSalesReasonColumnNames;
			IdColumns = SalesSalesOrderHeaderSalesReasonIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesOrderHeader>("SalesSalesOrderHeader")),
			TableName = "Sales.SalesOrderHeader",
			Alias = TableAlias + "_" + "SalesSalesOrderHeader",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesOrderHeader>("SalesSalesOrderHeader");
					var st = (entity as SalesSalesOrderHeaderSalesReason);

					if (st == null || row == null)
						return st;

					if (row.SalesOrderID == null || row.SalesOrderID == default(int))
						return st;

					st.SalesSalesOrderHeader = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesOrderHeaderColumnNames.   .ToString()
					//SalesSalesOrderHeaderSalesReasonColumnNames.      .ToString()
					JoinField = "SalesOrderID",
					Operator = Operator.Equals,
					ParentField = "SalesOrderID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, SalesSalesReason>("SalesSalesReason")),
			TableName = "Sales.SalesReason",
			Alias = TableAlias + "_" + "SalesSalesReason",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, SalesSalesReason>("SalesSalesReason");
					var st = (entity as SalesSalesOrderHeaderSalesReason);

					if (st == null || row == null)
						return st;

					if (row.SalesReasonID == null || row.SalesReasonID == default(int))
						return st;

					st.SalesSalesReason = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesSalesReasonColumnNames.   .ToString()
					//SalesSalesOrderHeaderSalesReasonColumnNames.      .ToString()
					JoinField = "SalesReasonID",
					Operator = Operator.Equals,
					ParentField = "SalesReasonID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		