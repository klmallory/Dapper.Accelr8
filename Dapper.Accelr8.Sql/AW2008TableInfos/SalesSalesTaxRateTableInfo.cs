
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
	public enum SalesSalesTaxRateFieldNames
	{	
		Id, 	
		StateProvinceID, 	
		TaxType, 	
		TaxRate, 	
		Name, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum SalesSalesTaxRateCascadeNames
	{	
		
		personstateprovince_p, 	}

	public class SalesSalesTaxRateTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> SalesSalesTaxRateColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesTaxRateFieldNames.Id, "SalesTaxRateID" }, 
						{ (int)SalesSalesTaxRateFieldNames.StateProvinceID, "StateProvinceID" }, 
						{ (int)SalesSalesTaxRateFieldNames.TaxType, "TaxType" }, 
						{ (int)SalesSalesTaxRateFieldNames.TaxRate, "TaxRate" }, 
						{ (int)SalesSalesTaxRateFieldNames.Name, "Name" }, 
						{ (int)SalesSalesTaxRateFieldNames.rowguid, "rowguid" }, 
						{ (int)SalesSalesTaxRateFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> SalesSalesTaxRateIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)SalesSalesTaxRateFieldNames.Id, "SalesTaxRateID" }, 
				};

		public SalesSalesTaxRateTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Sales";
			TableName = "Sales.SalesTaxRate";
			TableAlias = "salessalestaxrate";
			Columns = SalesSalesTaxRateColumnNames;
			IdColumns = SalesSalesTaxRateIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_SalesTaxRate_StateProvince_StateProvinceID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonStateProvince>("PersonStateProvince")),
			TableName = "Person.StateProvince",
			Alias = TableAlias + "_" + "PersonStateProvince",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonStateProvince>("PersonStateProvince");
					var st = (entity as SalesSalesTaxRate);

					if (st == null || row == null)
						return st;

					if (row.StateProvinceID == null || row.StateProvinceID == default(int))
						return st;

					st.PersonStateProvince = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonStateProvinceColumnNames.   .ToString()
					//SalesSalesTaxRateColumnNames.      .ToString()
					JoinField = "StateProvinceID",
					Operator = Operator.Equals,
					ParentField = "StateProvinceID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		