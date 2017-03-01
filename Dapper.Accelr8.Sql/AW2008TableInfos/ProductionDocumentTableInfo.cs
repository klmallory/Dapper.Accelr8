
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
	public enum ProductionDocumentColumnNames
	{	
		DocumentNode, 	
		DocumentLevel, 	
		Title, 	
		Owner, 	
		FolderFlag, 	
		FileName, 	
		FileExtension, 	
		Revision, 	
		ChangeNumber, 	
		Status, 	
		DocumentSummary, 	
		Document, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum ProductionDocumentCascadeNames
	{	
		
		humanresourcesemployee_p, 	}

	public class ProductionDocumentTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionDocumentTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionDocumentColumnNames.DocumentNode.ToString();
			//Schema = "Production.Document";
			TableName = "Production.Document";
			TableAlias = "productiondocument";
			ColumnNames = typeof(ProductionDocumentColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_Document_Employee_Owner
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee")),
			TableName = "HumanResources.Employee",
			Alias = TableAlias + "_" + "HumanResourcesEmployee",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee");
					var st = (entity as ProductionDocument);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.HumanResourcesEmployee = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//HumanResourcesEmployeeColumnNames.   .ToString()
					//ProductionDocumentColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "Owner",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		