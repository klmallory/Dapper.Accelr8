
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
	public enum SalesCurrencyRateColumnNames
	{	
		CurrencyRateID, 	
		CurrencyRateDate, 	
		FromCurrencyCode, 	
		ToCurrencyCode, 	
		AverageRate, 	
		EndOfDayRate, 	
		ModifiedDate, 	
	}

	public enum SalesCurrencyRateCascadeNames
	{	
		salessalesorderheader, 	
		
		salescurrency_p, 	}

	public class SalesCurrencyRateTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public SalesCurrencyRateTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = SalesCurrencyRateColumnNames.CurrencyRateID.ToString();
			//Schema = "Sales.CurrencyRate";
			TableName = "Sales.CurrencyRate";
			TableAlias = "salescurrencyrate";
			ColumnNames = typeof(SalesCurrencyRateColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_CurrencyRate_Currency_FromCurrencyCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, SalesCurrency>("SalesCurrency")),
			TableName = "Sales.Currency",
			Alias = TableAlias + "_" + "SalesCurrency",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, SalesCurrency>("SalesCurrency");
					var st = (entity as SalesCurrencyRate);

					if (st == null || row == null)
						return st;

					if (row.CurrencyCode == null || row.CurrencyCode == default(string))
						return st;

					st.SalesCurrency = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesCurrencyColumnNames.   .ToString()
					//SalesCurrencyRateColumnNames.      .ToString()
					JoinField = "CurrencyCode",
					Operator = Operator.Equals,
					ParentField = "FromCurrencyCode",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_CurrencyRate_Currency_ToCurrencyCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, SalesCurrency>("SalesCurrency")),
			TableName = "Sales.Currency",
			Alias = TableAlias + "_" + "SalesCurrency",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, SalesCurrency>("SalesCurrency");
					var st = (entity as SalesCurrencyRate);

					if (st == null || row == null)
						return st;

					if (row.CurrencyCode == null || row.CurrencyCode == default(string))
						return st;

					st.SalesCurrency = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//SalesCurrencyColumnNames.   .ToString()
					//SalesCurrencyRateColumnNames.      .ToString()
					JoinField = "CurrencyCode",
					Operator = Operator.Equals,
					ParentField = "ToCurrencyCode",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		